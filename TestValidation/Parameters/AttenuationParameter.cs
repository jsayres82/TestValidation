using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Nuvo.TestValidation.Calculators.Interfaces;
using Nuvo.TestValidation.Limits;

namespace Nuvo.TestValidation.Parameters
{
    public class AttenuationParameter : GenericParameter
    {
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

        public override List<string> MeasurementVariables { get; set; } = new List<string>();

        public override double MinimumMargin { get; set; }

        public AttenuationParameter(IParameterValueCalculator calculator)
            : base(calculator)
        {
        }

        public AttenuationParameter()
            : base()
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
