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
    public class RangeLimit : GenericLimit
    {
        //[JsonProperty("MinValue")]
        [XmlAttribute("MinValue")]
        public double MinValue { get; set; }

        //[JsonProperty("MaxValue")]
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
        public override GenericValidator<double> Validator { get; set; }

        public RangeLimit()
        {

        }

        public override double CalculateMargin(double domainValue, double rangeValue)
        {
            //if (Start <= domainValue && domainValue <= End)
            return Validator.CalculateMargin(rangeValue);
            //return double.NaN; // Skip validation if outside the specified frequency domain
        }

        public override bool ValidateMeasurement(double domainValue, double rangeValue)
        {
            if (MinValue <= rangeValue && rangeValue <= MaxValue)
                return Validator.Validate(domainValue); // Skip validation if outside the specified frequency domain
            return true;
        }

        public override bool ValidateMeasurement(double domainValue)
        {
            return Validator.Validate(domainValue);// measurement["Amplitude"] >= MinValue && measurement["Amplitude"] <= MaxValue;
        }

        public override double CalculateMargin(double domainValue, double SecondaryDomainValue, double rangeValue)
        {
            throw new NotImplementedException();
        }
    }
}
