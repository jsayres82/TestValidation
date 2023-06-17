using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.TestResults
{
    public class TestResult<T> : ITestResult
    {
        public string RequirementName { get; set; }
        public string ParameterName { get; set; }
        public bool Passed { get; set; }
        public T ParameterValue { get; set; }

        public TestResult(string parameterName, bool isPassed, T parameterValues)
        {
            RequirementName = parameterName;
            Passed = isPassed;
            ParameterValue = parameterValues;
        }
    }
}
