using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nuvo.TestValidation.Limits.Units
{
    [XmlInclude(typeof(MagSparamUnits))]
    [XmlInclude(typeof(PhaseSparamUnits))]
    public class SParamUnits : GenericUnits
    {
        public override List<UnitEnum> ValidUnitTypes { get; set; } = new List<UnitEnum>() { UnitEnum.dB, UnitEnum.LinearMag, UnitEnum.Phase, UnitEnum.Phase_Rad, UnitEnum.Imaginary, UnitEnum.Real };
        public override List<PrefixEnum> ValidPrefixTypes { get; set; } = new List<PrefixEnum>() {  };
        public SParamUnits() { }
    }
}
