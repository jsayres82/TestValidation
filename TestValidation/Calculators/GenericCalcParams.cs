using Nuvo.TestValidation.Calculators.SParam;
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Limits.Units;
using Nuvo.TestValidation.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nuvo.TestValidation.Calculators
{
    [XmlInclude(typeof(GenericSParamCalcParams))]
    [Serializable]
    public abstract class GenericCalcParams 
    {

        public virtual GenericLimit Limit { get; set; }
        [XmlElement]
        public virtual GenericUnits Units { get; set; }
        public GenericCalcParams() { }
    }

}

