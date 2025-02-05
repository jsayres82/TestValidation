using Nuvo.TestValidation.Limits;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Nuvo.TestValidation.TestResults
{
    public class TestResult<T> : ITestResult
    {
        public string RequirementName { get; set; }
        public string ParameterName { get; set; }
        public bool Passed { get; set; }
        //[JsonIgnore]
        [XmlIgnore]
        public T ParameterValue { get; set; }
        public double MinimumMargin { get; set; }
        public double ValueAtMinimumMargin { get; set; }
        //[JsonIgnore]
        [XmlIgnore]
        public double[] ParameterValues { get; set; }
        [XmlElement("LogSlopedDomainLimit", typeof(LogSlopedDomainLimit))]
        [XmlElement("LinearSlopedDomainLimit", typeof(LinearSlopedDomainLimit))]
        [XmlElement("DoubleLimit", typeof(DoubleLimit))]
        [XmlElement("RangeLimit", typeof(RangeLimit))]
        [XmlElement("DomainLimit", typeof(DomainLimit))]
        public GenericLimit Limit { get; set; }
        public TestResult()
        {

        }


        public TestResult(string parameterName, bool isPassed, double valuAtMinMargin, double minimumMargin)
        {
            ValueAtMinimumMargin = valuAtMinMargin;
            RequirementName = parameterName;
            Passed = isPassed;
            MinimumMargin = minimumMargin;
        }

        public TestResult(string parameterName, bool isPassed, T parameterValues, double valuAtMinMargin, double minimumMargin)
        {
            ValueAtMinimumMargin = valuAtMinMargin;
            RequirementName = parameterName;
            Passed = isPassed;
            ParameterValue = parameterValues;
            MinimumMargin = minimumMargin;
        }
    }
}
