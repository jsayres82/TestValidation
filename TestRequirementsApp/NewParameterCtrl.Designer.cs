
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
            flpMain = new System.Windows.Forms.FlowLayoutPanel();
            flpParam = new System.Windows.Forms.FlowLayoutPanel();
            panel2 = new System.Windows.Forms.Panel();
            label3 = new System.Windows.Forms.Label();
            cbSpecTypes = new EmptyTextComboBox();
            cbCalculator = new EmptyTextComboBox();
            label2 = new System.Windows.Forms.Label();
            flpCalcParams = new System.Windows.Forms.FlowLayoutPanel();
            lblParamCalcParams = new System.Windows.Forms.Label();
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            panel1 = new System.Windows.Forms.Panel();
            panelHeader1 = new PanelHeader();
            flpMain.SuspendLayout();
            flpParam.SuspendLayout();
            panel2.SuspendLayout();
            flpCalcParams.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flpMain
            // 
            flpMain.AutoSize = true;
            flpMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            flpMain.Controls.Add(flpParam);
            flpMain.Controls.Add(richTextBox1);
            flpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            flpMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flpMain.Location = new System.Drawing.Point(0, 0);
            flpMain.Name = "flpMain";
            flpMain.Size = new System.Drawing.Size(177, 184);
            flpMain.TabIndex = 0;
            // 
            // flpParam
            // 
            flpParam.AutoSize = true;
            flpParam.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            flpParam.Controls.Add(panel2);
            flpParam.Controls.Add(flpCalcParams);
            flpParam.Dock = System.Windows.Forms.DockStyle.Fill;
            flpParam.Location = new System.Drawing.Point(3, 3);
            flpParam.Name = "flpParam";
            flpParam.Size = new System.Drawing.Size(171, 124);
            flpParam.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(cbSpecTypes);
            panel2.Controls.Add(cbCalculator);
            panel2.Controls.Add(label2);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(153, 118);
            panel2.TabIndex = 28;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(5, 74);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(118, 15);
            label3.TabIndex = 27;
            label3.Text = "Parameter Calculator";
            // 
            // cbSpecTypes
            // 
            cbSpecTypes.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            cbSpecTypes.EmptyText = null;
            cbSpecTypes.ForeColor = System.Drawing.SystemColors.WindowText;
            cbSpecTypes.FormattingEnabled = true;
            cbSpecTypes.Location = new System.Drawing.Point(3, 41);
            cbSpecTypes.Name = "cbSpecTypes";
            cbSpecTypes.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            cbSpecTypes.Size = new System.Drawing.Size(145, 23);
            cbSpecTypes.TabIndex = 15;
            cbSpecTypes.SelectedIndexChanged += comboBoxSpecTypes_SelectedIndexChanged;
            // 
            // cbCalculator
            // 
            cbCalculator.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            cbCalculator.EmptyText = null;
            cbCalculator.ForeColor = System.Drawing.SystemColors.WindowText;
            cbCalculator.FormattingEnabled = true;
            cbCalculator.Location = new System.Drawing.Point(5, 92);
            cbCalculator.Name = "cbCalculator";
            cbCalculator.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            cbCalculator.Size = new System.Drawing.Size(145, 23);
            cbCalculator.TabIndex = 26;
            cbCalculator.SelectedIndexChanged += cbCalculator_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.MediumBlue;
            label2.Location = new System.Drawing.Point(5, 8);
            label2.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(135, 30);
            label2.TabIndex = 23;
            label2.Text = "Specification";
            // 
            // flpCalcParams
            // 
            flpCalcParams.AutoSize = true;
            flpCalcParams.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            flpCalcParams.Controls.Add(lblParamCalcParams);
            flpCalcParams.Dock = System.Windows.Forms.DockStyle.Fill;
            flpCalcParams.Location = new System.Drawing.Point(162, 3);
            flpCalcParams.Name = "flpCalcParams";
            flpCalcParams.Size = new System.Drawing.Size(6, 118);
            flpCalcParams.TabIndex = 31;
            // 
            // lblParamCalcParams
            // 
            lblParamCalcParams.AutoSize = true;
            lblParamCalcParams.Location = new System.Drawing.Point(3, 0);
            lblParamCalcParams.Name = "lblParamCalcParams";
            lblParamCalcParams.Size = new System.Drawing.Size(0, 15);
            lblParamCalcParams.TabIndex = 0;
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            richTextBox1.Enabled = false;
            richTextBox1.Location = new System.Drawing.Point(3, 133);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new System.Drawing.Size(171, 48);
            richTextBox1.TabIndex = 33;
            richTextBox1.Text = "";
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(flpMain);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 19);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(177, 184);
            panel1.TabIndex = 1;
            // 
            // panelHeader1
            // 
            panelHeader1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            panelHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader1.HeaderText = "Measurement Parameter";
            panelHeader1.Location = new System.Drawing.Point(0, 0);
            panelHeader1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelHeader1.Name = "panelHeader1";
            panelHeader1.Size = new System.Drawing.Size(177, 19);
            panelHeader1.TabIndex = 5;
            // 
            // ParameterCtrl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Controls.Add(panel1);
            Controls.Add(panelHeader1);
            Name = "ParameterCtrl";
            Size = new System.Drawing.Size(177, 203);
            flpMain.ResumeLayout(false);
            flpMain.PerformLayout();
            flpParam.ResumeLayout(false);
            flpParam.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            flpCalcParams.ResumeLayout(false);
            flpCalcParams.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.FlowLayoutPanel flpParam;
        private EmptyTextComboBox cbSpecTypes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private EmptyTextComboBox cbCalculator;
        private System.Windows.Forms.FlowLayoutPanel flpCalcParams;
        private System.Windows.Forms.Label lblParamCalcParams;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private PanelHeader panelHeader1;
    }
}
