
namespace Requirements_Builder
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
            this.components = new System.ComponentModel.Container();
            this.bindingDataSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxProgram = new Requirements_Builder.EmptyTextTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSpecFileName = new Requirements_Builder.EmptyTextTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxWaferName = new Requirements_Builder.EmptyTextTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSpecFileLoc = new Requirements_Builder.EmptyTextTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTestName = new System.Windows.Forms.TextBox();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.testArticle1 = new Requirements_Builder.TestArticleCtrl();
            this.panelHeader1 = new Requirements_Builder.PanelHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingDataSource1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingDataSource1
            // 
            this.bindingDataSource1.AllowNew = true;
            this.bindingDataSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // textBoxProgram
            // 
            this.textBoxProgram.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxProgram.EmptyText = null;
            this.textBoxProgram.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxProgram.Location = new System.Drawing.Point(240, 23);
            this.textBoxProgram.Name = "textBoxProgram";
            this.textBoxProgram.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxProgram.Size = new System.Drawing.Size(175, 23);
            this.textBoxProgram.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Program";
            // 
            // textBoxSpecFileName
            // 
            this.textBoxSpecFileName.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxSpecFileName.EmptyText = null;
            this.textBoxSpecFileName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxSpecFileName.Location = new System.Drawing.Point(240, 78);
            this.textBoxSpecFileName.Name = "textBoxSpecFileName";
            this.textBoxSpecFileName.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxSpecFileName.Size = new System.Drawing.Size(175, 23);
            this.textBoxSpecFileName.TabIndex = 8;
            this.textBoxSpecFileName.TextChanged += new System.EventHandler(this.textBoxSpecFileName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Spec File Name";
            // 
            // textBoxWaferName
            // 
            this.textBoxWaferName.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxWaferName.EmptyText = null;
            this.textBoxWaferName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxWaferName.Location = new System.Drawing.Point(17, 78);
            this.textBoxWaferName.Name = "textBoxWaferName";
            this.textBoxWaferName.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxWaferName.Size = new System.Drawing.Size(206, 23);
            this.textBoxWaferName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Wafer/Assy Name";
            // 
            // textBoxSpecFileLoc
            // 
            this.textBoxSpecFileLoc.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxSpecFileLoc.EmptyText = null;
            this.textBoxSpecFileLoc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxSpecFileLoc.Location = new System.Drawing.Point(17, 125);
            this.textBoxSpecFileLoc.Name = "textBoxSpecFileLoc";
            this.textBoxSpecFileLoc.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxSpecFileLoc.Size = new System.Drawing.Size(521, 23);
            this.textBoxSpecFileLoc.TabIndex = 10;
            this.textBoxSpecFileLoc.TextChanged += new System.EventHandler(this.textBoxSpecFileLoc_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Spec File Location";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Test Name";
            // 
            // textBoxTestName
            // 
            this.textBoxTestName.Location = new System.Drawing.Point(17, 23);
            this.textBoxTestName.Name = "textBoxTestName";
            this.textBoxTestName.Size = new System.Drawing.Size(204, 23);
            this.textBoxTestName.TabIndex = 14;
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Location = new System.Drawing.Point(542, 124);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(34, 23);
            this.buttonSelectFolder.TabIndex = 15;
            this.buttonSelectFolder.Text = "...";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonEdit);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1076, 160);
            this.flowLayoutPanel1.TabIndex = 16;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(3, 3);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(18, 154);
            this.buttonEdit.TabIndex = 19;
            this.buttonEdit.Text = "EDIT";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.panel1);
            this.flowLayoutPanel2.Controls.Add(this.testArticle1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Enabled = false;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(27, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1049, 154);
            this.flowLayoutPanel2.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxProgram);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonSelectFolder);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxTestName);
            this.panel1.Controls.Add(this.textBoxWaferName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxSpecFileLoc);
            this.panel1.Controls.Add(this.textBoxSpecFileName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 151);
            this.panel1.TabIndex = 18;
            // 
            // testArticle1
            // 
            this.testArticle1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.testArticle1.Location = new System.Drawing.Point(710, 3);
            this.testArticle1.Name = "testArticle1";
            this.testArticle1.Size = new System.Drawing.Size(331, 151);
            this.testArticle1.TabIndex = 19;
            // 
            // panelHeader1
            // 
            this.panelHeader1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader1.HeaderText = "Header";
            this.panelHeader1.Location = new System.Drawing.Point(0, 0);
            this.panelHeader1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelHeader1.Name = "panelHeader1";
            this.panelHeader1.Size = new System.Drawing.Size(1076, 23);
            this.panelHeader1.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1076, 160);
            this.panel2.TabIndex = 23;
            // 
            // TestInfoCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelHeader1);
            this.Name = "TestInfoCtrl";
            this.Size = new System.Drawing.Size(1076, 183);
            this.Load += new System.EventHandler(this.MeasurementInfoCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingDataSource1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private EmptyTextTextBox textBoxProgram;
        private System.Windows.Forms.Label label2;
        private EmptyTextTextBox textBoxSpecFileName;
        private System.Windows.Forms.Label label3;
        private EmptyTextTextBox textBoxWaferName;
        private System.Windows.Forms.Label label4;
        private EmptyTextTextBox textBoxSpecFileLoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTestName;
        private System.Windows.Forms.BindingSource bindingDataSource1;
        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private PanelHeader panelHeader1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private TestArticleCtrl testArticle1;
    }
}
