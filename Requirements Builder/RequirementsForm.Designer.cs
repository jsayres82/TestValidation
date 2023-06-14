
namespace Requirements_Builder
{
    partial class RequirementsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequirementsForm));
            this.butonNewSpecFile = new System.Windows.Forms.Button();
            this.buttonOpenSpecFile = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
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
            this.measurementInfoCtrl1 = new Requirements_Builder.TestInfoCtrl();
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
            this.butonNewSpecFile.Location = new System.Drawing.Point(12, 34);
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
            this.buttonOpenSpecFile.Location = new System.Drawing.Point(131, 35);
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
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flp2);
            this.splitContainer1.Panel2.Controls.Add(this.flp);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(1782, 1103);
            this.splitContainer1.SplitterDistance = 100;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(989, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Requirement Types";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1200, 38);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 31);
            this.button2.TabIndex = 8;
            this.button2.Text = "Add Requirement";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBoxRequirements
            // 
            this.comboBoxRequirements.FormattingEnabled = true;
            this.comboBoxRequirements.Location = new System.Drawing.Point(989, 38);
            this.comboBoxRequirements.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxRequirements.Name = "comboBoxRequirements";
            this.comboBoxRequirements.Size = new System.Drawing.Size(203, 28);
            this.comboBoxRequirements.TabIndex = 7;
            this.comboBoxRequirements.SelectedIndexChanged += new System.EventHandler(this.comboBoxRequirements_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(687, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Limit Types";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(897, 37);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "Add Limit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBoxLimitTypes
            // 
            this.comboBoxLimitTypes.FormattingEnabled = true;
            this.comboBoxLimitTypes.Location = new System.Drawing.Point(687, 37);
            this.comboBoxLimitTypes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxLimitTypes.Name = "comboBoxLimitTypes";
            this.comboBoxLimitTypes.Size = new System.Drawing.Size(203, 28);
            this.comboBoxLimitTypes.TabIndex = 4;
            this.comboBoxLimitTypes.SelectedIndexChanged += new System.EventHandler(this.comboBoxLimitTypes_SelectedIndexChanged);
            // 
            // labelSpecTypes
            // 
            this.labelSpecTypes.AutoSize = true;
            this.labelSpecTypes.Location = new System.Drawing.Point(384, 13);
            this.labelSpecTypes.Name = "labelSpecTypes";
            this.labelSpecTypes.Size = new System.Drawing.Size(136, 20);
            this.labelSpecTypes.TabIndex = 3;
            this.labelSpecTypes.Text = "Specification Types";
            // 
            // buttonAddSpec
            // 
            this.buttonAddSpec.Location = new System.Drawing.Point(594, 37);
            this.buttonAddSpec.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonAddSpec.Name = "buttonAddSpec";
            this.buttonAddSpec.Size = new System.Drawing.Size(86, 31);
            this.buttonAddSpec.TabIndex = 2;
            this.buttonAddSpec.Text = "Add Spec";
            this.buttonAddSpec.UseVisualStyleBackColor = true;
            // 
            // comboBoxParameters
            // 
            this.comboBoxParameters.FormattingEnabled = true;
            this.comboBoxParameters.Location = new System.Drawing.Point(384, 37);
            this.comboBoxParameters.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxParameters.Name = "comboBoxParameters";
            this.comboBoxParameters.Size = new System.Drawing.Size(203, 28);
            this.comboBoxParameters.TabIndex = 1;
            // 
            // buttonSaveSpecFile
            // 
            this.buttonSaveSpecFile.Location = new System.Drawing.Point(250, 35);
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
            this.flp2.Location = new System.Drawing.Point(0, 210);
            this.flp2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flp2.Name = "flp2";
            this.flp2.Size = new System.Drawing.Size(1782, 788);
            this.flp2.TabIndex = 3;
            this.flp2.WrapContents = false;
            this.flp2.Paint += new System.Windows.Forms.PaintEventHandler(this.flp2_Paint);
            // 
            // flp
            // 
            this.flp.AutoScroll = true;
            this.flp.AutoSize = true;
            this.flp.Controls.Add(this.measurementInfoCtrl1);
            this.flp.Dock = System.Windows.Forms.DockStyle.Top;
            this.flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp.Location = new System.Drawing.Point(0, 0);
            this.flp.MinimumSize = new System.Drawing.Size(0, 200);
            this.flp.Name = "flp";
            this.flp.Size = new System.Drawing.Size(1782, 210);
            this.flp.TabIndex = 0;
            // 
            // measurementInfoCtrl1
            // 
            this.measurementInfoCtrl1.AutoSize = true;
            this.measurementInfoCtrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.measurementInfoCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.measurementInfoCtrl1.fileName = null;
            this.measurementInfoCtrl1.folderName = null;
            this.measurementInfoCtrl1.Location = new System.Drawing.Point(3, 5);
            this.measurementInfoCtrl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.measurementInfoCtrl1.MinimumSize = new System.Drawing.Size(1017, 200);
            this.measurementInfoCtrl1.Name = "measurementInfoCtrl1";
            this.measurementInfoCtrl1.Size = new System.Drawing.Size(1017, 200);
            this.measurementInfoCtrl1.TabIndex = 1;
            this.measurementInfoCtrl1.Load += new System.EventHandler(this.measurementInfoCtrl1_Load);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // RequirementsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1782, 1103);
            this.Controls.Add(this.splitContainer1);
            this.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1775, 1000);
            this.Name = "RequirementsForm";
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
        private TestInfoCtrl measurementInfoCtrl1;
        private System.Windows.Forms.Button buttonSaveSpecFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FlowLayoutPanel flp2;
    }
}

