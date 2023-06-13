using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestValidation;

namespace Requirements_Builder
{
    public partial class MeasurementInfoCtrl : UserControl
    {
        public BindingSource source;
        public TestInfo testInfo { get; set; }
        public string fileName { get; set; }
        public string folderName { get; set; }
        public MeasurementInfoCtrl()
        {
            //bindingDataSource1 = new BindingSource();

            testInfo = new TestInfo() { TestName = "Test", Program = "1180", WaferName = "Pentaplexer", TestArticles = new List<TestArticle>() };
            InitializeComponent();
        }
        public MeasurementInfoCtrl(TestInfo info)
        {
            testInfo = new TestInfo() { TestName = "Test", Program = "1180", WaferName = "Pentaplexer", TestArticles = new List<TestArticle>() };

            InitializeComponent();
            BindData();
        }

        private void MeasurementInfoCtrl_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            if (testInfo != null)
            {
                bindingDataSource1.DataSource= testInfo;

                textBoxTestName.DataBindings.Add("Text", bindingDataSource1, "TestName");
                //textBoxTestName.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                textBoxProgram.DataBindings.Add("Text", bindingDataSource1, "Program");
                //textBoxProgram.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                textBoxWaferName.DataBindings.Add("Text", bindingDataSource1, "WaferName");
                //textBoxWaferName.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;

                // If there are multiple TestArticles in the list, you can bind to the first one
                if (testInfo.TestArticles != null && testInfo.TestArticles.Count > 0)
                {
                    TestArticle firstArticle = testInfo.TestArticles[0];
                    //textBoxSpecFileName.DataBindings.Add("Text", bindingSource1, "PartNumber");
                    //textBoxSpecFileName.DataBindings./*DefaultDataSourceUpdateMode*/ = DataSourceUpdateMode.OnPropertyChanged;
                    //// Bind the MeasurementFiles property to a control within the TestArticle user control, if available
                    //// Replace "someControl" with the actual control name within the TestArticle user control
                    //testArticle1.DataBindings.Add("Text", bindingSource1, "MeasurementFiles");
                    ////testArticle1.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                }

            }
        }

        public void UpdateTestInfo(TestInfo newInfo,string specFile)
        {
            fileName = Path.GetFileNameWithoutExtension(specFile);
            folderName = Path.GetDirectoryName(specFile);
            textBoxSpecFileLoc.Text = folderName;
            textBoxSpecFileName.Text = fileName;
            testInfo.TestName = newInfo.TestName;
            testInfo.Program = newInfo.Program;
            testInfo.WaferName = newInfo.WaferName;
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
                // If there are multiple TestArticles in the list, you can bind to the first one
                //if (testInfo.TestArticles != null && testInfo.TestArticles.Count > 0)
                //{
                //    TestArticle firstArticle = testInfo.TestArticles[0];
                //    textBoxSpecFileName.DataBindings.Add("Text", firstArticle, "PartNumber");
                //    textBoxSpecFileName.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                //    // Bind the MeasurementFiles property to a control within the TestArticle user control, if available
                //    // Replace "someControl" with the actual control name within the TestArticle user control
                //    testArticle1.DataBindings.Add("Text", firstArticle, "MeasurementFiles");
                //    testArticle1.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                //}

                bindingDataSource1.DataSource = newTestInfo;
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
           DialogResult result = folderBrowserDialog1.ShowDialog();
            if(result.Equals(DialogResult.OK))
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
    }
}
