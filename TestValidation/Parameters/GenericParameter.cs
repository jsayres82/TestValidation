using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TestValidation.Limits;
using TestValidation.Limits.Validators;
using System.Collections;

namespace TestValidation.Parameters
{
    [XmlInclude(typeof(AttenuationParameter))]
    [XmlInclude( typeof(ScatteringParameter))]
    [XmlInclude(typeof(RippleParameter))]
    [Serializable]
    public abstract class GenericParameter
    {
        public string Name { get; set; }

        //public abstract bool ValidateMeasurement(Dictionary<string, double> measurement);
        public string Description { get; set; }

        public abstract List<string> MeasurementVariables { get; set; }
        [XmlIgnore]
        public abstract Dictionary<string,List<double[]>> ParameterValues { get; }
        public abstract bool ValidateMeasurement(TestRequirement req, Dictionary<string, List<double[]>> measurement);
        public abstract Dictionary<string, double> CalculateParameterValue(TestRequirement req, Dictionary<string, List<double[]>> baseDataSet);
    }

}
