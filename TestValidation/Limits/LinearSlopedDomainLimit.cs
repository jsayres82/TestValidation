using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Nuvo.TestValidation.Limits.Validators;

namespace Nuvo.TestValidation.Limits
{
    public class LinearSlopedDomainLimit : GenericLimit
    {
        [XmlElement("StartFrequency")]
        public override double Start { get; set; }

        [XmlElement("EndFrequency")]
        public override double End { get; set; }

        public double StartValue { get; set; }
        public double EndValue { get; set; }
        public double StartValue2 { get; set; }
        public double EndValue2 { get; set; }
        private List<double> limitValues = new List<double>();

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

        public LinearSlopedDomainLimit()
        {
            IsSLopedLimit = true;

        }

        public override double CalculateMargin(double domainValue, double rangeValue)
        {
            Validator.Value = InterpolateAtValue(domainValue);
            if (Start <= domainValue && domainValue <= End)
            {
                limitValues.Add(Validator.Value);
                return Validator.CalculateMargin(rangeValue);
            }
            else
            {
                return double.NaN; // Skip validation if outside the specified frequency domain
            }
        }

        public override bool ValidateMeasurement(double domainValue, double rangeValue)
        {
            Validator.Value = InterpolateAtValue(domainValue);
            if (Start <= domainValue && domainValue <= End)
            {
                limitValues.Add(Validator.Value);
                return Validator.Validate(rangeValue);
            }
            else
            {
                return true; // Skip validation if outside the specified frequency domain
            }
        }

        public override bool ValidateMeasurement(double rangeValue)
        {
            bool pass = Validator.Validate(rangeValue);
            return pass;
        }

        private double InterpolateAtValue(double domainValue)
        {
            // Check if domainValue is within the range [Start, End]
            if (domainValue < Start || domainValue > End)
            {
                throw new ArgumentException("Domain value must be within the defined range.");
            }

            // Linear interpolation formula
            return StartValue + ((EndValue - StartValue) / (End - Start)) * (domainValue - Start);
        }
    }
}
