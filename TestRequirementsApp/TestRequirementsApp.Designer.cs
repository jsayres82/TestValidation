
namespace Nuvo.Requirements_Builder
{
    partial class TestRequirementsApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestRequirementsApp));
            this.butonNewSpecFile = new System.Windows.Forms.Button();
            this.buttonOpenSpecFile = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBoxSerialNumbers = new System.Windows.Forms.ListBox();
            this.buttonProcessResults = new System.Windows.Forms.Button();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.textBoxDataFolder = new Nuvo.Requirements_Builder.EmptyTextTextBox();
            this.labelSerialNumbers = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxRequirements = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxLimitTypes = new System.Windows.Forms.ComboBox();
            this.labelSpecTypes = new System.Windows.Forms.Label();
            this.comboBoxParameters = new System.Windows.Forms.ComboBox();
            this.buttonSaveSpecFile = new System.Windows.Forms.Button();
            this.flp2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flp = new System.Windows.Forms.FlowLayoutPanel();
            this.testInfoCtrl1 = new Nuvo.Requirements_Builder.TestInfoCtrl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flp.SuspendLayout();
            this.SuspendLayout();
            // 
            // butonNewSpecFile
            // 
            this.butonNewSpecFile.Location = new System.Drawing.Point(11, 8);
            this.butonNewSpecFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butonNewSpecFile.Name = "butonNewSpecFile";
            this.butonNewSpecFile.Size = new System.Drawing.Size(113, 31);
            this.butonNewSpecFile.TabIndex = 0;
            this.butonNewSpecFile.Text = "New Spec File";
            this.butonNewSpecFile.UseVisualStyleBackColor = true;
            this.butonNewSpecFile.Click += new System.EventHandler(this.butonNewSpecFile_Click);
            // 
            // buttonOpenSpecFile
            // 
            this.buttonOpenSpecFile.Location = new System.Drawing.Point(11, 47);
            this.buttonOpenSpecFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonOpenSpecFile.Name = "buttonOpenSpecFile";
            this.buttonOpenSpecFile.Size = new System.Drawing.Size(113, 31);
            this.buttonOpenSpecFile.TabIndex = 0;
            this.buttonOpenSpecFile.Text = "Open Spec File";
            this.buttonOpenSpecFile.UseVisualStyleBackColor = true;
            this.buttonOpenSpecFile.Click += new System.EventHandler(this.buttonOpenSpecFile_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBoxSerialNumbers);
            this.splitContainer1.Panel1.Controls.Add(this.buttonProcessResults);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSelectFolder);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxDataFolder);
            this.splitContainer1.Panel1.Controls.Add(this.labelSerialNumbers);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxRequirements);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxLimitTypes);
            this.splitContainer1.Panel1.Controls.Add(this.labelSpecTypes);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxParameters);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSaveSpecFile);
            this.splitContainer1.Panel1.Controls.Add(this.buttonOpenSpecFile);
            this.splitContainer1.Panel1.Controls.Add(this.butonNewSpecFile);
            this.splitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flp2);
            this.splitContainer1.Panel2.Controls.Add(this.flp);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(1782, 1061);
            this.splitContainer1.SplitterDistance = 131;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // listBoxSerialNumbers
            // 
            this.listBoxSerialNumbers.FormattingEnabled = true;
            this.listBoxSerialNumbers.ItemHeight = 20;
            this.listBoxSerialNumbers.Location = new System.Drawing.Point(1280, 36);
            this.listBoxSerialNumbers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBoxSerialNumbers.Name = "listBoxSerialNumbers";
            this.listBoxSerialNumbers.Size = new System.Drawing.Size(137, 84);
            this.listBoxSerialNumbers.TabIndex = 19;
            this.listBoxSerialNumbers.SelectedIndexChanged += new System.EventHandler(this.listBoxSerialNumbers_SelectedIndexChanged);
            // 
            // buttonProcessResults
            // 
            this.buttonProcessResults.Location = new System.Drawing.Point(1110, 85);
            this.buttonProcessResults.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonProcessResults.Name = "buttonProcessResults";
            this.buttonProcessResults.Size = new System.Drawing.Size(120, 31);
            this.buttonProcessResults.TabIndex = 18;
            this.buttonProcessResults.Text = "Process Results";
            this.buttonProcessResults.UseVisualStyleBackColor = true;
            this.buttonProcessResults.Click += new System.EventHandler(this.buttonProcessResults_Click);
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Location = new System.Drawing.Point(1063, 85);
            this.buttonSelectFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(39, 31);
            this.buttonSelectFolder.TabIndex = 17;
            this.buttonSelectFolder.Text = "...";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // textBoxDataFolder
            // 
            this.textBoxDataFolder.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxDataFolder.EmptyText = null;
            this.textBoxDataFolder.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxDataFolder.Location = new System.Drawing.Point(463, 87);
            this.textBoxDataFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxDataFolder.Name = "textBoxDataFolder";
            this.textBoxDataFolder.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxDataFolder.Size = new System.Drawing.Size(595, 27);
            this.textBoxDataFolder.TabIndex = 16;
            // 
            // labelSerialNumbers
            // 
            this.labelSerialNumbers.AutoSize = true;
            this.labelSerialNumbers.Location = new System.Drawing.Point(1293, 8);
            this.labelSerialNumbers.Name = "labelSerialNumbers";
            this.labelSerialNumbers.Size = new System.Drawing.Size(106, 20);
            this.labelSerialNumbers.TabIndex = 9;
            this.labelSerialNumbers.Text = "SerialNumbers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(463, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Measurement Data Folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Parameters";
            // 
            // comboBoxRequirements
            // 
            this.comboBoxRequirements.FormattingEnabled = true;
            this.comboBoxRequirements.Location = new System.Drawing.Point(242, 87);
            this.comboBoxRequirements.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxRequirements.Name = "comboBoxRequirements";
            this.comboBoxRequirements.Size = new System.Drawing.Size(203, 28);
            this.comboBoxRequirements.TabIndex = 7;
            this.comboBoxRequirements.SelectedIndexChanged += new System.EventHandler(this.comboBoxRequirements_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Requirements";
            // 
            // comboBoxLimitTypes
            // 
            this.comboBoxLimitTypes.FormattingEnabled = true;
            this.comboBoxLimitTypes.Location = new System.Drawing.Point(242, 48);
            this.comboBoxLimitTypes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxLimitTypes.Name = "comboBoxLimitTypes";
            this.comboBoxLimitTypes.Size = new System.Drawing.Size(203, 28);
            this.comboBoxLimitTypes.TabIndex = 4;
            this.comboBoxLimitTypes.SelectedIndexChanged += new System.EventHandler(this.comboBoxLimitTypes_SelectedIndexChanged);
            // 
            // labelSpecTypes
            // 
            this.labelSpecTypes.AutoSize = true;
            this.labelSpecTypes.Location = new System.Drawing.Point(144, 12);
            this.labelSpecTypes.Name = "labelSpecTypes";
            this.labelSpecTypes.Size = new System.Drawing.Size(98, 20);
            this.labelSpecTypes.TabIndex = 3;
            this.labelSpecTypes.Text = "Part Numbers";
            // 
            // comboBoxParameters
            // 
            this.comboBoxParameters.FormattingEnabled = true;
            this.comboBoxParameters.Location = new System.Drawing.Point(242, 9);
            this.comboBoxParameters.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxParameters.Name = "comboBoxParameters";
            this.comboBoxParameters.Size = new System.Drawing.Size(203, 28);
            this.comboBoxParameters.TabIndex = 1;
            // 
            // buttonSaveSpecFile
            // 
            this.buttonSaveSpecFile.Location = new System.Drawing.Point(14, 85);
            this.buttonSaveSpecFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSaveSpecFile.Name = "buttonSaveSpecFile";
            this.buttonSaveSpecFile.Size = new System.Drawing.Size(113, 31);
            this.buttonSaveSpecFile.TabIndex = 0;
            this.buttonSaveSpecFile.Text = "Save Spec File";
            this.buttonSaveSpecFile.UseVisualStyleBackColor = true;
            this.buttonSaveSpecFile.Click += new System.EventHandler(this.buttonSaveSpecFile_Click);
            // 
            // flp2
            // 
            this.flp2.AutoScroll = true;
            this.flp2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flp2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flp2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp2.Location = new System.Drawing.Point(0, 254);
            this.flp2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flp2.Name = "flp2";
            this.flp2.Size = new System.Drawing.Size(1782, 671);
            this.flp2.TabIndex = 3;
            this.flp2.WrapContents = false;
            this.flp2.Paint += new System.Windows.Forms.PaintEventHandler(this.flp2_Paint);
            // 
            // flp
            // 
            this.flp.AutoSize = true;
            this.flp.Controls.Add(this.testInfoCtrl1);
            this.flp.Dock = System.Windows.Forms.DockStyle.Top;
            this.flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp.Location = new System.Drawing.Point(0, 0);
            this.flp.MinimumSize = new System.Drawing.Size(0, 200);
            this.flp.Name = "flp";
            this.flp.Size = new System.Drawing.Size(1782, 254);
            this.flp.TabIndex = 0;
            // 
            // testInfoCtrl1
            // 
            this.testInfoCtrl1.fileName = null;
            this.testInfoCtrl1.folderName = null;
            this.testInfoCtrl1.Location = new System.Drawing.Point(3, 5);
            this.testInfoCtrl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.testInfoCtrl1.Name = "testInfoCtrl1";
            this.testInfoCtrl1.Size = new System.Drawing.Size(1226, 244);
            this.testInfoCtrl1.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // TestRequirementsApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1782, 1061);
            this.Controls.Add(this.splitContainer1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1775, 998);
            this.Name = "TestRequirementsApp";
            this.Text = "Test Requirements App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox comboBoxParameters;
        private System.Windows.Forms.Button buttonOpenSpecFile;
        private System.Windows.Forms.Button butonNewSpecFile;
        private System.Windows.Forms.Label labelSpecTypes;
        private System.Windows.Forms.FlowLayoutPanel flp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxLimitTypes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxRequirements;
        private TestInfoCtrl measurementInfoCtrl1;
        private System.Windows.Forms.Button buttonSaveSpecFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FlowLayoutPanel flp2;
        private TestInfoCtrl testInfoCtrl1;
        private System.Windows.Forms.Button buttonProcessResults;
        private System.Windows.Forms.Button buttonSelectFolder;
        private EmptyTextTextBox textBoxDataFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListBox listBoxSerialNumbers;
        private System.Windows.Forms.Label labelSerialNumbers;
    }
}

