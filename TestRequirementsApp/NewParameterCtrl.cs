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
    public partial class NewParameterCtrl : UserControl
    {
        public event EventHandler ParameterUpdated;
        public Type[] parameterTypes;
        public GenericParameter Parameter;
        public Type ParameterType;
        public NewParameterCtrl()
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
            comboBoxUnitsPrefix.Items.AddRange(Enum.GetNames(typeof(PrefixEnum)));
            comboBoxLimitUnits.Items.AddRange(Enum.GetNames(typeof(UnitEnum)));
            comboBoxSpecTypes.SelectedIndexChanged -= this.comboBoxSpecTypes_SelectedIndexChanged;
        }

        public NewParameterCtrl(GenericParameter param)
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
            comboBoxUnitsPrefix.Items.AddRange(Enum.GetNames(typeof(PrefixEnum)));
            comboBoxLimitUnits.Items.AddRange(Enum.GetNames(typeof(UnitEnum)));
            comboBoxSpecTypes.SelectedIndexChanged -= this.comboBoxSpecTypes_SelectedIndexChanged;
        }

        public GenericParameter GetParameter()
        {
            var count = Parameter.ParameterVariableCount;
            var measVars = new List<string>() { textBoxAdditionalProperty1.Text, textBoxAdditionalProperty2.Text };

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
            return Parameter;
        }

        public void UpdateLimit(GenericParameter param)
        {
            Parameter = param;
            BindData();
            comboBoxSpecTypes.SelectedIndexChanged += this.comboBoxSpecTypes_SelectedIndexChanged;
        }

        private void BindData()
        {
            if (Parameter != null)
            {
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
                        labelVariableName2.Text = Parameter.VariableNames[i - 1].ToString();
                        if (Parameter.MeasurementVariables[i - 1] == null)
                            Parameter.MeasurementVariables.Add(textBoxAdditionalProperty2.Text);
                        else
                            textBoxAdditionalProperty2.Text = Parameter.MeasurementVariables[i - 1];
                    }
                }
                foreach (var variable in Parameter.MeasurementVariables)
                {
                    listView1.Items.Add(variable);
                }
            }
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
            ParameterUpdated.Invoke(this, null);
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
