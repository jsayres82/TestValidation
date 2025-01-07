using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MicrowaveNetworks;
using MicrowaveNetworks.Touchstone;
using Nuvo.TestValidation.Calculators.Interfaces;
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Parameters.Interfaces;
using Nuvo.TestValidation.Utilities.Math;

namespace Nuvo.TestValidation.Parameters
{
    public class GroupDelayParameter : GenericParameter
    {
        string[] s = new string[9] { "S11", "S12", "S13", "S21", "S22", "S23", "S31", "S32", "S33" };
        List<string> sprams = new List<string>();
        private List<(double, double, double, double, string)> csvData = new List<(double, double, double, double, string)>();
        private MathClass myMath = new MathClass();

        private Dictionary<string, List<double[]>> _doubleParameterValues = new Dictionary<string, List<double[]>>();

        [XmlIgnore]
        public override Dictionary<string, List<object[]>> ParameterValues
        {
            get
            {
                return _doubleParameterValues.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Select(innerList => innerList.Cast<object>().ToArray()).ToList());
            }
        }

        private List<string> variableNames = new List<string>() { "S-Param" };
        public override List<string> VariableNames { get { return variableNames; } }
        public override List<string> MeasurementVariables { get; set; }
        public override double ValueAtMinMargin
        {
            get => MinMargin;
            set => MinMargin = value;
        }
        private double[] reqLimit;
        private Dictionary<string, List<double[]>> parameterValues = new Dictionary<string, List<double[]>>();
        public static StreamWriter sw;
        private List<string> parameterDomain = new List<string>();
        private Dictionary<string, List<Complex>> complexParameterValue = new Dictionary<string, List<Complex>>();


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
            // Convert back to double arrays for validation
            Dictionary<string, List<double[]>> doubleMeasurement = measurement.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Select(arr => arr.Cast<double>().ToArray()).ToList());

            int index = 0;
            bool isPassed = true;
            MinMargin = double.MaxValue;
            var reqLimit = new double[parameterValues[MeasurementVariables.First()].Count];

            foreach (var sParam in MeasurementVariables)
            {
                foreach (var val in parameterValues[sParam])
                {
                    double testValue = val[0];
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

        private Dictionary<string, List<double[]>> parseMeasurementsFromFile(string filePath)
        {
            Dictionary<string, List<double[]>> data = new Dictionary<string, List<double[]>>();
            //Dictionary<string, List<string>> dataStr = combiner.ExtractSParameterData(filePath);
            Dictionary<string, List<string>> dataStr = new Dictionary<string, List<string>>();
            INetworkParametersCollection coll = Touchstone.ReadAllData(filePath);
            
            int portOne = Convert.ToInt32(MeasurementVariables[0].Substring(1)[0].ToString());
            int portTwo = Convert.ToInt32(MeasurementVariables[0].Substring(1)[1].ToString());

            parameterValues = new Dictionary<string, List<double[]>>();
            parameterValues.Add(MeasurementVariables[0], new List<double[]>());
            var vals = new List<double[]>();
            foreach (FrequencyParametersPair pair in coll)
            {
                vals.Add(new double[2] { pair.Parameters[portOne, portTwo].Magnitude_dB, pair.Parameters[portOne, portTwo].Phase_deg });
            }
            parameterValues[MeasurementVariables[0]] = vals;
            return parameterValues;
        }

        private Dictionary<string, List<double[]>> getMeasurementVariables(Dictionary<string, List<double[]>> measurement)
        {
            sprams.AddRange(s.ToList());
            parameterValues = new Dictionary<string, List<double[]>>();
            parameterDomain = measurement.Keys.ToList();
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

            parameterValues.Add(MeasurementVariables[0], new List<double[]>());
            foreach (var d in measurement.Keys)
            {
                index = 0;
                foreach (var val in measurement[d])
                {
                    if (index == idx)
                    {
                        var valF = new double[2]
                        {
                            20*Math.Log10(val[0]),
                            val[1]*(180/Math.PI)
                        };
                        parameterValues[MeasurementVariables[0]].Add(valF);
                        //Console.WriteLine($"{s[measurement[d].IndexOf(val)]}: {parsedData[s[measurement[d].IndexOf(val)]].Last().Magnitude} dB  {(180/Math.PI) * parsedData[s[measurement[d].IndexOf(val)]].Last().Phase} degrees");
                    }
                    index++;
                }
            }
            double fc = 0.0;
            bool auto_fc = true;
            double phaseDC;
            double fc2;
            double[] frequency = new double[parameterDomain.Count];
            double[] data1 = new double[parameterDomain.Count];
            index = 0;
            foreach (var freq in parameterDomain)
            {
                data1[index] = parameterValues[MeasurementVariables[0]].ElementAt(index)[1] * (Math.PI / 180);
                frequency[index++] = Convert.ToDouble(freq);
            }

            double[] phase = MathClass.Unwrap(frequency, data1, fc, auto_fc, out phaseDC, out fc2);
            data1 = MathClass.GroupDelay(MathClass.CutoffCorrectedFrequency(frequency, fc2), phase, false);
            index = 0;
            foreach (var freq in parameterDomain)
            {
                parameterValues[MeasurementVariables[0]][index][0] = data1[index++];
            }
            return parameterValues;
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
