using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nuvo.TestValidation.Limits;
using System.Reflection;
using static Nuvo.TestValidation.Limits.Units.UnitConverter;
using Nuvo.TestValidation.Parameters;

namespace Nuvo.Requirements_Builder
{
    public partial class TestRequirementControl : UserControl
    {
        public event EventHandler RequirementUpdated;
        public RequirementInfoCtrl reqCtrl;
        public LimitCtrl limCtrl;
        public ParameterCtrl paramCtrl;
        public TestRequirement testRequirement;
        public Dictionary<string, Control> controls;
        public int reqNum;
        public Type[] limits, parameters, requirements;
        public bool IsDeleted = false;

        public TestRequirementControl(TestRequirement requirement, int count, Type[] l, Type[] r, Type[] p)
        {
            InitializeComponent();
            limits = l;
            parameters = p;
            requirements = r;
            reqNum = count;
            testRequirement = requirement;
            controls = new Dictionary<string, Control>();
            InitializeComponents();
        }

        public TestRequirementControl(int reqnum)
        {
            InitializeComponent();
            var limit = new LimitCtrl();
            limits = limit.limitTypes;
            var parameter = new ParameterCtrl();
            parameters = parameter.parameterTypes;
            var requirement = new RequirementInfoCtrl();
            testRequirement = requirement.GetTestRequirement();
            reqNum = reqnum;
            controls = new Dictionary<string, Control>();

            reqCtrl = new RequirementInfoCtrl();
            flowLayoutPanel1.Controls.Add(reqCtrl);
            reqCtrl.UpdateInfo(testRequirement, reqNum);
            paramCtrl = new ParameterCtrl();
            flowLayoutPanel1.Controls.Add(paramCtrl);
            limCtrl = new LimitCtrl();
            flowLayoutPanel1.Controls.Add(limCtrl);
            limCtrl.UpdateLimit(testRequirement.Limit as GenericLimit);
            paramCtrl.UpdateLimit(testRequirement.CharacteristicParameter as GenericParameter);
            //InitializeComponents();
        }

