using Nuvo.TestValidation.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Calculators.SParam
{
    public interface ISParamCalculator
    {
        /// <summary>
        /// Calculates the insertion loss given the parameters.
        /// </summary>
        /// <param name="parameters">A CalculationParameters object that will be cast to the expected type.</param>
        /// <returns>The calculated insertion loss (in dB).</returns>
        double Calculate(TestRequirement req, Dictionary<string, List<object[]>> baseDataSet);
    }
}