using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Limits.Validators;
using Nuvo.TestValidation.Parameters.Interfaces;
using System.Collections;
using Nuvo.TestValidation.Calculators.Interfaces;
using Nuvo.TestValidation.Calculators;

namespace Nuvo.TestValidation.Parameters
{
    [XmlInclude(typeof(AttenuationParameter))]
    [XmlInclude( typeof(ScatteringParameter))]
    [XmlInclude(typeof(RippleParameter))]
    [Serializable]
    public abstract class GenericParameter : IParameterDetails
    {
        [XmlIgnore]
        public string FilePath { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public virtual int ParameterVariableCount { get; set; } = 1;
        public virtual string Description { get; set; } = "";
        public abstract List<string> VariableNames { get; }
        public abstract List<string> MeasurementVariables { get; set; }
        protected double MinMargin = double.MaxValue;

        [XmlIgnore]
        public abstract Dictionary<string, List<object[]>> ParameterValues { get; }

        public abstract double MinimumMargin { get; set; }
        Dictionary<string, List<object[]>> IParameterDetails.ParameterValues { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public abstract bool ValidateMeasurement(TestRequirement req, Dictionary<string, List<object[]>> measurement);

        private IParameterValueCalculator _parameterValueCalculator;

        public GenericParameter(IParameterValueCalculator calculator)
        {
            _parameterValueCalculator = new DoubleParameterValueCalculator();
        }

        public GenericParameter()
        {
            _parameterValueCalculator = new DoubleParameterValueCalculator();
        }

        public virtual Dictionary<string, object> CalculateParameterValue2(TestRequirement req, Dictionary<string, List<object[]>> baseDataSet)
        {
            return _parameterValueCalculator.Calculate2(req, baseDataSet);
        }

        public virtual Dictionary<string, List<object[]>>  CalculateParameterValue(TestRequirement req, Dictionary<string, List<object[]>> baseDataSet)
        {
            return _parameterValueCalculator.Calculate(req, baseDataSet);
        }

        public abstract object[] GetParameterLimits();

        Dictionary<string, object> IParameterDetails.CalculateParameterValue(TestRequirement req, Dictionary<string, List<object[]>> baseDataSet)
        {
            throw new NotImplementedException();
        }
    }

}
