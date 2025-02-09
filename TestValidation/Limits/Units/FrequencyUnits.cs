using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Limits.Units
{
    public class FrequencyUnits : GenericUnits
    {
        public override List<UnitEnum> ValidUnitTypes { get; set; } = new List<UnitEnum>() { UnitEnum.Hertz };
        public override List<PrefixEnum> ValidPrefixTypes { get; set; } = new List<PrefixEnum>() { PrefixEnum.Mega, PrefixEnum.Giga };
        public FrequencyUnits() { }
    }
}
