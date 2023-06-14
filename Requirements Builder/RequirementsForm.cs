using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;
using TestValidation;
using TestValidation.Parameters;
using TestValidation.Limits;
using static TestValidation.Limits.Units.UnitConverter;
using TestValidation.Limits.Validators;

namespace Requirements_Builder
{
    public partial class RequirementsForm : Form
    {
        string specFile = "C:\\Users\\214782\\source\\repos\\TestValidation\\TestValidation\\bin\\Debug\\net5.0\\test_spec_file.xml";
        public MeasurementProcessor measurementProcessor = new MeasurementProcessor();
        public DataGridView dgv;
        public Type[] requirementTypes;
        public Type[] parameterTypes;
        public Type[] limitTypes;

        public RequirementsForm()
        {
            InitializeComponent();

            // Load the assembly containing the CharacteristicParameter classes
            Assembly assembly = Assembly.LoadFrom("TestValidation.dll");

            // Get all the CharacteristicParameter classes
            parameterTypes = assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(GenericParameter)))
                .ToArray();

            // Get all the Requirements classes
            requirementTypes = assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(GenericLimit)))
                .ToArray();

            // Get all the Limit classes
            limitTypes = assembly.GetTypes()
                .Where(IsIndexType)
                .ToArray();

            // Loop through the CharacteristicParameter classes
            foreach (Type limitType in limitTypes)
            {
                comboBoxLimitTypes.Items.Add(limitType.Name);
            }
            // Loop through the CharacteristicParameter classes
            foreach (Type requirementType in requirementTypes)
            {
                comboBoxRequirements.Items.Add(requirementType.Name);
            }

            // Loop through the CharacteristicParameter classes
            foreach (Type parameterType in parameterTypes)
            {
                Console.WriteLine($"Characteristic Parameter: {parameterType.Name}");
                comboBoxParameters.Items.Add(parameterType.Name);
                // Get all the methods of the CharacteristicParameter class
                MethodInfo[] methods = parameterType.GetMethods();

                // Loop through the methods
                foreach (MethodInfo method in methods)
                {
                    Console.WriteLine($"- Method: {method.Name}");
                }

                Console.WriteLine();
            }

            UpdateFromSpecFile(specFile);
        }

        private void UpdateFromSpecFile(string specFile)
        {
            flp2.Controls.Clear();
            if(measurementProcessor.TestRequirements!=null)
                measurementProcessor.TestRequirements.Requirements.Clear();
            TestRequirements requirements = measurementProcessor.ParseTestSpecsFromXml(specFile);
            measurementInfoCtrl1.UpdateTestInfo(measurementProcessor.TestInfo, specFile);
            //dgv.Show();
            DisplayTestRequirements(requirements.Requirements);
            foreach (var req in requirements.Requirements)
            {
            }

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

        public void CreateControls(object obj, Control parentControl)
        {
            FlowLayoutPanel f = new FlowLayoutPanel();
            f.FlowDirection = FlowDirection.TopDown;
            f.BorderStyle = BorderStyle.FixedSingle;
            f.Width = 500;
            f.Height = 200;
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
                else
                {
                    // Create a text box for the property
                    TextBox textBox = new TextBox();

                    // Set the initial text box value from the object property
                    object propertyValue = propertyInfo.GetValue(obj);
                    textBox.Text = propertyValue?.ToString();

                    f.Controls.Add(label);
                    if (propertyValue == null)
                    {
                        if (propertyInfo.Name == "Limit")
                        {
                            ComboBox comboBox = new ComboBox();
                            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                            // Loop through the CharacteristicParameter classes
                            foreach (Type limitType in limitTypes)
                            {
                                comboBox.Items.Add(limitType.Name);
                            }
                            comboBox.SelectedIndex = 0;

                            f.Controls.Add(comboBox);
                            Type[] typeArgs = { typeof(double) };
                            var makeme = limitTypes[comboBox.SelectedIndex].MakeGenericType(typeArgs);
                            var o = Activator.CreateInstance(makeme);
                            PropertyInfo[] properties = o.GetType().GetProperties();

                            CreateControls(o, f);
                        }
                    }
                    else
                    {
                        f.Controls.Add(textBox);

                        // Add the label and text box to the parent control
                        parentControl.Controls.Add(f);
                    }
                        // If the property is a complex object, recursively create controls for it
                    if (propertyInfo.PropertyType.IsClass && propertyInfo.PropertyType != typeof(string))
                    {
                        if (propertyInfo.Name != "Limit")
                        {
                            CreateControls(propertyValue, parentControl);
                        }
                    }
                }

            }
        }

        public void DisplayTestRequirements(List<TestRequirement> testRequirements)
        {
            int reqCount = 0;
            foreach (var requirement in testRequirements)
            {
                reqCount++;
                // Create the custom control
                TestRequirementControl control = new TestRequirementControl(requirement, reqCount,limitTypes,requirementTypes,parameterTypes);
                control.RequirementUpdated += Control_RequirementUpdated;
                control.BorderStyle = BorderStyle.FixedSingle;
                control.Top = reqCount * 50;
                control.AutoSize = true;
                control.Dock = DockStyle.Fill;
                control.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                //// Add the control to a form and display the form
                flp2.Controls.Add(control);
            }
        }

        private void Control_RequirementUpdated(object sender, EventArgs e)
        {
            //measurementInfoCtrl1.UpdateTestInfo(measurementProcessor.TestInfo, specFile);
            var ctrl= (sender as TestRequirementControl);
            measurementProcessor.TestRequirements.Requirements[(sender as TestRequirementControl).reqNum - 1].Name = ctrl.testRequirement.Name;
            measurementProcessor.TestRequirements.Requirements[(sender as TestRequirementControl).reqNum - 1].Limit = ctrl.testRequirement.Limit;
            measurementProcessor.TestRequirements.Requirements[(sender as TestRequirementControl).reqNum - 1].CharacteristicParameter = ctrl.testRequirement.CharacteristicParameter;

        }

        private void comboBoxLimitTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type[] typeArgs = { typeof(double) };
            var makeme = limitTypes[comboBoxLimitTypes.SelectedIndex].MakeGenericType(typeArgs);
            var o = Activator.CreateInstance(makeme);
            PropertyInfo[] properties = o.GetType().GetProperties();

            CreateControls(o, flp2);
        }

        private void comboBoxRequirements_SelectedIndexChanged(object sender, EventArgs e)
        {
            var o = Activator.CreateInstance(requirementTypes[comboBoxRequirements.SelectedIndex]);
            PropertyInfo[] properties = o.GetType().GetProperties();

            CreateControls(o, flp2);
        }

        private void butonNewSpecFile_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void measurementInfoCtrl1_Load(object sender, EventArgs e)
        {

        }

        private void buttonSaveSpecFile_Click(object sender, EventArgs e)
        {
            measurementProcessor.TestInfo.Program = measurementInfoCtrl1.testInfo.Program;
            measurementProcessor.TestInfo.TestName = measurementInfoCtrl1.testInfo.TestName;
            measurementProcessor.TestInfo.WaferName = measurementInfoCtrl1.testInfo.WaferName;
            measurementProcessor.TestInfo.TestArticles = measurementInfoCtrl1.testInfo.TestArticles;


            // Serialize the TestRequirement instance to XML
            var serializer = new XmlSerializer(typeof(MeasurementProcessor));
            using (var writer = new StreamWriter($"{measurementInfoCtrl1.folderName}\\{measurementInfoCtrl1.fileName}.xml"))
            {
                serializer.Serialize(writer, measurementProcessor);
            }
        }

        private void buttonOpenSpecFile_Click(object sender, EventArgs e)
        {

            DialogResult result = openFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                specFile = openFileDialog1.FileName;
                UpdateFromSpecFile(specFile);
            }

        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            foreach (Control c in flp2.Controls)
                c.Width = this.Width;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flp2_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
