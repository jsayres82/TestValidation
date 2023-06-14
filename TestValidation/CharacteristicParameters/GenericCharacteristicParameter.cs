using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TestValidation.Limits;
using TestValidation.Limits.Validators;

namespace TestValidation.CharacteristicParameters
{
    [XmlInclude(typeof(AttenuationParameter))]
    [XmlInclude( typeof(ScatteringParameter))]
    [XmlInclude(typeof(RippleParameter))]
    public abstract class GenericCharacteristicParameter
    {
        public string Name { get; set; }

        //public abstract bool ValidateMeasurement(Dictionary<string, double> measurement);
        public string Description { get; set; }
        public List<string> MeasurementVariables { get; set; }
        public abstract bool ValidateMeasurement(TestRequirement req, Dictionary<string, List<double[]>> measurement);
        public abstract Dictionary<string, double> CalculateParameterValue(TestRequirement req, Dictionary<string, List<double[]>> baseDataSet);
    }

}
