
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static Nuvo.TestValidation.Limits.Units.UnitConverter;
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
using Nuvo.TestValidation.Limits.Validators;

namespace Nuvo.Requirements_Builder
{
    public partial class GenericLimitForm : UserControl
    {
        private readonly GenericValidator<object> _limit;

        public GenericLimitForm(GenericValidator<object> limit)
        {
            InitializeComponent();
            _limit = limit;
            CreateControls();
            SetValues();
        }

        private void CreateControls()
        {
            PropertyInfo[] properties = _limit.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(Unit))
                {
                    ComboBox comboBox = new ComboBox();
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox.DataSource = Enum.GetValues(typeof(Unit));
                    comboBox.DataBindings.Add("SelectedItem", _limit, property.Name);

                    flowLayoutPanel.Controls.Add(new Label { Text = property.Name });
                    flowLayoutPanel.Controls.Add(comboBox);
                }
                else if (property.PropertyType == typeof(Prefix))
                {
                    ComboBox comboBox = new ComboBox();
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox.DataSource = Enum.GetValues(typeof(Prefix));
                    comboBox.DataBindings.Add("SelectedItem", _limit, property.Name);

                    flowLayoutPanel.Controls.Add(new Label { Text = property.Name });
                    flowLayoutPanel.Controls.Add(comboBox);
                }
                else
                {
                    TextBox textBox = new TextBox();
                    textBox.DataBindings.Add("Text", _limit, property.Name);

                    flowLayoutPanel.Controls.Add(new Label { Text = property.Name });
                    flowLayoutPanel.Controls.Add(textBox);
                }
            }
        }

        private void SetValues()
        {
            PropertyInfo[] properties = _limit.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(Unit) || property.PropertyType == typeof(Prefix))
                    continue;

                Control control = flowLayoutPanel.Controls.Find(property.Name, false).FirstOrDefault();

                if (control is TextBox textBox)
                    textBox.Text = property.GetValue(_limit)?.ToString();
            }
        }
    }
}