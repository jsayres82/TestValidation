using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Nuvo.TestValidation.Limits.Validators;
using Nuvo.TestValidation.Parameters;

namespace Nuvo.TestValidation.Limits
{
    public class TestRequirement
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("DoubleLimt", typeof(DoubleLimt))]
        [XmlElement("RangeLimit", typeof(RangeLimit))]
        [XmlElement("DomainLimit", typeof(DomainLimit))]
        public GenericLimit Limit { get; set; }

        [XmlElement("GroupDelay", typeof(GroupDelayParameter))]
        [XmlElement("PhaseDelay", typeof(PhaseBalanceParameter))]
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
