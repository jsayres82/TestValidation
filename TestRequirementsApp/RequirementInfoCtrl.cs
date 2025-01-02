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

namespace Nuvo.Requirements_Builder
{
    public partial class RequirementInfoCtrl : UserControl
    {
        private TestRequirement testRequirement;
        public RequirementInfoCtrl()
        {
            testRequirement = new TestRequirement()
            {
                Name = "Test Name"
            };

            InitializeComponent();
        }

        public TestRequirement GetTestRequirement()
        {
            testRequirement.Name = richTextBoxReqName.Text;
            return testRequirement;
        }

        private void RequirementInfo_Load(object sender, EventArgs e)
        {

        }

        public void UpdateInfo(TestRequirement testRequirement, int num)
        {
            richTextBoxReqNum.Text = num.ToString();
            richTextBoxReqName.Text = testRequirement.Name;
        }

    }
}
