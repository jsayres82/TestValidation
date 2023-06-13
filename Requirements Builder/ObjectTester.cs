using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomControls;
using TestValidation.Requirements;
using TestValidation.CharacteristicParameters;

namespace Requirements_Builder
{
    public partial class ObjectTester : UserControl
    {
        public ObjectTester()
        {
            InitializeComponent();
        }

        public void setObject(Object o)
        {
            this.invokeMethod(() =>
            {
                propertyGrid1.SelectedObject = o;
                panelHeader1.HeaderText = getName(o);
                objectMethodTester1.Initialize(o);
            });
        }

        private string getName(object o)
        {
            if (o is TestRequirement)
            {
                return (o as TestRequirement).Name;
            }
            else
            {
                return o.GetType().Name;
            }
        }
    }
}
