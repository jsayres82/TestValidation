using Nuvo.TestValidation.Calculators.SParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nuvo.TestValidation.Calculators
{
    [XmlInclude(typeof(GenericSParamCalculator))]
    public abstract class GenericCalculator
    {
        public virtual GenericCalcParams Params { get; set; } = new GenericSParamCalcParams();
        public GenericCalculator() { }

    }
}
