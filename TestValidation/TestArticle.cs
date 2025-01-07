using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation
{
    /// <summary>
    /// Not really sure what I was planning on doing with this class. Maybe for making a summary results output?
    /// </summary>
    public class TestArticle
    {
        public string Name { get; set; }
        public string WaferLotNumber { get; set; }
        public List<string> MeasurementFiles { get; set; }

    }
}
