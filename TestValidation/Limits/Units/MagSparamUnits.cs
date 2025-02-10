using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nuvo.TestValidation.Limits.Units
{
    public class MagSparamUnits : GenericUnits
    {
        public MagSparamUnits() 
        {
            Unit = UnitEnum.dB;
            ValidUnitTypes = new List<UnitEnum>() { UnitEnum.dB, UnitEnum.LinearMag };
            ValidPrefixTypes = new List<PrefixEnum>() { PrefixEnum.None };
        }
    }
}
