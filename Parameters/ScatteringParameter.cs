﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Limits.Validators;
using Nuvo.TestValidation.Parameters.Interfaces;
using Nuvo.TestValidation.TestResults;

namespace Nuvo.TestValidation.Parameters
{
    public class ScatteringParameter : GenericParameter
    {
        public string Description { get { return "Evaluates a scattering parameter for S-Parameter Matrix"; } }
        public override List<string> MeasurementVariables { get; set; }
        [XmlIgnore]
        public override Dictionary<string, List<double[]>> ParameterValues { get => parameterValues; }
        public override double MinimumMargin 
        {
             get => MinMargin; 
             set => MinMargin = value; 
        }
        private double[] reqLimit;
        private Dictionary<string, List<double[]>> parameterValues = new Dictionary<string, List<double[]>>();
        public static StreamWriter sw;
        private List<string> parameterDomain = new List<string>();
        private Dictionary<string, List<Complex>> complexParameterValue = new Dictionary<string, List<Complex>>();
        public override bool ValidateMeasurement(TestRequirement req, Dictionary<string, List<double[]>> measurement)
        {
            int index = 0;
            bool passed = true;
            bool ispassed = true;

            reqLimit = new double[parameterValues[MeasurementVariables.First()].Count];

            // Open the StreamWriter here; replace 'filePath' with your actual file path
            sw = new StreamWriter($"SerialNumber{serialNumber}_requirement_{req.Name}.csv",true);
            sw.WriteLine($"Frequency,TestValue,Margin,{req.Limit.Validator.GetType().Name},Result");

            foreach (var sParam in MeasurementVariables)
            {
                foreach (var val in parameterValues[sParam])
                {
                    double testValue = val[0];
                    double limit = req.Limit.Validator.Value;
                    reqLimit[index] = limit;
                    passed = true;
                    if (!req.Limit.ValidateMeasurement(System.Convert.ToDouble(parameterDomain.ElementAt(index)), testValue))
                    {
                        passed = false;
                        ispassed = false;
                    }
                    string result = passed == true ? "Passed" : "Failed";

                    double margin = req.Limit.CalculateMargin(System.Convert.ToDouble(parameterDomain.ElementAt(index)),testValue);
                    if (!double.NaN.Equals(margin))
                    {
                        if (margin < MinMargin)
                            MinMargin = margin;
                        // Write the test value, margin, and limit to the CSV file
                        sw.WriteLine($"{System.Convert.ToDouble(parameterDomain.ElementAt(index))},{testValue},{margin},{limit},{result}");

                    }
                    else
                    {
                        var test = 1;
                    }

                    index++;
                }
            }

            // Close the StreamWriter after all measurements have been validated
            sw.Close();

            return ispassed;
        }
        public static void WriteToCsv<T>(string filePath, T testValue, T margin, T limit)
        {
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                // Create a new file and write the header
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine("TestValue,Margin,Limit");
                }
            }

            // Append the test value, margin, and limit to the existing CSV file
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine($"{testValue},{margin},{limit}");
            }
        }
        public override Dictionary<string, double> CalculateParameterValue(TestRequirement req, Dictionary<string, List<double[]>> baseDataSet)
        {
            Dictionary<string, double> vals = new Dictionary<string, double>();
            baseDataSet = getMeasurementVariables(baseDataSet);
            foreach (var s in baseDataSet.Keys)
            {
                vals.Add(s, baseDataSet[s].First().First());
            }
            parameterValues = baseDataSet;
            return vals;
        }

        private Dictionary<string, List<double[]>> getMeasurementVariables(Dictionary<string, List<double[]>> measurement)
        {
            sprams.AddRange(s.ToList()); 
            parameterDomain = measurement.Keys.ToList();
            Dictionary<string, List<Complex>> parsedData = new Dictionary<string, List<Complex>>();
            foreach (var val in s)
                parsedData.Add(val, new List<Complex>());
            foreach (var d in measurement.Keys)
            {
                foreach (var val in measurement[d])
                {
                    var x = val.First();
                    var  y= val.Last();
                    parsedData[s[measurement[d].IndexOf(val)]].Add(new Complex(val[0], val[1]));
                    //Console.WriteLine($"{s[measurement[d].IndexOf(val)]}: {parsedData[s[measurement[d].IndexOf(val)]].Last().Magnitude} dB  {(180/Math.PI) * parsedData[s[measurement[d].IndexOf(val)]].Last().Phase} degrees");
                }
            }
            parameterValues = new Dictionary<string, List<double[]>>();
            complexParameterValue = parsedData;
            foreach(var variable in MeasurementVariables)
            {
                parameterValues.Add(variable, new List<double[]>());
                foreach (var value in complexParameterValue[variable])
                {
                    var val = new double[2]
                    {
                        value.Magnitude,
                        value.Phase * (180 / Math.PI)
                    };
                    parameterValues[variable].Add(val);
                }
            }

            return parameterValues;

        }

        public override double[] GetParameterLimits()
        {

            return reqLimit;
        }

        string[] s =new string[9] { "S11", "S12", "S13", "S21", "S22", "S23", "S31", "S32", "S33" };
        List<string> sprams = new List<string>();
    }
}
