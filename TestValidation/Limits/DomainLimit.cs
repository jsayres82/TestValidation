using Nuvo.TestValidation.Limits.Validators;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Nuvo.TestValidation.Limits.Units;

namespace Nuvo.TestValidation.Limits
{
    public class DomainLimit : GenericLimit
    {
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

        public DomainLimit()
        {

        }

        public DomainLimit(GenericUnits units)
            : base(units)
        {
            LimitRange = new SpecRange<double>();
            LimitRange.Units = units;
        }

        public override double CalculateMargin(double domainValue, double rangeValue)
        {
            if (Start <= domainValue && domainValue <= End)
                return Validator.CalculateMargin(rangeValue);
            return double.NaN; // Skip validation if outside the specified frequency domain
        }

        public override bool ValidateMeasurement(double domainValue, double rangeValue)
        {
            if ( Start <= domainValue && domainValue <= End)
                return Validator.Validate(rangeValue);
            return true; // Skip validation if outside the specified frequency domain
        }

        public override double CalculateMargin(double domainValue, double SecondaryDomainValue, double rangeValue)
        {
            throw new System.NotImplementedException();
        }
    }
}
