using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TestValidation.Requirements.Limits;

namespace TestValidation.Requirements
{
    public class DoubleRequirementProperty : GenericRequirementProperty
    {
        [XmlElement("Value")]
        public double Value { get; set; }

        //[XmlElement("IsMaxValue")]
        //public bool IsMaxValue { get; set; }
        [XmlElement("GreaterThanOrEqualLimit", typeof(GreaterThanOrEqualLimit<double>))]
        [XmlElement("GreaterThanLimit", typeof(GreaterThanLimit<double>))]
        [XmlElement("LessThanOrEqualLimit", typeof(LessThanOrEqualLimit<double>))]
        [XmlElement("LessThanLimit", typeof(LessThanLimit<double>))]
        [XmlElement("NotEqualLimit", typeof(NotEqualLimit<double>))]
        [XmlElement("EqualLimit", typeof(EqualLimit<double>))]
        [XmlElement("ToleranceLimit", typeof(ToleranceLimit<double>))]
        [XmlElement("PercentageLimit", typeof(PercentageLimit<double>))]
        [XmlElement("RampLimit", typeof(RampLimit<double>))]
        [XmlElement("BoundedLimit", typeof(BoundedLimit<double>))]
        public virtual GenericLimit<double> Limit { get; set; }

        //public DoublePropertyValue(double value)
        //{
        //    Value = value;
        //}

        public override bool ValidateMeasurement(double measurement)
        {
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
