using Nuvo.TestValidation.Calculators;
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Limits.Units;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nuvo.Requirements_Builder.ValidationCtrls
{
    public partial class RangeCtrl : UserControl
    {
        SpecRange<double> Range = new SpecRange<double>();
        private Dictionary<string, PrefixEnum> prefixDic = new Dictionary<string, PrefixEnum>();
        private Dictionary<string, UnitEnum> unitDic = new Dictionary<string, UnitEnum>();
        public RangeCtrl()
        {
            InitializeComponent();
        }

        public RangeCtrl(SpecRange<double> range)
        {
            InitializeComponent();

            Range = new SpecRange<double>();
            prefixDic = new Dictionary<string, PrefixEnum>();
            unitDic = new Dictionary<string, UnitEnum>();
            Range = range;
            if (range.IsSingleEnded)
            {
                lblMin.Visible = false;
                lblMax.Visible = false;
                tbMax.Visible = false;
                lblValue.Enabled = true;
                lblValue.Visible = true;
            }
            else
            {
                if (range.Minimum == null)
                    tbMin.Text = "0";
                else
                    tbMin.Text = range.Minimum.ToString();

                if (range.Maximum == null)
                    tbMax.Text = "0";
                else
                    tbMax.Text = range.Maximum.ToString();
            }
            prefixDic.Clear();
            unitDic.Clear();
            foreach (var unit in range.Units.ValidUnitTypes)
            {
                var r = new SpecRange<double>();
                var tempUnit = Activator.CreateInstance(range.Units.GetType()) as GenericUnits;
                tempUnit.Unit = unit;
                foreach (var prefix in range.Units.ValidPrefixTypes)
                {
                    var str = new string("");
                    tempUnit.Prefix = prefix;
                    prefixDic.Add(tempUnit.ToString(), prefix);
                    unitDic.Add(tempUnit.ToString(), unit);
                    str = tempUnit.ToString();
                    cbUnits.Items.Add(str);
                }
            }

            cbUnits.Tag = Range.Units;

            if (Range.Units == null)
            {
                if (cbUnits.Items.Count > 0)
                {
                    cbUnits.SelectedIndex = 0;
                    if (cbUnits.Items.Contains(range.Units.ToString()))
                        cbUnits.SelectedItem = Range.Units.ToString();
                }
            }
            else
            {
                cbUnits.SelectedItem = Range.Units.ToString();
            }
        }


        public SpecRange<double> GetSpecRange()
        {

            if (lblValue.Visible)
            {
                Range.Minimum = Convert.ToDouble(tbMin.Text);
                Range.Maximum = Convert.ToDouble(tbMin.Text);
            }
            Range.IsSingleEnded = lblValue.Visible;
            Range.Minimum = Convert.ToDouble(tbMin.Text);
            Range.Maximum = Convert.ToDouble(tbMax.Text);
            Range.Units.Prefix = prefixDic[cbUnits.SelectedItem.ToString()];
            Range.Units.Unit = unitDic[cbUnits.SelectedItem.ToString()];
            return Range;
        }
    }
}
