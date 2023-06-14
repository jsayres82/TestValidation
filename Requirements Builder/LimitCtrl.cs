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
using TestValidation.Limits;
using TestValidation.Limits.Validators;
using TestValidation.Parameters;
using static TestValidation.Limits.Units.UnitConverter;

namespace Requirements_Builder
{
    public partial class LimitCtrl : UserControl
    {
        public Type[] limitTypes;
        public Type[] validatorTypes;
        public GenericLimit Limit;
        public Type LimitType, ValidatorType;
        public LimitCtrl()
        {
            Limit = new DomainLimit()
            {
                Start = 10000,
                End = 50000,
                Validator = new LessThanValidator<double>() {
                    Value = -1, 
                    Prefix = Prefix.None, 
                    Unit = Unit.DecibelMilliwatt 
                }
            };
            LimitType = Limit.GetType();
            ValidatorType = Limit.Validator.GetType();
            InitializeComponent();

            // Load the assembly containing the CharacteristicParameter classes
            Assembly assembly = Assembly.LoadFrom("TestValidation.dll");

            // Get all the Requirements classes
            limitTypes = assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(GenericLimit)))
                .ToArray();

            // Get all the Limit classes
            validatorTypes = assembly.GetTypes()
                .Where(IsIndexType)
                .ToArray();

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
            comboBoxUnitsPrefix.Items.AddRange(Enum.GetNames(typeof(Prefix)));
            comboBoxLimitUnits.Items.AddRange(Enum.GetNames(typeof(Unit)));

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


        public void UpdateLimit(GenericLimit limit)
        {
            Limit = limit;
            //fileName = Path.GetFileNameWithoutExtension(specFile);
            //folderName = Path.GetDirectoryName(specFile);
            //textBoxSpecFileLoc.Text = folderName;
            //textBoxSpecFileName.Text = fileName;
            //testInfo.TestName = newInfo.TestName;
            //testInfo.Program = newInfo.Program;
            //testInfo.WaferName = newInfo.WaferName;
            //testInfo.TestArticles = newInfo.TestArticles;
            //bindingSource1.ResetBindings(true);
            BindData();
        }

        private void BindData()
        {
            if (Limit != null)
            {
                bindingSource1.DataSource = Limit;
                bindingSource2.DataSource = LimitType;
                bindingSource3.DataSource = ValidatorType;

                comboBoxLimitTypes.Text = LimitType.Name;
                comboBoxValidators.Text = ValidatorType.Name;

                textBoxValue.DataBindings.Add("Text", bindingSource1, "Validator.Value");
                comboBoxUnitsPrefix.DataBindings.Add("Text", bindingSource1, "Validator.Prefix");
                comboBoxLimitUnits.DataBindings.Add("Text", bindingSource1, "Validator.Unit");
                textBoxAdditionalProperty1.DataBindings.Add("Text", bindingSource1, "Start");
                textBoxAdditionalProperty2.DataBindings.Add("Text", bindingSource1, "End");

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

        private void comboBoxValidators_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
