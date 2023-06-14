using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TestValidation.Limits.Validators;

namespace TestValidation.Limits
{
    public class RangeLimit : GenericLimit
    {
        [XmlAttribute("MinValue")]
        public double MinValue { get; set; }

        [XmlAttribute("MaxValue")]
        public double MaxValue { get; set; }

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
        public virtual GenericValidator<double> Limit { get; set; }

        public override bool ValidateMeasurement(double freq, double measurement)
        {
            if (freq < MaxValue || freq > MinValue )
                return ValidateMeasurement(measurement); // Skip validation if outside the specified frequency domain
            return true;
        }
        public override bool ValidateMeasurement(double measurement)
        {
            return Limit.Validate(measurement);// measurement["Amplitude"] >= MinValue && measurement["Amplitude"] <= MaxValue;
        }
    }
}
