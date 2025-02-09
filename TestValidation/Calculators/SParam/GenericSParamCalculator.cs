using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nuvo.TestValidation.Calculators.SParam
{
    [XmlInclude(typeof(dBcSParamCalculator))]
    [XmlInclude(typeof(MixedSParamCalculator))]
    public class GenericSParamCalculator : GenericCalculator
    {
        public override GenericCalcParams Params { get; set; } = new GenericSParamCalcParams();

        public GenericSParamCalculator()
            :base() 
        {
            Params = new GenericSParamCalcParams();
        }
    }
}
