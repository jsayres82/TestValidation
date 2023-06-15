
namespace Requirements_Builder
{
    partial class TestArticleCtrl
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
            this.components = new System.ComponentModel.Container();
            this.textBoxTestName = new Requirements_Builder.EmptyTextTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.emptyTextTextBox1 = new Requirements_Builder.EmptyTextTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxMeasurementFiles = new System.Windows.Forms.ListBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTestName
            // 
            this.textBoxTestName.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxTestName.EmptyText = null;
            this.textBoxTestName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxTestName.Location = new System.Drawing.Point(3, 17);
            this.textBoxTestName.Name = "textBoxTestName";
            this.textBoxTestName.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxTestName.Size = new System.Drawing.Size(125, 23);
            this.textBoxTestName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // emptyTextTextBox1
            // 
            this.emptyTextTextBox1.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            this.emptyTextTextBox1.EmptyText = null;
            this.emptyTextTextBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.emptyTextTextBox1.Location = new System.Drawing.Point(3, 74);
            this.emptyTextTextBox1.Name = "emptyTextTextBox1";
            this.emptyTextTextBox1.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            this.emptyTextTextBox1.Size = new System.Drawing.Size(125, 23);
            this.emptyTextTextBox1.TabIndex = 6;
            this.emptyTextTextBox1.TextChanged += new System.EventHandler(this.emptyTextTextBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Part Number";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // listBoxMeasurementFiles
            // 
            this.listBoxMeasurementFiles.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBoxMeasurementFiles.FormattingEnabled = true;
            this.listBoxMeasurementFiles.ItemHeight = 15;
            this.listBoxMeasurementFiles.Location = new System.Drawing.Point(134, 0);
            this.listBoxMeasurementFiles.Name = "listBoxMeasurementFiles";
            this.listBoxMeasurementFiles.Size = new System.Drawing.Size(177, 110);
            this.listBoxMeasurementFiles.TabIndex = 7;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.textBoxTestName.Controls;
            // 
            // TestArticleCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxMeasurementFiles);
            this.Controls.Add(this.emptyTextTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxTestName);
            this.Controls.Add(this.label1);
            this.Name = "TestArticleCtrl";
            this.Size = new System.Drawing.Size(311, 110);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EmptyTextTextBox textBoxTestName;
        private System.Windows.Forms.Label label1;
        private EmptyTextTextBox emptyTextTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxMeasurementFiles;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}
