using Nuvo.TestValidation.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nuvo.TestValidation.Calculators.SParam
{
    [XmlInclude(typeof(DbcParameters))]
    [XmlInclude(typeof(MixedScatterParameters))]
    [Serializable]
    public abstract class GenericScatterParams { }

    public class DbcParameters : GenericScatterParams
    {
        public double CarrierFrequency { get; set; }
    }

    public class MixedScatterParameters : GenericScatterParams
    {
        public double MeasuredValue { get; set; }
    }
}

