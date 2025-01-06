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
using Nuvo.TestValidation.Parameters;
using static Nuvo.TestValidation.Limits.Units.UnitConverter;

namespace Nuvo.Requirements_Builder
{
    public partial class ParameterCtrl : UserControl
    {
        public Type[] parameterTypes;
        public GenericParameter Parameter;
        public Type ParameterType;
        public ParameterCtrl()
        {
            InitializeComponent();
            Parameter = new ScatteringParameter()
            {
                MeasurementVariables = new List<string>()
                {
                    "S12"
                },
                Name = ""
            };
            ParameterType = Parameter.GetType();

            // Load the assembly containing the CharacteristicParameter classes
            Assembly assembly = Assembly.LoadFrom("Nuvo.TestValidation.dll");

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
            comboBoxSpecTypes.SelectedIndexChanged -= this.comboBoxSpecTypes_SelectedIndexChanged;
        }
        public ParameterCtrl(GenericParameter param)
        {
            InitializeComponent();
            Parameter = param;
            ParameterType = Parameter.GetType();

            // Load the assembly containing the CharacteristicParameter classes
            Assembly assembly = Assembly.LoadFrom("Nuvo.TestValidation.dll");

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
            comboBoxSpecTypes.SelectedIndexChanged -= this.comboBoxSpecTypes_SelectedIndexChanged;
        }

        public GenericParameter GetParameter()
        {
            var idx = 0;
            var count = Parameter.ParameterVariableCount;
            var measVars = new List<string>() { textBoxAdditionalProperty1.Text, textBoxAdditionalProperty2.Text };
            //Parameter.MeasurementVariables.Clear();
            if (Parameter.MeasurementVariables == null || Parameter.MeasurementVariables.Count == 0)
            {
                Parameter.MeasurementVariables = new List<string>() { "", "" };
            }
            for (int i = 0; i < count; i++) // var name in Parameter.VariableNames)
            {
                if (Parameter.MeasurementVariables[i] == null)
                    Parameter.MeasurementVariables.Add(measVars[i]);
                else
                    Parameter.MeasurementVariables[i] = measVars[i];
            }
            //if (Parameter.MeasurementVariables.Count > 0)
            //    Parameter.MeasurementVariables[0] = textBoxAdditionalProperty1.Text;
            //else
            //    Parameter.MeasurementVariables.Add(textBoxAdditionalProperty1.Text);

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

            //comboBoxSpecTypes.SelectedIndexChanged -= this.comboBoxSpecTypes_SelectedIndexChanged;
            BindData();
            comboBoxSpecTypes.SelectedIndexChanged += this.comboBoxSpecTypes_SelectedIndexChanged;
        }

        private void BindData()
        {
            if (Parameter != null)
            {
                //bindingSource1.DataSource = Parameter;
                //bindingSource2.DataSource = LimitType;
                //bindingSource3.DataSource = ValidatorType;

                ParameterType = Parameter.GetType();
                comboBoxSpecTypes.Text = ParameterType.Name;
                richTextBox1.Text = Parameter.Description;
                var count = Parameter.ParameterVariableCount;
                ShowAdditialParamCtrls(count);
                for (int i = 0; i < count; i++)
                {
                    if (i == 0)
                    {
                        if (Parameter.MeasurementVariables[i] == null)
                            Parameter.MeasurementVariables.Add(textBoxAdditionalProperty1.Text);
                        else
                            textBoxAdditionalProperty1.Text = Parameter.MeasurementVariables[i];
                        labelVariableName1.Text = Parameter.VariableNames[i].ToString();
                    }
                    else if (i == 1)
                    {
                        labelVariableName2.Text = Parameter.VariableNames[i].ToString();
                        if (Parameter.MeasurementVariables[i] == null)
                            Parameter.MeasurementVariables.Add(textBoxAdditionalProperty2.Text);
                        else
                            textBoxAdditionalProperty2.Text = Parameter.MeasurementVariables[i];
                    }
                }
                foreach (var variable in Parameter.MeasurementVariables)
                {
                    listView1.Items.Add(variable);
                }
                //textBoxAdditionalProperty1.Text = Parameter.Description;
                //richTextBox1.DataBindings.Add("Text", bindingSource1, "Description");
                //textBoxAdditionalProperty1.DataBindings.Add("Text", bindingSource1, "MeasurementVariables[0]");
                //textBoxAdditionalProperty2.DataBindings.Add("Text", bindingSource1, "MeasurementVariables[1]");

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
            Parameter = (o as GenericParameter);
            var count = Parameter.ParameterVariableCount;
            ShowAdditialParamCtrls(count);
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    labelVariableName1.Text = (o as GenericParameter).VariableNames[i];
                    textBoxAdditionalProperty1.Text = "";
                }
                else if (i == 1)
                {
                    labelVariableName2.Text = (o as GenericParameter).VariableNames[i];
                    textBoxAdditionalProperty2.Text = "";
                }
            }
            Parameter = o as GenericParameter;
        }

        private void ShowAdditialParamCtrls(int count)
        {
            labelVariableName1.Visible = false;
            textBoxAdditionalProperty1.Visible = false;
            labelVariableName2.Visible = false;
            textBoxAdditionalProperty2.Visible = false;
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    labelVariableName1.Visible = true;
                    textBoxAdditionalProperty1.Visible = true;
                }
                else if (i == 1)
                {
                    labelVariableName2.Visible = true;
                    textBoxAdditionalProperty2.Visible = true;
                }
            }
        }
    }
}
