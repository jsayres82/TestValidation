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
using static Nuvo.TestValidation.Limits.Units.UnitConverter;
using Nuvo.TestValidation.Parameters;
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Limits.Units;
using Nuvo.TestValidation.Limits.Validators;
using Nuvo.TestValidation.Parameters;
using static Nuvo.TestValidation.Limits.Units.UnitConverter;
using Nuvo.TestValidation.Limits.Validators;

namespace Nuvo.Requirements_Builder
{
    public partial class TestRequirementControl : UserControl
    {
        public event EventHandler RequirementUpdated;
        public RequirementInfoCtrl reqCtrl;
        public LimitCtrl limCtrl;
        public ParameterCtrl paramCtrl;
        public TestRequirement testRequirement;
        public Dictionary<string, Control> controls;
        public int reqNum;
        public Type[] limits, parameters, requirements;
        public bool IsDeleted = false;

        public TestRequirementControl(TestRequirement requirement, int count, Type[] l, Type[] r, Type[] p)
        {
            InitializeComponent();
            limits = l;
            parameters = p;
            requirements = r;
            reqNum = count;
            testRequirement = requirement;
            controls = new Dictionary<string, Control>();
            InitializeComponents();
        }

        public TestRequirementControl(int reqnum)
        {
            InitializeComponent();
            var parameter = new ParameterCtrl();
            parameters = parameter.parameterTypes;
            var requirement = new RequirementInfoCtrl();
            testRequirement = requirement.GetTestRequirement();
            reqNum = reqnum;
            controls = new Dictionary<string, Control>();

            reqCtrl = new RequirementInfoCtrl();
            flowLayoutPanel1.Controls.Add(reqCtrl);
            reqCtrl.UpdateInfo(testRequirement, reqNum);
            paramCtrl = new ParameterCtrl();
            flowLayoutPanel1.Controls.Add(paramCtrl);
            limCtrl = new LimitCtrl();
            flowLayoutPanel1.Controls.Add(limCtrl);
            paramCtrl.UpdateLimit(testRequirement.CharacteristicParameter);
            paramCtrl.ParameterUpdated += ParamCtrl_ParameterUpdated;
            limCtrl.UpdateLimit(testRequirement.Limit);
        }

        private void InitializeComponents()
        {
            foreach (var property in testRequirement.GetType().GetProperties())
            {

                if (property.MemberType != MemberTypes.Method)
                {
                    switch (property.Name.ToString())
                    {
                        case "Name":
                            reqCtrl = new RequirementInfoCtrl();
                            flowLayoutPanel1.Controls.Add(reqCtrl);
                            reqCtrl.UpdateInfo(testRequirement, reqNum);
                            break;
                        case "Limit":
                            limCtrl = new LimitCtrl();
                            limCtrl.UpdateLimit(testRequirement.Limit);
                            break;
                        case "CharacteristicParameter":
                            if (!property.Name.Equals("Property"))
                            {
                                paramCtrl = new ParameterCtrl();
                                paramCtrl.UpdateLimit(testRequirement.CharacteristicParameter);
                            }
                            break;
                        default:
                            break;
                    }
                    if (paramCtrl != null)
                    {
                        flowLayoutPanel1.Controls.Add(paramCtrl);
                        paramCtrl.ParameterUpdated += ParamCtrl_ParameterUpdated;
                    }
                    if (limCtrl != null)
                        flowLayoutPanel1.Controls.Add(limCtrl);
                }
            }
        }

        private void ParamCtrl_ParameterUpdated(object sender, EventArgs e)
        {
            var param = paramCtrl.Parameter;
            flowLayoutPanel1.Controls.Remove(limCtrl);
            setTestRequirementLimit(param);
            limCtrl = new LimitCtrl();
            flowLayoutPanel1.Controls.Add(limCtrl);
            limCtrl.UpdateLimit(testRequirement.Limit);
        }

        private void setTestRequirementLimit(GenericParameter param)
        {
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Enabled)
            {
                buttonEdit.Text = "EDIT";
                testRequirement.Name = reqCtrl.GetTestRequirement().Name;
                testRequirement.Limit = limCtrl.GetLimit();
                testRequirement.CharacteristicParameter = paramCtrl.GetParameter();
                flowLayoutPanel1.Enabled = false;
                btnDelete.Enabled = false;
                btnDelete.Visible = false;
                RequirementUpdated.Invoke(this, null);
            }
            else
            {
                buttonEdit.Text = "SAVE";
                btnDelete.Enabled = true;
                btnDelete.Visible = true;
                flowLayoutPanel1.Enabled = true;
            }
        }

        public Dictionary<string, string> GetPropertyValues()
        {
            Dictionary<string, string> propertyValues = new Dictionary<string, string>();

            foreach (var property in testRequirement.GetType().GetProperties())
            {
                if (controls.TryGetValue(property.Name, out Control control))
                {
                    if (control is TextBox textBox)
                    {
                        propertyValues[property.Name] = textBox.Text;
                    }
                }
            }

            return propertyValues;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            IsDeleted = true;
            RequirementUpdated.Invoke(this, new EventArgs());
        }
    }
}
