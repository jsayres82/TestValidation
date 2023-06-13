using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestValidation;

namespace Requirements_Builder
{
    public partial class TestArticleCtrl : UserControl
    {
        private TestArticle article;

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
                textBoxTestName.DataBindings.Add("Text", article, "Name");
                emptyTextTextBox1.DataBindings.Add("Text", article, "PartNumber");

                if (article.MeasurementFiles != null)
                {
                    listBoxMeasurementFiles.DataSource = article.MeasurementFiles;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void emptyTextTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
