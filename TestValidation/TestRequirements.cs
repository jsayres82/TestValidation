using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Nuvo.TestValidation.Limits
{   
    /// <summary>
    /// It's own special class to make serialization easier.
    /// </summary>
    public class TestRequirements
    {
        //[JsonProperty("TestRequirement")]
        [XmlElement("TestRequirement")]
        public List<TestRequirement> Requirements { get; set; }
        public TestRequirements()
        {
            Requirements = new List<TestRequirement>();
        }
    }
}