        private void InitializeComponents()
        {
            foreach (var property in testRequirement.GetType().GetProperties())
            {

                if (property.MemberType != MemberTypes.Method)
                {
                    switch (property.Name.ToString())
                    {
                        case "Name":
                            reqCtrl = new RequirementInfoCtrl();
                            flowLayoutPanel1.Controls.Add(reqCtrl);
                            reqCtrl.UpdateInfo(testRequirement, reqNum);
                            break;
                        case "Limit":
                            limCtrl = new LimitCtrl();
                            limCtrl.UpdateLimit(testRequirement.Limit as GenericLimit);
                            break;
                        case "CharacteristicParameter":
                            if (!property.Name.Equals("Property"))
                            {
                                paramCtrl = new ParameterCtrl();
                                paramCtrl.UpdateLimit(testRequirement.CharacteristicParameter as GenericParameter);
                            }
                            break;
                        default:
                            break;
                    }
                    if(paramCtrl != null)
                        flowLayoutPanel1.Controls.Add(paramCtrl);
                    if(limCtrl != null)
                        flowLayoutPanel1.Controls.Add(limCtrl);
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Enabled)
            {
                buttonEdit.Text = "EDIT";
                testRequirement.Name = reqCtrl.GetTestRequirement().Name;
                testRequirement.Limit = limCtrl.GetLimit();
                testRequirement.CharacteristicParameter = paramCtrl.GetParameter();
                flowLayoutPanel1.Enabled = false;
                btnDelete.Enabled = false;
                btnDelete.Visible = false;
                RequirementUpdated.Invoke(this, null);
            }
            else
            {
                buttonEdit.Text = "SAVE";
                btnDelete.Enabled = true;
                btnDelete.Visible = true;
                flowLayoutPanel1.Enabled = true;
            }
        }

        public void CreateControls(object obj, Control parentControl)
        {
            //FlowLayoutPanel f = new FlowLayoutPanel();
            //f.FlowDirection = FlowDirection.TopDown;
            //f.BorderStyle = BorderStyle.FixedSingle;
            //f.AutoSize = true;
            //parentControl.Controls.Add(f);

            //Type objectType = obj.GetType();

            //foreach (PropertyInfo propertyInfo in objectType.GetProperties())
            //{
            //    // Create a label for the property
            //    Label label = new Label();
            //    label.Text = propertyInfo.Name;
            //    if (propertyInfo.Name.Equals("Item"))
            //        break;
            //    label.AutoSize = true;
            //    if (propertyInfo.PropertyType == typeof(Unit))
            //    {
            //        ComboBox comboBox = new ComboBox();
            //        comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            //        comboBox.Items.AddRange(Enum.GetNames(typeof(Unit)));
            //        var val = propertyInfo.GetValue(obj).ToString() ;
            //        Unit value = Enum.Parse<Unit>(val);
            //        var index = comboBox.Items.IndexOf(val);
            //        comboBox.SelectedIndex = index;
            //        //comboBox.DataBindings.Add("SelectedItem", propertyInfo.GetValue(obj), propertyInfo.Name);

            //        f.Controls.Add(new Label { Text = propertyInfo.Name });
            //        f.Controls.Add(comboBox);
            //    }
            //    else if (propertyInfo.PropertyType == typeof(Prefix))
            //    {
            //        ComboBox comboBox = new ComboBox();
            //        comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            //        comboBox.Items.AddRange(Enum.GetNames(typeof(Prefix)));
            //        var val = propertyInfo.GetValue(obj).ToString();
            //        Prefix value= Enum.Parse<Prefix>(val);
            //        var index = comboBox.Items.IndexOf(val);
            //        comboBox.SelectedIndex = index;
            //        //comboBox.DataBindings.Add("SelectedItem", propertyInfo.GetValue(obj), propertyInfo.Name);
            //        f.Controls.Add(new Label { Text = propertyInfo.Name });
            //        f.Controls.Add(comboBox);
            //    }
            //    else
            //    {
            //        // Create a text box for the property
            //        TextBox textBox = new TextBox();

            //        // Set the initial text box value from the object property
            //        object propertyValue = propertyInfo.GetValue(obj);
            //        textBox.Text = propertyValue?.ToString();

            //        f.Controls.Add(label);
            //            if (propertyInfo.Name == "Limit")
            //            {
            //                ComboBox comboBox = new ComboBox();
            //                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            //                var index = -1;
            //                // Loop through the CharacteristicParameter classes
            //                foreach (Type limitType in limits)
            //                {
            //                    index++;
            //                    comboBox.Items.Add(limitType.Name);
            //                    if (propertyValue.GetType().Name.StartsWith(limitType.Name.Substring(0, limitType.Name.Length - 2)))
            //                        comboBox.SelectedIndex = index;
            //                }
            //                f.Controls.Add(comboBox);

            //                CreateControls(propertyValue, f);
            //            }
            //        else
            //        {
            //            f.Controls.Add(textBox);

            //            // Add the label and text box to the parent control
            //            parentControl.Controls.Add(f);
            //        }
            //    }

            //}
        }
        public void CreateParameterControls(object obj, Control parentControl)
        {
            //FlowLayoutPanel f = new FlowLayoutPanel();
            //f.FlowDirection = FlowDirection.TopDown;
            //f.BorderStyle = BorderStyle.FixedSingle;
            //f.AutoSize = true;
            //parentControl.Controls.Add(f);

            //Type objectType = obj.GetType();

            //foreach (PropertyInfo propertyInfo in objectType.GetProperties())
            //{
            //    // Create a label for the property
            //    Label label = new Label();
            //    label.Text = propertyInfo.Name;
            //    if (propertyInfo.Name.Equals("Item"))
            //        break;
            //    label.AutoSize = true;
            //    if (propertyInfo.PropertyType == typeof(Unit))
            //    {
            //        ComboBox comboBox = new ComboBox();
            //        comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            //        comboBox.Items.AddRange(Enum.GetNames(typeof(Unit)));
            //        var val = propertyInfo.GetValue(obj).ToString();
            //        Unit value = Enum.Parse<Unit>(val);
            //        var index = comboBox.Items.IndexOf(val);
            //        comboBox.SelectedIndex = index;
            //        //comboBox.DataBindings.Add("SelectedItem", propertyInfo.GetValue(obj), propertyInfo.Name);

            //        f.Controls.Add(new Label { Text = propertyInfo.Name });
            //        f.Controls.Add(comboBox);
            //    }
            //    else if (propertyInfo.PropertyType == typeof(Prefix))
            //    {
            //        ComboBox comboBox = new ComboBox();
            //        comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            //        comboBox.Items.AddRange(Enum.GetNames(typeof(Prefix)));
            //        var val = propertyInfo.GetValue(obj).ToString();
            //        Prefix value = Enum.Parse<Prefix>(val);
            //        var index = comboBox.Items.IndexOf(val);
            //        comboBox.SelectedIndex = index;
            //        //comboBox.DataBindings.Add("SelectedItem", propertyInfo.GetValue(obj), propertyInfo.Name);
            //        f.Controls.Add(new Label { Text = propertyInfo.Name });
            //        f.Controls.Add(comboBox);
            //    }
            //    else if(propertyInfo.Name == "MeasurementVariables")
            //    {
            //        label.Text = "MeasurementVariables";
            //        f.Controls.Add(label);
            //        var vars = propertyInfo.GetValue(obj) as List<string>;
            //        // Loop through the CharacteristicParameter classes
            //        foreach (string prop in vars)
            //        {
            //            TextBox textBox = new TextBox();
            //            string val = prop;
            //            textBox.Text = val;
            //            textBox.Width = Math.Max(25, (int)(2 * textBox.Text.Length * textBox.Font.Size / 3));
            //            f.Controls.Add(textBox);
            //        }
            //        //parentControl.Controls.Add(f);
            //    }
            //    else
            //    {
            //        TextBox textBox = new TextBox();
            //        // Set the initial text box value from the object property
            //        object propertyValue = propertyInfo.GetValue(obj);
            //        textBox.Text = propertyValue?.ToString();
            //        textBox.Width = Math.Max(25, (int)(2 * textBox.Text.Length * textBox.Font.Size / 3));
            //        f.Controls.Add(label);
            //        f.Controls.Add(textBox);
            //        // Add the label and text box to the parent control
            //        parentControl.Controls.Add(f);
            //    }
            //}
        }

        public Dictionary<string, string> GetPropertyValues()
        {
            Dictionary<string, string> propertyValues = new Dictionary<string, string>();

            foreach (var property in testRequirement.GetType().GetProperties())
            {
                if (controls.TryGetValue(property.Name, out Control control))
                {
                    if (control is TextBox textBox)
                    {
                        propertyValues[property.Name] = textBox.Text;
                    }
                }
            }

            return propertyValues;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            IsDeleted = true;
            RequirementUpdated.Invoke(this,new EventArgs());
        }
    }
}
