using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.TestResults
{
    public class TestReport
    {
        public string SerialNumber { get; set; }
        public string PartNumber { get; set; }
        public List<object> Results { get; set; }

        public TestReport()
        {
            Results = new List<object>();
        }
        public TestReport(string serialNum, string partNum)
        {
            SerialNumber = serialNum;
            PartNumber = partNum;
            Results = new List<object>();
        }
    }

}
