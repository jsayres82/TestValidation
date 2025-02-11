﻿using System.Xml.Serialization;
using Nuvo.TestValidation.Parameters;
using Newtonsoft.Json;

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
        //[JsonProperty("Name")]
        [XmlElement("Name")]
        public string Name { get; set; }


        [XmlElement("InsertionLossParameter", typeof(InsertionLossParameter))]
        [XmlElement("GroupDelayParameter", typeof(GroupDelayParameter))]
        [XmlElement("PhaseBalanceParameter", typeof(PhaseBalanceParameter))]
        [XmlElement("RippleParameter", typeof(FlatnessParameter))]
        [XmlElement("AttenuationParameter", typeof(AmplitudeBalanceParameter))]
        [XmlElement("ScatteringParameter", typeof(ScatteringParameter))]
        public GenericParameter CharacteristicParameter { get; set; }



        [XmlElement("DoubleLimt", typeof(DoubleLimit))]
        [XmlElement("RangeLimit", typeof(RangeLimit))]
        [XmlElement("DomainLimit", typeof(DomainLimit))]
        [XmlElement("LogSlopedDomainLimit", typeof(LogSlopedDomainLimit))]
        [XmlElement("LinearSlopedDomainLimit", typeof(LinearSlopedDomainLimit))]
        public GenericLimit Limit { get; set; }

        public void SetCharacteristicParameter(GenericParameter characteristicParameter)
        {
            CharacteristicParameter = characteristicParameter;
        }
    }

}
