using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestValidation.Limits;

namespace Requirements_Builder
{
    public partial class RequirementInfoCtrl : UserControl
    {
        TestRequirement testRequirement;
        public RequirementInfoCtrl()
        {
            testRequirement = new TestRequirement()
            {
                Name = "Test Name"
            };

            InitializeComponent();
        }

        private void RequirementInfo_Load(object sender, EventArgs e)
        {

        }

        public void UpdateInfo(TestRequirement testRequirement, int num)
        {
            richTextBoxReqNum.Text = num.ToString();
            richTextBoxReqName.Text = testRequirement.Name;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxRequirementTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
