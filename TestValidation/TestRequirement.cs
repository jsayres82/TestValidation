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
    /// <summary>
    /// Meat and potatoes.
    /// Requirement has 3 things:
    ///     1. A human friendly name
    ///     2. A device parameter we are evaluating
    ///     3. A specified performance level it needs to meet
    /// </summary>
    public class TestRequirement
    {
        [XmlElement("Name")]
        public string Name { get; set; }


        [XmlElement("GroupDelayParameter", typeof(GroupDelayParameter))]
        [XmlElement("PhaseBalanceParameter", typeof(PhaseBalanceParameter))]
        [XmlElement("RippleParameter", typeof(FlatnessParameter))]
        [XmlElement("AttenuationParameter", typeof(AmplitudeBalanceParameter))]
        [XmlElement("ScatteringParameter", typeof(ScatteringParameter))]
        public GenericParameter CharacteristicParameter { get; set; }



        [XmlElement("DoubleLimt", typeof(DoubleLimit))]
        [XmlElement("RangeLimit", typeof(RangeLimit))]
        [XmlElement("DomainLimit", typeof(DomainLimit))]
        public GenericLimit Limit { get; set; }

        public void SetCharacteristicParameter(GenericParameter characteristicParameter)
        {
            CharacteristicParameter = characteristicParameter;
        }
    }

}
