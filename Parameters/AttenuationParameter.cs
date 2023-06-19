using System.Collections.Generic;
using System.Xml.Serialization;
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Parameters.Interfaces;

namespace Nuvo.TestValidation.Parameters
{
    public class AttenuationParameter : GenericParameter
    {
        public string Description { get { return "Returns the scattering parameter specified in measurement variable"; } }
        public override List<string> MeasurementVariables { get; set; }
        [XmlIgnore]
        public override Dictionary<string, List<double[]>> ParameterValues { get => parameterValues; }
        public override double MinimumMargin
        {
            get => MinMargin;
            set => MinMargin = value;
        }
        private double[] reqLimit;

        private Dictionary<string, List<double[]>> parameterValues = new Dictionary<string, List<double[]>>();
        public override bool ValidateMeasurement(TestRequirement req, Dictionary<string, List<double[]>> baseDataSet)
        {
            reqLimit = new double[parameterValues[MeasurementVariables[0]].Count];
            return true;// propertyValue.ValidateMeasurement(measurement);
        }

        public override Dictionary<string, double> CalculateParameterValue(TestRequirement req, Dictionary<string, List<double[]>> baseDataSet)
        {
            return new Dictionary<string, double>();// baseDataSet;//["StopbandAttenuationParameter"];
        }

        public override double[] GetParameterLimits()
        {
            return reqLimit;
        }
    }

}
