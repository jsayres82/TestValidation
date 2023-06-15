using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomControls
{
    public static class ControlExtensions
    {
        public static void invokeMethod(this Control control, MethodInvoker method)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(method);
            }
            else
            {
                method();
            }
        }
    }
}
