using MicrowaveNetworks;
using MicrowaveNetworks.Touchstone;
using Nuvo.TestValidation.Calculators;
using Nuvo.TestValidation.Calculators.Interfaces;
using Nuvo.TestValidation.Limits;
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

namespace Nuvo.TestValidation.Parameters
{
    public class PhaseBalanceParameter : GenericParameter
    {
        string[] s = new string[9] { "S11", "S12", "S13", "S21", "S22", "S23", "S31", "S32", "S33" };
        List<string> sprams = new List<string>();
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

        public override double MinimumMargin { get; set; }

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

            int index = 0;
            bool isPassed = true;
            MinMargin = double.MaxValue;

            foreach (var sParam in MeasurementVariables)
            {
                foreach (var val in phaseBalanceParameterValues)
                {
                    // First Value in first array at frequency point "val"
                    double testValue = val.Value[0][0];
                    double limit = req.Limit.Validator.Value;
                    var freq = System.Convert.ToDouble(val.Key);
                    bool passed = req.Limit.ValidateMeasurement(freq, testValue);
                    isPassed &= passed;
                    string result = passed ? "Passed" : "Failed";

                    double margin = req.Limit.CalculateMargin(freq, testValue);
                    if (!double.IsNaN(margin))
                    {
                        MinMargin = Math.Min(MinMargin, margin);
                        if (margin < MinMargin)
                            MinMargin = margin;
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
            sprams.AddRange(s.ToList());
            int index = 0;
            int idx = 0;
            Dictionary<string, List<Complex>> parsedData = new Dictionary<string, List<Complex>>();
            foreach (var val in s)
            {
                parsedData.Add(val, new List<Complex>());
                if (val.Equals(MeasurementVariables[0]))
                    idx = index;
                index++;
            }
            index = 0;
            parameterDomain = baseDataSet.Keys.ToList();
            foreach (var d in baseDataSet)
            {
                index = 0;
                foreach (var val in d.Value)
                {
                    if (index == idx)
                    {
                        var valF = new double[1]
                        {
                            Convert.ToDouble(val[1])
                            //Convert.ToDouble(val[1])
                        };
                        phaseBalanceParameterValues.Add(d.Key.ToString(), new List<double[]>() { valF });

                        //Console.WriteLine($"{s[measurement[d].IndexOf(val)]}: {parsedData[s[measurement[d].IndexOf(val)]].Last().Magnitude} dB  {(180/Math.PI) * parsedData[s[measurement[d].IndexOf(val)]].Last().Phase} degrees");
                    }
                    index++;
                }
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
