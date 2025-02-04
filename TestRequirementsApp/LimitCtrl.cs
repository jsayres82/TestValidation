using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Limits.Units;
using Nuvo.TestValidation.Limits.Validators;
using Nuvo.TestValidation.Parameters;
using static Nuvo.TestValidation.Limits.Units.UnitConverter;

namespace Nuvo.Requirements_Builder
{
    public partial class LimitCtrl : UserControl
    {
        private static string LimitStr = "Limit";
        private static string ValidatorStr = "Validator";
        public Type[] limitTypes;
        public Type[] validatorTypes;
        public GenericLimit Limit;
        public Type LimitType, ValidatorType;
        private bool isSlopedLimit = false;

        public LimitCtrl()
        {
            InitializeComponent();
            comboBoxValidators.SelectedIndexChanged -= comboBoxValidators_SelectedIndexChanged;
            comboBoxLimitTypes.SelectedIndexChanged -= comboBoxLimitTypes_SelectedIndexChanged;
            // Load the assembly containing the CharacteristicParameter classes
            Assembly assembly = Assembly.LoadFrom("Nuvo.TestValidation.dll");

            // Get all the Limit classes
            limitTypes = assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(GenericLimit)))
                .ToArray();

            // Get all the Validator classes
            validatorTypes = assembly.GetTypes()
                .Where(IsIndexType)
                .ToArray();
            LimitType = limitTypes[0];
            ValidatorType = validatorTypes[0];
            // Loop through the CharacteristicParameter classes
            foreach (Type validator in validatorTypes)
            {
                comboBoxValidators.Items.Add(validator.Name);
            }
            // Loop through the CharacteristicParameter classes
            foreach (Type limitType in limitTypes)
            {
                comboBoxLimitTypes.Items.Add(limitType.Name);
            }
            comboBoxValidUnitsPrefix.Items.AddRange(Enum.GetNames(typeof(PrefixEnum)));
            //comboBoxLimitPrefix.Items.AddRange(Enum.GetNames(typeof(Prefix)));
            comboBoxLimitPrefix.Text = "None";
            comboBoxLimitPrefix.Items.Add("None");
            comboBoxValidatorUnits.Items.AddRange(Enum.GetNames(typeof(UnitEnum)));
            comboBoxLimitUnits.Text = "Hertz";
            comboBoxLimitUnits.Items.Add("Hertz");
            //comboBoxLimitUnits.Items.AddRange(Enum.GetNames(typeof(Unit)));

            comboBoxValidators.SelectedIndexChanged += comboBoxValidators_SelectedIndexChanged;
            comboBoxLimitTypes.SelectedIndexChanged += comboBoxLimitTypes_SelectedIndexChanged;

