using Nuvo.TestValidation.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Calculators.SParam
{
    public class dBcSParamCalculator : GenericSParamCalculator, ISParamCalculator
    {
        public dBcSParamCalculator(GenericScatterParams parameters)
        {
            Params = parameters as DbcParameters;
        }

        public double Calculate(TestRequirement req, Dictionary<string, List<object[]>> baseDataSet)
        {
            if (Params is not DbcParameters p)
                throw new ArgumentException("Expected DbcParameters");

            // Insertion loss (dBc) is given by 10*log10(carrierPower / interferencePower)
            return 10 * Math.Log10(p.CarrierFrequency / 1);
        }
    }
}
