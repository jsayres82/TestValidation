using MathNet.Numerics.Random;
using MathNet.Numerics.Statistics;
using MicrowaveNetworks;
using MicrowaveNetworks.Touchstone;
using Nuvo.TestValidation.Calculators;
using Nuvo.TestValidation.Calculators.Interfaces;
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Utilities;
using Nuvo.TestValidation.Utilities.Math;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MicrowaveNetworks;

namespace Nuvo.TestValidation.Parameters
{
    public class PhaseBalanceParameter : GenericParameter
    {
        List<string> sParams = new List<string>();
        private List<string> parameterDomain = new List<string>();
        private List<(double, double, double, double, string)> csvData = new List<(double, double, double, double, string)>();
        private MathClass myMath = new MathClass();

        private Dictionary<string, List<double[]>> phaseBalanceParameterValues = new Dictionary<string, List<double[]>>();

        [XmlIgnore]
        public override Dictionary<string, List<object[]>> ParameterValues
        {
            get
            {
                return phaseBalanceParameterValues.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Select(innerList => innerList.Cast<object>().ToArray()).ToList());
            }
        }

        public override List<string> MeasurementVariables { get; set; }

        public override double ValueAtMinMargin
        {
            get
            {
                return valueAtMinMargin;
            }
            set 
            { 
                valueAtMinMargin = value; 
            }
        }

        private double valueAtMinMargin = double.MinValue;

        public override List<string> VariableNames { get; } = new List<string>() { "S-Param", "All S-Params" };

        public PhaseBalanceParameter(IParameterValueCalculator calculator)
            : base(calculator)
        {
            Description = "Compares the unwrapped phase of specified \"S-Param\" to the mean of those in \"All S-Params\" list(comma seperated)";
            ParameterVariableCount = 2;
        }

        public PhaseBalanceParameter()
        {
            Description = "Compares the unwrapped phase of specified \"S-Param\" to the mean of those in \"All S-Params\" list(comma seperated)";
            ParameterVariableCount = 2;
        }

        public override bool ValidateMeasurement(TestRequirement req, Dictionary<string, List<object[]>> measurement)
        {
            // Convert back to double arrays for validation
            Dictionary<string, List<double[]>> doubleMeasurement = measurement.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Select(arr => arr.Cast<double>().ToArray()).ToList());
            csvData = new List<(double, double, double, double, string)>();
            int index = 0;
            bool isPassed = true;
            double lastMinMargin = double.MaxValue;
            MinMargin = double.MaxValue;
            //foreach (var sParam in MeasurementVariables[0])
            {
                foreach (var val in phaseBalanceParameterValues.Keys)
                {
                    // First Value in first array at frequency point "val"
                    double testValue = phaseBalanceParameterValues[val][0][0];
                    double limit = req.Limit.Validator.Value;
                    var freq = System.Convert.ToDouble(val);
                    bool passed = req.Limit.ValidateMeasurement(freq, testValue);
                    isPassed &= passed;
                    string result = passed ? "Passed" : "Failed";

                    double margin = req.Limit.CalculateMargin(freq, testValue);
                    if (!double.IsNaN(margin))
                    {
                        var newMinMargin = Math.Min(lastMinMargin, margin);
                        if (newMinMargin < lastMinMargin)
                        {
                            lastMinMargin = margin;
                            MinMargin = margin;
                            ValueAtMinMargin = testValue;
                        }
                        csvData.Add((freq, testValue, margin, limit, result));
                    }

                    index++;
                }
            }

            string fileName = $"{new FileInfo(FilePath).DirectoryName}\\SerialNumber{SerialNumber}_requirement_{req.Name}.csv";
            WriteToCsv(fileName, csvData);

            return isPassed;
        }

        public override Dictionary<string, List<object[]>> CalculateParameterValue(TestRequirement req, Dictionary<string, List<object[]>> baseDataSet)
        {
            phaseBalanceParameterValues = new Dictionary<string, List<double[]>>();
            sParams = SParamUtility.GenerateSparamStrings(new FileInfo(FilePath).Extension);
            var traceList = MeasurementVariables[1].Split(",");
            var traceIdxList = new List<int>();
            int index = 0;
            int idx = 0;
            Dictionary<string, List<Complex>> parsedData = new Dictionary<string, List<Complex>>();

            foreach (var val in sParams)
            {
                parsedData.Add(val, new List<Complex>());
                if (val.Equals(MeasurementVariables[0]))
                    idx = index;
                if(traceList.Contains(val))
                    traceIdxList.Add(index);
                index++;
            }

            parameterDomain = baseDataSet.Keys.ToList();
            var sumTraceList = new List<double>(parameterDomain.Count);
            var frequencyList = new List<string>(parameterDomain.Count);
            index = 0;
            Dictionary<string, List<NetworkParameter>> f = new Dictionary<string, List<NetworkParameter>>();
            Dictionary<int, double[]> keyValuePairs = new Dictionary<int, double[]>(4);
            foreach (var sparamIdx in traceIdxList)
                keyValuePairs.Add(sparamIdx, new double[parameterDomain.Count]);

            foreach (var d in baseDataSet)
            {
                frequencyList.Add(d.Key);
                foreach (var sparamIdx in traceIdxList)
                {
                    keyValuePairs[sparamIdx][index] = Convert.ToDouble(d.Value[sparamIdx][1]) * Math.PI/180;
                }
                index++;
            }

            foreach (var sparamIdx in traceIdxList)
            {
                keyValuePairs[sparamIdx] = MathClass.UnwrapPhase(keyValuePairs[sparamIdx]);
            }

            for(int i = 0; i < parameterDomain.Count; i++)
            {
                sumTraceList.Add(0);
                foreach (var sparamIdx in traceIdxList)
                {
                    var val = keyValuePairs[sparamIdx];
                    var val2 = val[i];
                    sumTraceList[i] += val2;// keyValuePairs[sparamIdx][i];
                }

                if(Math.Abs(keyValuePairs[idx][i] - sumTraceList[i]/4) > 10)
                {
                    var a = keyValuePairs[traceIdxList[0]][i];
                    var b = keyValuePairs[traceIdxList[1]][i];
                    var c = keyValuePairs[traceIdxList[2]][i];
                    var d = keyValuePairs[traceIdxList[3]][i];
                }
            }

            index = 0;
            foreach (var sum in sumTraceList)
            {
                var traceValAtFreq = keyValuePairs[idx][index];
                var aveAtFreq = sum / traceIdxList.Count;
                var phaseBalVal = Math.Abs((traceValAtFreq - aveAtFreq) * 180 / Math.PI);
                var phaseBal = new double[1]
                {
                        phaseBalVal
                };
                phaseBalanceParameterValues.Add(frequencyList[index++], new List<double[]>() { phaseBal });
            }
            return ParameterValues;
        }

        public override object[] GetParameterLimits()
        {
            return new object[] { double.MinValue, double.MaxValue }; // Example for double
        }

        private void WriteToCsv(string fileName, IEnumerable<(double frequency, double testValue, double margin, double limit, string result)> results)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (var sw = new StreamWriter(fileName, false))
            {
                sw.WriteLine("Frequency,TestValue,Margin,Limit,Result");
                foreach (var (frequency, testValue, margin, limit, result) in results)
                {
                    if (!double.IsNaN(margin))
                    {
                        sw.WriteLine($"{frequency},{testValue},{margin},{limit},{result}");
                    }
                }
            }
        }
    }
}
