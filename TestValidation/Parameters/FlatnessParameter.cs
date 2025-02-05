using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Nuvo.TestValidation.Calculators.Interfaces;
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Utilities;
using Newtonsoft.Json;

namespace Nuvo.TestValidation.Parameters
{
    public class FlatnessParameter : GenericParameter
    {
        private Dictionary<double, List<double[]>> flatnessParameterValues = new Dictionary<double, List<double[]>>();
        List<string> sParams = new List<string>();
        private List<(double, double, double, double, string)> csvData = new List<(double, double, double, double, string)>();
        // All points from start to stop that we need to evaluate.
        private List<string> parameterDomain = new List<string>();
        private int portCount = 0;

        //[JsonIgnore]
        [XmlIgnore]
        public override Dictionary<string, List<object[]>> ParameterValues
        {
            get
            {
                return flatnessParameterValues.ToDictionary(
                    kvp => kvp.Key.ToString(),
                    kvp => kvp.Value.Select(innerList => innerList.Cast<object>().ToArray()).ToList());
            }
        }

        //public override List<string> VariableNames { get { return variableNames; } }
        //public override List<string> MeasurementVariables { get; set; } = new List<string>();

        public override double ValueAtMinMargin { get; set; }

        public FlatnessParameter(IParameterValueCalculator calculator)
            : base(calculator)
        {
            VariableNames = new List<string>();
        }

        public FlatnessParameter()
            : base()
        {
            VariableNames = new List<string>();
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

        public override Dictionary<string, List<object[]>> CalculateParameterValue(TestRequirement req, Dictionary<string, List<object[]>> baseDataSet)
        {
            flatnessParameterValues = new Dictionary<double, List<double[]>>();
            // Determine what sParameters are in object list
            sParams = SParamUtility.GenerateSparamStrings(new FileInfo(FilePath).Extension);
            var coll = GenericDataConverter.ToNetworkParameters(baseDataSet);
            var frequencies = coll.Frequencies;
            // Get the port indexes of the s-parameter variables
            var portIDs = MeasurementVariables[1].Replace("S", "");
            Dictionary<string, int[]> ports = new Dictionary<string, int[]>();
            return ParameterValues;
        }

        public override object[] GetParameterLimits()
        {
            return new object[] { double.MinValue, double.MaxValue }; // Example for double
        }
    }

}
