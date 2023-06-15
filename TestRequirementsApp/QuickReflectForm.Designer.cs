 
namespace Requirements_Builder
{
    partial class QuickReflectForm
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
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickReflectForm));
            this._reflectTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // _reflectTreeView
            // 
            this._reflectTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._reflectTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._reflectTreeView.Location = new System.Drawing.Point(0, 0);
            this._reflectTreeView.Name = "_reflectTreeView";
            this._reflectTreeView.Size = new System.Drawing.Size(573, 603);
            this._reflectTreeView.TabIndex = 0;
            // 
            // QuickReflectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 603);
            this.Controls.Add(this._reflectTreeView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuickReflectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Quick Watch";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView _reflectTreeView;
    }
}