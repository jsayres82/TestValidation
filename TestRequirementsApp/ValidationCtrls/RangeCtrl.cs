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
        private Dictionary<string, GenericUnits> unitDic = new Dictionary<string, GenericUnits>();
        public RangeCtrl()
        {
            InitializeComponent();
        }

        public RangeCtrl(SpecRange<double> range)
        {
            InitializeComponent();
            if (range.IsSingleEnded)
            {
                lblMin.Visible = false;
                lblMax.Visible = false;
                tbMax.Visible = false;
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
            
            foreach (var unit in range.Units.ValidUnitTypes)
            {
                var tempUnit = Activator.CreateInstance(range.Units.GetType()) as GenericUnits;
                tempUnit.Unit = unit;
                foreach (var prefix in range.Units.ValidPrefixTypes)
                {
                    tempUnit.Prefix = prefix;
                    cbUnits.Items.Add(tempUnit.ToString());
                    unitDic.Add(tempUnit.ToString(), tempUnit);
                }
                cbUnits.Tag = tempUnit;
                if(cbUnits.Items.Count > 0)
                {
                    cbUnits.SelectedIndex = 0;
                    if (range.Units.Unit == null)
                    {
                        range.Units = unitDic[cbUnits.SelectedText];
                    }
                    else
                    {
                        if(cbUnits.Items.Contains(range.Units.Unit.ToString()))
                            cbUnits.SelectedText = range.Units.Unit.ToString();
                    }
                }
            }
        }
        
        public SpecRange<double> GetSpecRange()
        {
            if(lblValue.Visible)
            {
                Range.Minimum = Convert.ToDouble(tbMin.Text);
                Range.Maximum = Convert.ToDouble(tbMin.Text);
            }
            Range.IsSingleEnded = lblMin.Visible;
            Range.Minimum = Convert.ToDouble(tbMin.Text);
            Range.Maximum = Convert.ToDouble(tbMax.Text);
            Range.Units = unitDic[cbUnits.SelectedText];
            return Range;
        }
    }
}
