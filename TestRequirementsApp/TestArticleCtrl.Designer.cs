
namespace Nuvo.Requirements_Builder
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
            components = new System.ComponentModel.Container();
            bindingSource1 = new System.Windows.Forms.BindingSource(components);
            panel1 = new System.Windows.Forms.Panel();
            label4 = new System.Windows.Forms.Label();
            textBoxWaferLotNum = new EmptyTextTextBox();
            listBoxMeasurementFiles = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBoxWaferLotNum);
            panel1.Controls.Add(listBoxMeasurementFiles);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(358, 274);
            panel1.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(3, 10);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(107, 15);
            label4.TabIndex = 9;
            label4.Text = "Wafer/Lot Number";
            // 
            // textBoxWaferLotNum
            // 
            textBoxWaferLotNum.EmptyForeColor = System.Drawing.SystemColors.GrayText;
            textBoxWaferLotNum.EmptyText = null;
            textBoxWaferLotNum.ForeColor = System.Drawing.SystemColors.WindowText;
            textBoxWaferLotNum.Location = new System.Drawing.Point(3, 28);
            textBoxWaferLotNum.Name = "textBoxWaferLotNum";
            textBoxWaferLotNum.NonEmptyForeColor = System.Drawing.SystemColors.WindowText;
            textBoxWaferLotNum.Size = new System.Drawing.Size(150, 23);
            textBoxWaferLotNum.TabIndex = 10;
            textBoxWaferLotNum.TextChanged += textBoxWaferLotNum_TextChanged;
            // 
            // listBoxMeasurementFiles
            // 
            listBoxMeasurementFiles.Dock = System.Windows.Forms.DockStyle.Right;
            listBoxMeasurementFiles.FormattingEnabled = true;
            listBoxMeasurementFiles.ItemHeight = 15;
            listBoxMeasurementFiles.Location = new System.Drawing.Point(181, 0);
            listBoxMeasurementFiles.Name = "listBoxMeasurementFiles";
            listBoxMeasurementFiles.Size = new System.Drawing.Size(177, 274);
            listBoxMeasurementFiles.TabIndex = 8;
            // 
            // TestArticleCtrl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "TestArticleCtrl";
            Size = new System.Drawing.Size(358, 274);
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private EmptyTextTextBox textBoxWaferLotNum;
        private System.Windows.Forms.ListBox listBoxMeasurementFiles;
    }
}
