using Nuvo.TestValidation.Calculators;
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Limits.Units;
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

namespace Nuvo.Requirements_Builder.ValidationCtrls
{
    public partial class CalcParamCtrl : UserControl
    {
        public GenericCalcParams Params { get; set; }
        private Dictionary<string, GenericUnits> unitDic = new Dictionary<string, GenericUnits>();
        public CalcParamCtrl()
        {
            InitializeComponent();
        }

        public CalcParamCtrl(GenericCalcParams param)
        {
            InitializeComponent();
            Params = param;

            foreach (PropertyInfo pInfo in param.GetType().GetProperties())
            {
                if (pInfo.Name.Equals("Limit"))
                {
                    flowLayoutPanel1.Controls.Add(new RangeCtrl(param.Limit.LimitRange));
                }
                else if (pInfo.Name.Equals("Units"))
                {
                    unitDic.Clear();
                    foreach (var unit in param.Units.ValidUnitTypes)
                    {
                        var tempUnit = Activator.CreateInstance(param.Units.GetType()) as GenericUnits;
                        tempUnit.Unit = unit;
                        foreach (var prefix in param.Units.ValidPrefixTypes)
                        {
                            tempUnit.Prefix = prefix;
                            unitDic.Add(tempUnit.ToString(), tempUnit);
                        }
                    }
                    flowLayoutPanel1.Controls.Add(updateCalculatorParametersComboBox(pInfo, unitDic));
                }
                else
                {
                    flowLayoutPanel1.Controls.Add(updateCalculatorParameters(pInfo));
                }
                Console.WriteLine($"- Property: {pInfo.Name}");
            }
        }

        public GenericCalcParams GetCalculatorParameter()
        {
            var x = Params.GetType().GetProperties();
            foreach (var ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is FlowLayoutPanel)
                {
                    FlowLayoutPanel panel = (ctrl as FlowLayoutPanel);
                    if (panel.Name.Contains("CalculatorParam_"))
                    {
                        var prop = Params.GetType().GetProperty((panel.Tag as PropertyInfo).Name);
                        if (prop.PropertyType == typeof(double))
                            prop.SetValue(Params, System.Convert.ToDouble((panel.Controls[1] as TextBox).Text));
                        else if(prop.PropertyType == typeof(List<string>))
                        {
                            prop.SetValue(Params, (panel.Controls[1] as ComboBox).SelectedText);
                        }
                        else
                            prop.SetValue(Params, (panel.Controls[1] as TextBox).Text);
                    }
                }
                else if(ctrl is RangeCtrl)
                {
                    Params.Limit.LimitRange = (ctrl as RangeCtrl).GetSpecRange();
                }
            }
            return Params;
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
            tb.Text = propInfo.GetValue(Params).ToString();
            tb.TextAlign = HorizontalAlignment.Center;
            tb.Tag = propInfo.GetValue(Params);
            flp.Controls.Add(l);
            flp.Controls.Add(tb);
            flp.Tag = propInfo;
            flp.Name = "CalculatorParam_" + propInfo.Name;
            return flp;
        }

        private FlowLayoutPanel updateCalculatorParametersComboBox(PropertyInfo propInfo, Dictionary<string, GenericUnits> items)
        {
            Label l = new Label();
            l.Margin = new Padding(3, 0, 3, 0);
            ComboBox cb = new ComboBox();
            cb.Size = new Size(120, 23);
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.FlowDirection = FlowDirection.TopDown;
            flp.AutoSize = true;
            flp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            l.Text = propInfo.Name;
            l.TextAlign = ContentAlignment.MiddleLeft;
            foreach (string item in items.Keys)
            {
                cb.Items.Add(item);
            }

            if (items.Count > 0)
            {
                cb.SelectedIndex = 0;
            }
            flp.Controls.Add(l);
            flp.Controls.Add(cb);
            flp.Tag = propInfo;
            flp.Name = "CalculatorParam_" + propInfo.Name;
            return flp;
        }

    }
}