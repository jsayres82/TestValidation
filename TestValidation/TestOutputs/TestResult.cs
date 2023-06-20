using Nuvo.TestValidation.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nuvo.TestValidation.TestResults
{
    public class TestResult<T> : ITestResult
    {
        public string RequirementName { get; set; }
        public string ParameterName { get; set; }
        public bool Passed { get; set; }
        [XmlIgnore]
        public T ParameterValue { get; set; }
        public double MinimumMargin { get; set; }
        [XmlIgnore]
        public double[] ParameterValues { get; set; }
        [XmlElement("DoubleLimt", typeof(DoubleLimt))]
        [XmlElement("RangeLimit", typeof(RangeLimit))]
        [XmlElement("DomainLimit", typeof(DomainLimit))]
        public GenericLimit Limit { get; set; }
        public TestResult()
        {

        }


        public TestResult(string parameterName, bool isPassed, T parameterValues, double margin)
        {
            MinimumMargin = margin;
            RequirementName = parameterName;
            Passed = isPassed;
            ParameterValue = parameterValues;
        }
    }
}
