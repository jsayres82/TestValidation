using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nuvo.TestValidation.Limits.Units
{
    public class FrequencyUnits : GenericUnits
    {
        //[XmlIgnore]
        //public override List<UnitEnum> ValidUnitTypes { get; set; } = new List<UnitEnum>() { UnitEnum.Hertz };
        //[XmlIgnore]
        //public override List<PrefixEnum> ValidPrefixTypes { get; set; } = new List<PrefixEnum>() { PrefixEnum.Mega, PrefixEnum.Giga };
        public FrequencyUnits() 
        {
            ValidUnitTypes = new List<UnitEnum>() { UnitEnum.Hertz };
            ValidPrefixTypes = new List<PrefixEnum>() { PrefixEnum.Mega, PrefixEnum.Giga };
        }
    }
}
