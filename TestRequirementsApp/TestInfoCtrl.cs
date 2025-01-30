using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nuvo.TestValidation;
using Nuvo.TestValidation.Utilities;
using static Nuvo.TestValidation.Limits.Units.UnitConverter;

namespace Nuvo.Requirements_Builder
{
    public partial class TestInfoCtrl : UserControl
    {
        public event EventHandler TestInfoUpdated;
        public BindingSource source;
        public bool isBound = false;
        public TestInfo testInfo { get; set; }
        public string fileName { get; set; }
        public string folderName { get; set; }
        public TestInfoCtrl()
        {
            isBound = false;
            testInfo = new TestInfo() { TestName = "Test", Program = "1180", WaferName = "Pentaplexer", TestArticles = new TestArticle() };
            InitializeComponent();
            BindData();
            isBound = true;
            cbMeasuremntFileType.SelectedIndexChanged -= CbMeasuremntFileType_SelectedIndexChanged;
            cbMeasuremntFileType.Items.AddRange(Enum.GetNames(typeof(MeasFileTypes)));
            cbMeasuremntFileType.SelectedIndexChanged += CbMeasuremntFileType_SelectedIndexChanged;
        }


        public TestInfoCtrl(TestInfo info)
        {
            testInfo = new TestInfo() { TestName = "Test", Program = "1180", WaferName = "Pentaplexer", TestArticles = new TestArticle() };
            isBound = false;
            InitializeComponent();
            BindData();
            isBound = true;
            cbMeasuremntFileType.SelectedIndexChanged -= CbMeasuremntFileType_SelectedIndexChanged;
            cbMeasuremntFileType.Items.AddRange(Enum.GetNames(typeof(MeasFileTypes)));
            cbMeasuremntFileType.SelectedIndexChanged += CbMeasuremntFileType_SelectedIndexChanged;
        }

        private void CbMeasuremntFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelParamCount.Visible = false;
            testInfo.MeasFileType = cbMeasuremntFileType.Text;
            if (testInfo.MeasFileType.Equals(Enum.GetName(MeasFileTypes.sXp)))
            {
                panelParamCount.Visible = true;
            }
            else
            {
                panelParamCount.Visible = false;
            }
            if (!flowLayoutPanel2.Enabled)
                testInfo.ParamCount = System.Convert.ToInt32(testInfo.ParamCount);
            else
                nudParameterCount.Value = System.Convert.ToDecimal(testInfo.ParamCount);
        }

        private void MeasurementInfoCtrl_Load(object sender, EventArgs e)
        {
            if (isBound == false)
            {
                BindData();
                isBound = true;
            }
        }

        private void BindData()
        {
            if (testInfo != null)
            {
                bindingDataSource1.DataSource = testInfo;

                textBoxTestName.DataBindings.Add("Text", bindingDataSource1, "TestName");
                textBoxProgram.DataBindings.Add("Text", bindingDataSource1, "Program");
                textBoxWaferName.DataBindings.Add("Text", bindingDataSource1, "WaferName");
                textBoxPartNumber.DataBindings.Add("Text", bindingDataSource1, "PartNum");
                cbMeasuremntFileType.DataBindings.Add("Text", bindingDataSource1, "MeasFileType");

                nudParameterCount.Value = System.Convert.ToDecimal(testInfo.ParamCount);

                // If there are multiple TestArticles in the list, you can bind to the first one
                if (testInfo.TestArticles != null)
                {
                    TestArticle firstArticle = testInfo.TestArticles;
                }

            }
        }

        public void UpdateTestInfo(TestInfo newInfo, string specFile)
        {
            fileName = Path.GetFileNameWithoutExtension(specFile);
            folderName = Path.GetDirectoryName(specFile);
            textBoxSpecFileLoc.Text = folderName;
            textBoxSpecFileName.Text = fileName;
            testInfo.TestName = newInfo.TestName;
            testInfo.Program = newInfo.Program;
            testInfo.WaferName = newInfo.WaferName;
            testInfo.PartNum = newInfo.PartNum;
            testInfo.MeasFileType = newInfo.MeasFileType;
            if (testInfo.MeasFileType == null)
                testInfo.MeasFileType = Enum.GetName(MeasFileTypes.None);

            if (testInfo.MeasFileType.Equals(Enum.GetName(MeasFileTypes.sXp)))
            {
                panelParamCount.Visible = true;
            }
            else
            {
                panelParamCount.Visible = false;
            }
            testInfo.ParamCount = newInfo.ParamCount;
            nudParameterCount.Value = System.Convert.ToDecimal(testInfo.ParamCount);

            testInfo.TestArticles = newInfo.TestArticles;
            bindingDataSource1.ResetBindings(true);
        }

        private void BindData(TestInfo newTestInfo)
        {
            if (newTestInfo != null)
            {
                bindingDataSource1.DataSource = testInfo;
                bindingDataSource1.AllowNew = true;
                textBoxTestName.DataBindings.Add("Text", bindingDataSource1.DataMember, "TestName");
                textBoxTestName.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                textBoxProgram.DataBindings.Add("Text", bindingDataSource1, "Program");
                textBoxProgram.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                textBoxWaferName.DataBindings.Add("Text", bindingDataSource1, "WaferName");
                textBoxWaferName.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                textBoxPartNumber.DataBindings.Add("Text", bindingDataSource1, "PartNum");
                textBoxPartNumber.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                cbMeasuremntFileType.DataBindings.Add("Text", bindingDataSource1, "MeasFileType");
                cbMeasuremntFileType.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;

                nudParameterCount.Value = System.Convert.ToDecimal(testInfo.ParamCount);
                bindingDataSource1.DataSource = newTestInfo;
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                folderName = folderBrowserDialog1.SelectedPath;
                textBoxSpecFileLoc.Text = folderName;
            }
        }

        private void textBoxSpecFileName_TextChanged(object sender, EventArgs e)
        {
            fileName = textBoxSpecFileName.Text;
        }

        private void textBoxSpecFileLoc_TextChanged(object sender, EventArgs e)
        {
            folderName = textBoxSpecFileLoc.Text;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel2.Enabled)
            {
                buttonEdit.Text = "EDIT";
                testInfo.Program = textBoxProgram.Text;
                testInfo.TestName = textBoxTestName.Text;
                testInfo.WaferName = textBoxWaferName.Text;
                testInfo.PartNum = textBoxPartNumber.Text;
                testInfo.MeasFileType = cbMeasuremntFileType.Text;
                testInfo.ParamCount = System.Convert.ToInt16(nudParameterCount.Value);
                testInfo.TestArticles = testArticleCtrl1.Article;
                flowLayoutPanel2.Enabled = false;
                TestInfoUpdated.Invoke(this, null);
            }
            else
            {
                buttonEdit.Text = "SAVE";
                flowLayoutPanel2.Enabled = true;
            }
        }
    }
}
