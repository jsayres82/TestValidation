using System.Collections.Generic;
using TestValidation.Limits;

namespace TestValidation.Parameters
{
    public class AttenuationParameter : GenericParameter
    {
        public string Description { get { return "Returns the scattering parameter specified in measurement variable"; } }
        public override List<string> MeasurementVariables { get; set; }
        public override bool ValidateMeasurement(TestRequirement req, Dictionary<string, List<double[]>> baseDataSet)
        {
            return true;// propertyValue.ValidateMeasurement(measurement);
        }

        public override Dictionary<string, double> CalculateParameterValue(TestRequirement req, Dictionary<string, List<double[]>> baseDataSet)
        {
            return new Dictionary<string, double>();// baseDataSet;//["StopbandAttenuationParameter"];
        }
    }

}
