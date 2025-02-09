using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nuvo.TestValidation.Limits.Units
{
    public class MagSparamUnits : SParamUnits
    {
        public override List<UnitEnum> ValidUnitTypes { get; set; } = new List<UnitEnum>() { UnitEnum.dB, UnitEnum.LinearMag };
        public override List<PrefixEnum> ValidPrefixTypes { get; set; } = new List<PrefixEnum>() { PrefixEnum.None };
        public MagSparamUnits() { }
    }
}
