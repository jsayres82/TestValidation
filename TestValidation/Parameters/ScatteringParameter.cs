using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Nuvo.TestValidation.Calculators;
using Nuvo.TestValidation.Calculators.Interfaces;
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Limits.Validators;
using Nuvo.TestValidation.Parameters.Interfaces;
using Nuvo.TestValidation.TestResults;
using Nuvo.TestValidation.Utilities;
using Nuvo.TestValidation.Utilities.Math;
using Org.BouncyCastle.Ocsp;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace Nuvo.TestValidation.Parameters
{
    public class ScatteringParameter : GenericParameter
    {
        // This can go away now that we pass number of indeces. Need to implement a utility function that can generates the string arrays
        string[] s = new string[9] { "S11", "S12", "S13", "S21", "S22", "S23", "S31", "S32", "S33" };
        List<string> sprams = new List<string>();

        // This holds the results that will be written to file as we validate the set
        private List<(double, double, double, double, string)> csvData = new List<(double, double, double, double, string)>();

        private MathClass myMath = new MathClass();

        // All points from start to stop that we need to evaluate.
        private List<string> parameterDomain = new List<string>();
        // What we want to end up with.
        private Dictionary<string, List<double[]>> scatteringParameterValues = new Dictionary<string, List<double[]>>();
        
        [XmlIgnore]
        public override Dictionary<string, List<object[]>> ParameterValues
        {
            get
            {
                return scatteringParameterValues.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Select(innerList => innerList.Cast<object>().ToArray()).ToList());
            }
        }

        // Is currently justin the matrix index to evaluate for right now.  But if we were to implement an amplitude balance we could add the list of ports as well
        // then just set the requirment to use the AmplitudeBalanceCalulator
        public override List<string> VariableNames { get; } = new List<string>() { "S-Param" };

        // What to use for each variable. For S-Param it would be S12 or S11 or S15. For amplitude balance it would be S12,S13,S14,S15 to indicate that want to compare
        //  to normalize S15 to the average of the four(S12,S13,S14,S15)
        public override List<string> MeasurementVariables { get; set; } = new List<string>();

        // What gets reported in the report output table
        public override double MinimumMargin 
        {
            get
            {
                return MinMargin;
            }
            set { MinMargin = value; }
        }

        /// <summary>
        /// Constructor - Each calculator would have it's own description of what it is doing
        /// </summary>
        /// <param name="calculator"></param>
        public ScatteringParameter(IParameterValueCalculator calculator)
            : base(calculator)
        {

            Description = "Compares the value of the specified \"S-Param\" to the limit specified.";
            VariableNames = new List<string>() { "S-Param" }; 
        }
        /// <summary>
        /// Constructor - Needed for serialization.
        /// </summary>
        public ScatteringParameter()
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
            MinMargin = double.MaxValue;
            csvData = new List<(double, double, double, double, string)>();

            foreach (var sParam in MeasurementVariables)
            {
                foreach (var val in scatteringParameterValues)
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

        /// <summary>
        /// Get the value
        /// </summary>
        /// <param name="req"></param>
        /// <param name="baseDataSet"></param>
        /// <returns></returns>
        public override Dictionary<string, List<object[]>> CalculateParameterValue(TestRequirement req, Dictionary<string, List<object[]>> baseDataSet)
        {
            scatteringParameterValues = new Dictionary<string, List<double[]>>();
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
                            Convert.ToDouble(val[0])
                        };
                        scatteringParameterValues.Add(d.Key.ToString(), new List<double[]>() { valF });
                    }
                    index++;
                }
            }

            return ParameterValues;
        }
        
        /// <summary>
        /// Dont remember, it's not used yet though
        /// </summary>
        /// <returns></returns>
        public override object[] GetParameterLimits()
        {
            return new object[] { double.MinValue, double.MaxValue }; // Example for double
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
