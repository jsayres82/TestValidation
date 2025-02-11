using MicrowaveNetworks.Touchstone;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Nuvo.Requirements_Builder.ValidationCtrls
{
    public partial class sNpSelectCheckBox : UserControl
    {
        public int NumPorts = 1;
        public List<string> PortList = new List<string>();
        private Dictionary<string, int> sParameterStrDic = new Dictionary<string, int>();

        public List<string> SelectedSParameterList = new List<string>();

        private Dictionary<string, CheckBox> CheckBoxDic = new Dictionary<string, CheckBox>();
        public sNpSelectCheckBox()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Create all checkboxes that will allow user to select desired S-Parameters
        /// </summary>
        void initialize_sparameter_checkboxes()
        {
            PortList = new List<string>();
            sParameterStrDic = new Dictionary<string, int>();
            SelectedSParameterList = new List<string>();
            CheckBoxDic = new Dictionary<string, CheckBox>();
            flowLayoutPanel1.Controls.Clear();

            for (int i = 1; i <= NumPorts; i++)
            {
                for (int j = 1; j <= NumPorts; j++)
                {
                    var cbSxP = new CheckBox();

                    cbSxP.AutoSize = true;
                    cbSxP.UseVisualStyleBackColor = true;
                    if (i >= 10 | j > 10)
                    {
                        cbSxP.Name = @$"cbS{i}_{j}";
                        cbSxP.Text = @$"S{i}_{j}";
                        PortList.Add(@$"S{i}_{j}");
                        sParameterStrDic.Add(PortList.Last(), PortList.Count - 1);
                    }
                    else
                    {
                        cbSxP.Name = @$"cbS{i}{j}";
                        cbSxP.Text = @$"S{i}{j}";
                        PortList.Add(@$"S{i}{j}");
                        sParameterStrDic.Add(PortList.Last(), PortList.Count - 1);
                    }
                    flowLayoutPanel1.Controls.Add(cbSxP);
                    CheckBoxDic.Add(cbSxP.Text, cbSxP);
                    cbSxP.CheckStateChanged += CbSxP_CheckStateChanged;
                }
            }
        }

        private void CbSxP_CheckStateChanged(object sender, EventArgs e)
        {
            var sparam = ((sender as CheckBox).Text);

            if ((sender as CheckBox).Checked)
            {
                lbSParameters.Items.Add(sparam);
                SelectedSParameterList.Add(sparam);
                (sender as CheckBox).BackColor = System.Drawing.Color.Lime;
            }
            else
            {
                lbSParameters.Items.Remove(sparam);
                SelectedSParameterList.Remove(sparam);
                (sender as CheckBox).BackColor = System.Drawing.Color.Transparent;
            }
        }

        private void btnEditSelection_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2Collapsed)
            {
                btnEditSelection.Text = "Collapse";
            }
            else
            {
                btnEditSelection.Text = "Edit";
            }
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
        }

        private void nudNumPorts_ValueChanged(object sender, EventArgs e)
        {
            lbSParameters.Text = string.Empty;
            NumPorts = Convert.ToInt32(nudNumPorts.Value);
            var newSize = new Size(Math.Max(lbSParameters.MinimumSize.Width, NumPorts * 20),
                Math.Max(lbSParameters.MinimumSize.Height, NumPorts * 10) + 58);
            this.Size = newSize;
            foreach (var sparam in sParameterStrDic.Keys)
            {
                CheckBoxDic[sparam].CheckStateChanged -= CbSxP_CheckStateChanged;
                CheckBoxDic[sparam].BackColor = System.Drawing.Color.Transparent;
                CheckBoxDic[sparam].Checked = false;
                lbSParameters.Items.Remove(sparam);
                SelectedSParameterList.Remove(sparam);
                CheckBoxDic[sparam].CheckStateChanged += CbSxP_CheckStateChanged;
            }
            initialize_sparameter_checkboxes();
        }
    }
}
