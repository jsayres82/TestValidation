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
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Limits.Validators;
using Nuvo.TestValidation.Parameters;
using static Nuvo.TestValidation.Limits.Units.UnitConverter;

namespace Nuvo.Requirements_Builder
{
    public partial class LimitCtrl : UserControl
    {
        public Type[] limitTypes;
        public Type[] validatorTypes;
        public GenericLimit Limit;
        public Type LimitType, ValidatorType;
        public LimitCtrl()
        {
            //LimitType = Limit.GetType();
            //ValidatorType = Limit.Validator.GetType();
            InitializeComponent();
            comboBoxValidators.SelectedIndexChanged -= comboBoxValidators_SelectedIndexChanged;
            comboBoxLimitTypes.SelectedIndexChanged -= comboBoxLimitTypes_SelectedIndexChanged;
            // Load the assembly containing the CharacteristicParameter classes
            Assembly assembly = Assembly.LoadFrom("Nuvo.TestValidation.dll");

            // Get all the Requirements classes
            limitTypes = assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(GenericLimit)))
                .ToArray();

            // Get all the Limit classes
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
            comboBoxUnitsPrefix.Items.AddRange(Enum.GetNames(typeof(Prefix)));
            comboBoxLimitUnits.Items.AddRange(Enum.GetNames(typeof(Unit)));

            comboBoxValidators.SelectedIndexChanged += comboBoxValidators_SelectedIndexChanged;
            comboBoxLimitTypes.SelectedIndexChanged += comboBoxLimitTypes_SelectedIndexChanged;
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
            foreach (var p in Limit.GetType().GetProperties())
            {
                if (p.Name.Equals("Start"))
                {
                    p.SetValue(Limit,System.Convert.ToDouble(textBoxAdditionalProperty1.Text));
                }
                else if (p.Name.Equals("End"))
                {
                    p.SetValue(Limit, System.Convert.ToDouble(textBoxAdditionalProperty2.Text));
                }
                else if (p.Name.Equals("MinValue"))
                {
                    p.SetValue(Limit, System.Convert.ToDouble(textBoxAdditionalProperty1.Text));
                }
                else if (p.Name.Equals("MaxValue"))
                {
                    p.SetValue(Limit, System.Convert.ToDouble(textBoxAdditionalProperty2.Text));
                }
                else if (p.Name.Equals("Validator"))
                {
                    foreach (var p2 in Limit.Validator.GetType().GetProperties())
                    {
                        if (p2.Name.Equals("Value"))
                        {
                            p2.SetValue(Limit.Validator, System.Convert.ToDouble(textBoxValue.Text));
                        }
                        else if (p2.Name.Equals("Prefix"))
                        {
                            p2.SetValue(Limit.Validator, Enum.Parse<Prefix>(comboBoxUnitsPrefix.Text));
                        }
                        else if (p2.Name.Equals("Unit"))
                        {
                            p2.SetValue(Limit.Validator, Enum.Parse<Unit>(comboBoxLimitUnits.Text));
                        }
                    }
                }
            }
            return Limit;
        }

        public void UpdateLimit(GenericLimit limit)
        {
            if(limit != null)
            {

                comboBoxValidators.SelectedIndexChanged -= comboBoxValidators_SelectedIndexChanged;
                comboBoxLimitTypes.SelectedIndexChanged -= comboBoxLimitTypes_SelectedIndexChanged;
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
                foreach (var p in Limit.GetType().GetProperties())
                {
                    comboBoxLimitTypes.Text = Limit.GetType().Name;
                    if (p.Name.Equals("Start"))
                    {
                        textBoxAdditionalProperty1.Text =  p.GetValue(Limit).ToString();
                    }
                    else if (p.Name.Equals("End"))
                    {
                        textBoxAdditionalProperty2.Text = p.GetValue(Limit).ToString();
                    }
                    else if (p.Name.Equals("MinValue"))
                    {
                        textBoxAdditionalProperty1.Text = p.GetValue(Limit).ToString();
                    }
                    else if (p.Name.Equals("MaxValue"))
                    {
                        textBoxAdditionalProperty2.Text = p.GetValue(Limit).ToString();
                    }
                    else if (p.Name.Equals("Validator"))
                    {
                        comboBoxValidators.Text = Limit.Validator.GetType().Name;
                        foreach (var p2 in Limit.Validator.GetType().GetProperties())
                        {
                            if (p2.Name.Equals("Value"))
                            {
                                textBoxValue.Text = p2.GetValue(Limit.Validator).ToString();
                            }
                            else if (p2.Name.Equals("Prefix"))
                            {
                                comboBoxUnitsPrefix.Text = p2.GetValue(Limit.Validator).ToString();
                            }
                            else if (p2.Name.Equals("Unit"))
                            {
                                comboBoxLimitUnits.Text = p2.GetValue(Limit.Validator).ToString();
                            }
                        }
                    }
                }
                BindData();

                comboBoxValidators.SelectedIndexChanged += comboBoxValidators_SelectedIndexChanged;
                comboBoxLimitTypes.SelectedIndexChanged += comboBoxLimitTypes_SelectedIndexChanged;
            }
        }

        private void comboBoxLimitTypes_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBoxValidators.SelectedIndexChanged -= comboBoxValidators_SelectedIndexChanged;
            bindingSource1.ResetBindings(false);
            var o = Activator.CreateInstance(limitTypes[comboBoxLimitTypes.SelectedIndex]);
            PropertyInfo[] properties = o.GetType().GetProperties();
            (o as GenericLimit).Validator = new LessThanValidator<double>()
            {
                Prefix = Prefix.None,
                Unit = Unit.None,
                Value = 0
            };
            Limit = o as GenericLimit;

            BindData();
            comboBoxValidators.SelectedIndexChanged += comboBoxValidators_SelectedIndexChanged;
        }

        private void comboBoxValidators_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindingSource1.ResetBindings(false);
            Type[] typeArgs = { typeof(double) };
            var makeme = validatorTypes[comboBoxValidators.SelectedIndex].MakeGenericType(typeArgs);
            var o = Activator.CreateInstance(makeme);

            PropertyInfo[] properties = o.GetType().GetProperties();

            Limit.Validator = o as GenericValidator<double>;
            foreach (var p in properties)
            {
                if (p.Name.Equals("Value"))
                {
                    p.SetValue(Limit.Validator, 0);
                }
                else if(p.Name.Equals("Prefix"))
                {
                    p.SetValue(Limit.Validator, Prefix.None);
                }
                else if (p.Name.Equals("Unit"))
                {
                    p.SetValue(Limit.Validator, Unit.DecibelMilliwatt);
                }
            }
        }

        private void BindData()
        {
            if (Limit != null)
            {

            }
        }

    }
}
