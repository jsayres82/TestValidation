
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
            btnAddSpec = new System.Windows.Forms.Button();
            listBoxSerialNumbers = new System.Windows.Forms.ListBox();
            buttonProcessResults = new System.Windows.Forms.Button();
            buttonSelectFolder = new System.Windows.Forms.Button();
            textBoxDataFolder = new EmptyTextTextBox();
            labelSerialNumbers = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            buttonSaveSpecFile = new System.Windows.Forms.Button();
            flp2 = new System.Windows.Forms.FlowLayoutPanel();
            flp = new System.Windows.Forms.FlowLayoutPanel();
            testInfoCtrl1 = new TestInfoCtrl();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
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
            splitContainer1.Panel1.Controls.Add(buttonSaveSpecFile);
            splitContainer1.Panel1.Controls.Add(buttonOpenSpecFile);
            splitContainer1.Panel1.Controls.Add(butonNewSpecFile);
            splitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(flp2);
            splitContainer1.Panel2.Controls.Add(flp);
            splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            splitContainer1.Size = new System.Drawing.Size(1639, 796);
            splitContainer1.SplitterDistance = 131;
            splitContainer1.TabIndex = 0;
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
            buttonProcessResults.Location = new System.Drawing.Point(698, 26);
            buttonProcessResults.Name = "buttonProcessResults";
            buttonProcessResults.Size = new System.Drawing.Size(105, 23);
            buttonProcessResults.TabIndex = 18;
            buttonProcessResults.Text = "Process Results";
            buttonProcessResults.UseVisualStyleBackColor = true;
            buttonProcessResults.Click += buttonProcessResults_Click;
            // 
            // buttonSelectFolder
            // 
            buttonSelectFolder.Location = new System.Drawing.Point(657, 26);
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
            textBoxDataFolder.Location = new System.Drawing.Point(132, 27);
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
            label3.Location = new System.Drawing.Point(132, 9);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(143, 15);
            label3.TabIndex = 9;
            label3.Text = "Measurement Data Folder";
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
            flp2.AutoSize = true;
            flp2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            flp2.BackColor = System.Drawing.Color.WhiteSmoke;
            flp2.Dock = System.Windows.Forms.DockStyle.Fill;
            flp2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flp2.Location = new System.Drawing.Point(0, 202);
            flp2.Name = "flp2";
            flp2.Size = new System.Drawing.Size(1639, 459);
            flp2.TabIndex = 3;
            flp2.WrapContents = false;
            // 
            // flp
            // 
            flp.AutoSize = true;
            flp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            flp.Controls.Add(testInfoCtrl1);
            flp.Dock = System.Windows.Forms.DockStyle.Top;
            flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flp.Location = new System.Drawing.Point(0, 0);
            flp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            flp.MinimumSize = new System.Drawing.Size(0, 150);
            flp.Name = "flp";
            flp.Size = new System.Drawing.Size(1639, 202);
            flp.TabIndex = 0;
            // 
            // testInfoCtrl1
            // 
            testInfoCtrl1.AutoSize = true;
            testInfoCtrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            testInfoCtrl1.fileName = null;
            testInfoCtrl1.folderName = null;
            testInfoCtrl1.Location = new System.Drawing.Point(3, 4);
            testInfoCtrl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            testInfoCtrl1.Name = "testInfoCtrl1";
            testInfoCtrl1.Size = new System.Drawing.Size(990, 194);
            testInfoCtrl1.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // TestRequirementsApp
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.Silver;
            ClientSize = new System.Drawing.Size(1639, 796);
            Controls.Add(splitContainer1);
            DoubleBuffered = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MinimumSize = new System.Drawing.Size(1655, 758);
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
            flp.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonOpenSpecFile;
        private System.Windows.Forms.Button butonNewSpecFile;
        private System.Windows.Forms.FlowLayoutPanel flp;
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

