using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Nuvo.TestValidation
{
    /// <summary>
    /// Header information useful in for the test report and also to help with program logic
    /// </summary>
    [Serializable]
    public class TestInfo
    {
        public string TestName { get; set; }
        public string Program { get; set; }
        public string WaferName { get; set; }
        public string PartNum { get; set; }
        public string MeasFileType { get; set; }
        public int ParamCount { get; set; } = 0;
        [JsonIgnore]
        [XmlIgnore]
        public TestArticle TestArticles { get; set; }
    }
}
