﻿using Nuvo.TestValidation.Calculators.Interfaces;
using Nuvo.TestValidation.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Nuvo.TestValidation.Parameters.Antenna
{
    public class CrossPolarizationParameter : GenericParameter
    {
        private Dictionary<string, List<double[]>> crossPolarizationParameterValues = new Dictionary<string, List<double[]>>();

        //[JsonIgnore]
        [XmlIgnore]
        public override Dictionary<string, List<object[]>> ParameterValues
        {
            get
            {
                return crossPolarizationParameterValues.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Select(innerList => innerList.Cast<object>().ToArray()).ToList());
            }
        }
        private List<string> variableNames = new List<string>() { "S-Param" };
        //public override List<string> VariableNames { get { return variableNames; } }

        //public override List<string> MeasurementVariables { get; set; } = new List<string>();

        public override double ValueAtMinMargin { get; set; }

        public CrossPolarizationParameter(IParameterValueCalculator calculator)
            : base(calculator)
        {
            VariableNames = new List<string>() { "S-Param" };
        }

        public CrossPolarizationParameter()
            : base()
        {
            VariableNames = new List<string>() { "S-Param" };
        }

        public override bool ValidateMeasurement(TestRequirement req, Dictionary<string, List<object[]>> measurement)
        {
            // Convert back to double arrays for validation
            Dictionary<string, List<double[]>> doubleMeasurement = measurement.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Select(arr => arr.Cast<double>().ToArray()).ToList());

            // Your validation logic here for doubles
            return true; // Placeholder
        }

        public override object[] GetParameterLimits()
        {
            return new object[] { double.MinValue, double.MaxValue }; // Example for double
        }
    }
}
