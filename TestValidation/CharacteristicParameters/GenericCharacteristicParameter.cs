using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TestValidation.Requirements;
using TestValidation.Requirements.Limits;

namespace TestValidation.CharacteristicParameters
{
    [XmlInclude(typeof(AttenuationParameter))]
    [XmlInclude( typeof(InsertionLossParameter))]
    [XmlInclude(typeof(RippleParameter))]
    public abstract class GenericCharacteristicParameter
    {
        public string Name { get; set; }

        //public abstract bool ValidateMeasurement(Dictionary<string, double> measurement);
        public string Description { get; set; }
        public List<string> MeasurementVariables { get; set; }
        public abstract bool ValidateMeasurement(Dictionary<string, double> measurement);
        public abstract Dictionary<string, double> CalculateParameterValue(Dictionary<string, double> baseDataSet);
    }

}
