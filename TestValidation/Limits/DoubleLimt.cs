using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TestValidation.Limits.Validators;

namespace TestValidation.Limits
{
    public class DoubleLimt : GenericLimit
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
        public virtual GenericValidator<double> Limit { get; set; }

        //public DoublePropertyValue(double value)
        //{
        //    Value = value;
        //}

        public override bool ValidateMeasurement(double measurement)
        {
            return Limit.Validate(measurement);
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
            return false;
        }
    }
}
