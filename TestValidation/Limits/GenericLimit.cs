using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Nuvo.TestValidation.Limits.Validators;
using Nuvo.TestValidation.Parameters;

namespace Nuvo.TestValidation.Limits
{
    /// <summary>
    /// Range and Domain could be handled with same class but this makes doing things like evaluating gain over frequency and gain over az/el cleaner
    /// </summary>
    public abstract class GenericLimit
    {
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
        public abstract GenericValidator<double> Validator { get; set; }
        [XmlIgnore]
        public bool IsSLopedLimit = false;
        //[JsonProperty("StartFrequency")]
        [XmlElement("StartFrequency")]
        public virtual double Start { get; set; }

        //[JsonProperty("StartFrequency")]
        [XmlElement("EndFrequency")]
        public virtual double End { get; set; }

        public abstract double CalculateMargin(double domainValue, double rangeValue);

        public virtual bool ValidateMeasurement(double freq, double measurement)
        {
            return Validator.Validate(measurement);  
        }

        public virtual bool ValidateMeasurement(double measurement)
        {
            return Validator.Validate(measurement);
        }
    }

}
