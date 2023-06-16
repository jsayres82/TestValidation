namespace Nuvo.Math.Core.Gui
{
	/// <summary>
	/// Background Worker dialog
	/// </summary>
	// Token: 0x02000047 RID: 71
	public partial class BackgroundWorkerDialog : global::Nuvo.Math.Core.Gui.MyForm
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		// Token: 0x0600037C RID: 892 RVA: 0x0000EE7A File Offset: 0x0000D07A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		// Token: 0x0600037D RID: 893 RVA: 0x0000EE9C File Offset: 0x0000D09C
		private void InitializeComponent()
		{
			this.progressBar1 = new global::System.Windows.Forms.ProgressBar();
			this.buttonCancel = new global::System.Windows.Forms.Button();
			this.bw = new global::System.ComponentModel.BackgroundWorker();
			base.SuspendLayout();
			this.progressBar1.Location = new global::System.Drawing.Point(8, 8);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new global::System.Drawing.Size(536, 23);
			this.progressBar1.Step = 1;
			this.progressBar1.TabIndex = 0;
			this.buttonCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new global::System.Drawing.Point(552, 8);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new global::System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new global::System.EventHandler(this.buttonCancel_Click);
			this.bw.WorkerReportsProgress = true;
			this.bw.WorkerSupportsCancellation = true;
			this.bw.RunWorkerCompleted += new global::System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
			this.bw.ProgressChanged += new global::System.ComponentModel.ProgressChangedEventHandler(this.bw_ProgressChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.buttonCancel;
			base.ClientSize = new global::System.Drawing.Size(634, 40);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.progressBar1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "BackgroundWorkerDialog";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			base.TopMost = true;
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.BackgroundWorkerDialog_FormClosing);
			base.ResumeLayout(false);
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x04000043 RID: 67
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000044 RID: 68
		private global::System.Windows.Forms.ProgressBar progressBar1;

		// Token: 0x04000045 RID: 69
		private global::System.Windows.Forms.Button buttonCancel;

		// Token: 0x04000046 RID: 70
		private global::System.ComponentModel.BackgroundWorker bw;
	}
}
