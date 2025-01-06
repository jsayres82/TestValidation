
namespace Nuvo.Requirements_Builder
{
    partial class ParameterCtrl
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
            flpMain = new System.Windows.Forms.FlowLayoutPanel();
            flpParam = new System.Windows.Forms.FlowLayoutPanel();
            label2 = new System.Windows.Forms.Label();
            comboBoxSpecTypes = new EmptyTextComboBox();
            label1 = new System.Windows.Forms.Label();
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            labelVariableName1 = new System.Windows.Forms.Label();
            textBoxAdditionalProperty1 = new EmptyTextTextBox();
            labelVariableName2 = new System.Windows.Forms.Label();
            textBoxAdditionalProperty2 = new EmptyTextTextBox();
            panelHeader1 = new PanelHeader();
            panelDetails = new System.Windows.Forms.Panel();
            label8 = new System.Windows.Forms.Label();
            listView1 = new System.Windows.Forms.ListView();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            comboBoxUnitsPrefix = new EmptyTextComboBox();
            comboBoxLimitUnits = new EmptyTextComboBox();
            labelAdditionalProperty2 = new System.Windows.Forms.Label();
            labelAdditionalProperty1 = new System.Windows.Forms.Label();
            emptyTextTextBox3 = new EmptyTextTextBox();
            emptyTextTextBox1 = new EmptyTextTextBox();
            bindingSource1 = new System.Windows.Forms.BindingSource(components);
            flpMain.SuspendLayout();
            flpParam.SuspendLayout();
            panelDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // flpMain
            // 
            flpMain.Controls.Add(flpParam);
            flpMain.Location = new System.Drawing.Point(0, 29);
            flpMain.Name = "flpMain";
            flpMain.Size = new System.Drawing.Size(455, 291);
            flpMain.TabIndex = 0;
            // 
            // flpParam
            // 
            flpParam.Controls.Add(label2);
            flpParam.Controls.Add(comboBoxSpecTypes);
            flpParam.Controls.Add(label1);
            flpParam.Controls.Add(richTextBox1);
            flpParam.Controls.Add(labelVariableName1);
            flpParam.Controls.Add(textBoxAdditionalProperty1);
            flpParam.Controls.Add(labelVariableName2);
            flpParam.Controls.Add(textBoxAdditionalProperty2);
            flpParam.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flpParam.Location = new System.Drawing.Point(3, 3);
            flpParam.Name = "flpParam";
            flpParam.Size = new System.Drawing.Size(158, 288);
            flpParam.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.MediumBlue;
            label2.Location = new System.Drawing.Point(5, 5);
            label2.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(112, 30);
            label2.TabIndex = 23;
            label2.Text = "Parameter";
            // 
            // comboBoxSpecTypes
            // 
            comboBoxSpecTypes.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            comboBoxSpecTypes.EmptyText = null;
            comboBoxSpecTypes.ForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxSpecTypes.FormattingEnabled = true;
            comboBoxSpecTypes.Location = new System.Drawing.Point(3, 38);
            comboBoxSpecTypes.Name = "comboBoxSpecTypes";
            comboBoxSpecTypes.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxSpecTypes.Size = new System.Drawing.Size(145, 23);
            comboBoxSpecTypes.TabIndex = 15;
            comboBoxSpecTypes.SelectedIndexChanged += comboBoxSpecTypes_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 64);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(124, 15);
            label1.TabIndex = 22;
            label1.Text = "Parameter Description";
            // 
            // richTextBox1
            // 
            richTextBox1.Enabled = false;
            richTextBox1.Location = new System.Drawing.Point(3, 82);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new System.Drawing.Size(145, 64);
            richTextBox1.TabIndex = 21;
            richTextBox1.Text = "";
            // 
            // labelVariableName1
            // 
            labelVariableName1.AutoSize = true;
            labelVariableName1.Location = new System.Drawing.Point(3, 149);
            labelVariableName1.Name = "labelVariableName1";
            labelVariableName1.Size = new System.Drawing.Size(119, 15);
            labelVariableName1.TabIndex = 20;
            labelVariableName1.Text = "Additional Property 1";
            labelVariableName1.Visible = false;
            // 
            // textBoxAdditionalProperty1
            // 
            textBoxAdditionalProperty1.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            textBoxAdditionalProperty1.EmptyText = null;
            textBoxAdditionalProperty1.ForeColor = System.Drawing.SystemColors.WindowText;
            textBoxAdditionalProperty1.Location = new System.Drawing.Point(3, 167);
            textBoxAdditionalProperty1.Name = "textBoxAdditionalProperty1";
            textBoxAdditionalProperty1.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            textBoxAdditionalProperty1.Size = new System.Drawing.Size(119, 23);
            textBoxAdditionalProperty1.TabIndex = 17;
            textBoxAdditionalProperty1.Visible = false;
            // 
            // labelVariableName2
            // 
            labelVariableName2.AutoSize = true;
            labelVariableName2.Location = new System.Drawing.Point(3, 193);
            labelVariableName2.Name = "labelVariableName2";
            labelVariableName2.Size = new System.Drawing.Size(119, 15);
            labelVariableName2.TabIndex = 19;
            labelVariableName2.Text = "Additional Property 2";
            labelVariableName2.Visible = false;
            // 
            // textBoxAdditionalProperty2
            // 
            textBoxAdditionalProperty2.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            textBoxAdditionalProperty2.EmptyText = null;
            textBoxAdditionalProperty2.ForeColor = System.Drawing.SystemColors.WindowText;
            textBoxAdditionalProperty2.Location = new System.Drawing.Point(3, 211);
            textBoxAdditionalProperty2.Name = "textBoxAdditionalProperty2";
            textBoxAdditionalProperty2.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            textBoxAdditionalProperty2.Size = new System.Drawing.Size(119, 23);
            textBoxAdditionalProperty2.TabIndex = 18;
            textBoxAdditionalProperty2.Visible = false;
            // 
            // panelHeader1
            // 
            panelHeader1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            panelHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader1.HeaderText = "Measurement Parameter";
            panelHeader1.Location = new System.Drawing.Point(0, 0);
            panelHeader1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelHeader1.Name = "panelHeader1";
            panelHeader1.Size = new System.Drawing.Size(458, 23);
            panelHeader1.TabIndex = 2;
            // 
            // panelDetails
            // 
            panelDetails.Controls.Add(label8);
            panelDetails.Controls.Add(listView1);
            panelDetails.Controls.Add(label6);
            panelDetails.Controls.Add(label5);
            panelDetails.Controls.Add(comboBoxUnitsPrefix);
            panelDetails.Controls.Add(comboBoxLimitUnits);
            panelDetails.Controls.Add(labelAdditionalProperty2);
            panelDetails.Controls.Add(labelAdditionalProperty1);
            panelDetails.Controls.Add(emptyTextTextBox3);
            panelDetails.Controls.Add(emptyTextTextBox1);
            panelDetails.Location = new System.Drawing.Point(167, 29);
            panelDetails.Name = "panelDetails";
            panelDetails.Size = new System.Drawing.Size(288, 291);
            panelDetails.TabIndex = 4;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label8.ForeColor = System.Drawing.Color.MediumBlue;
            label8.Location = new System.Drawing.Point(12, 8);
            label8.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(239, 30);
            label8.TabIndex = 24;
            label8.Text = "Measurement Variables";
            // 
            // listView1
            // 
            listView1.HideSelection = false;
            listView1.Location = new System.Drawing.Point(12, 41);
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(244, 65);
            listView1.TabIndex = 15;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(11, 122);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(67, 15);
            label6.TabIndex = 14;
            label6.Text = "Units Prefix";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(136, 122);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(64, 15);
            label5.TabIndex = 14;
            label5.Text = "Limit Units";
            // 
            // comboBoxUnitsPrefix
            // 
            comboBoxUnitsPrefix.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            comboBoxUnitsPrefix.EmptyText = null;
            comboBoxUnitsPrefix.ForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxUnitsPrefix.FormattingEnabled = true;
            comboBoxUnitsPrefix.Location = new System.Drawing.Point(11, 140);
            comboBoxUnitsPrefix.Name = "comboBoxUnitsPrefix";
            comboBoxUnitsPrefix.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxUnitsPrefix.Size = new System.Drawing.Size(119, 23);
            comboBoxUnitsPrefix.TabIndex = 13;
            // 
            // comboBoxLimitUnits
            // 
            comboBoxLimitUnits.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            comboBoxLimitUnits.EmptyText = null;
            comboBoxLimitUnits.ForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxLimitUnits.FormattingEnabled = true;
            comboBoxLimitUnits.Location = new System.Drawing.Point(136, 140);
            comboBoxLimitUnits.Name = "comboBoxLimitUnits";
            comboBoxLimitUnits.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxLimitUnits.Size = new System.Drawing.Size(125, 23);
            comboBoxLimitUnits.TabIndex = 13;
            // 
            // labelAdditionalProperty2
            // 
            labelAdditionalProperty2.AutoSize = true;
            labelAdditionalProperty2.Location = new System.Drawing.Point(145, 178);
            labelAdditionalProperty2.Name = "labelAdditionalProperty2";
            labelAdditionalProperty2.Size = new System.Drawing.Size(119, 15);
            labelAdditionalProperty2.TabIndex = 10;
            labelAdditionalProperty2.Text = "Additional Property 2";
            // 
            // labelAdditionalProperty1
            // 
            labelAdditionalProperty1.AutoSize = true;
            labelAdditionalProperty1.Location = new System.Drawing.Point(11, 178);
            labelAdditionalProperty1.Name = "labelAdditionalProperty1";
            labelAdditionalProperty1.Size = new System.Drawing.Size(119, 15);
            labelAdditionalProperty1.TabIndex = 10;
            labelAdditionalProperty1.Text = "Additional Property 1";
            // 
            // emptyTextTextBox3
            // 
            emptyTextTextBox3.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            emptyTextTextBox3.EmptyText = null;
            emptyTextTextBox3.ForeColor = System.Drawing.SystemColors.WindowText;
            emptyTextTextBox3.Location = new System.Drawing.Point(145, 196);
            emptyTextTextBox3.Name = "emptyTextTextBox3";
            emptyTextTextBox3.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            emptyTextTextBox3.Size = new System.Drawing.Size(119, 23);
            emptyTextTextBox3.TabIndex = 9;
            // 
            // emptyTextTextBox1
            // 
            emptyTextTextBox1.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            emptyTextTextBox1.EmptyText = null;
            emptyTextTextBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            emptyTextTextBox1.Location = new System.Drawing.Point(11, 196);
            emptyTextTextBox1.Name = "emptyTextTextBox1";
            emptyTextTextBox1.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            emptyTextTextBox1.Size = new System.Drawing.Size(119, 23);
            emptyTextTextBox1.TabIndex = 9;
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = label8.Controls;
            // 
            // ParameterCtrl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(panelDetails);
            Controls.Add(panelHeader1);
            Controls.Add(flpMain);
            Name = "ParameterCtrl";
            Size = new System.Drawing.Size(458, 328);
            flpMain.ResumeLayout(false);
            flpParam.ResumeLayout(false);
            flpParam.PerformLayout();
            panelDetails.ResumeLayout(false);
            panelDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.FlowLayoutPanel flpParam;
        private System.Windows.Forms.Panel panelDetails;
        private PanelHeader panelHeader1;
        private System.Windows.Forms.Label labelAdditionalProperty1;
        private EmptyTextTextBox emptyTextTextBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private EmptyTextComboBox comboBoxUnitsPrefix;
        private EmptyTextComboBox comboBoxLimitUnits;
        private EmptyTextComboBox comboBoxSpecTypes;
        private System.Windows.Forms.Label labelAdditionalProperty2;
        private EmptyTextTextBox emptyTextTextBox3;
        private System.Windows.Forms.Label label7;
        private EmptyTextTextBox textBoxAdditionalProperty1;
        private System.Windows.Forms.Label labelVariableName2;
        private EmptyTextTextBox textBoxAdditionalProperty2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label labelVariableName1;
    }
}
