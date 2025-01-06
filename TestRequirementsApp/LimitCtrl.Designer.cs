
namespace Nuvo.Requirements_Builder
{
    partial class LimitCtrl
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
            flpSpec = new System.Windows.Forms.FlowLayoutPanel();
            label2 = new System.Windows.Forms.Label();
            comboBoxLimitTypes = new EmptyTextComboBox();
            label7 = new System.Windows.Forms.Label();
            textBoxAdditionalProperty1 = new EmptyTextTextBox();
            label3 = new System.Windows.Forms.Label();
            textBoxAdditionalProperty2 = new EmptyTextTextBox();
            bindingSource1 = new System.Windows.Forms.BindingSource(components);
            label5 = new System.Windows.Forms.Label();
            panelHeader1 = new PanelHeader();
            panelLimit = new System.Windows.Forms.Panel();
            label6 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            comboBoxUnitsPrefix = new EmptyTextComboBox();
            comboBoxLimitUnits = new EmptyTextComboBox();
            comboBoxValidators = new EmptyTextComboBox();
            labelAdditionalProperty2 = new System.Windows.Forms.Label();
            labelAdditionalProperty1 = new System.Windows.Forms.Label();
            tbAddProp2 = new EmptyTextTextBox();
            tbAddProp1 = new EmptyTextTextBox();
            bindingSource2 = new System.Windows.Forms.BindingSource(components);
            bindingSource3 = new System.Windows.Forms.BindingSource(components);
            flpMain.SuspendLayout();
            flpSpec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            panelLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource3).BeginInit();
            SuspendLayout();
            // 
            // flpMain
            // 
            flpMain.Controls.Add(flpSpec);
            flpMain.Location = new System.Drawing.Point(0, 29);
            flpMain.Name = "flpMain";
            flpMain.Size = new System.Drawing.Size(455, 247);
            flpMain.TabIndex = 0;
            // 
            // flpSpec
            // 
            flpSpec.Controls.Add(label2);
            flpSpec.Controls.Add(comboBoxLimitTypes);
            flpSpec.Controls.Add(label7);
            flpSpec.Controls.Add(textBoxAdditionalProperty1);
            flpSpec.Controls.Add(label3);
            flpSpec.Controls.Add(textBoxAdditionalProperty2);
            flpSpec.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flpSpec.Location = new System.Drawing.Point(3, 3);
            flpSpec.Name = "flpSpec";
            flpSpec.Size = new System.Drawing.Size(158, 244);
            flpSpec.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.MediumBlue;
            label2.Location = new System.Drawing.Point(5, 5);
            label2.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(59, 30);
            label2.TabIndex = 16;
            label2.Text = "Limit";
            // 
            // comboBoxLimitTypes
            // 
            comboBoxLimitTypes.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            comboBoxLimitTypes.EmptyText = null;
            comboBoxLimitTypes.ForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxLimitTypes.FormattingEnabled = true;
            comboBoxLimitTypes.Location = new System.Drawing.Point(5, 38);
            comboBoxLimitTypes.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            comboBoxLimitTypes.Name = "comboBoxLimitTypes";
            comboBoxLimitTypes.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxLimitTypes.Size = new System.Drawing.Size(145, 23);
            comboBoxLimitTypes.TabIndex = 15;
            comboBoxLimitTypes.SelectedIndexChanged += comboBoxLimitTypes_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(5, 64);
            label7.Margin = new System.Windows.Forms.Padding(5, 0, 3, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(31, 15);
            label7.TabIndex = 20;
            label7.Text = "Start";
            // 
            // textBoxAdditionalProperty1
            // 
            textBoxAdditionalProperty1.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            textBoxAdditionalProperty1.EmptyText = null;
            textBoxAdditionalProperty1.ForeColor = System.Drawing.SystemColors.WindowText;
            textBoxAdditionalProperty1.Location = new System.Drawing.Point(5, 79);
            textBoxAdditionalProperty1.Margin = new System.Windows.Forms.Padding(5, 0, 3, 0);
            textBoxAdditionalProperty1.Name = "textBoxAdditionalProperty1";
            textBoxAdditionalProperty1.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            textBoxAdditionalProperty1.Size = new System.Drawing.Size(119, 23);
            textBoxAdditionalProperty1.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(5, 102);
            label3.Margin = new System.Windows.Forms.Padding(5, 0, 3, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(31, 15);
            label3.TabIndex = 19;
            label3.Text = "Stop";
            // 
            // textBoxAdditionalProperty2
            // 
            textBoxAdditionalProperty2.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            textBoxAdditionalProperty2.EmptyText = null;
            textBoxAdditionalProperty2.ForeColor = System.Drawing.SystemColors.WindowText;
            textBoxAdditionalProperty2.Location = new System.Drawing.Point(5, 117);
            textBoxAdditionalProperty2.Margin = new System.Windows.Forms.Padding(5, 0, 3, 0);
            textBoxAdditionalProperty2.Name = "textBoxAdditionalProperty2";
            textBoxAdditionalProperty2.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            textBoxAdditionalProperty2.Size = new System.Drawing.Size(119, 23);
            textBoxAdditionalProperty2.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(137, 129);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(64, 15);
            label5.TabIndex = 14;
            label5.Text = "Limit Units";
            // 
            // panelHeader1
            // 
            panelHeader1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            panelHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader1.HeaderText = "Limit";
            panelHeader1.Location = new System.Drawing.Point(0, 0);
            panelHeader1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelHeader1.Name = "panelHeader1";
            panelHeader1.Size = new System.Drawing.Size(458, 23);
            panelHeader1.TabIndex = 2;
            // 
            // panelLimit
            // 
            panelLimit.Controls.Add(label6);
            panelLimit.Controls.Add(label5);
            panelLimit.Controls.Add(label4);
            panelLimit.Controls.Add(comboBoxUnitsPrefix);
            panelLimit.Controls.Add(comboBoxLimitUnits);
            panelLimit.Controls.Add(comboBoxValidators);
            panelLimit.Controls.Add(labelAdditionalProperty2);
            panelLimit.Controls.Add(labelAdditionalProperty1);
            panelLimit.Controls.Add(tbAddProp2);
            panelLimit.Controls.Add(tbAddProp1);
            panelLimit.Location = new System.Drawing.Point(167, 29);
            panelLimit.Name = "panelLimit";
            panelLimit.Size = new System.Drawing.Size(288, 247);
            panelLimit.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(12, 129);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(67, 15);
            label6.TabIndex = 14;
            label6.Text = "Units Prefix";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.ForeColor = System.Drawing.Color.MediumBlue;
            label4.Location = new System.Drawing.Point(12, 8);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(98, 30);
            label4.TabIndex = 14;
            label4.Text = "Validator";
            // 
            // comboBoxUnitsPrefix
            // 
            comboBoxUnitsPrefix.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            comboBoxUnitsPrefix.EmptyText = null;
            comboBoxUnitsPrefix.ForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxUnitsPrefix.FormattingEnabled = true;
            comboBoxUnitsPrefix.Location = new System.Drawing.Point(12, 147);
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
            comboBoxLimitUnits.Location = new System.Drawing.Point(137, 147);
            comboBoxLimitUnits.Name = "comboBoxLimitUnits";
            comboBoxLimitUnits.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxLimitUnits.Size = new System.Drawing.Size(125, 23);
            comboBoxLimitUnits.TabIndex = 13;
            // 
            // comboBoxValidators
            // 
            comboBoxValidators.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            comboBoxValidators.EmptyText = null;
            comboBoxValidators.ForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxValidators.FormattingEnabled = true;
            comboBoxValidators.Location = new System.Drawing.Point(12, 41);
            comboBoxValidators.Name = "comboBoxValidators";
            comboBoxValidators.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxValidators.Size = new System.Drawing.Size(194, 23);
            comboBoxValidators.TabIndex = 13;
            comboBoxValidators.SelectedIndexChanged += comboBoxValidators_SelectedIndexChanged;
            // 
            // labelAdditionalProperty2
            // 
            labelAdditionalProperty2.AutoSize = true;
            labelAdditionalProperty2.Location = new System.Drawing.Point(143, 79);
            labelAdditionalProperty2.Name = "labelAdditionalProperty2";
            labelAdditionalProperty2.Size = new System.Drawing.Size(119, 15);
            labelAdditionalProperty2.TabIndex = 10;
            labelAdditionalProperty2.Text = "Additional Property 2";
            // 
            // labelAdditionalProperty1
            // 
            labelAdditionalProperty1.AutoSize = true;
            labelAdditionalProperty1.Location = new System.Drawing.Point(12, 79);
            labelAdditionalProperty1.Name = "labelAdditionalProperty1";
            labelAdditionalProperty1.Size = new System.Drawing.Size(119, 15);
            labelAdditionalProperty1.TabIndex = 10;
            labelAdditionalProperty1.Text = "Additional Property 1";
            // 
            // tbAddProp2
            // 
            tbAddProp2.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            tbAddProp2.EmptyText = null;
            tbAddProp2.ForeColor = System.Drawing.SystemColors.WindowText;
            tbAddProp2.Location = new System.Drawing.Point(143, 97);
            tbAddProp2.Name = "tbAddProp2";
            tbAddProp2.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            tbAddProp2.Size = new System.Drawing.Size(119, 23);
            tbAddProp2.TabIndex = 9;
            // 
            // tbAddProp1
            // 
            tbAddProp1.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            tbAddProp1.EmptyText = null;
            tbAddProp1.ForeColor = System.Drawing.SystemColors.WindowText;
            tbAddProp1.Location = new System.Drawing.Point(12, 97);
            tbAddProp1.Name = "tbAddProp1";
            tbAddProp1.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            tbAddProp1.Size = new System.Drawing.Size(119, 23);
            tbAddProp1.TabIndex = 9;
            // 
            // LimitCtrl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(panelLimit);
            Controls.Add(panelHeader1);
            Controls.Add(flpMain);
            Name = "LimitCtrl";
            Size = new System.Drawing.Size(458, 279);
            flpMain.ResumeLayout(false);
            flpSpec.ResumeLayout(false);
            flpSpec.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            panelLimit.ResumeLayout(false);
            panelLimit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.FlowLayoutPanel flpSpec;
        private System.Windows.Forms.Panel panelLimit;
        private PanelHeader panelHeader1;
        private System.Windows.Forms.Label labelAdditionalProperty1;
        private EmptyTextTextBox tbAddProp1;
        private System.Windows.Forms.Label label4;
        private EmptyTextComboBox comboBoxValidators;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private EmptyTextComboBox comboBoxUnitsPrefix;
        private EmptyTextComboBox comboBoxLimitUnits;
        private System.Windows.Forms.Label label2;
        private EmptyTextComboBox comboBoxLimitTypes;
        private System.Windows.Forms.Label labelAdditionalProperty2;
        private EmptyTextTextBox tbAddProp2;
        private System.Windows.Forms.Label label7;
        private EmptyTextTextBox textBoxAdditionalProperty1;
        private System.Windows.Forms.Label label3;
        private EmptyTextTextBox textBoxAdditionalProperty2;
        public System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.BindingSource bindingSource3;
    }
}
