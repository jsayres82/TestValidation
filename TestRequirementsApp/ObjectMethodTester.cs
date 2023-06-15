using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.InteropServices;
using System.Threading;
using CustomControls;

namespace Requirements_Builder
{
    public partial class ObjectMethodTester : UserControl
    {
        #region Fields

        private Object objectToTest;
        private Int32 columns = 1;
        private Int32 rowHeight = 100;
        private Type currentType = null;
        private Dictionary<Type, List<MethodTester>> methodsByType = new Dictionary<Type, List<MethodTester>>();
        private List<MethodTester> methods = new List<MethodTester>();

        #endregion Fields

        #region Properties

        public Int32 Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        public Int32 RowHeight
        {
            get { return rowHeight; }
            set { rowHeight = value; }
        }

        #endregion Properties

        #region Constructors

        public ObjectMethodTester()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        public void Initialize(Object objectToTest)
        {
            this.objectToTest = objectToTest;
            Type type = objectToTest.GetType();
            this.panelHeader1.HeaderText = DynamicMethodAdapter.getFriendlyTypeName(type);

            if (type != currentType)
            {
                tableLayoutPanel.Visible = false;
            }
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync(type);
            }
        }

        private void initializeMethods(Type type, DoWorkEventArgs e)
        {
            if (currentType != type)
            {
                // Clear out previous methods
                foreach (var method in methods)
                {
                    if (tableLayoutPanel.Controls.Contains(method))
                    {
                        this.invokeMethod(() =>
                        {
                            tableLayoutPanel.Controls.Remove(method);
                        });
                    }
                }
                if (methodsByType.ContainsKey(type))
                {
                    methods = methodsByType[type];
                }
                else
                {
                    methods = new List<MethodTester>();
                    foreach (var method in getPublicMethods())
                    {
                        if (backgroundWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }

                        var tester = new MethodTester();
                        tester.Initialize(method, objectToTest);
                        methods.Add(tester);
                    }

                    methodsByType[type] = methods;
                }
            }

            foreach (var method in methods)
            {
                method.Instance = objectToTest;
            }
        }

        private List<MethodInfo> getPublicMethods()
        {
            return (from m in objectToTest.GetType().GetMethods()
                    where !m.DeclaringType.Namespace.StartsWith("System") && !m.IsSpecialName
                    orderby m.Name
                    select m).ToList();
        }

        private void layoutMethods(Type type)
        {
            if (currentType == type)
            {
                return;
            }

            Int32 rows = (Int32)Math.Ceiling(methods.Count / (Double)Columns);
            tableLayoutPanel.RowStyles.Clear();
            for (int i = 0; i < rows; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, (float)RowHeight));
            }

            tableLayoutPanel.ColumnStyles.Clear();
            for (int i = 0; i < columns; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)(1.0 / Columns)));
            }

            var column = 0;
            var row = -1;
            for (int i = 0; i < methods.Count; i++)
            {
                column = i % Columns;
                if (column == 0)
                {
                    row++;
                }

                var method = methods[i];

                if (!tableLayoutPanel.Controls.Contains(method))
                {
                    tableLayoutPanel.Controls.Add(method);
                }

                tableLayoutPanel.SetCellPosition(method,
                    new TableLayoutPanelCellPosition(column, row));

                method.Dock = DockStyle.Fill;
            }
        }

        #region Redraw Suspend/Resume
        [DllImport("user32.dll", EntryPoint = "SendMessageA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private const int WM_SETREDRAW = 0xB;

        private void SuspendDrawing()
        {
            SendMessage(Handle, WM_SETREDRAW, 0, 0);
        }

        private void ResumeDrawing() { ResumeDrawing(true); }
        private void ResumeDrawing(bool redraw)
        {
            SendMessage(Handle, WM_SETREDRAW, 1, 0);

            if (redraw)
            {
                Refresh();
            }
        }
        #endregion

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Type type = e.Argument as Type;
            e.Result = type;
            initializeMethods(type, e);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }

            Type type = e.Result as Type;
            try
            {
                SuspendLayout();
                //this.SuspendDrawing();
                layoutMethods(type);
            }
            finally
            {
                ResumeLayout(true);
                //this.ResumeDrawing(true);
            }

            tableLayoutPanel.Visible = true;

            if (type != currentType)
            {
                panel1.ScrollControlIntoView(tableLayoutPanel);
            }
            currentType = type;
        }

        #endregion Methods
    }
}
