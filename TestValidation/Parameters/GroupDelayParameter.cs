using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nuvo.TestValidation.Calculators.Interfaces;
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Utilities.Math;
using Newtonsoft.Json;

namespace Nuvo.TestValidation.Parameters
{
    public class GroupDelayParameter : ScatteringParameter
    {
        private Dictionary<string, List<double[]>> groupDelayParameterValues = new Dictionary<string, List<double[]>>();
        private List<(double, double, double, double, string)> csvData = new List<(double, double, double, double, string)>();

        public override double ValueAtMinMargin
        {
            get => MinMargin;
            set => MinMargin = value;
        }

        public static StreamWriter sw;

        public GroupDelayParameter(IParameterValueCalculator calculator)
            : base(calculator)
        {
            Description = "Evaluates a scattering parameter for S-Parameter Matrix";
        }

        public GroupDelayParameter()
            : base()
        {
            Description = "Evaluates a scattering parameter for S-Parameter Matrix";
        }

        public override bool ValidateMeasurement(TestRequirement req, Dictionary<string, List<object[]>> measurement)
        {
            int index = 0;
            bool isPassed = true;
            double lastMinMargin = double.MaxValue;
            MinMargin = double.MaxValue;
            csvData = new List<(double, double, double, double, string)>();
            ValueAtMinMargin = double.MaxValue;

            foreach (var sParam in MeasurementVariables)
            {
                foreach (var val in groupDelayParameterValues)
                {
                    // First Value in first array at frequency point "val"
                    double testValue = (double)val.Value[0].First();
                    double limit = req.Limit.Validator.Value;
                    var freq = System.Convert.ToDouble(val.Key);
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


        /// <summary>
        /// Get the value
        /// </summary>
        /// <param name="req"></param>
        /// <param name="baseDataSet"></param>
        /// <returns></returns>
        public override Dictionary<string, List<object[]>> CalculateParameterValue(TestRequirement req, Dictionary<string, List<object[]>> baseDataSet)
        {
            var paramValDic = base.CalculateParameterValue(req, baseDataSet);
            List<double> freqList = new List<double>();
            List<double> phaseList = new List<double>();

            foreach(var val in paramValDic)
            {
                freqList.Add(System.Convert.ToDouble(val.Key));
                // Convert to radians
                phaseList.Add(System.Convert.ToDouble(val.Value[0].First()) * System.Math.PI/180);
            }
            var gdRadians = MathClass.GroupDelay(freqList.ToArray(), phaseList.ToArray(), true);
            groupDelayParameterValues.Clear();
            for (int i = 0; i < gdRadians.Length; i++)
            {
                var valArray = new double[1];
                valArray[0] = gdRadians[i];
                groupDelayParameterValues.Add(freqList.ElementAt(i).ToString(), new List<double[]>() { valArray });
            }

            return groupDelayParameterValues.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Select(innerList => innerList.Cast<object>().ToArray()).ToList());
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
