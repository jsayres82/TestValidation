using Nuvo.TestValidation.Calculators.Interfaces;
using Nuvo.TestValidation.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Calculators
{
    public class DoubleParameterValueCalculator : IParameterValueCalculator
    {
        public Dictionary<string, object> Calculate2(TestRequirement req, Dictionary<string, List<object[]>> baseDataSet)
        {
            var result = new Dictionary<string, object>();
            foreach (var kvp in baseDataSet)
            {
                var doubleArrays = kvp.Value.Select(arr => arr.Cast<double>().ToArray()).ToList();
                //result[kvp.Key] = doubleArrays.SelectMany(arr => arr).Average(); // Average of all values
            }
            return result;
        }

        public Dictionary<string, List<object[]>> Calculate(TestRequirement req, Dictionary<string, List<object[]>> baseDataSet)
        {
            var result = new Dictionary<string, object>();
            foreach (var kvp in baseDataSet)
            {
                var doubleArrays = kvp.Value.Select(arr => arr.Cast<double>().ToArray()).ToList();
                //result[kvp.Key] = doubleArrays.SelectMany(arr => arr).Average(); // Average of all values
            }
            return baseDataSet;
        }
    }
}
