using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestMetrics
{
    public class TestResult
    {
        public string FileName { get; set; }
        public string PartNumber { get; set; }
        public int WaferNumber { get; set; }
        public string TestName { get; set; }
        public List<Specification> Specifications { get; set; }
        public bool PassFail { get; set; }
        public List<string> DataFiles { get; set; }
    }
}
