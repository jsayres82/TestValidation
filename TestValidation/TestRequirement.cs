using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using TestValidation.Limits.Validators;
using TestValidation.Parameters;

namespace TestValidation.Limits
{
    public class TestRequirement
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("DoubleLimt", typeof(DoubleLimt))]
        [XmlElement("RangeLimit", typeof(RangeLimit))]
        [XmlElement("DomainLimit", typeof(DomainLimit))]
        public GenericLimit Limit { get; set; }

        [XmlElement("RippleParameter", typeof(RippleParameter))]
        [XmlElement("AttenuationParameter", typeof(AttenuationParameter))]
        [XmlElement("ScatteringParameter", typeof(ScatteringParameter))]
        public GenericParameter CharacteristicParameter { get; set; }

        public void SetCharacteristicParameter(GenericParameter characteristicParameter)
        {
            CharacteristicParameter = characteristicParameter;
        }
    }

}
