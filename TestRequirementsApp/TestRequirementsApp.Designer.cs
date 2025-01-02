
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
            butonNewSpecFile = new System.Windows.Forms.Button();
            buttonOpenSpecFile = new System.Windows.Forms.Button();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            listBoxSerialNumbers = new System.Windows.Forms.ListBox();
            buttonProcessResults = new System.Windows.Forms.Button();
            buttonSelectFolder = new System.Windows.Forms.Button();
            textBoxDataFolder = new EmptyTextTextBox();
            labelSerialNumbers = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            comboBoxRequirements = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            comboBoxLimitTypes = new System.Windows.Forms.ComboBox();
            labelSpecTypes = new System.Windows.Forms.Label();
            comboBoxParameters = new System.Windows.Forms.ComboBox();
            buttonSaveSpecFile = new System.Windows.Forms.Button();
            flp2 = new System.Windows.Forms.FlowLayoutPanel();
            flp = new System.Windows.Forms.FlowLayoutPanel();
            testInfoCtrl1 = new TestInfoCtrl();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            btnAddSpec = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            flp.SuspendLayout();
            SuspendLayout();
            // 
            // butonNewSpecFile
            // 
            butonNewSpecFile.Location = new System.Drawing.Point(10, 6);
            butonNewSpecFile.Name = "butonNewSpecFile";
            butonNewSpecFile.Size = new System.Drawing.Size(99, 23);
            butonNewSpecFile.TabIndex = 0;
            butonNewSpecFile.Text = "New Spec File";
            butonNewSpecFile.UseVisualStyleBackColor = true;
            butonNewSpecFile.Click += butonNewSpecFile_Click;
            // 
            // buttonOpenSpecFile
            // 
            buttonOpenSpecFile.Location = new System.Drawing.Point(10, 35);
            buttonOpenSpecFile.Name = "buttonOpenSpecFile";
            buttonOpenSpecFile.Size = new System.Drawing.Size(99, 23);
            buttonOpenSpecFile.TabIndex = 0;
            buttonOpenSpecFile.Text = "Open Spec File";
            buttonOpenSpecFile.UseVisualStyleBackColor = true;
            buttonOpenSpecFile.Click += buttonOpenSpecFile_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Cursor = System.Windows.Forms.Cursors.HSplit;
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnAddSpec);
            splitContainer1.Panel1.Controls.Add(listBoxSerialNumbers);
            splitContainer1.Panel1.Controls.Add(buttonProcessResults);
            splitContainer1.Panel1.Controls.Add(buttonSelectFolder);
            splitContainer1.Panel1.Controls.Add(textBoxDataFolder);
            splitContainer1.Panel1.Controls.Add(labelSerialNumbers);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(comboBoxRequirements);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(comboBoxLimitTypes);
            splitContainer1.Panel1.Controls.Add(labelSpecTypes);
            splitContainer1.Panel1.Controls.Add(comboBoxParameters);
            splitContainer1.Panel1.Controls.Add(buttonSaveSpecFile);
            splitContainer1.Panel1.Controls.Add(buttonOpenSpecFile);
            splitContainer1.Panel1.Controls.Add(butonNewSpecFile);
            splitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(flp2);
            splitContainer1.Panel2.Controls.Add(flp);
            splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            splitContainer1.Size = new System.Drawing.Size(1559, 796);
            splitContainer1.SplitterDistance = 131;
            splitContainer1.TabIndex = 0;
            // 
            // listBoxSerialNumbers
            // 
            listBoxSerialNumbers.FormattingEnabled = true;
            listBoxSerialNumbers.ItemHeight = 15;
            listBoxSerialNumbers.Location = new System.Drawing.Point(1120, 27);
            listBoxSerialNumbers.Name = "listBoxSerialNumbers";
            listBoxSerialNumbers.Size = new System.Drawing.Size(120, 64);
            listBoxSerialNumbers.TabIndex = 19;
            listBoxSerialNumbers.SelectedIndexChanged += listBoxSerialNumbers_SelectedIndexChanged;
            // 
            // buttonProcessResults
            // 
            buttonProcessResults.Location = new System.Drawing.Point(971, 64);
            buttonProcessResults.Name = "buttonProcessResults";
            buttonProcessResults.Size = new System.Drawing.Size(105, 23);
            buttonProcessResults.TabIndex = 18;
            buttonProcessResults.Text = "Process Results";
            buttonProcessResults.UseVisualStyleBackColor = true;
            buttonProcessResults.Click += buttonProcessResults_Click;
            // 
            // buttonSelectFolder
            // 
            buttonSelectFolder.Location = new System.Drawing.Point(930, 64);
            buttonSelectFolder.Name = "buttonSelectFolder";
            buttonSelectFolder.Size = new System.Drawing.Size(34, 23);
            buttonSelectFolder.TabIndex = 17;
            buttonSelectFolder.Text = "...";
            buttonSelectFolder.UseVisualStyleBackColor = true;
            buttonSelectFolder.Click += buttonSelectFolder_Click;
            // 
            // textBoxDataFolder
            // 
            textBoxDataFolder.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            textBoxDataFolder.EmptyText = null;
            textBoxDataFolder.ForeColor = System.Drawing.SystemColors.WindowText;
            textBoxDataFolder.Location = new System.Drawing.Point(405, 65);
            textBoxDataFolder.Name = "textBoxDataFolder";
            textBoxDataFolder.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            textBoxDataFolder.Size = new System.Drawing.Size(521, 23);
            textBoxDataFolder.TabIndex = 16;
            // 
            // labelSerialNumbers
            // 
            labelSerialNumbers.AutoSize = true;
            labelSerialNumbers.Location = new System.Drawing.Point(1131, 6);
            labelSerialNumbers.Name = "labelSerialNumbers";
            labelSerialNumbers.Size = new System.Drawing.Size(84, 15);
            labelSerialNumbers.TabIndex = 9;
            labelSerialNumbers.Text = "SerialNumbers";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(405, 47);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(143, 15);
            label3.TabIndex = 9;
            label3.Text = "Measurement Data Folder";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(126, 68);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(66, 15);
            label2.TabIndex = 9;
            label2.Text = "Parameters";
            // 
            // comboBoxRequirements
            // 
            comboBoxRequirements.FormattingEnabled = true;
            comboBoxRequirements.Location = new System.Drawing.Point(212, 65);
            comboBoxRequirements.Name = "comboBoxRequirements";
            comboBoxRequirements.Size = new System.Drawing.Size(178, 23);
            comboBoxRequirements.TabIndex = 7;
            comboBoxRequirements.SelectedIndexChanged += comboBoxRequirements_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(126, 39);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(80, 15);
            label1.TabIndex = 6;
            label1.Text = "Requirements";
            // 
            // comboBoxLimitTypes
            // 
            comboBoxLimitTypes.FormattingEnabled = true;
            comboBoxLimitTypes.Location = new System.Drawing.Point(212, 36);
            comboBoxLimitTypes.Name = "comboBoxLimitTypes";
            comboBoxLimitTypes.Size = new System.Drawing.Size(178, 23);
            comboBoxLimitTypes.TabIndex = 4;
            comboBoxLimitTypes.SelectedIndexChanged += comboBoxLimitTypes_SelectedIndexChanged;
            // 
            // labelSpecTypes
            // 
            labelSpecTypes.AutoSize = true;
            labelSpecTypes.Location = new System.Drawing.Point(126, 9);
            labelSpecTypes.Name = "labelSpecTypes";
            labelSpecTypes.Size = new System.Drawing.Size(80, 15);
            labelSpecTypes.TabIndex = 3;
            labelSpecTypes.Text = "Part Numbers";
            // 
            // comboBoxParameters
            // 
            comboBoxParameters.FormattingEnabled = true;
            comboBoxParameters.Location = new System.Drawing.Point(212, 7);
            comboBoxParameters.Name = "comboBoxParameters";
            comboBoxParameters.Size = new System.Drawing.Size(178, 23);
            comboBoxParameters.TabIndex = 1;
            // 
            // buttonSaveSpecFile
            // 
            buttonSaveSpecFile.Location = new System.Drawing.Point(12, 64);
            buttonSaveSpecFile.Name = "buttonSaveSpecFile";
            buttonSaveSpecFile.Size = new System.Drawing.Size(99, 23);
            buttonSaveSpecFile.TabIndex = 0;
            buttonSaveSpecFile.Text = "Save Spec File";
            buttonSaveSpecFile.UseVisualStyleBackColor = true;
            buttonSaveSpecFile.Click += buttonSaveSpecFile_Click;
            // 
            // flp2
            // 
            flp2.AutoScroll = true;
            flp2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            flp2.BackColor = System.Drawing.Color.WhiteSmoke;
            flp2.Dock = System.Windows.Forms.DockStyle.Fill;
            flp2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flp2.Location = new System.Drawing.Point(0, 191);
            flp2.Name = "flp2";
            flp2.Size = new System.Drawing.Size(1559, 470);
            flp2.TabIndex = 3;
            flp2.WrapContents = false;
            flp2.Paint += flp2_Paint;
            // 
            // flp
            // 
            flp.AutoSize = true;
            flp.Controls.Add(testInfoCtrl1);
            flp.Dock = System.Windows.Forms.DockStyle.Top;
            flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flp.Location = new System.Drawing.Point(0, 0);
            flp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            flp.MinimumSize = new System.Drawing.Size(0, 150);
            flp.Name = "flp";
            flp.Size = new System.Drawing.Size(1559, 191);
            flp.TabIndex = 0;
            // 
            // testInfoCtrl1
            // 
            testInfoCtrl1.fileName = null;
            testInfoCtrl1.folderName = null;
            testInfoCtrl1.Location = new System.Drawing.Point(3, 4);
            testInfoCtrl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            testInfoCtrl1.Name = "testInfoCtrl1";
            testInfoCtrl1.Size = new System.Drawing.Size(1073, 183);
            testInfoCtrl1.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnAddSpec
            // 
            btnAddSpec.Location = new System.Drawing.Point(12, 93);
            btnAddSpec.Name = "btnAddSpec";
            btnAddSpec.Size = new System.Drawing.Size(99, 23);
            btnAddSpec.TabIndex = 20;
            btnAddSpec.Text = "Add Spec";
            btnAddSpec.UseVisualStyleBackColor = true;
            btnAddSpec.Click += btnAddSpec_Click;
            // 
            // TestRequirementsApp
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Silver;
            ClientSize = new System.Drawing.Size(1559, 796);
            Controls.Add(splitContainer1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MinimumSize = new System.Drawing.Size(1555, 758);
            Name = "TestRequirementsApp";
            Text = "Test Requirements App";
            Load += Form1_Load;
            Resize += Form1_Resize;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            flp.ResumeLayout(false);
            ResumeLayout(false);
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
        private System.Windows.Forms.Button btnAddSpec;
    }
}

