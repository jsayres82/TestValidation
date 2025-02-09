using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Limits.Units
{
    public class TimeSparamUnits : GenericUnits
    {
        public override List<UnitEnum> ValidUnitTypes { get; set; } = new List<UnitEnum>() { UnitEnum.Seconds };
        public override List<PrefixEnum> ValidPrefixTypes { get; set; } = new List<PrefixEnum>() { PrefixEnum.Pico, PrefixEnum.Femto, PrefixEnum.Nano, PrefixEnum.Micro, PrefixEnum.Milli, PrefixEnum.None };

        public TimeSparamUnits() { }
    }
}
