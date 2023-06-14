using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TestValidation.Limits;

namespace TestValidation.CharacteristicParameters
{
    public class GroupDelayParameter : GenericCharacteristicParameter
    {
        public string Description { get { return "Returns the scattering parameter specified in measurement variable"; } }
        public List<string> MeasurementVariables { get; set; }
        public override bool ValidateMeasurement(TestRequirement req, Dictionary<string, List<double[]>> measurement)
        {
            return true;// propertyValue.ValidateMeasurement(measurement);
        }

        public override Dictionary<string, double> CalculateParameterValue(TestRequirement req, Dictionary<string, List<double[]>> baseDataSet)
        {
            Dictionary<string, double> par = new Dictionary<string, double>();
            return par;//["StopbandAttenuationParameter"];
        }
    }
}
