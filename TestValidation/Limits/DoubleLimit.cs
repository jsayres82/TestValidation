using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
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

        //public DoublePropertyValue(double value)
        //{
        //    Value = value;
        //}

        public DoubleLimit()
        {

        }
        public override double CalculateMargin(double domainValue, double rangeValue)
        {
            //if (Start <= domainValue && domainValue <= End)
                return Validator.CalculateMargin(rangeValue);
            //return double.NaN; // Skip validation if outside the specified frequency domain
        }

        public override bool ValidateMeasurement(double measurement)
        {
            return Validator.Validate(measurement);
            //Limit.Validate(measurement["Amplitude"]);
                //switch (Comparison)
                //{
                //    case "GT":
                //        return measurement["Amplitude"] > Value;
                //        break;
                //    case "GTEQ":
                //        return measurement["Amplitude"] >= Value;
                //        break;
                //    case "LT":
                //        return measurement["Amplitude"] < Value;
                //        break;
                //    case "LTEQ":
                //        return measurement["Amplitude"] <= Value;
                //        break;
                //    case "EQ":
                //        return measurement["Amplitude"] == Value;
                //        break;

                //}
                //if (IsMaxValue)
                //    return kvp < Value;
                //else
                //    return kvp > Value;
            //return false;
        }
    }
}
