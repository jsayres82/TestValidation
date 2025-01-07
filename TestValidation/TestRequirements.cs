using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nuvo.TestValidation.Limits
{   
    /// <summary>
    /// It's own special class to make serialization easier.
    /// </summary>
    public class TestRequirements
    {
        [XmlElement("TestRequirement")]
        public List<TestRequirement> Requirements { get; set; }
        public TestRequirements()
        {
            Requirements = new List<TestRequirement>();
        }
    }
}
