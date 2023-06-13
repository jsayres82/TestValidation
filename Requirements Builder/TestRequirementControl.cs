using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestValidation.Requirements;
using System.Reflection;
using static TestValidation.Requirements.Units.UnitConverter;
using TestValidation.CharacteristicParameters;

namespace Requirements_Builder
{
    public partial class TestRequirementControl : UserControl
    {
        public event EventHandler RequirementUpdated;
        public TestRequirement testRequirement;
        public Dictionary<string, Control> controls;
        public int requirementX, requirementY,reqNum;
        public Type[] limits,parameters,requirements;
        public TestRequirementControl(TestRequirement requirement, int count, Type[] l, Type[] r, Type[] p)
        {
            limits = l;
            parameters = p;
            requirements = r;
            reqNum = count;
            testRequirement = requirement;
            Dock = DockStyle.Fill;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PropertyInfo[] props = testRequirement.GetType().GetProperties();
            controls = new Dictionary<string, Control>();

            InitializeComponent();
            Label reqNumLbl = new Label();
            reqNumLbl.Text = reqNum.ToString();
            reqNumLbl.AutoSize = true;
            Button editButton = new Button();
            editButton.Text = "Edit";
            editButton.Click += new System.EventHandler(OnEditButtonClicked);
            flowLayoutPanel1.Controls.Add(reqNumLbl);
            flowLayoutPanel1.Controls.Add(editButton);
            controls.Add("Requirement Number", reqNumLbl);
            InitializeComponents();

        }

        private void OnEditButtonClicked(object sender, EventArgs e)
        {
            var test = (sender as Control).Parent.Controls[0].Text;
            RequirementUpdated.Invoke(this, null);
        }

        private void InitializeComponents()
        {
            int labelTop = 10;
            int textBoxTop = 30;
            int labelLeft = 10;
            int textBoxLeft = 10;
            foreach (var property in testRequirement.GetType().GetProperties())
            {
                FlowLayoutPanel f = new FlowLayoutPanel();
                f.FlowDirection = FlowDirection.TopDown;
                f.BorderStyle = BorderStyle.FixedSingle;
                f.Name = reqNum.ToString() + property.Name + "FLP";
                f.AutoSize = true;
                flowLayoutPanel1.Controls.Add(f);

                if (property.MemberType != MemberTypes.Method)
                {
                    //reqNum++;
                    Label label = new Label();
                    TextBox textBox = new TextBox();
                    switch (property.Name.ToString())
                    {
                        case "Name":
                            // Create label
                            label.Text = "Requirement Name";
                            label.AutoSize = true;
                            label.Location = new Point(textBoxLeft, labelTop);
                            
                            f.Controls.Add(label);
                            controls.Add(reqNum.ToString() + property.Name + "label", label);

                            // Create text box
                            textBox.Location = new Point(textBoxLeft, textBoxTop);
                            textBox.Top = textBoxTop;
                            textBox.Left = textBoxLeft;
                            textBox.Width = 150;
                            textBox.TextChanged += TextBox_TextChanged;
                            textBox.Text = testRequirement.Name;
                            textBox.TextChanged += TextBox_TextChanged1;


                            f.Controls.Add(textBox);
                            controls.Add("RequirementName_TextBox", textBox);
                            break;
                        case "Limit":
                            
                                this.CreateControls(testRequirement.Limit, flowLayoutPanel1);
                            
                            break;
                        case "CharacteristicParameter":
                            if (!property.Name.Equals("Property"))
                            {
                                // Create label
                                label.Text = "Parameter Type";
                                label.AutoSize = true;
                                label.Location = new Point(textBoxLeft, labelTop);

                                f.Controls.Add(label);
                                controls.Add(reqNum.ToString() + property.Name + "label", label);

                                // Create text box
                                textBox.Location = new Point(textBoxLeft, textBoxTop);
                                textBox.Top = textBoxTop;
                                textBox.Left = textBoxLeft;
                                textBox.Width = 250;
                                textBox.Name = "ParameterType_TextBox";
                                textBox.Text = testRequirement.CharacteristicParameter.GetType().Name;
                                textBox.TextChanged += TextBox_TextChanged1;
                                f.Controls.Add(textBox);
                                controls.Add("ParameterType_TextBox", textBox);
                                this.CreateParameterControls(testRequirement.CharacteristicParameter, f);
                            }

                            break;
                        default:
                            break;
                    }

                    // Update positions for next label and text box
                    //labelTop += 40;
                    //textBoxTop += 40;
                }
            }
        }

