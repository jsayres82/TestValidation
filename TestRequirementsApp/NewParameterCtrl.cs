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
using Nuvo.Requirements_Builder.ValidationCtrls;
using Nuvo.TestValidation.Calculators;
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Parameters;
using static Nuvo.TestValidation.Limits.Units.GenericUnits;

namespace Nuvo.Requirements_Builder
{
    public partial class ParameterCtrl : UserControl
    {
        public event EventHandler ParameterUpdated;
        public Type[] parameterTypes;
        public GenericParameter Parameter;
        public Type ParameterType;
        public GenericCalculator Calculator;
        public Type CalcType;
        public Type[] calcTypes;

        public ParameterCtrl()
        {
            InitializeComponent();
            Parameter = new ScatteringParameter()
            {
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
                cbSpecTypes.Items.Add(parameterType.Name);
                // Get all the methods of the CharacteristicParameter class
                MethodInfo[] methods = parameterType.GetMethods();

                // Loop through the methods
                foreach (MethodInfo method in methods)
                {
                    Console.WriteLine($"- Method: {method.Name}");
                }

                Console.WriteLine();
            }
            Calculator = Parameter.Calculator;
            cbCalculator.Items.Clear();
            // Load the assembly containing the CharacteristicParameter classes
            // Get all the CharacteristicParameter classes
            calcTypes = assembly.GetTypes()
                .Where(t => t.IsSubclassOf(Calculator.GetType()))
                .ToArray();
            cbCalculator.Items.AddRange(calcTypes);
            int idx = 0;
            foreach (Type calc in calcTypes)
            {
                var name = Calculator.GetType().Name;
                if (calc.Name.Equals(name))
                {
                    cbCalculator.SelectedIndex = idx;
                    break;
                }
                else
                {
                    idx++;
                }
            }
            cbCalculator.SelectedIndexChanged -= this.cbCalculator_SelectedIndexChanged;
            cbSpecTypes.SelectedIndexChanged -= this.comboBoxSpecTypes_SelectedIndexChanged;
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
                cbSpecTypes.Items.Add(parameterType.Name);
                // Get all the methods of the CharacteristicParameter class
                MethodInfo[] methods = parameterType.GetMethods();

                // Loop through the methods
                foreach (MethodInfo method in methods)
                {
                    Console.WriteLine($"- Method: {method.Name}");
                }

                Console.WriteLine();
            }

            Calculator = Activator.CreateInstance(param.Calculator.GetType()) as GenericCalculator;
            cbCalculator.Items.Clear();
            // Load the assembly containing the CharacteristicParameter classes
            // Get all the CharacteristicParameter classes
            calcTypes = assembly.GetTypes()
                .Where(t => t.IsSubclassOf(Calculator.GetType()))
                .ToArray();
            cbCalculator.Items.AddRange(calcTypes);
            cbCalculator.SelectedItem = Calculator.GetType().Name;
            cbCalculator.SelectedIndexChanged -= this.cbCalculator_SelectedIndexChanged;
            cbSpecTypes.SelectedIndexChanged -= this.comboBoxSpecTypes_SelectedIndexChanged;
        }

        private void UpdateLimitInteral(GenericParameter param)
        {
        }

        public GenericParameter GetParameter()
        {
            //Parameter.Calculator = cbCalculator.SelectedItem as GenericCalculator;
            //Parameter = cbSpecTypes.SelectedItem as GenericParameter;
            foreach (var ctrl in flpCalcParams.Controls)
            {
                if(ctrl is CalcParamCtrl)
                {
                    Parameter.Calculator.Params = (ctrl as CalcParamCtrl).GetCalculatorParameter();
                }
            }
            return Parameter;
        }

        public void UpdateLimit(GenericParameter param)
        {
            Parameter = param;
            BindData();
            cbSpecTypes.SelectedIndexChanged += this.comboBoxSpecTypes_SelectedIndexChanged;
            cbCalculator.SelectedIndexChanged += this.cbCalculator_SelectedIndexChanged;
        }

        private void BindData()
        {
            if (Parameter != null)
            {
                ParameterType = Parameter.GetType();
                cbSpecTypes.Text = ParameterType.Name;
                richTextBox1.Text = Parameter.Description;
                var count = Parameter.ParameterVariableCount;
                ShowAdditialParamCtrls(count);
                for (int i = 0; i < count; i++)
                {
                }
                foreach (var variable in Parameter.MeasurementVariables)
                {
                }
                if(Parameter.Calculator != null)
                {
                    Calculator = Parameter.Calculator;
                    flpCalcParams.Controls.Clear();
                    cbCalculator.Items.Clear();

                    // Load the assembly containing the CharacteristicParameter classes
                    Assembly assembly = Assembly.LoadFrom("Nuvo.TestValidation.dll");

                    // Load the assembly containing the CharacteristicParameter classes
                    // Get all the CharacteristicParameter classes
                    calcTypes = assembly.GetTypes()
                        .Where(t => t.IsSubclassOf(Calculator.GetType()))
                        .ToArray();
                    cbCalculator.Items.AddRange(calcTypes);
                    cbCalculator.SelectedItem = Calculator.GetType();

                    flpCalcParams.Controls.Clear();
                    flpCalcParams.Controls.Add(new CalcParamCtrl(Calculator.Params));
                }
            }
        }

