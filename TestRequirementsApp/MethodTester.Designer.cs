namespace Requirements_Builder
{
    partial class MethodTester
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
            this.parametersPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.invokeButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // parametersPropertyGrid
            // 
            this.parametersPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parametersPropertyGrid.HelpVisible = false;
            this.parametersPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.parametersPropertyGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.parametersPropertyGrid.Name = "parametersPropertyGrid";
            this.parametersPropertyGrid.Size = new System.Drawing.Size(383, 90);
            this.parametersPropertyGrid.TabIndex = 1;
            this.parametersPropertyGrid.ToolbarVisible = false;
            // 
            // invokeButton
            // 
            this.invokeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.invokeButton.Location = new System.Drawing.Point(383, 0);
            this.invokeButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.invokeButton.MaximumSize = new System.Drawing.Size(82, 27);
            this.invokeButton.MinimumSize = new System.Drawing.Size(82, 27);
            this.invokeButton.Name = "invokeButton";
            this.invokeButton.Size = new System.Drawing.Size(82, 27);
            this.invokeButton.TabIndex = 1;
            this.invokeButton.Text = "Invoke";
            this.invokeButton.UseVisualStyleBackColor = true;
            this.invokeButton.Click += new System.EventHandler(this.invokeButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.parametersPropertyGrid);
            this.panel1.Controls.Add(this.invokeButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 92);
            this.panel1.TabIndex = 2;
            // 
            // MethodTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(467, 92);
            this.Name = "MethodTester";
            this.Size = new System.Drawing.Size(467, 92);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PanelHeader header;
        private System.Windows.Forms.PropertyGrid parametersPropertyGrid;
        private System.Windows.Forms.Button invokeButton;
        private System.Windows.Forms.Panel panel1;


    }
}
