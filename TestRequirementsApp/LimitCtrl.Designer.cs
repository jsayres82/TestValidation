
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
            panel2 = new System.Windows.Forms.Panel();
            textBoxAdditionalProperty2 = new EmptyTextTextBox();
            label3 = new System.Windows.Forms.Label();
            textBoxAdditionalProperty1 = new EmptyTextTextBox();
            label7 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            comboBoxLimitPrefix = new EmptyTextComboBox();
            comboBoxLimitUnits = new EmptyTextComboBox();
            panelLimit = new System.Windows.Forms.Panel();
            label5 = new System.Windows.Forms.Label();
            comboBoxValidatorUnits = new EmptyTextComboBox();
            flpLimit = new System.Windows.Forms.FlowLayoutPanel();
            label6 = new System.Windows.Forms.Label();
            comboBoxValidUnitsPrefix = new EmptyTextComboBox();
            label4 = new System.Windows.Forms.Label();
            comboBoxValidators = new EmptyTextComboBox();
            bindingSource1 = new System.Windows.Forms.BindingSource(components);
            panelHeader1 = new PanelHeader();
            bindingSource2 = new System.Windows.Forms.BindingSource(components);
            bindingSource3 = new System.Windows.Forms.BindingSource(components);
            flpMain.SuspendLayout();
            flpSpec.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panelLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource3).BeginInit();
            SuspendLayout();
            // 
            // flpMain
            // 
            flpMain.Controls.Add(flpSpec);
            flpMain.Controls.Add(panelLimit);
            flpMain.Location = new System.Drawing.Point(0, 29);
            flpMain.Name = "flpMain";
            flpMain.Size = new System.Drawing.Size(621, 394);
            flpMain.TabIndex = 0;
            flpMain.Paint += flpMain_Paint;
            // 
            // flpSpec
            // 
            flpSpec.Controls.Add(label2);
            flpSpec.Controls.Add(comboBoxLimitTypes);
            flpSpec.Controls.Add(panel2);
            flpSpec.Controls.Add(panel1);
            flpSpec.Location = new System.Drawing.Point(3, 3);
            flpSpec.Name = "flpSpec";
            flpSpec.Size = new System.Drawing.Size(283, 198);
            flpSpec.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = System.Windows.Forms.DockStyle.Left;
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
            comboBoxLimitTypes.Location = new System.Drawing.Point(5, 40);
            comboBoxLimitTypes.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            comboBoxLimitTypes.Name = "comboBoxLimitTypes";
            comboBoxLimitTypes.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxLimitTypes.Size = new System.Drawing.Size(271, 23);
            comboBoxLimitTypes.TabIndex = 15;
            comboBoxLimitTypes.SelectedIndexChanged += comboBoxLimitTypes_SelectedIndexChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(textBoxAdditionalProperty2);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(textBoxAdditionalProperty1);
            panel2.Controls.Add(label7);
            panel2.Location = new System.Drawing.Point(3, 69);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(127, 89);
            panel2.TabIndex = 16;
            // 
            // textBoxAdditionalProperty2
            // 
            textBoxAdditionalProperty2.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            textBoxAdditionalProperty2.EmptyText = null;
            textBoxAdditionalProperty2.ForeColor = System.Drawing.SystemColors.WindowText;
            textBoxAdditionalProperty2.Location = new System.Drawing.Point(5, 54);
            textBoxAdditionalProperty2.Margin = new System.Windows.Forms.Padding(5, 0, 3, 0);
            textBoxAdditionalProperty2.Name = "textBoxAdditionalProperty2";
            textBoxAdditionalProperty2.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            textBoxAdditionalProperty2.Size = new System.Drawing.Size(119, 23);
            textBoxAdditionalProperty2.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(5, 39);
            label3.Margin = new System.Windows.Forms.Padding(5, 0, 3, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(31, 15);
            label3.TabIndex = 19;
            label3.Text = "Stop";
            // 
            // textBoxAdditionalProperty1
            // 
            textBoxAdditionalProperty1.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            textBoxAdditionalProperty1.EmptyText = null;
            textBoxAdditionalProperty1.ForeColor = System.Drawing.SystemColors.WindowText;
            textBoxAdditionalProperty1.Location = new System.Drawing.Point(5, 16);
            textBoxAdditionalProperty1.Margin = new System.Windows.Forms.Padding(5, 0, 3, 0);
            textBoxAdditionalProperty1.Name = "textBoxAdditionalProperty1";
            textBoxAdditionalProperty1.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            textBoxAdditionalProperty1.Size = new System.Drawing.Size(119, 23);
            textBoxAdditionalProperty1.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(5, 1);
            label7.Margin = new System.Windows.Forms.Padding(5, 0, 3, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(31, 15);
            label7.TabIndex = 20;
            label7.Text = "Start";
            // 
            // panel1
            // 
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(comboBoxLimitPrefix);
            panel1.Controls.Add(comboBoxLimitUnits);
            panel1.Location = new System.Drawing.Point(136, 69);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(140, 89);
            panel1.TabIndex = 15;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(4, 1);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(67, 15);
            label9.TabIndex = 14;
            label9.Text = "Units Prefix";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(4, 39);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(64, 15);
            label10.TabIndex = 14;
            label10.Text = "Limit Units";
            // 
            // comboBoxLimitPrefix
            // 
            comboBoxLimitPrefix.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            comboBoxLimitPrefix.EmptyText = null;
            comboBoxLimitPrefix.ForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxLimitPrefix.FormattingEnabled = true;
            comboBoxLimitPrefix.Location = new System.Drawing.Point(4, 16);
            comboBoxLimitPrefix.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            comboBoxLimitPrefix.Name = "comboBoxLimitPrefix";
            comboBoxLimitPrefix.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxLimitPrefix.Size = new System.Drawing.Size(125, 23);
            comboBoxLimitPrefix.TabIndex = 13;
            // 
            // comboBoxLimitUnits
            // 
            comboBoxLimitUnits.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            comboBoxLimitUnits.EmptyText = null;
            comboBoxLimitUnits.ForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxLimitUnits.FormattingEnabled = true;
            comboBoxLimitUnits.Location = new System.Drawing.Point(4, 54);
            comboBoxLimitUnits.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            comboBoxLimitUnits.Name = "comboBoxLimitUnits";
            comboBoxLimitUnits.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxLimitUnits.Size = new System.Drawing.Size(125, 23);
            comboBoxLimitUnits.TabIndex = 13;
            // 
            // panelLimit
            // 
            panelLimit.AutoScroll = true;
            panelLimit.Controls.Add(label5);
            panelLimit.Controls.Add(comboBoxValidatorUnits);
            panelLimit.Controls.Add(flpLimit);
            panelLimit.Controls.Add(label6);
            panelLimit.Controls.Add(comboBoxValidUnitsPrefix);
            panelLimit.Controls.Add(label4);
            panelLimit.Controls.Add(comboBoxValidators);
            panelLimit.Location = new System.Drawing.Point(292, 3);
            panelLimit.Name = "panelLimit";
            panelLimit.Size = new System.Drawing.Size(321, 198);
            panelLimit.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(13, 55);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(64, 15);
            label5.TabIndex = 14;
            label5.Text = "Limit Units";
            // 
            // comboBoxValidatorUnits
            // 
            comboBoxValidatorUnits.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            comboBoxValidatorUnits.EmptyText = null;
            comboBoxValidatorUnits.ForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxValidatorUnits.FormattingEnabled = true;
            comboBoxValidatorUnits.Location = new System.Drawing.Point(140, 70);
            comboBoxValidatorUnits.Name = "comboBoxValidatorUnits";
            comboBoxValidatorUnits.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxValidatorUnits.Size = new System.Drawing.Size(119, 23);
            comboBoxValidatorUnits.TabIndex = 13;
            // 
            // flpLimit
            // 
            flpLimit.AutoSize = true;
            flpLimit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            flpLimit.Dock = System.Windows.Forms.DockStyle.Bottom;
            flpLimit.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flpLimit.Location = new System.Drawing.Point(0, 198);
            flpLimit.Name = "flpLimit";
            flpLimit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            flpLimit.Size = new System.Drawing.Size(321, 0);
            flpLimit.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(140, 55);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(67, 15);
            label6.TabIndex = 14;
            label6.Text = "Units Prefix";
            // 
            // comboBoxValidUnitsPrefix
            // 
            comboBoxValidUnitsPrefix.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            comboBoxValidUnitsPrefix.EmptyText = null;
            comboBoxValidUnitsPrefix.ForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxValidUnitsPrefix.FormattingEnabled = true;
            comboBoxValidUnitsPrefix.Location = new System.Drawing.Point(3, 70);
            comboBoxValidUnitsPrefix.Name = "comboBoxValidUnitsPrefix";
            comboBoxValidUnitsPrefix.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxValidUnitsPrefix.Size = new System.Drawing.Size(119, 23);
            comboBoxValidUnitsPrefix.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.ForeColor = System.Drawing.Color.MediumBlue;
            label4.Location = new System.Drawing.Point(9, -2);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(98, 30);
            label4.TabIndex = 14;
            label4.Text = "Validator";
            // 
            // comboBoxValidators
            // 
            comboBoxValidators.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            comboBoxValidators.EmptyText = null;
            comboBoxValidators.ForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxValidators.FormattingEnabled = true;
            comboBoxValidators.Location = new System.Drawing.Point(9, 28);
            comboBoxValidators.Name = "comboBoxValidators";
            comboBoxValidators.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            comboBoxValidators.Size = new System.Drawing.Size(194, 23);
            comboBoxValidators.TabIndex = 13;
            comboBoxValidators.SelectedIndexChanged += comboBoxValidators_SelectedIndexChanged;
            // 
            // panelHeader1
            // 
            panelHeader1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            panelHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader1.HeaderText = "Limit";
            panelHeader1.Location = new System.Drawing.Point(0, 0);
            panelHeader1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelHeader1.Name = "panelHeader1";
            panelHeader1.Size = new System.Drawing.Size(624, 23);
            panelHeader1.TabIndex = 2;
            // 
            // LimitCtrl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(panelHeader1);
            Controls.Add(flpMain);
            Name = "LimitCtrl";
            Size = new System.Drawing.Size(624, 426);
            flpMain.ResumeLayout(false);
            flpSpec.ResumeLayout(false);
            flpSpec.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelLimit.ResumeLayout(false);
            panelLimit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.FlowLayoutPanel flpSpec;
        private System.Windows.Forms.Panel panelLimit;
        private PanelHeader panelHeader1;
        private System.Windows.Forms.Label label4;
        private EmptyTextComboBox comboBoxValidators;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private EmptyTextComboBox comboBoxValidUnitsPrefix;
        private EmptyTextComboBox comboBoxValidatorUnits;
        private System.Windows.Forms.Label label2;
        private EmptyTextComboBox comboBoxLimitTypes;
        private System.Windows.Forms.Label label7;
        private EmptyTextTextBox textBoxAdditionalProperty1;
        private System.Windows.Forms.Label label3;
        private EmptyTextTextBox textBoxAdditionalProperty2;
        public System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.BindingSource bindingSource3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private EmptyTextComboBox comboBoxLimitPrefix;
        private EmptyTextComboBox comboBoxLimitUnits;
        private System.Windows.Forms.FlowLayoutPanel flpLimit;
    }
}
