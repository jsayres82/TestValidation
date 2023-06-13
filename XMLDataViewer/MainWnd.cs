using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Qazi.GUI.CommonDialogs;

namespace XMLDataTableViewerApplication
{
    public partial class MainWnd : Form
    {
        public MainWnd()
        {
            InitializeComponent();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(openFileDialog1.FileName);
            DataTableSelectorWnd dtswnd = new DataTableSelectorWnd("", ds);
            dtswnd.ShowDialog();
            DataTable dt = ds.Tables[dtswnd.TableName];
            DataTableViewer dtviewer = new DataTableViewer(dt, openFileDialog1.FileName);
            dtviewer.MdiParent = this;
            dtviewer.Show();
        }
    }
}