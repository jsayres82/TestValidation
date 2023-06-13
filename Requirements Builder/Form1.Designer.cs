
namespace Requirements_Builder
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.butonNewSpecFile = new System.Windows.Forms.Button();
            this.buttonOpenSpecFile = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flpHeader = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBoxRequirements = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxLimitTypes = new System.Windows.Forms.ComboBox();
            this.labelSpecTypes = new System.Windows.Forms.Label();
            this.buttonAddSpec = new System.Windows.Forms.Button();
            this.comboBoxParameters = new System.Windows.Forms.ComboBox();
            this.buttonSaveSpecFile = new System.Windows.Forms.Button();
            this.flp2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flp = new System.Windows.Forms.FlowLayoutPanel();
            this.measurementInfoCtrl1 = new Requirements_Builder.MeasurementInfoCtrl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flp.SuspendLayout();
            this.SuspendLayout();
            // 
            // butonNewSpecFile
            // 
            this.butonNewSpecFile.Location = new System.Drawing.Point(12, 12);
            this.butonNewSpecFile.Name = "butonNewSpecFile";
            this.butonNewSpecFile.Size = new System.Drawing.Size(99, 23);
            this.butonNewSpecFile.TabIndex = 0;
            this.butonNewSpecFile.Text = "New Spec File";
            this.butonNewSpecFile.UseVisualStyleBackColor = true;
            this.butonNewSpecFile.Click += new System.EventHandler(this.butonNewSpecFile_Click);
            // 
            // buttonOpenSpecFile
            // 
            this.buttonOpenSpecFile.Location = new System.Drawing.Point(134, 13);
            this.buttonOpenSpecFile.Name = "buttonOpenSpecFile";
            this.buttonOpenSpecFile.Size = new System.Drawing.Size(99, 23);
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
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.flpHeader);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxRequirements);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxLimitTypes);
            this.splitContainer1.Panel1.Controls.Add(this.labelSpecTypes);
            this.splitContainer1.Panel1.Controls.Add(this.buttonAddSpec);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxParameters);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSaveSpecFile);
            this.splitContainer1.Panel1.Controls.Add(this.buttonOpenSpecFile);
            this.splitContainer1.Panel1.Controls.Add(this.butonNewSpecFile);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.flp2);
            this.splitContainer1.Panel2.Controls.Add(this.flp);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(984, 811);
            this.splitContainer1.SplitterDistance = 137;
            this.splitContainer1.TabIndex = 0;
            // 
            // flpHeader
            // 
            this.flpHeader.Location = new System.Drawing.Point(239, 13);
            this.flpHeader.Name = "flpHeader";
            this.flpHeader.Size = new System.Drawing.Size(653, 58);
            this.flpHeader.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(535, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Requirement Types";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(719, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Add Requirement";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBoxRequirements
            // 
            this.comboBoxRequirements.FormattingEnabled = true;
            this.comboBoxRequirements.Location = new System.Drawing.Point(535, 93);
            this.comboBoxRequirements.Name = "comboBoxRequirements";
            this.comboBoxRequirements.Size = new System.Drawing.Size(178, 23);
            this.comboBoxRequirements.TabIndex = 7;
            this.comboBoxRequirements.SelectedIndexChanged += new System.EventHandler(this.comboBoxRequirements_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Limit Types";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(454, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Add Limit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBoxLimitTypes
            // 
            this.comboBoxLimitTypes.FormattingEnabled = true;
            this.comboBoxLimitTypes.Location = new System.Drawing.Point(270, 92);
            this.comboBoxLimitTypes.Name = "comboBoxLimitTypes";
            this.comboBoxLimitTypes.Size = new System.Drawing.Size(178, 23);
            this.comboBoxLimitTypes.TabIndex = 4;
            this.comboBoxLimitTypes.SelectedIndexChanged += new System.EventHandler(this.comboBoxLimitTypes_SelectedIndexChanged);
            // 
            // labelSpecTypes
            // 
            this.labelSpecTypes.AutoSize = true;
            this.labelSpecTypes.Location = new System.Drawing.Point(5, 74);
            this.labelSpecTypes.Name = "labelSpecTypes";
            this.labelSpecTypes.Size = new System.Drawing.Size(107, 15);
            this.labelSpecTypes.TabIndex = 3;
            this.labelSpecTypes.Text = "Specification Types";
            // 
            // buttonAddSpec
            // 
            this.buttonAddSpec.Location = new System.Drawing.Point(189, 92);
            this.buttonAddSpec.Name = "buttonAddSpec";
            this.buttonAddSpec.Size = new System.Drawing.Size(75, 23);
            this.buttonAddSpec.TabIndex = 2;
            this.buttonAddSpec.Text = "Add Spec";
            this.buttonAddSpec.UseVisualStyleBackColor = true;
            // 
            // comboBoxParameters
            // 
            this.comboBoxParameters.FormattingEnabled = true;
            this.comboBoxParameters.Location = new System.Drawing.Point(5, 92);
            this.comboBoxParameters.Name = "comboBoxParameters";
            this.comboBoxParameters.Size = new System.Drawing.Size(178, 23);
            this.comboBoxParameters.TabIndex = 1;
            // 
            // buttonSaveSpecFile
            // 
            this.buttonSaveSpecFile.Location = new System.Drawing.Point(13, 41);
            this.buttonSaveSpecFile.Name = "buttonSaveSpecFile";
            this.buttonSaveSpecFile.Size = new System.Drawing.Size(99, 23);
            this.buttonSaveSpecFile.TabIndex = 0;
            this.buttonSaveSpecFile.Text = "Save Spec File";
            this.buttonSaveSpecFile.UseVisualStyleBackColor = true;
            this.buttonSaveSpecFile.Click += new System.EventHandler(this.buttonSaveSpecFile_Click);
            // 
            // flp2
            // 
            this.flp2.AutoScroll = true;
            this.flp2.AutoSize = true;
            this.flp2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp2.Location = new System.Drawing.Point(0, 156);
            this.flp2.Name = "flp2";
            this.flp2.Size = new System.Drawing.Size(984, 514);
            this.flp2.TabIndex = 3;
            this.flp2.WrapContents = false;
            // 
            // flp
            // 
            this.flp.AutoScroll = true;
            this.flp.AutoSize = true;
            this.flp.Controls.Add(this.measurementInfoCtrl1);
            this.flp.Dock = System.Windows.Forms.DockStyle.Top;
            this.flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp.Location = new System.Drawing.Point(0, 0);
            this.flp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flp.MinimumSize = new System.Drawing.Size(0, 150);
            this.flp.Name = "flp";
            this.flp.Size = new System.Drawing.Size(984, 156);
            this.flp.TabIndex = 0;
            this.flp.WrapContents = false;
            // 
            // measurementInfoCtrl1
            // 
            this.measurementInfoCtrl1.AutoSize = true;
            this.measurementInfoCtrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.measurementInfoCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.measurementInfoCtrl1.fileName = null;
            this.measurementInfoCtrl1.folderName = null;
            this.measurementInfoCtrl1.Location = new System.Drawing.Point(3, 3);
            this.measurementInfoCtrl1.MinimumSize = new System.Drawing.Size(890, 150);
            this.measurementInfoCtrl1.Name = "measurementInfoCtrl1";
            this.measurementInfoCtrl1.Size = new System.Drawing.Size(890, 150);
            this.measurementInfoCtrl1.TabIndex = 1;
            this.measurementInfoCtrl1.Load += new System.EventHandler(this.measurementInfoCtrl1_Load);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(984, 811);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(950, 750);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flp.ResumeLayout(false);
            this.flp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonAddSpec;
        private System.Windows.Forms.ComboBox comboBoxParameters;
        private System.Windows.Forms.Button buttonOpenSpecFile;
        private System.Windows.Forms.Button butonNewSpecFile;
        private System.Windows.Forms.Label labelSpecTypes;
        private System.Windows.Forms.FlowLayoutPanel flp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxLimitTypes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBoxRequirements;
        private System.Windows.Forms.FlowLayoutPanel flpHeader;
        private MeasurementInfoCtrl measurementInfoCtrl1;
        private System.Windows.Forms.Button buttonSaveSpecFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FlowLayoutPanel flp2;
    }
}

