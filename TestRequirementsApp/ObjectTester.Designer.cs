namespace Requirements_Builder
{
    partial class ObjectTester
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panelHeader1 = new PanelHeader();
            this.objectMethodTester1 = new Requirements_Builder.ObjectMethodTester();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 20);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.propertyGrid1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.objectMethodTester1);
            this.splitContainer1.Size = new System.Drawing.Size(443, 405);
            this.splitContainer1.SplitterDistance = 194;
            this.splitContainer1.TabIndex = 1;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(441, 192);
            this.propertyGrid1.TabIndex = 0;
            // 
            // panelHeader1
            // 
            this.panelHeader1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader1.HeaderText = "Object Name";
            this.panelHeader1.Location = new System.Drawing.Point(0, 0);
            this.panelHeader1.Name = "panelHeader1";
            this.panelHeader1.Size = new System.Drawing.Size(443, 20);
            this.panelHeader1.TabIndex = 0;
            // 
            // objectMethodTester1
            // 
            this.objectMethodTester1.AutoScroll = true;
            this.objectMethodTester1.Columns = 1;
            this.objectMethodTester1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectMethodTester1.Location = new System.Drawing.Point(0, 0);
            this.objectMethodTester1.Name = "objectMethodTester1";
            this.objectMethodTester1.RowHeight = 100;
            this.objectMethodTester1.Size = new System.Drawing.Size(441, 205);
            this.objectMethodTester1.TabIndex = 0;
            // 
            // ObjectTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelHeader1);
            this.Name = "ObjectTester";
            this.Size = new System.Drawing.Size(443, 425);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PanelHeader panelHeader1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private ObjectMethodTester objectMethodTester1;
    }
}
