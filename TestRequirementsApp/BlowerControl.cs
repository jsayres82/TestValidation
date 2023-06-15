// © Parata Systems, LLC 2010
// All rights reserved.

using System;
using System.Windows.Forms;

namespace Requirements_Builder
{
    public partial class BlowerControl : UserControl
    {
        public double Value;
     
        public BlowerControl()
        {
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(settingBox.Text))
            {
                MessageBox.Show("Please enter a blower setting.");
                return;
            }

            Double setting = 0;
            if (!Double.TryParse(settingBox.Text, out setting))
            {
                MessageBox.Show(String.Format("\"{0}\" is an invalid blower setting.", settingBox.Text));
                return;
            }

            Value = setting;
        }
    }
}
