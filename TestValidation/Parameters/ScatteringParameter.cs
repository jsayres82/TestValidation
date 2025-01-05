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
        string[] s = new string[9] { "S11", "S12", "S13", "S21", "S22", "S23", "S31", "S32", "S33" };
        List<string> sprams = new List<string>();
        private List<(double, double, double, double, string)> csvData = new List<(double, double, double, double, string)>();
        private MathClass myMath = new MathClass();
        private List<string> parameterDomain = new List<string>();
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

        public override List<string> MeasurementVariables { get; set; } = new List<string>();

        public override double MinimumMargin 
        {
            get
            {
                return MinMargin;
            }
            set { MinMargin = value; }
        }

        public ScatteringParameter(IParameterValueCalculator calculator)
            : base(calculator)
        {
        }

        public ScatteringParameter()
            : base()
        {
        }

        public override bool ValidateMeasurement(TestRequirement req, Dictionary<string, List<object[]>> measurement)
        {
            int index = 0;
            bool isPassed = true;
            MinMargin = double.MaxValue;
            var reqLimit = new double[ParameterValues.Count];
            csvData = new List<(double, double, double, double, string)>();

            foreach (var sParam in MeasurementVariables)
            {
                foreach (var val in scatteringParameterValues)
                {
                    // First Value in first array at frequency point "val"
                    double testValue = val.Value[0][0];
                    double limit = req.Limit.Validator.Value;
                    reqLimit[index] = limit;
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
                    }
                    csvData.Add((freq, testValue, margin, limit, result));

                    index++;
                }
            }

            string fileName = $"{new FileInfo(FilePath).DirectoryName}\\SerialNumber{SerialNumber}_requirement_{req.Name}.csv";
            WriteToCsv(fileName, csvData);

            return isPassed;
        }

        private Dictionary<string, List<double[]>> getMeasurementVariables(Dictionary<string, List<double[]>> measurement)
        {
            sprams.AddRange(s.ToList());
            //parameterDomain = measurement.Keys.ToList();
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

            scatteringParameterValues.Add(MeasurementVariables[0], new List<double[]>());
            foreach (var d in measurement.Keys)
            {
                index = 0;
                foreach (var val in measurement[d])
                {
                    if (index == idx)
                    {
                        var valF = new double[2]
                        {
                            20*Math.Log10(Convert.ToDouble(val[0])),
                            Convert.ToDouble(val[1])*(180/Math.PI)
                        };
                        scatteringParameterValues[MeasurementVariables[0]].Add(valF);
                        //Console.WriteLine($"{s[measurement[d].IndexOf(val)]}: {parsedData[s[measurement[d].IndexOf(val)]].Last().Magnitude} dB  {(180/Math.PI) * parsedData[s[measurement[d].IndexOf(val)]].Last().Phase} degrees");
                    }
                    index++;
                }
            }

            return scatteringParameterValues;
        }

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
                            Convert.ToDouble(val[0])
                            //Convert.ToDouble(val[1])
                        };
                        scatteringParameterValues.Add(d.Key.ToString(), new List<double[]>() { valF });

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
