using MicrowaveNetworks;
using Nuvo.TestValidation.Calculators.Interfaces;
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Utilities;
using Nuvo.TestValidation.Utilities.Math;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Nuvo.TestValidation.Parameters
{
    public class PhaseBalanceParameter : GenericParameter
    {
        private Dictionary<double, List<double[]>> phaseBalanceParameterValues = new Dictionary<double, List<double[]>>();
        List<string> sParams = new List<string>();
        private List<(double, double, double, double, string)> csvData = new List<(double, double, double, double, string)>();
        // All points from start to stop that we need to evaluate.
        private List<string> parameterDomain = new List<string>();
        private int portCount = 0;

        //[JsonIgnore]
        [XmlIgnore]
        public override Dictionary<string, List<object[]>> ParameterValues
        {
            get
            {
                return phaseBalanceParameterValues.ToDictionary(
                    kvp => kvp.Key.ToString(),
                    kvp => kvp.Value.Select(innerList => innerList.Cast<object>().ToArray()).ToList());
            }
        }

        //public override List<string> MeasurementVariables { get; set; }

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

        //public override List<string> VariableNames { get; set; } = new List<string>() { "S-Param", "All S-Params" };

        public PhaseBalanceParameter(IParameterValueCalculator calculator)
            : base(calculator)
        {
            Description = "Compares the unwrapped phase of specified \"S-Param\" to the mean of those in \"All S-Params\" list(comma seperated)";
            ParameterVariableCount = 2;
            VariableNames = new List<string>() { "S-Param", "All S-Params" };
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
            phaseBalanceParameterValues = new Dictionary<double, List<double[]>>();
            // Determine what sParameters are in object list
            sParams = SParamUtility.GenerateSparamStrings(new FileInfo(FilePath).Extension);
            var coll = GenericDataConverter.ToNetworkParameters(baseDataSet);
            var frequencies = coll.Frequencies;
            // Get the port indexes of the s-parameter variables
            var portIDs = MeasurementVariables[1].Replace("S", "");
            Dictionary<string, int[]> ports = new Dictionary<string, int[]>();
            // Create list of secondary variables
            var traceList = portIDs.Split(",");
            foreach (var index in traceList)
            {
                // Handle s-parameters with more than 9 ports
                if (index.Contains("_"))
                {
                    ports.Add(index, new int[2] { Convert.ToInt16(index.Split("_").First()), Convert.ToInt16(index.Split("_").First()) });
                }
                else
                {
                    ports.Add(index, new int[2] { Convert.ToInt16(index.Substring(0,1)), Convert.ToInt16(index.Substring(1, 1)) });
                }
            }

            Dictionary<string, IReadOnlyDictionary<double, NetworkParameter>> sParamDic = new Dictionary<string, IReadOnlyDictionary<double, NetworkParameter>>();
            foreach (var p in ports)
                sParamDic.Add(p.Key, coll.GetParametersForPorts(p.Value[0], p.Value[1]));
            
            parameterDomain = baseDataSet.Keys.ToList();
            var sumTraceList = new Dictionary<string, List<double>>(parameterDomain.Count);
            var frequencyList = new List<string>(parameterDomain.Count);
            var traceArray = MathClass.UnwrapPhase(sParamDic[MeasurementVariables[0].Remove(0,1)].Values.ToArray(), true).ToList();
            // Holds the index of the current frequency during looping
            int freqIdx = 0;
            foreach (var p in sParamDic)
            {
                // Add the new value for sum at current frequency 
                sumTraceList.Add(p.Key, new List<double>());
                sumTraceList[p.Key] = MathClass.UnwrapPhase(sParamDic[p.Key].Values.ToArray(), true).ToList();
            }

            // perform the calculation - 
            double[] sum = new double[parameterDomain.Count];
            for (int i = 0; i < parameterDomain.Count; i++)
            {
                foreach (var sparamIdx in sParamDic.Keys)
                {
                    sum[i] += sumTraceList[sparamIdx][i];
                }
            }

            freqIdx = 0;
            // For each frequency calculate final parameter value
            foreach (var freq in parameterDomain)
            {
                var traceValAtFreq = traceArray[freqIdx];
                var aveAtFreq = sum[freqIdx] / sParamDic.Keys.Count;
                var phaseBalVal = Math.Abs(traceValAtFreq - aveAtFreq);
                var phaseBal = new double[1]
                {
                        phaseBalVal
                };
                phaseBalanceParameterValues.Add(frequencies.ToArray()[freqIdx++], new List<double[]> { phaseBal } );
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
