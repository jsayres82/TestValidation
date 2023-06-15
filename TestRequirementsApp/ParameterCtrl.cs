using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestValidation.Parameters;
using static TestValidation.Limits.Units.UnitConverter;

namespace Requirements_Builder
{
    public partial class ParameterCtrl : UserControl
    {
        public Type[] parameterTypes;
        public GenericParameter Parameter;
        public Type ParameterType;
        public ParameterCtrl()
        {
            Parameter = new ScatteringParameter()
            {
                MeasurementVariables = new List<string>()
                {
                    "S12"
                },
                Name = ""
            };
            ParameterType = Parameter.GetType();
            InitializeComponent();

            // Load the assembly containing the CharacteristicParameter classes
            Assembly assembly = Assembly.LoadFrom("TestValidation.dll");

            // Get all the CharacteristicParameter classes
            parameterTypes = assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(GenericParameter)))
                .ToArray();

            // Loop through the CharacteristicParameter classes
            foreach (Type parameterType in parameterTypes)
            {
                Console.WriteLine($"Characteristic Parameter: {parameterType.Name}");
                comboBoxSpecTypes.Items.Add(parameterType.Name);
                // Get all the methods of the CharacteristicParameter class
                MethodInfo[] methods = parameterType.GetMethods();

                // Loop through the methods
                foreach (MethodInfo method in methods)
                {
                    Console.WriteLine($"- Method: {method.Name}");
                }

                Console.WriteLine();
            }
            comboBoxUnitsPrefix.Items.AddRange(Enum.GetNames(typeof(Prefix)));
            comboBoxLimitUnits.Items.AddRange(Enum.GetNames(typeof(Unit)));
        }

        public GenericParameter GetParameter()
        {
            Parameter.MeasurementVariables[0] = textBoxAdditionalProperty1.Text;
            return Parameter;
        }

        public void UpdateLimit(GenericParameter param)
        {
            Parameter = param;
            //fileName = Path.GetFileNameWithoutExtension(specFile);
            //folderName = Path.GetDirectoryName(specFile);
            //textBoxSpecFileLoc.Text = folderName;
            //textBoxSpecFileName.Text = fileName;
            //testInfo.TestName = newInfo.TestName;
            //testInfo.Program = newInfo.Program;
            //testInfo.WaferName = newInfo.WaferName;
            //testInfo.TestArticles = newInfo.TestArticles;
            //bindingSource1.ResetBindings(true);
            BindData();
        }

        private void BindData()
        {
            if (Parameter != null)
            {
                bindingSource1.DataSource = Parameter;
                //bindingSource2.DataSource = LimitType;
                //bindingSource3.DataSource = ValidatorType;

                comboBoxSpecTypes.Text = ParameterType.Name;
                foreach (var variable in Parameter.MeasurementVariables.ToList())
                {
                    listView1.Items.Add(variable);
                    textBoxAdditionalProperty1.Text = variable;
                }
                //textBoxAdditionalProperty1.Text = Parameter.Description;
                richTextBox1.DataBindings.Add("Text", bindingSource1, "Description");
                //textBoxAdditionalProperty1.DataBindings.Add("Text", bindingSource1, "MeasurementVariables[0]");

                //// If there are multiple TestArticles in the list, you can bind to the first one
                //if (testInfo.TestArticles != null && testInfo.TestArticles.Count > 0)
                //{
                //    TestArticle firstArticle = testInfo.TestArticles[0];
                //    //textBoxSpecFileName.DataBindings.Add("Text", bindingSource1, "PartNumber");
                //    //textBoxSpecFileName.DataBindings./*DefaultDataSourceUpdateMode*/ = DataSourceUpdateMode.OnPropertyChanged;
                //    //// Bind the MeasurementFiles property to a control within the TestArticle user control, if available
                //    //// Replace "someControl" with the actual control name within the TestArticle user control
                //    //testArticle1.DataBindings.Add("Text", bindingSource1, "MeasurementFiles");
                //    ////testArticle1.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                //}

            }
        }
        private void panelHeader1_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxSpecTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var o = Activator.CreateInstance(parameterTypes[comboBoxSpecTypes.SelectedIndex]);
            PropertyInfo[] properties = o.GetType().GetProperties();
            (o as GenericParameter).MeasurementVariables = new List<string>()
            {
                textBoxAdditionalProperty1.Text
            };
            Parameter = o as GenericParameter;
        }
    }
}
