using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TestValidation.Requirements.Limits;

namespace TestValidation.Requirements
{
    public class DomainRequirementProperty : GenericRequirementProperty
    {
        [XmlElement("StartFrequency")]
        public double Start { get; set; }

        [XmlElement("EndFrequency")]
        public double End { get; set; }

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
        public GenericLimit<double> Limit { get; set; }

        //public DomainPropertyRequirement(double startFrequency, double endFrequency, GenericRequirementProperty property)
        //{
        //    StartFrequency = startFrequency;
        //    EndFrequency = endFrequency;
        //    Property = property;
        //}

        public override bool ValidateMeasurement(double measurement)
        {
            //if (measurement["Frequency"] < Start || measurement["Frequency"] > End)
            //    return Property.ValidateMeasurement(measurement); // Skip validation if outside the specified frequency domain
            return true;
            //return Property.ValidateMeasurement(measurement);
        }
    }
}
