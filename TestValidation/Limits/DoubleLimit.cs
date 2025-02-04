using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Nuvo.TestValidation.Limits.Validators;

namespace Nuvo.TestValidation.Limits
{
    /// <summary>
    /// I don't remember why I did this one.  Maybe for things like DC test that have only a single measurement point?
    /// </summary>
    public class DoubleLimit : GenericLimit
    {
        [XmlElement("Value")]
        public double Value { get; set; }

        //[JsonProperty("StartFrequency")]
        [XmlElement("StartFrequency")]
        public override double Start { get; set; }

        //[JsonProperty("StartFrequency")]
        [XmlElement("EndFrequency")]
        public override double End { get; set; }
        public double StartValue { get; set; }
        public double EndValue { get; set; }
        public double StartValue2 { get; set; }
        public double EndValue2 { get; set; }

        //[XmlElement("IsMaxValue")]
        //public bool IsMaxValue { get; set; }
        [XmlElement("GreaterThanOrEqualValidator", typeof(GreaterThanOrEqualValidator<double>))]
        [XmlElement("GreaterThanValidator", typeof(GreaterThanValidator<double>))]
        [XmlElement("LessThanOrEqualValidator", typeof(LessThanOrEqualValidator<double>))]
        [XmlElement("LessThanValidator", typeof(LessThanValidator<double>))]
        [XmlElement("NotEqualValidator", typeof(NotEqualValidator<double>))]
        [XmlElement("EqualValidator", typeof(EqualValidator<double>))]
        [XmlElement("ToleranceValidator", typeof(ToleranceValidator<double>))]
        [XmlElement("PercentageValidator", typeof(PercentageValidator<double>))]
        [XmlElement("RampValidator", typeof(RampValidator<double>))]
        [XmlElement("BoundedValidator", typeof(BoundedValidator<double>))]
        public override GenericValidator<double> Validator { get; set; }

        public DoubleLimit()
        {

        }
        public override double CalculateMargin(double domainValue, double rangeValue)
        {
                return Validator.CalculateMargin(rangeValue);
        }

        public override bool ValidateMeasurement(double measurement)
        {
            return Validator.Validate(measurement);
        }
    }
}