        private void TextBox_TextChanged1(object sender, EventArgs e)
        {
            if((sender as TextBox).Name.StartsWith("RequirementName"))
            {
                testRequirement.Name = (sender as TextBox).Text;
            }
            else if((sender as TextBox).Name.StartsWith("ParameterType"))
            {
                if((sender as TextBox).Text.StartsWith("Atten"))
                    testRequirement.CharacteristicParameter = new AttenuationParameter();
                else if((sender as TextBox).Text.StartsWith("Inser"))
                    testRequirement.CharacteristicParameter = new InsertionLossParameter();
                else if ((sender as TextBox).Text.StartsWith("Ripp"))
                    testRequirement.CharacteristicParameter = new RippleParameter();
                else
                {

                }
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            testRequirement.Name = (sender as TextBox).Text;
            //RequirementUpdated.Invoke(this.testRequirement, null);
        }

        public void CreateControls(object obj, Control parentControl)
        {
            FlowLayoutPanel f = new FlowLayoutPanel();
            f.FlowDirection = FlowDirection.TopDown;
            f.BorderStyle = BorderStyle.FixedSingle;
            f.AutoSize = true;
            parentControl.Controls.Add(f);

            Type objectType = obj.GetType();

            foreach (PropertyInfo propertyInfo in objectType.GetProperties())
            {
                // Create a label for the property
                Label label = new Label();
                label.Text = propertyInfo.Name;
                if (propertyInfo.Name.Equals("Item"))
                    break;
                label.AutoSize = true;
                if (propertyInfo.PropertyType == typeof(Unit))
                {
                    ComboBox comboBox = new ComboBox();
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox.Items.AddRange(Enum.GetNames(typeof(Unit)));
                    var val = propertyInfo.GetValue(obj).ToString() ;
                    Unit value = Enum.Parse<Unit>(val);
                    var index = comboBox.Items.IndexOf(val);
                    comboBox.SelectedIndex = index;
                    //comboBox.DataBindings.Add("SelectedItem", propertyInfo.GetValue(obj), propertyInfo.Name);

                    f.Controls.Add(new Label { Text = propertyInfo.Name });
                    f.Controls.Add(comboBox);
                }
                else if (propertyInfo.PropertyType == typeof(Prefix))
                {
                    ComboBox comboBox = new ComboBox();
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox.Items.AddRange(Enum.GetNames(typeof(Prefix)));
                    var val = propertyInfo.GetValue(obj).ToString();
                    Prefix value= Enum.Parse<Prefix>(val);
                    var index = comboBox.Items.IndexOf(val);
                    comboBox.SelectedIndex = index;
                    //comboBox.DataBindings.Add("SelectedItem", propertyInfo.GetValue(obj), propertyInfo.Name);
                    f.Controls.Add(new Label { Text = propertyInfo.Name });
                    f.Controls.Add(comboBox);
                }
                else
                {
                    // Create a text box for the property
                    TextBox textBox = new TextBox();

                    // Set the initial text box value from the object property
                    object propertyValue = propertyInfo.GetValue(obj);
                    textBox.Text = propertyValue?.ToString();

                    f.Controls.Add(label);
                        if (propertyInfo.Name == "Limit")
                        {
                            ComboBox comboBox = new ComboBox();
                            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                            var index = -1;
                            // Loop through the CharacteristicParameter classes
                            foreach (Type limitType in limits)
                            {
                                index++;
                                comboBox.Items.Add(limitType.Name);
                                if (propertyValue.GetType().Name.StartsWith(limitType.Name.Substring(0, limitType.Name.Length - 2)))
                                    comboBox.SelectedIndex = index;
                            }
                            f.Controls.Add(comboBox);

                            CreateControls(propertyValue, f);
                        }
                    else
                    {
                        f.Controls.Add(textBox);

                        // Add the label and text box to the parent control
                        parentControl.Controls.Add(f);
                    }
                }
               
            }
        }
        public void CreateParameterControls(object obj, Control parentControl)
        {
            FlowLayoutPanel f = new FlowLayoutPanel();
            f.FlowDirection = FlowDirection.TopDown;
            f.BorderStyle = BorderStyle.FixedSingle;
            f.AutoSize = true;
            parentControl.Controls.Add(f);

            Type objectType = obj.GetType();

            foreach (PropertyInfo propertyInfo in objectType.GetProperties())
            {
                // Create a label for the property
                Label label = new Label();
                label.Text = propertyInfo.Name;
                if (propertyInfo.Name.Equals("Item"))
                    break;
                label.AutoSize = true;
                if (propertyInfo.PropertyType == typeof(Unit))
                {
                    ComboBox comboBox = new ComboBox();
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox.Items.AddRange(Enum.GetNames(typeof(Unit)));
                    var val = propertyInfo.GetValue(obj).ToString();
                    Unit value = Enum.Parse<Unit>(val);
                    var index = comboBox.Items.IndexOf(val);
                    comboBox.SelectedIndex = index;
                    //comboBox.DataBindings.Add("SelectedItem", propertyInfo.GetValue(obj), propertyInfo.Name);

                    f.Controls.Add(new Label { Text = propertyInfo.Name });
                    f.Controls.Add(comboBox);
                }
                else if (propertyInfo.PropertyType == typeof(Prefix))
                {
                    ComboBox comboBox = new ComboBox();
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox.Items.AddRange(Enum.GetNames(typeof(Prefix)));
                    var val = propertyInfo.GetValue(obj).ToString();
                    Prefix value = Enum.Parse<Prefix>(val);
                    var index = comboBox.Items.IndexOf(val);
                    comboBox.SelectedIndex = index;
                    //comboBox.DataBindings.Add("SelectedItem", propertyInfo.GetValue(obj), propertyInfo.Name);
                    f.Controls.Add(new Label { Text = propertyInfo.Name });
                    f.Controls.Add(comboBox);
                }
                else if(propertyInfo.Name == "MeasurementVariables")
                {
                    label.Text = "MeasurementVariables";
                    f.Controls.Add(label);
                    var vars = propertyInfo.GetValue(obj) as List<string>;
                    // Loop through the CharacteristicParameter classes
                    foreach (string prop in vars)
                    {
                        TextBox textBox = new TextBox();
                        string val = prop;
                        textBox.Text = val;
                        textBox.Width = Math.Max(25, (int)(2 * textBox.Text.Length * textBox.Font.Size / 3));
                        f.Controls.Add(textBox);
                    }
                    //parentControl.Controls.Add(f);
                }
                else
                {
                    TextBox textBox = new TextBox();
                    // Set the initial text box value from the object property
                    object propertyValue = propertyInfo.GetValue(obj);
                    textBox.Text = propertyValue?.ToString();
                    textBox.Width = Math.Max(25, (int)(2 * textBox.Text.Length * textBox.Font.Size / 3));
                    f.Controls.Add(label);
                    f.Controls.Add(textBox);
                    // Add the label and text box to the parent control
                    parentControl.Controls.Add(f);
                }
            }
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
    }
}
