using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Requirements_Builder
{
    public partial class MethodTester : UserControl
    {
        #region Fields

        MethodInfo method;
        Object parametersObject;

        #endregion Fields

        #region Properties

        [Browsable(false)]
        public Object Instance { get; set; }

        #endregion Properties

        #region Constructors

        public MethodTester()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        public void Initialize(MethodInfo method, Object instance)
        {
            this.method = method;
            Instance = instance;
            this.header.HeaderText = DynamicMethodAdapter.getMethodSignature(method);

            this.parametersObject = getParametersObject(method);
            parametersPropertyGrid.SelectedObject = parametersObject;
        }

        private object getParametersObject(MethodInfo method)
        {
            return DynamicMethodAdapter.Create(method, DynamicMethodAdapter.Output.Memory);
        }

        private void invokeButton_Click(object sender, EventArgs e)
        {
            invokeMethodAndSetReturn();
        }

        private Object[] getParameterValues()
        {
            var names = getParameterNames();

            if (names.Length == 0)
            {
                return null;
            }

            var values = new Object[names.Length];

            if (parametersObject != null)
            {
                for (int i = 0; i < names.Length; i++)
                {
                    // Invoke the getter on the property with the given name
                    values[i] = parametersObject.GetType().GetProperty(names[i]).GetGetMethod().Invoke(parametersObject, null);
                }
            }

            return values;
        }

        private bool tryInvokeMethod(out object returnValue)
        {
            try
            {
                returnValue = method.Invoke(Instance, getParameterValues());
                return true;
            }
            catch (Exception e)
            {
                returnValue = e;
                MessageBox.Show("Exception while invoking method " + header.HeaderText + ":\n\r\n\r" + e.ToString());
                return false;
            }
        }

        private void invokeMethodAndSetReturn()
        {
            object value;
            if (tryInvokeMethod(out value) && !DynamicMethodAdapter.isVoid(method))
            {
                parametersObject.GetType().GetProperty("Return").GetSetMethod().Invoke(parametersObject, new Object[] { value });
            }

            parametersPropertyGrid.Refresh();
        }

        private String[] getParameterNames()
        {
            return DynamicMethodAdapter.getParameterNames(method);
        }

        #endregion Methods
    }
}