            comboBoxLimitTypes.SelectedIndex = 1;
            comboBoxValidators.SelectedIndex = 0;
            UpdateLimit(Limit);
            comboBoxLimitTypes.SelectedIndex = 0;
        }

        public LimitCtrl(List<object> validLimits, List<object> validValidators, List<string> validLimitUnits, List<string> validLimitValidatorUnits)
        {
            InitializeComponent();
            if(validLimits != null)
            {
                comboBoxValidators.SelectedIndexChanged -= comboBoxValidators_SelectedIndexChanged;
                comboBoxLimitTypes.SelectedIndexChanged -= comboBoxLimitTypes_SelectedIndexChanged;
                comboBoxLimitTypes.Items.Clear();
                limitTypes = new Type[validLimits.Count];
                // Loop through the CharacteristicParameter classes
                for (int i = 0; i < validLimits.Count; i++)// limitType in validLimits)
                {
                    var o = Activator.CreateInstance((Type)validLimits[i]) as GenericLimit;//
                    limitTypes[i] = o.GetType();
                    comboBoxLimitTypes.Items.Add(limitTypes[i].Name);
                }

                LimitType = limitTypes[0];
                Type[] typeArgs = { typeof(double) };
                comboBoxValidators.Items.Clear();
                validatorTypes = new Type[validValidators.Count];

                // Loop through the CharacteristicParameter classes
                for (int i = 0; i < validValidators.Count; i++)// limitType in validLimits)
                {
                    var makeme = (Type)validValidators[i];
                    var makeme2 = makeme.MakeGenericType(typeArgs);
                    var o = Activator.CreateInstance(makeme2);
                    validatorTypes[i] = o.GetType();
                    comboBoxValidators.Items.Add(validatorTypes[i].Name);
                }
                ValidatorType = validatorTypes[0];
                comboBoxLimitTypes.SelectedIndex = 0;
                comboBoxValidators.SelectedIndex = 0;
                comboBoxValidatorUnits.Items.Clear();
                comboBoxValidUnitsPrefix.Items.AddRange(Enum.GetNames(typeof(PrefixEnum)));
                comboBoxValidatorUnits.Items.AddRange(validLimitValidatorUnits.ToArray());
                comboBoxValidUnitsPrefix.SelectedIndex = comboBoxValidUnitsPrefix.Items.IndexOf(PrefixEnum.Giga.ToString());
                comboBoxValidatorUnits.SelectedIndex = 0;

                comboBoxLimitUnits.Items.Clear();
                comboBoxLimitPrefix.Items.AddRange(Enum.GetNames(typeof(PrefixEnum)));
                comboBoxLimitUnits.Items.AddRange(validLimitUnits.ToArray());
                comboBoxLimitPrefix.SelectedIndex = comboBoxValidUnitsPrefix.Items.IndexOf(PrefixEnum.None.ToString());
                comboBoxLimitUnits.SelectedIndex = 0;
                //comboBoxLimitUnits.Items.AddRange(Enum.GetNames(typeof(Unit)));
                comboBoxValidators.SelectedIndexChanged += comboBoxValidators_SelectedIndexChanged;
                comboBoxLimitTypes.SelectedIndexChanged += comboBoxLimitTypes_SelectedIndexChanged;
                
            }
            else
            {
            comboBoxValidators.SelectedIndexChanged -= comboBoxValidators_SelectedIndexChanged;
            comboBoxLimitTypes.SelectedIndexChanged -= comboBoxLimitTypes_SelectedIndexChanged;
            comboBoxLimitTypes.Items.Clear();
                Assembly assembly = Assembly.LoadFrom("Nuvo.TestValidation.dll");

                // Get all the Limit classes
                limitTypes = assembly.GetTypes()
                    .Where(t => t.IsSubclassOf(typeof(GenericLimit)))
                    .ToArray();

                // Get all the Validator classes
                validatorTypes = assembly.GetTypes()
                    .Where(IsIndexType)
                    .ToArray();
                LimitType = limitTypes[0];
                ValidatorType = validatorTypes[0];
                // Loop through the CharacteristicParameter classes
                foreach (Type validator in validatorTypes)
                {
                    comboBoxValidators.Items.Add(validator.Name);
                }
                // Loop through the CharacteristicParameter classes
                foreach (Type limitType in limitTypes)
                {
                    comboBoxLimitTypes.Items.Add(limitType.Name);
                }
                comboBoxValidUnitsPrefix.Items.AddRange(Enum.GetNames(typeof(PrefixEnum)));
                //comboBoxLimitPrefix.Items.AddRange(Enum.GetNames(typeof(Prefix)));
                comboBoxLimitPrefix.Text = "None";
                comboBoxLimitPrefix.Items.Add("None");
                comboBoxValidatorUnits.Items.AddRange(Enum.GetNames(typeof(UnitEnum)));
                comboBoxLimitUnits.Text = "Hertz";
                comboBoxLimitUnits.Items.Add("Hertz");
                //comboBoxLimitUnits.Items.AddRange(Enum.GetNames(typeof(Unit)));
                comboBoxValidators.SelectedIndexChanged += comboBoxValidators_SelectedIndexChanged;
                comboBoxLimitTypes.SelectedIndexChanged += comboBoxLimitTypes_SelectedIndexChanged;
                comboBoxLimitTypes.SelectedIndex = 0;
                comboBoxValidators.SelectedIndex = 0;
            }
            UpdateLimit(Limit);
        }

        private bool IsIndexType(Type type)
        {
            var indexDefinition = typeof(GenericValidator<>).GetGenericTypeDefinition();
            return !type.IsAbstract
                   && type.IsClass
                   && type.BaseType is not null
                   && type.BaseType.IsGenericType
                   && type.BaseType.GetGenericTypeDefinition() == indexDefinition;
        }

        public GenericLimit GetLimit()
        {
            var x = Limit.GetType().GetProperties();
            foreach (var ctrl in flpLimit.Controls)
            {
                if (ctrl is FlowLayoutPanel)
                {
                    FlowLayoutPanel panel = (ctrl as FlowLayoutPanel);
                    if (panel.Name.Contains("Limit_"))
                    {
                        var prop = Limit.GetType().GetProperty((panel.Tag as PropertyInfo).Name);
                        if (prop.PropertyType == typeof(double))
                            prop.SetValue(Limit, System.Convert.ToDouble((panel.Controls[1] as TextBox).Text));
                        else
                            prop.SetValue(Limit, (panel.Controls[1] as TextBox).Text);
                    }
                    else if (panel.Name.Contains("Validator_"))
                    {
                        var prop = Limit.Validator.GetType().GetProperty((panel.Tag as PropertyInfo).Name);
                        if (prop.PropertyType == typeof(double))
                            prop.SetValue(Limit.Validator, System.Convert.ToDouble((panel.Controls[1] as TextBox).Text));
                        else
                            prop.SetValue(Limit.Validator, (panel.Controls[1] as TextBox).Text);
                    }
                    Limit.Validator.Prefix = Enum.Parse<PrefixEnum>(comboBoxValidUnitsPrefix.Text);
                    Limit.Validator.Unit = Enum.Parse<UnitEnum>(comboBoxValidatorUnits.Text);

                    Limit.Start = System.Convert.ToDouble(textBoxAdditionalProperty1.Text);
                    Limit.End = System.Convert.ToDouble(textBoxAdditionalProperty1.Text);
                }
            }
            return Limit;
        }

        private void UpdateLimitInteral(GenericLimit limit)
        {
            flpLimit.Controls.Clear();
            if (limit != null)
            {
                Dictionary<string, FlowLayoutPanel> flpDic = new Dictionary<string, FlowLayoutPanel>();
                Limit = limit;
                isSlopedLimit = limit.IsSLopedLimit;

                foreach (var p in Limit.GetType().GetProperties())
                {
                    if (!p.Name.Equals("Validator"))
                    {
                    }

                    comboBoxLimitTypes.Text = Limit.GetType().Name;
                    if (p.Name.Equals("Start"))
                    {
                        textBoxAdditionalProperty1.Text = p.GetValue(Limit).ToString();
                    }
                    else if (p.Name.Equals("End"))
                    {
                        textBoxAdditionalProperty2.Text = p.GetValue(Limit).ToString();
                    }
                    else if (p.Name.Equals("MinValue"))
                    {
                        var flp = CreateLimitPanel(p);
                        flpDic.Add(flp.Name, flp);
                        flpLimit.Controls.Add(flpDic.Last().Value);
                    }
                    else if (p.Name.Equals("MaxValue"))
                    {
                        var flp = CreateLimitPanel(p);
                        flpDic.Add(flp.Name, flp);
                        flpLimit.Controls.Add(flpDic.Last().Value);
                    }
                    if (p.Name.Equals("StartValue"))
                    {
                        var flp = CreateLimitPanel(p);
                        flpDic.Add(flp.Name, flp);
                        flpLimit.Controls.Add(flpDic.Last().Value);
                    }
                    else if (p.Name.Equals("EndValue"))
                    {
                        var flp = CreateLimitPanel(p);
                        flpDic.Add(flp.Name, flp);
                        flpLimit.Controls.Add(flpDic.Last().Value);
                    }
                    else if (p.Name.Equals("StartValue2"))
                    {
                        //if (!Limit.Validator.GetType().ToString().Contains("Bound"))
                        //{
                        //    flpLimit.Controls.Remove(flpList.Select(f => (f.Tag as PropertyInfo).Name == "StartValue2") as Control);
                        //    flpList.Remove(flpList.Where(f=> (f.Tag as PropertyInfo).Name == "StartValue2").First());
                        //}
                    }
                    else if (p.Name.Equals("EndValue2"))
                    {
                        //if (!Limit.Validator.GetType().ToString().Contains("Bound"))
                        //{
                        //    flpLimit.Controls.Remove(flpList.Select(f => (f.Tag as PropertyInfo).Name == "EndValue2") as Control);// Remove(flpList.Last());
                        //    flpList.Remove(flpList.Where(f => (f.Tag as PropertyInfo).Name == "EndValue2").First());
                        //}
                    }
                    else if (p.Name.Equals("Validator"))
                    {
                        if (!isSlopedLimit)
                        {
                            if (!Limit.Validator.GetType().ToString().Contains("Bound"))
                            {
                                List<string> labeLNames = new List<string>();
                                //comboBoxValidators.Text = Limit.Validator.GetType().Name;
                                foreach (var p2 in Limit.Validator.GetType().GetProperties())
                                {
                                    if (p2.Name.Equals("Validator"))
                                    {
                                        //tbAddProp1.Text = p2.GetValue(Limit.Validator).ToString();
                                    }
                                    else
                                    {
                                        if (p2.Name.Equals("Value"))
                                        {
                                            var flp = CreateLimitPanel(p2, Limit.Validator);
                                            flpDic.Add(flp.Name, flp);
                                            flpLimit.Controls.Add(flpDic.Last().Value);
                                        }
                                        else if (p2.Name.Equals("Prefix"))
                                        {
                                        }
                                        else if (p2.Name.Equals("Unit"))
                                        {
                                        }
                                        else if (p2.Name.Equals("LowerBound"))
                                        {
                                            var flp = CreateLimitPanel(p2, Limit.Validator);
                                            flpDic.Add(flp.Name, flp);
                                            flpLimit.Controls.Add(flpDic.Last().Value);
                                        }
                                        else if (p2.Name.Equals("UpperBound"))
                                        {
                                            var flp = CreateLimitPanel(p2, Limit.Validator);
                                            flpDic.Add(flp.Name, flp);
                                            flpLimit.Controls.Add(flpDic.Last().Value);
                                        }
                                        else if (p2.Name.Equals("Tolerance"))
                                        {
                                            var flp = CreateLimitPanel(p2, Limit.Validator);
                                            flpDic.Add(flp.Name, flp);
                                            flpLimit.Controls.Add(flpDic.Last().Value);
                                        }
                                    }
                                }
                            }
                        }
                        else if (Limit.Validator != null)
                        {
                            if (Limit.Validator.GetType().ToString().Contains("Bound"))
                            {
                                if (Limit is LogSlopedDomainLimit)
                                {
                                    var flp = CreateLimitPanel((Limit as LogSlopedDomainLimit).GetType().GetProperties().Where(f => f.Name == "StartValue2").First());
                                    flpDic.Add(flp.Name, flp);
                                    flpLimit.Controls.Add(flpDic.Last().Value);

                                    flp = CreateLimitPanel((Limit as LogSlopedDomainLimit).GetType().GetProperties().Where(f => f.Name == "EndValue2").First());
                                    flpDic.Add(flp.Name, flp);
                                    flpLimit.Controls.Add(flpDic.Last().Value);
                                }
                                else if (Limit is LinearSlopedDomainLimit)
                                {
                                    var flp = CreateLimitPanel((Limit as LinearSlopedDomainLimit).GetType().GetProperties().Where(f => f.Name == "StartValue2").First());
                                    flpDic.Add(flp.Name, flp);
                                    flpLimit.Controls.Add(flpDic.Last().Value);

                                    flp = CreateLimitPanel((Limit as LinearSlopedDomainLimit).GetType().GetProperties().Where(f => f.Name == "EndValue2").First());
                                    flpDic.Add(flp.Name, flp);
                                    flpLimit.Controls.Add(flpDic.Last().Value);
                                }

                            }
                            else if (Limit.Validator.GetType().ToString().Contains("Toler"))
                            {
                                var flp = CreateLimitPanel(Limit.Validator.GetType().GetProperty("Tolerance"), Limit.Validator);
                                flpDic.Add(flp.Name, flp);
                                flpLimit.Controls.Add(flpDic.Last().Value);
                            }
                            else
                            {
                                if (flpDic.ContainsKey("Limit_StartValue2"))
                                {
                                    flpLimit.Controls.Remove(flpDic["Limit_StartValue2"]);
                                    flpDic.Remove("Limit_StartValue2");
                                }
                                if (flpDic.ContainsKey("Limit_EndValue2"))
                                {
                                    flpLimit.Controls.Remove(flpDic["Limit_EndValue2"]);
                                    flpDic.Remove("Limit_EndValue2");
                                }
                            }
                        }
                    }
                }
            }
        }

        public void UpdateLimit(GenericLimit limit)
        {
            flpLimit.Controls.Clear();
            if (limit != null)
            {
                Dictionary<string, FlowLayoutPanel> flpDic = new Dictionary<string, FlowLayoutPanel>();

                comboBoxValidators.SelectedIndexChanged -= comboBoxValidators_SelectedIndexChanged;
                comboBoxLimitTypes.SelectedIndexChanged -= comboBoxLimitTypes_SelectedIndexChanged;
                Limit = limit;
                isSlopedLimit = limit.IsSLopedLimit;
                comboBoxValidators.Text = Limit.Validator.GetType().Name;
                comboBoxValidUnitsPrefix.SelectedText = Limit.Validator.Prefix.ToString();
                comboBoxValidatorUnits.SelectedText = Limit.Validator.Unit.ToString();

                foreach (var p in Limit.GetType().GetProperties())
                {
                    if (!p.Name.Equals("Validator"))
                    {
                    }

                    comboBoxLimitTypes.Text = Limit.GetType().Name;
                    if (p.Name.Equals("Start"))
                    {
                        textBoxAdditionalProperty1.Text = p.GetValue(Limit).ToString();
                    }
                    else if (p.Name.Equals("End"))
                    {
                        textBoxAdditionalProperty2.Text = p.GetValue(Limit).ToString();
                    }
                    else if (p.Name.Equals("MinValue"))
                    {
                        var flp = CreateLimitPanel(p);
                        flpDic.Add(flp.Name, flp);
                        flpLimit.Controls.Add(flpDic.Last().Value);
                    }
                    else if (p.Name.Equals("MaxValue"))
                    {
                        var flp = CreateLimitPanel(p);
                        flpDic.Add(flp.Name, flp);
                        flpLimit.Controls.Add(flpDic.Last().Value);
                    }
                    if (p.Name.Equals("StartValue"))
                    {
                        var flp = CreateLimitPanel(p);
                        flpDic.Add(flp.Name, flp);
                        flpLimit.Controls.Add(flpDic.Last().Value);
                    }
                    else if (p.Name.Equals("EndValue"))
                    {
                        var flp = CreateLimitPanel(p);
                        flpDic.Add(flp.Name, flp);
                        flpLimit.Controls.Add(flpDic.Last().Value);
                    }
                    else if (p.Name.Equals("StartValue2"))
                    {
                        //if (!Limit.Validator.GetType().ToString().Contains("Bound"))
                        //{
                        //    flpLimit.Controls.Remove(flpList.Select(f => (f.Tag as PropertyInfo).Name == "StartValue2") as Control);
                        //    flpList.Remove(flpList.Where(f=> (f.Tag as PropertyInfo).Name == "StartValue2").First());
                        //}
                    }
                    else if (p.Name.Equals("EndValue2"))
                    {
                        //if (!Limit.Validator.GetType().ToString().Contains("Bound"))
                        //{
                        //    flpLimit.Controls.Remove(flpList.Select(f => (f.Tag as PropertyInfo).Name == "EndValue2") as Control);// Remove(flpList.Last());
                        //    flpList.Remove(flpList.Where(f => (f.Tag as PropertyInfo).Name == "EndValue2").First());
                        //}
                    }
                    else if (p.Name.Equals("Validator"))
                    {
                        if (!isSlopedLimit)
                        {
                            if (!Limit.Validator.GetType().ToString().Contains("Bound"))
                            {
                                List<string> labeLNames = new List<string>();
                                //comboBoxValidators.Text = Limit.Validator.GetType().Name;
                                foreach (var p2 in Limit.Validator.GetType().GetProperties())
                                {
                                    if (p2.Name.Equals("Validator"))
                                    {
                                        //tbAddProp1.Text = p2.GetValue(Limit.Validator).ToString();
                                    }
                                    else
                                    {
                                        if (p2.Name.Equals("Value"))
                                        {
                                            var flp = CreateLimitPanel(p2, Limit.Validator);
                                            flpDic.Add(flp.Name, flp);
                                            flpLimit.Controls.Add(flpDic.Last().Value);
                                        }
                                        else if (p2.Name.Equals("Prefix"))
                                        {
                                        }
                                        else if (p2.Name.Equals("Unit"))
                                        {
                                        }
                                        else if (p2.Name.Equals("LowerBound"))
                                        {
                                            var flp = CreateLimitPanel(p2, Limit.Validator);
                                            flpDic.Add(flp.Name, flp);
                                            flpLimit.Controls.Add(flpDic.Last().Value);
                                        }
                                        else if (p2.Name.Equals("UpperBound"))
                                        {
                                            var flp = CreateLimitPanel(p2, Limit.Validator);
                                            flpDic.Add(flp.Name, flp);
                                            flpLimit.Controls.Add(flpDic.Last().Value);
                                        }
                                        else if (p2.Name.Equals("Tolerance"))
                                        {
                                            var flp = CreateLimitPanel(p2, Limit.Validator);
                                            flpDic.Add(flp.Name, flp);
                                            flpLimit.Controls.Add(flpDic.Last().Value);
                                        }
                                    }
                                }
                            }
                        }
                        else if (Limit.Validator != null)
                        {
                            if (Limit.Validator.GetType().ToString().Contains("Bound"))
                            {
                                if (Limit is LogSlopedDomainLimit)
                                {
                                    var flp = CreateLimitPanel((Limit as LogSlopedDomainLimit).GetType().GetProperties().Where(f => f.Name == "StartValue2").First());
                                    flpDic.Add(flp.Name, flp);
                                    flpLimit.Controls.Add(flpDic.Last().Value);

                                    flp = CreateLimitPanel((Limit as LogSlopedDomainLimit).GetType().GetProperties().Where(f => f.Name == "EndValue2").First());
                                    flpDic.Add(flp.Name, flp);
                                    flpLimit.Controls.Add(flpDic.Last().Value);
                                }
                                else if (Limit is LinearSlopedDomainLimit)
                                {
                                    var flp = CreateLimitPanel((Limit as LinearSlopedDomainLimit).GetType().GetProperties().Where(f => f.Name == "StartValue2").First());
                                    flpDic.Add(flp.Name, flp);
                                    flpLimit.Controls.Add(flpDic.Last().Value);

                                    flp = CreateLimitPanel((Limit as LinearSlopedDomainLimit).GetType().GetProperties().Where(f => f.Name == "EndValue2").First());
                                    flpDic.Add(flp.Name, flp);
                                    flpLimit.Controls.Add(flpDic.Last().Value);
                                }

                            }
                            else if (Limit.Validator.GetType().ToString().Contains("Toler"))
                            {
                                var flp = CreateLimitPanel(Limit.Validator.GetType().GetProperty("Tolerance"), Limit.Validator);
                                flpDic.Add(flp.Name, flp);
                                flpLimit.Controls.Add(flpDic.Last().Value);
                            }
                            else
                            {
                                if (flpDic.ContainsKey("Limit_StartValue2"))
                                {
                                    flpLimit.Controls.Remove(flpDic["Limit_StartValue2"]);
                                    flpDic.Remove("Limit_StartValue2");
                                }
                                if (flpDic.ContainsKey("Limit_EndValue2"))
                                {
                                    flpLimit.Controls.Remove(flpDic["Limit_EndValue2"]);
                                    flpDic.Remove("Limit_EndValue2");
                                }
                            }
                        }
                    }

                    comboBoxValidators.SelectedIndexChanged += comboBoxValidators_SelectedIndexChanged;
                    comboBoxLimitTypes.SelectedIndexChanged += comboBoxLimitTypes_SelectedIndexChanged;
                }
            }
        }

        private void comboBoxLimitTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            flpLimit.Controls.Clear();
            comboBoxValidators.SelectedIndexChanged -= comboBoxValidators_SelectedIndexChanged;
            comboBoxLimitTypes.SelectedIndexChanged -= comboBoxLimitTypes_SelectedIndexChanged;
            bindingSource1.ResetBindings(false);
            var o = Activator.CreateInstance(limitTypes[comboBoxLimitTypes.SelectedIndex]);
            isSlopedLimit = (o as GenericLimit).IsSLopedLimit;
            PropertyInfo[] properties = o.GetType().GetProperties();

            (o as GenericLimit).Validator = new LessThanValidator<double>()
            {
                Prefix = PrefixEnum.None,
                Unit = UnitEnum.None,
                Value = 0
            };
            Limit = o as GenericLimit;
            UpdateLimitInteral(Limit);
            comboBoxValidators.SelectedIndexChanged += comboBoxValidators_SelectedIndexChanged;
            comboBoxLimitTypes.SelectedIndexChanged += comboBoxLimitTypes_SelectedIndexChanged;
        }

        private void comboBoxValidators_SelectedIndexChanged(object sender, EventArgs e)
        {
            flpLimit.Controls.Clear();
            bindingSource1.ResetBindings(false);
            Type[] typeArgs = { typeof(double) };
            var makeme = validatorTypes[comboBoxValidators.SelectedIndex].MakeGenericType(typeArgs);
            var o = Activator.CreateInstance(makeme);

            PropertyInfo[] properties = o.GetType().GetProperties();

            Limit.Validator = o as GenericValidator<double>;
            List<string> labeLNames = new List<string>();
            foreach (var p in properties)
            {
                if (p.Name.Equals("Value"))
                {
                    p.SetValue(Limit.Validator, 0);
                }
                else if (p.Name.Equals("Prefix"))
                {
                    p.SetValue(Limit.Validator, PrefixEnum.None);
                }
                else if (p.Name.Equals("Unit"))
                {
                    p.SetValue(Limit.Validator, UnitEnum.dBmW);
                }
                else if (p.Name.Equals("LowerBound"))
                {
                    labeLNames.Add(p.Name);
                    p.SetValue(Limit.Validator, UnitEnum.dBmW);
                }
                else if (p.Name.Equals("UpperBound"))
                {
                    labeLNames.Add(p.Name);
                    p.SetValue(Limit.Validator, UnitEnum.dBmW);
                }
                else if (p.Name.Equals("Tolerance"))
                {
                    labeLNames.Add(p.Name);
                    p.SetValue(Limit.Validator, UnitEnum.dBmW);
                }
            }

            comboBoxValidators.SelectedIndexChanged -= comboBoxValidators_SelectedIndexChanged;
            comboBoxLimitTypes.SelectedIndexChanged -= comboBoxLimitTypes_SelectedIndexChanged;
            UpdateLimitInteral(Limit);
            comboBoxValidators.SelectedIndexChanged += comboBoxValidators_SelectedIndexChanged;
            comboBoxLimitTypes.SelectedIndexChanged += comboBoxLimitTypes_SelectedIndexChanged;
        }

        private FlowLayoutPanel CreateLimitPanel(PropertyInfo propInfo)
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
            tb.Text = propInfo.GetValue(Limit).ToString();
            tb.TextAlign = HorizontalAlignment.Center;
            flp.Controls.Add(l);
            flp.Controls.Add(tb);
            flp.Tag = propInfo;
            flp.Name = "Limit_" + propInfo.Name;
            return flp;
        }

        private FlowLayoutPanel CreateLimitPanel(PropertyInfo propInfo, object v)
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
            tb.Text = propInfo.GetValue(Limit.Validator).ToString();
            tb.TextAlign = HorizontalAlignment.Center;
            flp.Controls.Add(l);
            flp.Controls.Add(tb);
            flp.Tag = propInfo;
            flp.Name = "Validator_" + propInfo.Name;
            return flp;
        }
    }
}
