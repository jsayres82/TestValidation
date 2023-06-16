using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TestValidation.Limits;

namespace TestValidation.Parameters
{
    public class GroupDelayParameter : GenericParameter
    {
        public string Description { get { return "Returns the scattering parameter specified in measurement variable"; } }
        public override List<string> MeasurementVariables { get; set; }
        [XmlIgnore]
        public override Dictionary<string, List<double[]>> ParameterValues { get => parameterValues; }
        private Dictionary<string, List<double[]>> parameterValues = new Dictionary<string, List<double[]>>();
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
