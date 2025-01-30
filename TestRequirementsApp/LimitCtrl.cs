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
            //LimitType = Limit.GetType();
            //ValidatorType = Limit.Validator.GetType();
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
            //comboBoxLimitTypes.SelectedIndexChanged += comboBoxLimitTypes_SelectedIndexChanged;
            UpdateLimit(Limit);
        }

        public LimitCtrl(List<object> validLimits, List<object> validValidators, List<string> validLimitUnits, List<string> validLimitValidatorUnits)
        {
            InitializeComponent();
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
            //comboBoxLimitTypes.SelectedIndexChanged += comboBoxLimitTypes_SelectedIndexChanged;
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
            //foreach (var p in Limit.GetType().GetProperties())
            //{
            //    if (p.Name.Equals("Start"))
            //    {
            //        p.SetValue(Limit, System.Convert.ToDouble(textBoxAdditionalProperty1.Text));//val);
            //    }
            //    else if (p.Name.Equals("End"))
            //    {
            //        p.SetValue(Limit, System.Convert.ToDouble(textBoxAdditionalProperty2.Text));//val);
            //    }
            //    else if (p.Name.Equals("MinValue"))
            //    {
            //        p.SetValue(Limit, System.Convert.ToDouble(textBoxAdditionalProperty1.Text));
            //    }
            //    else if (p.Name.Equals("MaxValue"))
            //    {
            //        p.SetValue(Limit, System.Convert.ToDouble(textBoxAdditionalProperty2.Text));
            //    }
            //    else if (p.Name.Equals("Validator"))
            //    {
            //        foreach (var p2 in Limit.Validator.GetType().GetProperties())
            //        {
            //            if (p2.Name.Equals("Value"))
            //            {
            //                p2.SetValue(Limit.Validator, System.Convert.ToDouble(tbAddProp1.Text));
            //            }
            //            else if (p2.Name.Equals("Prefix"))
            //            {
            //                p2.SetValue(Limit.Validator, Enum.Parse<PrefixEnum>(comboBoxValidUnitsPrefix.Text));
            //            }
            //            else if (p2.Name.Equals("Unit"))
            //            {
            //                p2.SetValue(Limit.Validator, Enum.Parse<UnitEnum>(comboBoxValidatorUnits.Text));
            //            }
            //            else if (p2.Name.Equals("LowerBound"))
            //            {
            //                p2.SetValue(Limit.Validator, System.Convert.ToDouble(tbAddProp1.Text));
            //            }
            //            else if (p2.Name.Equals("UpperBound"))
            //            {
            //                p2.SetValue(Limit.Validator, System.Convert.ToDouble(tbAddProp2.Text));
            //            }
            //            else if (p2.Name.Equals("Tolerance"))
            //            {
            //                p2.SetValue(Limit.Validator, System.Convert.ToDouble(tbAddProp1.Text));
            //            }
            //        }
            //    }
            //}
            return Limit;
        }

        private void UpdateLimitInteral(GenericLimit limit)
        {
            flpLimit.Controls.Clear();
            if (limit != null)
            {
                List<FlowLayoutPanel> flpList = new List<FlowLayoutPanel>();

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
                    }
                    else if (p.Name.Equals("End"))
                    {
                    }
                    else if (p.Name.Equals("MinValue"))
                    {
                        flpList.Add(CreateLimitPanel(p));
                        flpLimit.Controls.Add(flpList.Last());
                    }
                    else if (p.Name.Equals("MaxValue"))
                    {
                        flpList.Add(CreateLimitPanel(p));
                        flpLimit.Controls.Add(flpList.Last());
                    }
                    if (p.Name.Equals("StartValue"))
                    {
                        flpList.Add(CreateLimitPanel(p));
                        flpLimit.Controls.Add(flpList.Last());
                    }
                    else if (p.Name.Equals("EndValue"))
                    {
                        flpList.Add(CreateLimitPanel(p));
                        flpLimit.Controls.Add(flpList.Last());
                    }
                    if (p.Name.Equals("StartValue2"))
                    {
                    }
                    else if (p.Name.Equals("EndValue2"))
                    {
                    }
                    else if (p.Name.Equals("Validator"))
                    {
                        if (!isSlopedLimit)
                        {
                            flpList.Clear();
                            flpLimit.Controls.Clear();
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
                                        flpList.Add(CreateLimitPanel(p2, Limit.Validator));
                                        flpLimit.Controls.Add(flpList.Last());
                                    }
                                    else if (p2.Name.Equals("Prefix"))
                                    {
                                    }
                                    else if (p2.Name.Equals("Unit"))
                                    {
                                    }
                                    else if (p2.Name.Equals("LowerBound"))
                                    {
                                        flpList.Add(CreateLimitPanel(p2, Limit.Validator));
                                        flpLimit.Controls.Add(flpList.Last());
                                    }
                                    else if (p2.Name.Equals("UpperBound"))
                                    {
                                        flpList.Add(CreateLimitPanel(p2, Limit.Validator));
                                        flpLimit.Controls.Add(flpList.Last());
                                    }
                                    else if (p2.Name.Equals("Tolerance"))
                                    {
                                        flpList.Add(CreateLimitPanel(p2, Limit.Validator));
                                        flpLimit.Controls.Add(flpList.Last());
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
                                    var found = flpList.Where(f => (f.Tag as PropertyInfo).Name == "StartValue2");
                                    if (!found.Any(f => (f.Tag as PropertyInfo).Name == "StartValue2"))
                                    {
                                        flpList.Add(CreateLimitPanel((Limit as LogSlopedDomainLimit).GetType().GetProperties().Where(f => f.Name == "StartValue2").First()));
                                        flpLimit.Controls.Add(flpList.Last());
                                    }

                                    found = flpList.Where(f => (f.Tag as PropertyInfo).Name == "EndValue2");
                                    if (!found.Any(f => (f.Tag as PropertyInfo).Name == "EndValue2"))
                                    {
                                        flpList.Add(CreateLimitPanel((Limit as LogSlopedDomainLimit).GetType().GetProperties().Where(f => f.Name == "EndValue2").First()));
                                        flpLimit.Controls.Add(flpList.Last());
                                    }
                                }
                                else if (Limit is LinearSlopedDomainLimit)
                                {
                                    var found = flpList.Where(f => (f.Tag as PropertyInfo).Name == "StartValue2");
                                    if (!found.Any(f => (f.Tag as PropertyInfo).Name == "StartValue2"))
                                    {
                                        flpList.Add(CreateLimitPanel((Limit as LinearSlopedDomainLimit).GetType().GetProperties().Where(f => f.Name == "StartValue2").First()));
                                        flpLimit.Controls.Add(flpList.Last());
                                    }

                                    found = flpList.Where(f => (f.Tag as PropertyInfo).Name == "EndValue2");
                                    if (!found.Any(f=> (f.Tag as PropertyInfo).Name == "EndValue2"))
                                    {
                                        flpList.Add(CreateLimitPanel((Limit as LinearSlopedDomainLimit).GetType().GetProperties().Where(f => f.Name == "EndValue2").First()));
                                        flpLimit.Controls.Add(flpList.Last());
                                    }
                                }

                            }
                            else if (Limit.Validator.GetType().ToString().Contains("Toler"))
                            {
                                flpList.Add(CreateLimitPanel(Limit.Validator.GetType().GetProperty("Tolerance"), Limit.Validator));
                                flpLimit.Controls.Add(flpList.Last());
                            }
                            else
                            {
                                var found = flpList.Where(f => (f.Tag as PropertyInfo).Name == "StartValue2");
                                if (found.Count() > 0)
                                {
                                    flpLimit.Controls.Remove(flpList.Select(f => (f.Tag as PropertyInfo).Name == "StartValue2") as Control);
                                    flpList.Remove(flpList.Where(f => (f.Tag as PropertyInfo).Name == "StartValue2").First());
                                }
                                found = flpList.Where(f => (f.Tag as PropertyInfo).Name == "EndValue2");
                                if (found.Count() > 0)
                                {
                                    flpLimit.Controls.Remove(flpList.Select(f => (f.Tag as PropertyInfo).Name == "EndValue2") as Control);// Remove(flpList.Last());
                                    flpList.Remove(flpList.Where(f => (f.Tag as PropertyInfo).Name == "EndValue2").First());
                                }
                            }
                        }
                    }
                    BindData();

                    //comboBoxValidators.SelectedIndexChanged += comboBoxValidators_SelectedIndexChanged;
                    //comboBoxLimitTypes.SelectedIndexChanged += comboBoxLimitTypes_SelectedIndexChanged;
                }
            }
        }

        public void UpdateLimit(GenericLimit limit)
        {
            flpLimit.Controls.Clear();
            if (limit != null)
            {
                List<FlowLayoutPanel> flpList = new List<FlowLayoutPanel>();

                comboBoxValidators.SelectedIndexChanged -= comboBoxValidators_SelectedIndexChanged;
                comboBoxLimitTypes.SelectedIndexChanged -= comboBoxLimitTypes_SelectedIndexChanged;
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
                    }
                    else if (p.Name.Equals("End"))
                    {
                    }
                    else if (p.Name.Equals("MinValue"))
                    {
                        flpList.Add(CreateLimitPanel(p));
                        flpLimit.Controls.Add(flpList.Last());
                    }
                    else if (p.Name.Equals("MaxValue"))
                    {
                        flpList.Add(CreateLimitPanel(p));
                        flpLimit.Controls.Add(flpList.Last());
                    }
                    if (p.Name.Equals("StartValue"))
                    {
                        flpList.Add(CreateLimitPanel(p));
                        flpLimit.Controls.Add(flpList.Last());
                    }
                    else if (p.Name.Equals("EndValue"))
                    {
                        flpList.Add(CreateLimitPanel(p));
                        flpLimit.Controls.Add(flpList.Last());
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
                                            flpList.Add(CreateLimitPanel(p2, Limit.Validator));
                                            flpLimit.Controls.Add(flpList.Last());
                                        }
                                        else if (p2.Name.Equals("Prefix"))
                                        {
                                        }
                                        else if (p2.Name.Equals("Unit"))
                                        {
                                        }
                                        else if (p2.Name.Equals("LowerBound"))
                                        {
                                            flpList.Add(CreateLimitPanel(p2, Limit.Validator));
                                            flpLimit.Controls.Add(flpList.Last());
                                        }
                                        else if (p2.Name.Equals("UpperBound"))
                                        {
                                            flpList.Add(CreateLimitPanel(p2, Limit.Validator));
                                            flpLimit.Controls.Add(flpList.Last());
                                        }
                                        else if (p2.Name.Equals("Tolerance"))
                                        {
                                            flpList.Add(CreateLimitPanel(p2, Limit.Validator));
                                            flpLimit.Controls.Add(flpList.Last());
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
                                    flpList.Add(CreateLimitPanel((Limit as LogSlopedDomainLimit).GetType().GetProperties().Where(f => f.Name == "StartValue2").First()));
                                    flpLimit.Controls.Add(flpList.Last());

                                    flpList.Add(CreateLimitPanel((Limit as LogSlopedDomainLimit).GetType().GetProperties().Where(f => f.Name == "EndValue2").First()));
                                    flpLimit.Controls.Add(flpList.Last());
                                }
                                else if (Limit is LinearSlopedDomainLimit)
                                {
                                    flpList.Add(CreateLimitPanel((Limit as LinearSlopedDomainLimit).GetType().GetProperties().Where(f => f.Name == "StartValue2").First()));
                                    flpLimit.Controls.Add(flpList.Last());
                                    flpList.Add(CreateLimitPanel((Limit as LinearSlopedDomainLimit).GetType().GetProperties().Where(f => f.Name == "EndValue2").First()));
                                    flpLimit.Controls.Add(flpList.Last());
                                }

                            }
                            else if (Limit.Validator.GetType().ToString().Contains("Toler"))
                            {
                                flpList.Add(CreateLimitPanel(Limit.Validator.GetType().GetProperty("Tolerance"), Limit.Validator));
                                flpLimit.Controls.Add(flpList.Last());
                            }
                            else
                            {
                                var found = flpList.Select(f => (f.Tag as PropertyInfo).Name == "StartValue2");
                                if (found.Count() > 0)
                                {
                                    flpLimit.Controls.Remove(flpList.Select(f => (f.Tag as PropertyInfo).Name == "StartValue2") as Control);
                                    flpList.Remove(flpList.Where(f => (f.Tag as PropertyInfo).Name == "StartValue2").First());
                                }
                                found = flpList.Select(f => (f.Tag as PropertyInfo).Name == "EndValue2");
                                if (found.Count() > 0)
                                {
                                    flpLimit.Controls.Remove(flpList.Select(f => (f.Tag as PropertyInfo).Name == "EndValue2") as Control);// Remove(flpList.Last());
                                    flpList.Remove(flpList.Where(f => (f.Tag as PropertyInfo).Name == "EndValue2").First());
                                }
                            }
                        }
                    }
                    BindData();

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
            BindData();
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
            ShowAdditialParamCtrls(labeLNames);

            comboBoxValidators.SelectedIndexChanged -= comboBoxValidators_SelectedIndexChanged;
            comboBoxLimitTypes.SelectedIndexChanged -= comboBoxLimitTypes_SelectedIndexChanged;
            UpdateLimitInteral(Limit);
            comboBoxValidators.SelectedIndexChanged += comboBoxValidators_SelectedIndexChanged;
            comboBoxLimitTypes.SelectedIndexChanged += comboBoxLimitTypes_SelectedIndexChanged;
        }

        private void BindData()
        {
            if (Limit != null)
            {

            }
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
            tb.Text = propInfo.GetValue(Limit).ToString();
            flp.Controls.Add(l);
            flp.Controls.Add(tb);
            flp.Tag = propInfo;
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
            tb.Text = propInfo.GetValue(Limit.Validator).ToString();
            flp.Controls.Add(l);
            flp.Controls.Add(tb);
            flp.Tag = propInfo;
            return flp;
        }


        private void ShowAdditialParamCtrls(List<string> labelNames)
        {
            //labelAdditionalProperty1.Visible = false;
            //labelAdditionalProperty2.Visible = false;
            //tbAddProp1.Visible = false;
            //tbAddProp2.Visible = false;
            //switch (labelNames.Count)
            //{
            //    case 0:
            //        labelAdditionalProperty1.Text = "Limit Value";
            //        labelAdditionalProperty1.Visible = true;
            //        tbAddProp1.Visible = true;
            //        break;
            //    case 1:
            //        labelAdditionalProperty1.Text = "Value";
            //        labelAdditionalProperty2.Text = labelNames[0];
            //        labelAdditionalProperty1.Visible = true;
            //        labelAdditionalProperty2.Visible = true;
            //        tbAddProp1.Visible = true;
            //        tbAddProp2.Visible = true;
            //        break;

            //    case 2:
            //        labelAdditionalProperty1.Text = labelNames[0];
            //        labelAdditionalProperty2.Text = labelNames[1];
            //        labelAdditionalProperty1.Visible = true;
            //        labelAdditionalProperty2.Visible = true;
            //        tbAddProp1.Visible = true;
            //        tbAddProp2.Visible = true;
            //        break;
            //    default:
            //        break;
            //}
        }

        private void flpMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