        private void updateCalculatorComboBox()
        {
            if (Parameter.Calculator == null)
                return;
            // Load the assembly containing the CharacteristicParameter classes
            Assembly assembly = Assembly.LoadFrom("Nuvo.TestValidation.dll");

            // Get all the CharacteristicParameter classes
            calcTypes = assembly.GetTypes()
                .Where(t => t.IsSubclassOf(Parameter.Calculator.GetType()))
                .ToArray();

            cbCalculator.Items.Clear();
            // Loop through the CharacteristicParameter classes
            foreach (Type type in calcTypes)
            {
                Console.WriteLine($"Parameter Calculator: {type.Name}");
                cbCalculator.Items.Add(type.Name);
                // Get all the methods of the CharacteristicParameter class
                PropertyInfo[] calcParams = type.GetProperties();

                // Loop through the methods
                foreach (PropertyInfo prop in calcParams)
                {
                    Console.WriteLine($"- Property: {prop.Name}");
                }

                Console.WriteLine();
            }
            cbCalculator.SelectedIndex = 0;
            Calculator = Activator.CreateInstance(calcTypes[cbCalculator.SelectedIndex]) as GenericCalculator;
            Parameter = Activator.CreateInstance(parameterTypes[cbSpecTypes.SelectedIndex]) as GenericParameter;
            Parameter.Calculator = Calculator;
            CalcType = Calculator.Params.GetType();
            var CalcParamType = Calculator.Params.GetType();
            foreach (PropertyInfo pInfo in CalcParamType.BaseType.GetProperties())
            {
                //flpCalcParams.Controls.Add(updateCalculatorParameters(pInfo));
                //Console.WriteLine($"- Property: {pInfo.Name}");
            }

            flpCalcParams.Controls.Clear();
            flpCalcParams.Controls.Add(new CalcParamCtrl(Calculator.Params));
            //foreach (PropertyInfo pInfo in CalcParamType.GetProperties())
            //{
            //    flpCalcParams.Controls.Add(updateCalculatorParameters(pInfo));
            //    Console.WriteLine($"- Property: {pInfo.Name}");
            //}
        }

        private FlowLayoutPanel updateCalculatorParameters(PropertyInfo propInfo)
        {
            Label l = new Label();
            l.Margin = new Padding(3, 0, 3, 0);
            TextBox tb = new TextBox();
            tb.Size = new Size(120, 23);
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.FlowDirection = FlowDirection.TopDown;
            flp.AutoSize = true;
            flp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            l.Text = propInfo.Name;
            l.TextAlign = ContentAlignment.MiddleLeft;
            tb.Text = propInfo.GetValue(Calculator.Params).ToString();
            tb.TextAlign = HorizontalAlignment.Center;
            flp.Controls.Add(l);
            flp.Controls.Add(tb);
            flp.Tag = propInfo;
            flp.Name = "Calculator_" + propInfo.Name;
            return flp;
        }

        private void comboBoxSpecTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Parameter = Activator.CreateInstance(parameterTypes[cbSpecTypes.SelectedIndex]) as GenericParameter;
            Calculator = Parameter.Calculator;
            if (Calculator == null)
                return;
            CalcType = Calculator.GetType();
            updateCalculatorComboBox();
            ParameterUpdated.Invoke(this, null);
        }

        private void ShowAdditialParamCtrls(int count)
        {
        }

        private void cbCalculator_SelectedIndexChanged(object sender, EventArgs e)
        {
            flpCalcParams.Controls.Clear();
            Calculator = Activator.CreateInstance(calcTypes[cbCalculator.SelectedIndex]) as GenericCalculator;
            Parameter = Activator.CreateInstance(parameterTypes[cbSpecTypes.SelectedIndex]) as GenericParameter;
            Parameter.Calculator = Calculator;
            CalcType = Calculator.Params.GetType();
            var CalcParamType = Calculator.Params.GetType();
            foreach (PropertyInfo pInfo in CalcParamType.BaseType.GetProperties())
            {
                //flpCalcParams.Controls.Add(updateCalculatorParameters(pInfo));
                //Console.WriteLine($"- Property: {pInfo.Name}");
            }

            flpCalcParams.Controls.Clear();

            flpCalcParams.Controls.Add(new CalcParamCtrl(Calculator.Params));
            //foreach (PropertyInfo pInfo in CalcParamType.GetProperties())
            //{
            //    flpCalcParams.Controls.Add(updateCalculatorParameters(pInfo));
            //    Console.WriteLine($"- Property: {pInfo.Name}");
            //}
        }
    }
}
