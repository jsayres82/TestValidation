using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Limits.Units;
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
    public class GenericSParamCalcParams : GenericCalcParams
    {
        public string ParameterIndex { get; set; } = "";
        //public List<string> ParameterIndeces { get; set; }
        public GenericSParamCalcParams()
        {
            Limit = new DomainLimit(new FrequencyUnits());
            Units = new SParamUnits();
        }
    }

    public class DbcParameters : GenericSParamCalcParams
    {
        public bool IsReciprocal { get; set; }
        public double CarrierFrequency { get; set; }
        public List<string> NormalizedTo { get; set; } = new List<string>();
        public DbcParameters()
            : base() 
        {
            Limit = new DomainLimit(new FrequencyUnits());
            Units = new MagSparamUnits() { Unit = UnitEnum.dB, ValidUnitTypes = new List<UnitEnum>() { UnitEnum.dB } };
            IsReciprocal = false;
            ParameterIndex = "";
            CarrierFrequency = 0;
        }
    }

    public class MixedScatterParameters : GenericSParamCalcParams
    {
        public double MeasuredValue { get; set; }
        //public override GenericUnits Units { get; set; } = new MagSparamUnits();
        //public string ParameterIndex = "";
        public MixedScatterParameters()
            : base()
        {
            Limit = new DomainLimit(new FrequencyUnits());
            Units = new MagSparamUnits();
            ParameterIndex = "";
            MeasuredValue = 0;
        }
    }
}
