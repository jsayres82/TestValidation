using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Requirements_Builder
{
    public partial class PanelHeader : UserControl
    {
        public override DockStyle Dock
        {
            get { return base.Dock; }
            set { base.Dock = DockStyle.Top; }
        }

        public override string Text
        {
            get { return HeaderText; }
            set { HeaderText = value; }
        }

        public String HeaderText
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public PanelHeader()
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
        }
    }
}
