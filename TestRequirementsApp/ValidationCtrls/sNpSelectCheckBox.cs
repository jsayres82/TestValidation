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
        private Size expandedSize = new Size();
        public List<string> SelectedSParameterList = new List<string>();

        private Dictionary<string, CheckBox> CheckBoxDic = new Dictionary<string, CheckBox>();
        public sNpSelectCheckBox()
        {
            InitializeComponent();
            expandedSize = this.MinimumSize;
            initialize_sparameter_checkboxes();
        }

        public sNpSelectCheckBox(int numPorts, List<string> selectedPorts)
        {
            InitializeComponent();
            expandedSize = this.MinimumSize;
            NumPorts = numPorts;
            initialize_sparameter_checkboxes();
            foreach (string port in selectedPorts)
            {
                CheckBoxDic[port].CheckState = CheckState.Checked;
            }
        }

        public List<string> GetSParameterList()
        {
            return SelectedSParameterList;
        }

        public int GetNumPorts()
        {
            return NumPorts;
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
                this.Size = expandedSize;
            }
            else
            {
                btnEditSelection.Text = "Edit";
                this.Size = this.MinimumSize;
            }
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
        }

        private void nudNumPorts_ValueChanged(object sender, EventArgs e)
        {
            lbSParameters.Text = string.Empty;
            NumPorts = Convert.ToInt32(nudNumPorts.Value);
            var newSize = new Size(Math.Max(flowLayoutPanel1.MinimumSize.Width, NumPorts * 50),
                Math.Max(flowLayoutPanel1.MinimumSize.Height, NumPorts * 25));
            var deltaWidth = NumPorts * 50 - flowLayoutPanel1.MinimumSize.Width;
            var deltaHeight = NumPorts * 25 - flowLayoutPanel1.MinimumSize.Height;
            this.expandedSize = new Size(this.MinimumSize.Width + deltaWidth, this.MinimumSize.Height + deltaHeight);
            if (btnEditSelection.Text.Equals("Collapse"))
                this.Size = expandedSize;
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
