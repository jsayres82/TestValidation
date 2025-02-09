namespace Nuvo.Requirements_Builder.ValidationCtrls
{
    partial class RangeCtrl
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
            gpRange = new System.Windows.Forms.GroupBox();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            lblMin = new System.Windows.Forms.Label();
            lblValue = new System.Windows.Forms.Label();
            tbMin = new System.Windows.Forms.TextBox();
            lblMax = new System.Windows.Forms.Label();
            tbMax = new System.Windows.Forms.TextBox();
            lblUnits = new System.Windows.Forms.Label();
            cbUnits = new System.Windows.Forms.ComboBox();
            gpRange.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // gpRange
            // 
            gpRange.AutoSize = true;
            gpRange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            gpRange.Controls.Add(flowLayoutPanel1);
            gpRange.Dock = System.Windows.Forms.DockStyle.Fill;
            gpRange.Location = new System.Drawing.Point(0, 0);
            gpRange.Name = "gpRange";
            gpRange.Size = new System.Drawing.Size(500, 51);
            gpRange.TabIndex = 0;
            gpRange.TabStop = false;
            gpRange.Text = "Range";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(lblMin);
            flowLayoutPanel1.Controls.Add(lblValue);
            flowLayoutPanel1.Controls.Add(tbMin);
            flowLayoutPanel1.Controls.Add(lblMax);
            flowLayoutPanel1.Controls.Add(tbMax);
            flowLayoutPanel1.Controls.Add(lblUnits);
            flowLayoutPanel1.Controls.Add(cbUnits);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(494, 29);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // lblMin
            // 
            lblMin.AutoSize = true;
            lblMin.Location = new System.Drawing.Point(3, 0);
            lblMin.Name = "lblMin";
            lblMin.Size = new System.Drawing.Size(31, 15);
            lblMin.TabIndex = 0;
            lblMin.Text = "Start";
            // 
            // lblValue
            // 
            lblValue.AutoSize = true;
            lblValue.Enabled = false;
            lblValue.Location = new System.Drawing.Point(40, 0);
            lblValue.Name = "lblValue";
            lblValue.Size = new System.Drawing.Size(35, 15);
            lblValue.TabIndex = 1;
            lblValue.Text = "Value";
            lblValue.Visible = false;
            // 
            // tbMin
            // 
            tbMin.Location = new System.Drawing.Point(81, 3);
            tbMin.Name = "tbMin";
            tbMin.Size = new System.Drawing.Size(100, 23);
            tbMin.TabIndex = 2;
            // 
            // lblMax
            // 
            lblMax.AutoSize = true;
            lblMax.Location = new System.Drawing.Point(187, 0);
            lblMax.Name = "lblMax";
            lblMax.Size = new System.Drawing.Size(31, 15);
            lblMax.TabIndex = 3;
            lblMax.Text = "Stop";
            // 
            // tbMax
            // 
            tbMax.Location = new System.Drawing.Point(224, 3);
            tbMax.Name = "tbMax";
            tbMax.Size = new System.Drawing.Size(100, 23);
            tbMax.TabIndex = 4;
            // 
            // lblUnits
            // 
            lblUnits.AutoSize = true;
            lblUnits.Location = new System.Drawing.Point(330, 0);
            lblUnits.Name = "lblUnits";
            lblUnits.Size = new System.Drawing.Size(34, 15);
            lblUnits.TabIndex = 5;
            lblUnits.Text = "Units";
            // 
            // cbUnits
            // 
            cbUnits.FormattingEnabled = true;
            cbUnits.Location = new System.Drawing.Point(370, 3);
            cbUnits.Name = "cbUnits";
            cbUnits.Size = new System.Drawing.Size(121, 23);
            cbUnits.TabIndex = 6;
            // 
            // RangeCtrl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Controls.Add(gpRange);
            Name = "RangeCtrl";
            Size = new System.Drawing.Size(500, 51);
            gpRange.ResumeLayout(false);
            gpRange.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox gpRange;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox tbMin;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.TextBox tbMax;
        private System.Windows.Forms.Label lblUnits;
        private System.Windows.Forms.ComboBox cbUnits;
    }
}
