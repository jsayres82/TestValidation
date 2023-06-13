using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TestValidation.Requirements;

namespace TestValidation.CharacteristicParameters
{
    public class AttenuationParameter : GenericCharacteristicParameter
    {
        public string Description { get { return "Returns the scattering parameter specified in measurement variable"; } }
        public List<string> MeasurementVariables { get; set; }
        public override bool ValidateMeasurement(Dictionary<string, double> measurement)
        {
            return true;// propertyValue.ValidateMeasurement(measurement);
        }

        public override Dictionary<string, double> CalculateParameterValue(Dictionary<string, double> baseDataSet)
        {
            return baseDataSet;//["StopbandAttenuationParameter"];
        }
    }

}
