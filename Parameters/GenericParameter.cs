using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Limits.Validators;
using Nuvo.TestValidation.Parameters.Interfaces;
using Nuvo.TestValidation.Parameters.Interfaces;
using System.Collections;

namespace Nuvo.TestValidation.Parameters
{
    [XmlInclude(typeof(AttenuationParameter))]
    [XmlInclude( typeof(ScatteringParameter))]
    [XmlInclude(typeof(RippleParameter))]
    [Serializable]
    public abstract class GenericParameter : IParameterDetails
    {
        public string serialNumber { get; set; }
        public string Name { get; set; }

        //public abstract bool ValidateMeasurement(Dictionary<string, double> measurement);
        public string Description { get; set; }

        public abstract List<string> MeasurementVariables { get; set; }
        protected double MinMargin = double.MaxValue;
        [XmlIgnore]
        public abstract Dictionary<string,List<double[]>> ParameterValues { get; }
        public abstract double MinimumMargin { get; set; }

        public abstract bool ValidateMeasurement(TestRequirement req, Dictionary<string, List<double[]>> measurement);
        public abstract Dictionary<string, double> CalculateParameterValue(TestRequirement req, Dictionary<string, List<double[]>> baseDataSet);

        public abstract double[] GetParameterLimits();
    }

}
