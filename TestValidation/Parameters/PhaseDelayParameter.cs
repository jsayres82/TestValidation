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
    public class PhaseDelayParameter : GenericParameter
    {
        string[] s = new string[9] { "S11", "S12", "S13", "S21", "S22", "S23", "S31", "S32", "S33" };
        List<string> sprams = new List<string>();
        private List<(double, double, double, double, string)> csvData = new List<(double, double, double, double, string)>();
        private MathClass myMath = new MathClass();

        private Dictionary<string, List<double[]>> phaseDelayParameterValues = new Dictionary<string, List<double[]>>();

        [XmlIgnore]
        public override Dictionary<string, List<object[]>> ParameterValues
        {
            get
            {
                return phaseDelayParameterValues.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Select(innerList => innerList.Cast<object>().ToArray()).ToList());
            }
        }

        public override List<string> MeasurementVariables { get; set; } = new List<string>();

        public override double MinimumMargin { get; set; }

        public PhaseDelayParameter(IParameterValueCalculator calculator)
            : base(calculator)
        {
        }

        public PhaseDelayParameter()
        {
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
            var reqLimit = new double[ParameterValues[MeasurementVariables.First()].Count];

            foreach (var sParam in MeasurementVariables)
            {
                foreach (var val in ParameterValues[sParam])
                {
                    double testValue = Convert.ToDouble(val[0]);
                    double limit = req.Limit.Validator.Value;
                    reqLimit[index] = limit;
                    bool passed = req.Limit.ValidateMeasurement(System.Convert.ToDouble(doubleMeasurement.ElementAt(index)), testValue);
                    isPassed &= passed;
                    string result = passed ? "Passed" : "Failed";

                    double margin = req.Limit.CalculateMargin(System.Convert.ToDouble(doubleMeasurement.ElementAt(index)), testValue);
                    if (!double.IsNaN(margin))
                    {
                        MinMargin = Math.Min(MinMargin, margin);
                    }

                    csvData.Add((System.Convert.ToDouble(doubleMeasurement.ElementAt(index)), testValue, margin, limit, result));

                    index++;
                }
            }

            string fileName = $"SerialNumber{SerialNumber}_requirement_{req.Name}.csv";
            WriteToCsv(fileName, csvData);

            return isPassed;
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
