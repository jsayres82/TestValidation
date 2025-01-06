using Nuvo.TestValidation.Calculators.Interfaces;
using Nuvo.TestValidation.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nuvo.TestValidation.Parameters.Antenna
{
    public class HalfPowerBeamWidthParameter : GenericParameter
    {
        private Dictionary<string, List<double[]>> halfPowerBeamWidthParameterValues = new Dictionary<string, List<double[]>>();

        [XmlIgnore]
        public override Dictionary<string, List<object[]>> ParameterValues
        {
            get
            {
                return halfPowerBeamWidthParameterValues.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Select(innerList => innerList.Cast<object>().ToArray()).ToList());
            }
        }
        private List<string> variableNames = new List<string>() { "S-Param" };
        public override List<string> VariableNames { get { return variableNames; } }

        public override List<string> MeasurementVariables { get; set; } = new List<string>();

        public override double MinimumMargin { get; set; }

        public HalfPowerBeamWidthParameter(IParameterValueCalculator calculator)
            : base(calculator)
        {
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
