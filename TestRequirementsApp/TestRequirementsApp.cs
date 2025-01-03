using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;
using Nuvo.TestValidation;
using Nuvo.TestValidation.Parameters;
using Nuvo.TestValidation.Limits;
using static Nuvo.TestValidation.Limits.Units.UnitConverter;
using Nuvo.TestValidation.Limits.Validators;
using Nuvo.TestValidation.TestResults;

namespace Nuvo.Requirements_Builder
{
    public partial class TestRequirementsApp : Form
    {
        string specFile = ".\\TestData\\test_spec_file.xml";
        public MeasurementProcessor measurementProcessor = new MeasurementProcessor();
        public DataGridView dgv;
        public string MeasurementFolder;
        public Type[] requirementTypes;
        public Type[] parameterTypes;
        public Type[] limitTypes;
        TestRequirements requirements;
        public List<string> SerialNumbers = new List<string>();
        public Dictionary<string, TestReport> TestReportsDic = new Dictionary<string, TestReport>();

        public TestRequirementsApp()
        {
            InitializeComponent();

            // Load the assembly containing the CharacteristicParameter classes
            Assembly assembly = Assembly.LoadFrom("Nuvo.TestValidation.dll");

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
            if (measurementProcessor.TestRequirements != null)
                measurementProcessor.TestRequirements.Requirements.Clear();
            requirements = measurementProcessor.ParseTestSpecsFromXml(specFile);
            testInfoCtrl1.UpdateTestInfo(measurementProcessor.TestInfo, specFile);
            testInfoCtrl1.TestInfoUpdated += TestInfoCtrl1_TestInfoUpdated;
            //dgv.Show();
            DisplayTestRequirements(requirements.Requirements);
        }

        private void TestInfoCtrl1_TestInfoUpdated(object sender, EventArgs e)
        {
            measurementProcessor.TestInfo = testInfoCtrl1.testInfo;
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
                TestRequirementControl control = new TestRequirementControl(requirement, reqCount, limitTypes, requirementTypes, parameterTypes);
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
            var ctrl = (sender as TestRequirementControl);
            if(e == null)
            {
                if (measurementProcessor.TestRequirements.Requirements.Count < (sender as TestRequirementControl).reqNum)
                {
                    measurementProcessor.TestRequirements.Requirements.Add(ctrl.testRequirement);
                }
                else
                {
                    measurementProcessor.TestRequirements.Requirements[(sender as TestRequirementControl).reqNum - 1] = ctrl.testRequirement;
                }
            }
            else
            {
                var delReqNum = (sender as TestRequirementControl).reqNum;
                measurementProcessor.TestRequirements.Requirements.Remove((sender as TestRequirementControl).testRequirement);
                flp2.Controls.RemoveAt(delReqNum - 1);
                foreach (TestRequirementControl c in flp2.Controls)
                {
                    if(c.reqNum > delReqNum)
                    {
                        c.reqNum--;
                        c.reqCtrl.UpdateInfo(c.testRequirement, c.reqNum);
                        c.Top = c.reqNum * 50;
                    }

                }
            }
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
            flp2.Controls.Clear();
            if (measurementProcessor.TestRequirements != null)
                measurementProcessor.TestRequirements.Requirements.Clear();
            int reqNum = flp2.Controls.Count + 1;
            TestRequirementControl control = new TestRequirementControl(reqNum);
            control.RequirementUpdated += Control_RequirementUpdated;
            control.BorderStyle = BorderStyle.FixedSingle;
            control.Top = (flp2.Controls.Count + 1) * 50;
            control.AutoSize = true;
            control.Dock = DockStyle.Fill;
            control.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //// Add the control to a form and display the form
            flp2.Controls.Add(control);

            testInfoCtrl1.UpdateTestInfo(measurementProcessor.TestInfo, specFile);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonSaveSpecFile_Click(object sender, EventArgs e)
        {
            // Serialize the TestRequirement instance to XML
            var serializer = new XmlSerializer(typeof(MeasurementProcessor));
            using (var writer = new StreamWriter($"{testInfoCtrl1.folderName}\\{testInfoCtrl1.fileName}.xml"))
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

        private void buttonProcessResults_Click(object sender, EventArgs e)
        {
            List<string> results;
            string output = "";
            MeasurementFolder = textBoxDataFolder.Text;
            List<string> files = measurementProcessor.GetFilesInFolder(MeasurementFolder).ToList();
            listBoxSerialNumbers.Items.Clear();
            TestReportsDic = new Dictionary<string, TestReport>();

            foreach (var serial in files)
            {
                var serialNumber = Path.GetFileName(serial).Split("_")[1].Replace("SN", "");
                SerialNumbers.Add(serialNumber);
                listBoxSerialNumbers.Items.Add(serialNumber);
                measurementProcessor.CalculateCharacteristicParameters(serial, serialNumber);
                var result = measurementProcessor.ValidateMeasurement();
                TestReportsDic.Add(serialNumber, result);
            }

            MessageBox.Show($"Processing Complete.  {files.Count} Analyzed");
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                MeasurementFolder = folderBrowserDialog1.SelectedPath;
                textBoxDataFolder.Text = MeasurementFolder;
            }
        }

        private void listBoxSerialNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var results = TestReportsDic[listBoxSerialNumbers.SelectedItem.ToString()];
            var resultString = $"SN {results.SerialNumber}\r\n";
            int reqCount = 0;
            foreach (var r in results.Results)
            {
                reqCount++;
                resultString += $"{reqCount} - {(r as ITestResult).RequirementName}: {((r as ITestResult).Passed ? "Passed" : "Failed")} Margin = {(r as ITestResult).MinimumMargin.ToString("0.###E+0")}\r\n";
            }
            MessageBox.Show(resultString);
        }

        private void btnAddSpec_Click(object sender, EventArgs e)
        {
            int reqNum = flp2.Controls.Count + 1;
            TestRequirementControl control = new TestRequirementControl(reqNum);
            control.RequirementUpdated += Control_RequirementUpdated;
            control.BorderStyle = BorderStyle.FixedSingle;
            control.Top = (flp2.Controls.Count + 1) * 50;
            control.AutoSize = true;
            control.Dock = DockStyle.Fill;
            control.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //// Add the control to a form and display the form
            flp2.Controls.Add(control);
        }
    }

}
