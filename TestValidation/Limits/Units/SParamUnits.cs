using Nuvo.TestValidation.Calculators.SParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nuvo.TestValidation.Limits.Units
{
    [XmlInclude(typeof(DbcParameters))]
    [XmlInclude(typeof(PhaseSparamUnits))]
    public class SParamUnits : GenericUnits
    {
        public SParamUnits() 
        {
            Unit = UnitEnum.dB;
            ValidUnitTypes = new List<UnitEnum>() { UnitEnum.dB, UnitEnum.LinearMag, UnitEnum.Phase, UnitEnum.Phase_Rad, UnitEnum.Imaginary, UnitEnum.Real };
            ValidPrefixTypes = new List<PrefixEnum>() { PrefixEnum.None };
        }
    }
}
