using Nuvo.TestValidation.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Calculators.Interfaces
{
    public interface IParameterValueCalculator
    {
        Dictionary<string, object> Calculate2(TestRequirement req, Dictionary<string, List<object[]>> baseDataSet);

        Dictionary<string, List<object[]>> Calculate(TestRequirement req, Dictionary<string, List<object[]>> baseDataSet);
    }
}
