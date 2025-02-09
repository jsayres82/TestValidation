using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Limits.Units
{
    public class PhaseSparamUnits : SParamUnits
    {
        public override List<UnitEnum> ValidUnitTypes { get; set; } = new List<UnitEnum>() { UnitEnum.Phase, UnitEnum.Phase_Rad };
        public override List<PrefixEnum> ValidPrefixTypes { get; set; } = new List<PrefixEnum>() { };
        public PhaseSparamUnits() { }
    }
}
