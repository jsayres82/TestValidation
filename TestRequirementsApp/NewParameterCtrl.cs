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
            //flpCalcParams.Controls.Clear();
            //if (param != null)
            //{
            //    Dictionary<string, FlowLayoutPanel> flpDic = new Dictionary<string, FlowLayoutPanel>();
            //    lblParamCalcParams.Text = param.Calculator.Params.GetType().Name;
            //    foreach (var p in Parameter.Pa.GetType().GetProperties())
            //    {
            //        cbCalculator.Text = Limit.GetType().Name;
            //        if (p.Name.Equals("Start"))
            //        {
            //            textBoxAdditionalProperty1.Text = p.GetValue(Limit).ToString();
            //        }
            //        else if (p.Name.Equals("End"))
            //        {
            //            textBoxAdditionalProperty2.Text = p.GetValue(Limit).ToString();
            //        }
            //        else if (p.Name.Equals("MinValue"))
            //        {
            //            var flp = CreateLimitPanel(p);
            //            flpDic.Add(flp.Name, flp);
            //            flpLimit.Controls.Add(flpDic.Last().Value);
            //        }
            //        else if (p.Name.Equals("MaxValue"))
            //        {
            //            var flp = CreateLimitPanel(p);
            //            flpDic.Add(flp.Name, flp);
            //            flpLimit.Controls.Add(flpDic.Last().Value);
            //        }
            //        if (p.Name.Equals("StartValue"))
            //        {
            //            var flp = CreateLimitPanel(p);
            //            flpDic.Add(flp.Name, flp);
            //            flpLimit.Controls.Add(flpDic.Last().Value);
            //        }
            //        else if (p.Name.Equals("EndValue"))
            //        {
            //            var flp = CreateLimitPanel(p);
            //            flpDic.Add(flp.Name, flp);
            //            flpLimit.Controls.Add(flpDic.Last().Value);
            //        }
            //        else if (p.Name.Equals("StartValue2"))
            //        {
            //            //if (!Limit.Validator.GetType().ToString().Contains("Bound"))
            //            //{
            //            //    flpLimit.Controls.Remove(flpList.Select(f => (f.Tag as PropertyInfo).Name == "StartValue2") as Control);
            //            //    flpList.Remove(flpList.Where(f=> (f.Tag as PropertyInfo).Name == "StartValue2").First());
            //            //}
            //        }
            //        else if (p.Name.Equals("EndValue2"))
            //        {
            //            //if (!Limit.Validator.GetType().ToString().Contains("Bound"))
            //            //{
            //            //    flpLimit.Controls.Remove(flpList.Select(f => (f.Tag as PropertyInfo).Name == "EndValue2") as Control);// Remove(flpList.Last());
            //            //    flpList.Remove(flpList.Where(f => (f.Tag as PropertyInfo).Name == "EndValue2").First());
            //            //}
            //        }
            //        else if (p.Name.Equals("Validator"))
            //        {
            //            if (!isSlopedLimit)
            //            {
            //                if (!Limit.Validator.GetType().ToString().Contains("Bound"))
            //                {
            //                    List<string> labeLNames = new List<string>();
            //                    //comboBoxValidators.Text = Limit.Validator.GetType().Name;
            //                    foreach (var p2 in Limit.Validator.GetType().GetProperties())
            //                    {
            //                        if (p2.Name.Equals("Validator"))
            //                        {
            //                            //tbAddProp1.Text = p2.GetValue(Limit.Validator).ToString();
            //                        }
            //                        else
            //                        {
            //                            if (p2.Name.Equals("Value"))
            //                            {
            //                                var flp = CreateLimitPanel(p2, Limit.Validator);
            //                                flpDic.Add(flp.Name, flp);
            //                                flpLimit.Controls.Add(flpDic.Last().Value);
            //                            }
            //                            else if (p2.Name.Equals("Prefix"))
            //                            {
            //                            }
            //                            else if (p2.Name.Equals("Unit"))
            //                            {
            //                            }
            //                            else if (p2.Name.Equals("LowerBound"))
            //                            {
            //                                var flp = CreateLimitPanel(p2, Limit.Validator);
            //                                flpDic.Add(flp.Name, flp);
            //                                flpLimit.Controls.Add(flpDic.Last().Value);
            //                            }
            //                            else if (p2.Name.Equals("UpperBound"))
            //                            {
            //                                var flp = CreateLimitPanel(p2, Limit.Validator);
            //                                flpDic.Add(flp.Name, flp);
            //                                flpLimit.Controls.Add(flpDic.Last().Value);
            //                            }
            //                            else if (p2.Name.Equals("Tolerance"))
            //                            {
            //                                var flp = CreateLimitPanel(p2, Limit.Validator);
            //                                flpDic.Add(flp.Name, flp);
            //                                flpLimit.Controls.Add(flpDic.Last().Value);
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //            else if (Limit.Validator != null)
            //            {
            //                if (Limit.Validator.GetType().ToString().Contains("Bound"))
            //                {
            //                    if (Limit is LogSlopedDomainLimit)
            //                    {
            //                        var flp = CreateLimitPanel((Limit as LogSlopedDomainLimit).GetType().GetProperties().Where(f => f.Name == "StartValue2").First());
            //                        flpDic.Add(flp.Name, flp);
            //                        flpLimit.Controls.Add(flpDic.Last().Value);

            //                        flp = CreateLimitPanel((Limit as LogSlopedDomainLimit).GetType().GetProperties().Where(f => f.Name == "EndValue2").First());
            //                        flpDic.Add(flp.Name, flp);
            //                        flpLimit.Controls.Add(flpDic.Last().Value);
            //                    }
            //                    else if (Limit is LinearSlopedDomainLimit)
            //                    {
            //                        var flp = CreateLimitPanel((Limit as LinearSlopedDomainLimit).GetType().GetProperties().Where(f => f.Name == "StartValue2").First());
            //                        flpDic.Add(flp.Name, flp);
            //                        flpLimit.Controls.Add(flpDic.Last().Value);

            //                        flp = CreateLimitPanel((Limit as LinearSlopedDomainLimit).GetType().GetProperties().Where(f => f.Name == "EndValue2").First());
            //                        flpDic.Add(flp.Name, flp);
            //                        flpLimit.Controls.Add(flpDic.Last().Value);
            //                    }

            //                }
            //                else if (Limit.Validator.GetType().ToString().Contains("Toler"))
            //                {
            //                    var flp = CreateLimitPanel(Limit.Validator.GetType().GetProperty("Tolerance"), Limit.Validator);
            //                    flpDic.Add(flp.Name, flp);
            //                    flpLimit.Controls.Add(flpDic.Last().Value);
            //                }
            //                else
            //                {
            //                    if (flpDic.ContainsKey("Limit_StartValue2"))
            //                    {
            //                        flpLimit.Controls.Remove(flpDic["Limit_StartValue2"]);
            //                        flpDic.Remove("Limit_StartValue2");
            //                    }
            //                    if (flpDic.ContainsKey("Limit_EndValue2"))
            //                    {
            //                        flpLimit.Controls.Remove(flpDic["Limit_EndValue2"]);
            //                        flpDic.Remove("Limit_EndValue2");
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
        }

        public GenericParameter GetParameter()
        {
            foreach (var ctrl in flpCalcParams.Controls)
            {
                if(ctrl is CalcParamCtrl)
                {
                    Parameter.Calculator.Params = (ctrl as CalcParamCtrl).GetCalculatorParameter();
                }
            }
            Parameter.Calculator = cbCalculator.SelectedItem as GenericCalculator;
            Parameter = cbSpecTypes.SelectedItem as GenericParameter;
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

                    flpCalcParams.Controls.Add(new CalcParamCtrl(Calculator.Params));
                    //// Load the assembly containing the CharacteristicParameter classes
                    //// Get all the CharacteristicParameter classes
                    //calcTypes = assembly.GetTypes()
                    //    .Where(t => t.IsSubclassOf(Calculator.GetType()))
                    //    .ToArray();
                    //cbCalculator.Items.AddRange(calcTypes);
                    //int idx = 0;
                    //foreach (Type calc in calcTypes)
                    //{
                    //    var name = Calculator.GetType().Name;
                    //    if (calc.Name.Equals(name))
                    //    {
                    //        cbCalculator.SelectedIndex = idx;
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        idx++;
                    //    }
                    //}
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
            CalcType = Calculator.GetType();
            updateCalculatorComboBox();
            //// Load the assembly containing the CharacteristicParameter classes
            //Assembly assembly = Assembly.LoadFrom("Nuvo.TestValidation.dll");

            //// Get all the CharacteristicParameter classes
            //calcTypes = assembly.GetTypes()
            //    .Where(t => t.IsSubclassOf(calc.GetType()))
            //    .ToArray();

            //// Loop through the CharacteristicParameter classes
            //foreach (Type type in calcTypes)
            //{
            //    Console.WriteLine($"Parameter Calculator: {type.Name}");
            //    cbCalculator.Items.Add(type.Name);
            //    // Get all the methods of the CharacteristicParameter class
            //    PropertyInfo[] calcParams = type.GetProperties();

            //    // Loop through the methods
            //    foreach (PropertyInfo prop in calcParams)
            //    {
            //        Console.WriteLine($"- Property: {prop.Name}");
            //    }

            //    Console.WriteLine();
            //}
            //cbCalculator.SelectedIndex = 0;
            //PropertyInfo[] properties = calc.GetType().GetProperties();
            //var calcProp = calc.GetType().GetProperties();
            //var count = calcProp.Length;
            //for (int i = 0; i < count; i++)
            //{
            //}
            //var selCalc = Activator.CreateInstance(calcTypes[cbCalculator.SelectedIndex]);
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


            flpCalcParams.Controls.Add(new CalcParamCtrl(Calculator.Params));
            //foreach (PropertyInfo pInfo in CalcParamType.GetProperties())
            //{
            //    flpCalcParams.Controls.Add(updateCalculatorParameters(pInfo));
            //    Console.WriteLine($"- Property: {pInfo.Name}");
            //}
        }
    }
}
