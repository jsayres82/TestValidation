namespace Nuvo.Requirements_Builder.ValidationCtrls
{
    partial class sNpSelectCheckBox
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
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            panel1 = new System.Windows.Forms.Panel();
            lbSParameters = new System.Windows.Forms.ListBox();
            panel4 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            nudNumPorts = new System.Windows.Forms.NumericUpDown();
            panel2 = new System.Windows.Forms.Panel();
            btnEditSelection = new System.Windows.Forms.Button();
            panel5 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            gbSnP = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudNumPorts).BeginInit();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            gbSnP.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new System.Drawing.Point(3, 19);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel1);
            splitContainer1.Panel1.Controls.Add(panel4);
            splitContainer1.Panel1MinSize = 30;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(flowLayoutPanel1);
            splitContainer1.Panel2Collapsed = true;
            splitContainer1.Panel2MinSize = 0;
            splitContainer1.Size = new System.Drawing.Size(104, 108);
            splitContainer1.SplitterDistance = 59;
            splitContainer1.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.AutoSize = true;
            panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(lbSParameters);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 58);
            panel1.Margin = new System.Windows.Forms.Padding(3, 18, 3, 3);
            panel1.MinimumSize = new System.Drawing.Size(125, 60);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(125, 60);
            panel1.TabIndex = 3;
            // 
            // lbSParameters
            // 
            lbSParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            lbSParameters.FormattingEnabled = true;
            lbSParameters.ItemHeight = 15;
            lbSParameters.Location = new System.Drawing.Point(0, 0);
            lbSParameters.Name = "lbSParameters";
            lbSParameters.Size = new System.Drawing.Size(125, 60);
            lbSParameters.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel4.Controls.Add(panel3);
            panel4.Controls.Add(panel2);
            panel4.Controls.Add(panel5);
            panel4.Dock = System.Windows.Forms.DockStyle.Top;
            panel4.Location = new System.Drawing.Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(104, 58);
            panel4.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.AutoSize = true;
            panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel3.Controls.Add(nudNumPorts);
            panel3.Dock = System.Windows.Forms.DockStyle.Right;
            panel3.Location = new System.Drawing.Point(63, 0);
            panel3.MinimumSize = new System.Drawing.Size(40, 0);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(41, 33);
            panel3.TabIndex = 9;
            // 
            // nudNumPorts
            // 
            nudNumPorts.AutoSize = true;
            nudNumPorts.Dock = System.Windows.Forms.DockStyle.Fill;
            nudNumPorts.Location = new System.Drawing.Point(0, 0);
            nudNumPorts.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudNumPorts.Name = "nudNumPorts";
            nudNumPorts.Size = new System.Drawing.Size(41, 23);
            nudNumPorts.TabIndex = 3;
            nudNumPorts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            nudNumPorts.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudNumPorts.ValueChanged += nudNumPorts_ValueChanged;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(btnEditSelection);
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(0, 33);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(104, 25);
            panel2.TabIndex = 8;
            // 
            // btnEditSelection
            // 
            btnEditSelection.AutoSize = true;
            btnEditSelection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnEditSelection.Dock = System.Windows.Forms.DockStyle.Bottom;
            btnEditSelection.Location = new System.Drawing.Point(0, 0);
            btnEditSelection.Name = "btnEditSelection";
            btnEditSelection.Size = new System.Drawing.Size(104, 25);
            btnEditSelection.TabIndex = 7;
            btnEditSelection.Text = "Edit";
            btnEditSelection.UseVisualStyleBackColor = true;
            btnEditSelection.Click += btnEditSelection_Click;
            // 
            // panel5
            // 
            panel5.AutoSize = true;
            panel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel5.Controls.Add(label1);
            panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            panel5.Location = new System.Drawing.Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(104, 58);
            panel5.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(37, 15);
            label1.TabIndex = 6;
            label1.Text = "Ports:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel1.MinimumSize = new System.Drawing.Size(104, 50);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(150, 50);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // gbSnP
            // 
            gbSnP.AutoSize = true;
            gbSnP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            gbSnP.Controls.Add(splitContainer1);
            gbSnP.Dock = System.Windows.Forms.DockStyle.Fill;
            gbSnP.Location = new System.Drawing.Point(0, 0);
            gbSnP.Name = "gbSnP";
            gbSnP.Size = new System.Drawing.Size(110, 130);
            gbSnP.TabIndex = 5;
            gbSnP.TabStop = false;
            gbSnP.Text = "S-Parameter Selection";
            // 
            // sNpSelectCheckBox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(gbSnP);
            MinimumSize = new System.Drawing.Size(110, 130);
            Name = "sNpSelectCheckBox";
            Size = new System.Drawing.Size(110, 130);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudNumPorts).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            gbSnP.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnEditSelection;
        private System.Windows.Forms.NumericUpDown nudNumPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lbSParameters;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox gbSnP;
        private System.Windows.Forms.Panel panel5;
    }
}
