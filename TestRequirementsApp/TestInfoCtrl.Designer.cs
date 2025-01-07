
namespace Nuvo.Requirements_Builder
{
    partial class TestInfoCtrl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            bindingDataSource1 = new System.Windows.Forms.BindingSource(components);
            textBoxProgram = new EmptyTextTextBox();
            label2 = new System.Windows.Forms.Label();
            textBoxSpecFileName = new EmptyTextTextBox();
            textBoxWaferName = new EmptyTextTextBox();
            label4 = new System.Windows.Forms.Label();
            textBoxSpecFileLoc = new EmptyTextTextBox();
            label5 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            textBoxTestName = new System.Windows.Forms.TextBox();
            buttonSelectFolder = new System.Windows.Forms.Button();
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            panel1 = new System.Windows.Forms.Panel();
            label6 = new System.Windows.Forms.Label();
            panel3 = new System.Windows.Forms.Panel();
            panel4 = new System.Windows.Forms.Panel();
            panelParamCount = new System.Windows.Forms.Panel();
            labelParamCount = new System.Windows.Forms.Label();
            nudParameterCount = new System.Windows.Forms.NumericUpDown();
            textBoxPartNumber = new EmptyTextTextBox();
            label3 = new System.Windows.Forms.Label();
            cbMeasuremntFileType = new System.Windows.Forms.ComboBox();
            label7 = new System.Windows.Forms.Label();
            testArticleCtrl1 = new TestArticleCtrl();
            panel2 = new System.Windows.Forms.Panel();
            buttonEdit = new System.Windows.Forms.Button();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            panel5 = new System.Windows.Forms.Panel();
            panelHeader1 = new PanelHeader();
            ((System.ComponentModel.ISupportInitialize)bindingDataSource1).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panelParamCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudParameterCount).BeginInit();
            panel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // bindingDataSource1
            // 
            bindingDataSource1.AllowNew = true;
            bindingDataSource1.CurrentChanged += bindingSource1_CurrentChanged;
            // 
            // textBoxProgram
            // 
            textBoxProgram.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            textBoxProgram.EmptyText = null;
            textBoxProgram.ForeColor = System.Drawing.SystemColors.WindowText;
            textBoxProgram.Location = new System.Drawing.Point(229, 23);
            textBoxProgram.Name = "textBoxProgram";
            textBoxProgram.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            textBoxProgram.Size = new System.Drawing.Size(175, 23);
            textBoxProgram.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(229, 5);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(53, 15);
            label2.TabIndex = 3;
            label2.Text = "Program";
            // 
            // textBoxSpecFileName
            // 
            textBoxSpecFileName.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            textBoxSpecFileName.EmptyText = null;
            textBoxSpecFileName.ForeColor = System.Drawing.SystemColors.WindowText;
            textBoxSpecFileName.Location = new System.Drawing.Point(229, 78);
            textBoxSpecFileName.Name = "textBoxSpecFileName";
            textBoxSpecFileName.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            textBoxSpecFileName.Size = new System.Drawing.Size(175, 23);
            textBoxSpecFileName.TabIndex = 8;
            textBoxSpecFileName.TextChanged += textBoxSpecFileName_TextChanged;
            // 
            // textBoxWaferName
            // 
            textBoxWaferName.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            textBoxWaferName.EmptyText = null;
            textBoxWaferName.ForeColor = System.Drawing.SystemColors.WindowText;
            textBoxWaferName.Location = new System.Drawing.Point(17, 78);
            textBoxWaferName.Name = "textBoxWaferName";
            textBoxWaferName.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            textBoxWaferName.Size = new System.Drawing.Size(206, 23);
            textBoxWaferName.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(17, 60);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(102, 15);
            label4.TabIndex = 5;
            label4.Text = "Wafer/Assy Name";
            // 
            // textBoxSpecFileLoc
            // 
            textBoxSpecFileLoc.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            textBoxSpecFileLoc.EmptyText = null;
            textBoxSpecFileLoc.ForeColor = System.Drawing.SystemColors.WindowText;
            textBoxSpecFileLoc.Location = new System.Drawing.Point(17, 125);
            textBoxSpecFileLoc.Name = "textBoxSpecFileLoc";
            textBoxSpecFileLoc.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            textBoxSpecFileLoc.Size = new System.Drawing.Size(347, 23);
            textBoxSpecFileLoc.TabIndex = 10;
            textBoxSpecFileLoc.TextChanged += textBoxSpecFileLoc_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(17, 107);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(102, 15);
            label5.TabIndex = 9;
            label5.Text = "Spec File Location";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(17, 5);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(62, 15);
            label1.TabIndex = 12;
            label1.Text = "Test Name";
            // 
            // textBoxTestName
            // 
            textBoxTestName.Location = new System.Drawing.Point(17, 23);
            textBoxTestName.Name = "textBoxTestName";
            textBoxTestName.Size = new System.Drawing.Size(204, 23);
            textBoxTestName.TabIndex = 14;
            // 
            // buttonSelectFolder
            // 
            buttonSelectFolder.Location = new System.Drawing.Point(370, 124);
            buttonSelectFolder.Name = "buttonSelectFolder";
            buttonSelectFolder.Size = new System.Drawing.Size(34, 23);
            buttonSelectFolder.TabIndex = 15;
            buttonSelectFolder.Text = "...";
            buttonSelectFolder.UseVisualStyleBackColor = true;
            buttonSelectFolder.Click += buttonSelectFolder_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(panel1);
            flowLayoutPanel2.Controls.Add(panel3);
            flowLayoutPanel2.Controls.Add(testArticleCtrl1);
            flowLayoutPanel2.Enabled = false;
            flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(978, 157);
            flowLayoutPanel2.TabIndex = 16;
            flowLayoutPanel2.WrapContents = false;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(textBoxProgram);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(buttonSelectFolder);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBoxTestName);
            panel1.Controls.Add(textBoxWaferName);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(textBoxSpecFileLoc);
            panel1.Controls.Add(textBoxSpecFileName);
            panel1.Controls.Add(label5);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(407, 151);
            panel1.TabIndex = 18;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(227, 60);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(88, 15);
            label6.TabIndex = 7;
            label6.Text = "Spec File Name";
            // 
            // panel3
            // 
            panel3.Controls.Add(panel4);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(416, 3);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(198, 151);
            panel3.TabIndex = 20;
            // 
            // panel4
            // 
            panel4.AutoSize = true;
            panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel4.Controls.Add(panelParamCount);
            panel4.Controls.Add(textBoxPartNumber);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(cbMeasuremntFileType);
            panel4.Controls.Add(label7);
            panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            panel4.Location = new System.Drawing.Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(198, 151);
            panel4.TabIndex = 23;
            // 
            // panelParamCount
            // 
            panelParamCount.Controls.Add(labelParamCount);
            panelParamCount.Controls.Add(nudParameterCount);
            panelParamCount.Location = new System.Drawing.Point(6, 99);
            panelParamCount.Name = "panelParamCount";
            panelParamCount.Size = new System.Drawing.Size(157, 49);
            panelParamCount.TabIndex = 22;
            panelParamCount.Visible = false;
            // 
            // labelParamCount
            // 
            labelParamCount.AutoSize = true;
            labelParamCount.Location = new System.Drawing.Point(3, 4);
            labelParamCount.Name = "labelParamCount";
            labelParamCount.Size = new System.Drawing.Size(97, 15);
            labelParamCount.TabIndex = 18;
            labelParamCount.Text = "Parameter Count";
            labelParamCount.Visible = false;
            // 
            // nudParameterCount
            // 
            nudParameterCount.Location = new System.Drawing.Point(3, 23);
            nudParameterCount.Name = "nudParameterCount";
            nudParameterCount.Size = new System.Drawing.Size(97, 23);
            nudParameterCount.TabIndex = 21;
            nudParameterCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPartNumber
            // 
            textBoxPartNumber.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            textBoxPartNumber.EmptyText = null;
            textBoxPartNumber.ForeColor = System.Drawing.SystemColors.WindowText;
            textBoxPartNumber.Location = new System.Drawing.Point(3, 23);
            textBoxPartNumber.Name = "textBoxPartNumber";
            textBoxPartNumber.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            textBoxPartNumber.Size = new System.Drawing.Size(125, 23);
            textBoxPartNumber.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 5);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(75, 15);
            label3.TabIndex = 5;
            label3.Text = "Part Number";
            // 
            // cbMeasuremntFileType
            // 
            cbMeasuremntFileType.FormattingEnabled = true;
            cbMeasuremntFileType.Location = new System.Drawing.Point(3, 78);
            cbMeasuremntFileType.Name = "cbMeasuremntFileType";
            cbMeasuremntFileType.Size = new System.Drawing.Size(155, 23);
            cbMeasuremntFileType.TabIndex = 20;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(6, 60);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(122, 15);
            label7.TabIndex = 19;
            label7.Text = "Measuremnt File Type";
            // 
            // testArticleCtrl1
            // 
            testArticleCtrl1.Dock = System.Windows.Forms.DockStyle.Right;
            testArticleCtrl1.Location = new System.Drawing.Point(625, 8);
            testArticleCtrl1.Margin = new System.Windows.Forms.Padding(8);
            testArticleCtrl1.MinimumSize = new System.Drawing.Size(330, 0);
            testArticleCtrl1.Name = "testArticleCtrl1";
            testArticleCtrl1.Size = new System.Drawing.Size(345, 141);
            testArticleCtrl1.TabIndex = 16;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(buttonEdit);
            panel2.Controls.Add(flowLayoutPanel2);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(3, 28);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(981, 160);
            panel2.TabIndex = 23;
            // 
            // buttonEdit
            // 
            buttonEdit.Dock = System.Windows.Forms.DockStyle.Left;
            buttonEdit.Location = new System.Drawing.Point(0, 0);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new System.Drawing.Size(18, 160);
            buttonEdit.TabIndex = 20;
            buttonEdit.Text = "EDIT";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(panel5);
            flowLayoutPanel1.Controls.Add(panel2);
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(987, 191);
            flowLayoutPanel1.TabIndex = 24;
            // 
            // panel5
            // 
            panel5.AutoSize = true;
            panel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel5.Controls.Add(panelHeader1);
            panel5.Dock = System.Windows.Forms.DockStyle.Top;
            panel5.Location = new System.Drawing.Point(3, 3);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(981, 19);
            panel5.TabIndex = 25;
            // 
            // panelHeader1
            // 
            panelHeader1.AutoSize = true;
            panelHeader1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelHeader1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            panelHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader1.HeaderText = "Header";
            panelHeader1.Location = new System.Drawing.Point(0, 0);
            panelHeader1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelHeader1.Name = "panelHeader1";
            panelHeader1.Size = new System.Drawing.Size(981, 19);
            panelHeader1.TabIndex = 25;
            // 
            // TestInfoCtrl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Controls.Add(flowLayoutPanel1);
            Name = "TestInfoCtrl";
            Size = new System.Drawing.Size(990, 194);
            Load += MeasurementInfoCtrl_Load;
            ((System.ComponentModel.ISupportInitialize)bindingDataSource1).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panelParamCount.ResumeLayout(false);
            panelParamCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudParameterCount).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private EmptyTextTextBox textBoxProgram;
        private System.Windows.Forms.Label label2;
        private EmptyTextTextBox textBoxSpecFileName;
        private EmptyTextTextBox textBoxWaferName;
        private System.Windows.Forms.Label label4;
        private EmptyTextTextBox textBoxSpecFileLoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTestName;
        private System.Windows.Forms.BindingSource bindingDataSource1;
        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private EmptyTextTextBox textBoxPartNumber;
        private System.Windows.Forms.NumericUpDown nudParameterCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMeasuremntFileType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelParamCount;
        private TestArticleCtrl testArticleCtrl1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel5;
        private PanelHeader panelHeader1;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Panel panelParamCount;
    }
}
