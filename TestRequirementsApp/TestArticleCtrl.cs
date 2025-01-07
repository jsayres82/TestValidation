using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nuvo.TestValidation;

namespace Nuvo.Requirements_Builder
{
    public partial class TestArticleCtrl : UserControl
    {
        /// <summary>
        /// This use to be a list of TestArticles but I don't have any use for it yet.  Maybe a 
        /// test article could be a specific az/el coordinate of antenna data?
        /// </summary>
        private TestArticle article;
        public TestArticle Article { get { return article; } }
        public TestArticleCtrl()
        {
            InitializeComponent();
        }

        public TestArticleCtrl(TestArticle article)
        {
            InitializeComponent();
            this.article = article;
            BindData();
        }

        private void BindData()
        {
            if (article != null)
            {
                textBoxWaferLotNum.DataBindings.Add("Text", article, "PartNumber");

                if (article.MeasurementFiles != null)
                {
                    listBoxMeasurementFiles.DataSource = article.MeasurementFiles;
                }
            }
        }

        public List<string> GetTestedPartNumbers()
        {
            return article.MeasurementFiles;
        }

        public string GetWaferLotTested()
        {
            return article.WaferLotNumber;
        }

        private void textBoxWaferLotNum_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
