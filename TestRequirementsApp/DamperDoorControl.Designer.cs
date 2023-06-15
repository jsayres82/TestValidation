namespace Requirements_Builder
{
    partial class DamperDoorControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.inactivateButton = new System.Windows.Forms.Button();
            this.activateButton = new System.Windows.Forms.Button();
            this.solenoidStateLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.solenoidNameLabel = new System.Windows.Forms.Label();
            this.getSolenoidButton = new System.Windows.Forms.Button();
            this.cellLocationBox = new CustomControls.EmptyTextTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 20);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Damper Door Control";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.inactivateButton);
            this.panel2.Controls.Add(this.activateButton);
            this.panel2.Controls.Add(this.solenoidStateLabel);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.solenoidNameLabel);
            this.panel2.Controls.Add(this.getSolenoidButton);
            this.panel2.Controls.Add(this.cellLocationBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 113);
            this.panel2.TabIndex = 2;
            // 
            // inactivateButton
            // 
            this.inactivateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inactivateButton.Location = new System.Drawing.Point(96, 87);
            this.inactivateButton.Name = "inactivateButton";
            this.inactivateButton.Size = new System.Drawing.Size(87, 23);
            this.inactivateButton.TabIndex = 8;
            this.inactivateButton.Text = "Inactivate";
            this.inactivateButton.UseVisualStyleBackColor = true;
            this.inactivateButton.Click += new System.EventHandler(this.inactivateButton_Click);
            // 
            // activateButton
            // 
            this.activateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.activateButton.Location = new System.Drawing.Point(3, 87);
            this.activateButton.Name = "activateButton";
            this.activateButton.Size = new System.Drawing.Size(87, 23);
            this.activateButton.TabIndex = 7;
            this.activateButton.Text = "Activate";
            this.activateButton.UseVisualStyleBackColor = true;
            this.activateButton.Click += new System.EventHandler(this.activateButton_Click);
            // 
            // solenoidStateLabel
            // 
            this.solenoidStateLabel.AutoSize = true;
            this.solenoidStateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solenoidStateLabel.Location = new System.Drawing.Point(44, 67);
            this.solenoidStateLabel.Margin = new System.Windows.Forms.Padding(3);
            this.solenoidStateLabel.Name = "solenoidStateLabel";
            this.solenoidStateLabel.Size = new System.Drawing.Size(53, 13);
            this.solenoidStateLabel.TabIndex = 6;
            this.solenoidStateLabel.Text = "Unknown";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "State:";
            // 
            // solenoidNameLabel
            // 
            this.solenoidNameLabel.AutoSize = true;
            this.solenoidNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solenoidNameLabel.Location = new System.Drawing.Point(3, 48);
            this.solenoidNameLabel.Margin = new System.Windows.Forms.Padding(3);
            this.solenoidNameLabel.Name = "solenoidNameLabel";
            this.solenoidNameLabel.Size = new System.Drawing.Size(76, 13);
            this.solenoidNameLabel.TabIndex = 4;
            this.solenoidNameLabel.Text = "No Solenoid";
            // 
            // getSolenoidButton
            // 
            this.getSolenoidButton.Location = new System.Drawing.Point(83, 6);
            this.getSolenoidButton.Name = "getSolenoidButton";
            this.getSolenoidButton.Size = new System.Drawing.Size(87, 23);
            this.getSolenoidButton.TabIndex = 3;
            this.getSolenoidButton.Text = "Get Solenoid";
            this.getSolenoidButton.UseVisualStyleBackColor = true;
            this.getSolenoidButton.Click += new System.EventHandler(this.getSolenoidButton_Click);
            // 
            // cellLocationBox
            // 
            this.cellLocationBox.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            this.cellLocationBox.EmptyText = "Cell Location";
            this.cellLocationBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cellLocationBox.Location = new System.Drawing.Point(3, 8);
            this.cellLocationBox.Name = "cellLocationBox";
            this.cellLocationBox.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            this.cellLocationBox.Size = new System.Drawing.Size(74, 20);
            this.cellLocationBox.TabIndex = 2;
            this.cellLocationBox.Text = "Cell Location";
            // 
            // DamperDoorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(188, 135);
            this.Name = "DamperDoorControl";
            this.Size = new System.Drawing.Size(186, 133);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private CustomControls.EmptyTextTextBox cellLocationBox;
        private System.Windows.Forms.Button getSolenoidButton;
        private System.Windows.Forms.Button inactivateButton;
        private System.Windows.Forms.Button activateButton;
        private System.Windows.Forms.Label solenoidStateLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label solenoidNameLabel;
    }
}
