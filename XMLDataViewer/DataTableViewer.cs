using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XMLDataTableViewerApplication
{
    public partial class DataTableViewer : Form
    {
        public DataTableViewer(DataTable dt, string fileName)
        {
            InitializeComponent();
            Text = dt.TableName;
            lblRecordCount.Text = dt.Rows.Count.ToString();
            lblFilePath.Text = fileName;
            dataGridView1.DataSource = dt;
        }
    }
}