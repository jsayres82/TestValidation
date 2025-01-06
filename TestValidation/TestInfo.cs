using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nuvo.TestValidation
{
    [Serializable]
    public class TestInfo
    {
        public string TestName { get; set; }
        public string Program { get; set; }
        public string WaferName { get; set; }
        //public string PartNum { get; set; }
        public List<TestArticle> TestArticles { get; set; }
        public string InputFileType { get; set; }
    }
}
