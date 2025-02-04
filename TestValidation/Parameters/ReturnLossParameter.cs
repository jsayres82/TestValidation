using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Parameters
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    using global::Nuvo.TestValidation.Calculators.Interfaces;
    using global::Nuvo.TestValidation.Limits;
    using System.Reflection;
    using global::Nuvo.TestValidation.Limits.Validators;
    using static global::Nuvo.TestValidation.Limits.Units.UnitConverter;

    namespace Nuvo.TestValidation.Parameters
    {
        public class ReturnLossParameter : ScatteringParameter
        {
            //private Dictionary<string, List<double[]>> scatteringParameterValues = new Dictionary<string, List<double[]>>();
            //private List<string> sParams = new List<string>();
            private List<(double, double, double, double, string)> csvData = new List<(double, double, double, double, string)>();
            // All points from start to stop that we need to evaluate.
            private List<string> parameterDomain = new List<string>();
            private int portCount = 0;

            //[XmlIgnore]
            //public override Dictionary<string, List<object[]>> ParameterValues
            //{
            //    get
            //    {
            //        return scatteringParameterValues.ToDictionary(
            //            kvp => kvp.Key,
            //            kvp => kvp.Value.Select(innerList => innerList.Cast<object>().ToArray()).ToList());
            //    }
            //}

            
            // Is currently justin the matrix index to evaluate for right now.  But if we were to implement an amplitude balance we could add the list of ports as well
            // then just set the requirment to use the AmplitudeBalanceCalulator
            public override List<string> VariableNames { get; } = new List<string>() { "S-Param" };

            // What to use for each variable. For S-Param it would be S12 or S11 or S15. For amplitude balance it would be S12,S13,S14,S15 to indicate that want to compare
            //  to normalize S15 to the average of the four(S12,S13,S14,S15)
            public override List<string> MeasurementVariables { get; set; } = new List<string>();

            // What gets reported in the report output table
            public override double ValueAtMinMargin
            {
                get
                {
                    return valueAtMinMargin;
                }
                set { valueAtMinMargin = value; }
            }

            private double valueAtMinMargin = double.MinValue;
            /// <summary>
            /// Constructor - Each calculator would have it's own description of what it is doing
            /// </summary>
            /// <param name="calculator"></param>
            public ReturnLossParameter(IParameterValueCalculator calculator)
                : base(calculator)
            {
                Description = "Compares the value of the specified \"S-Param\" to the limit specified.";
                VariableNames = new List<string>() { "S-Param" };
            }

            /// <summary>
            /// Constructor - Needed for serialization.
            /// </summary>
            public ReturnLossParameter()
                : base()
            {
                Description = "Compares the value of the specified \"S-Param\" to the limit specified.";
                VariableNames = new List<string>() { "S-Param" };
            }

            /// <summary>
            /// Creates output dispo
            /// </summary>
            /// <param name="req"></param>
            /// <param name="measurement"></param>
            /// <returns></returns>
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
                    foreach (var val in base.ParameterValues)
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
            //public override Dictionary<string, List<object[]>> CalculateParameterValue(TestRequirement req, Dictionary<string, List<object[]>> baseDataSet)
            //{
            //    scatteringParameterValues = new Dictionary<string, List<double[]>>();
            //    sParams = SParamUtility.GenerateSparamStrings(new FileInfo(FilePath).Extension);
            //    int index = 0;
            //    int idx = 0;
            //    Dictionary<string, List<Complex>> parsedData = new Dictionary<string, List<Complex>>();
            //    foreach (var val in sParams)
            //    {
            //        parsedData.Add(val, new List<Complex>());
            //        if (val.Equals(MeasurementVariables[0]))
            //            idx = index;
            //        index++;
            //    }

            //    parameterDomain = baseDataSet.Keys.ToList();
            //    foreach (var d in baseDataSet)
            //    {
            //        index = 0;
            //        foreach (var val in d.Value)
            //        {
            //            if (index == idx)
            //            {
            //                var valF = new double[1]
            //                {
            //                Convert.ToDouble(val[0])
            //                };
            //                scatteringParameterValues.Add(d.Key.ToString(), new List<double[]>() { valF });
            //            }
            //            index++;
            //        }
            //    }

            //    return ParameterValues;
            //}

            /// <summary>
            /// Dont remember, it's not used yet though
            /// </summary>
            /// <returns></returns>
            public override object[] GetParameterLimits()
            {
                return new object[] { double.MinValue }; // Example for double
            }

            /// <summary>
            /// Save the csv that will be used for pdf graphs and also wafer/lot level data outputs.
            /// </summary>
            /// <param name="fileName"></param>
            /// <param name="results"></param>
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

}
