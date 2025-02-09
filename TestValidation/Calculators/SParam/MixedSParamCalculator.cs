using Nuvo.TestValidation.Calculators.SParam;
using Nuvo.TestValidation.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Calculators.SParam
{
    public class MixedSParamCalculator : GenericSParamCalculator, ISParamCalculator
    {
        public MixedSParamCalculator()
        {
            Params = new MixedScatterParameters();
        }

        public MixedSParamCalculator(GenericCalcParams parameters)
        {
            Params = parameters as MixedScatterParameters;
        }

        public double Calculate(TestRequirement req, Dictionary<string, List<object[]>> baseDataSet)
        {
            if (Params is not MixedScatterParameters p)
                throw new ArgumentException("Expected MixedMeasurementParameters");

            // For this example, assume the measured value is in dB and needs a 3 dB correction.
            return p.MeasuredValue - 3.0;
        }
    }
}