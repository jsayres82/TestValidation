using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using TestValidation.Requirements.Limits;
using TestValidation.CharacteristicParameters;

namespace TestValidation.Requirements
{
    public class TestRequirement
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("DoubleRequirementProperty", typeof(DoubleRequirementProperty))]
        [XmlElement("DomainRequirementProperty", typeof(DomainRequirementProperty))]
        [XmlElement("RangeRequirementProperty", typeof(RangeRequirementProperty))]
        public GenericRequirementProperty Limit { get; set; }

        [XmlElement("RippleParameter", typeof(RippleParameter))]
        [XmlElement("AttenuationParameter", typeof(AttenuationParameter))]
        [XmlElement("InsertionLossParameter", typeof(InsertionLossParameter))]
        public GenericCharacteristicParameter CharacteristicParameter { get; set; }

        public void SetCharacteristicParameter(GenericCharacteristicParameter characteristicParameter)
        {
            CharacteristicParameter = characteristicParameter;
        }
    }

}
