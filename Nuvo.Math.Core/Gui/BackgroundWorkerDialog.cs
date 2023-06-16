using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Nuvo.Math.Core.Gui
{
	/// <summary>
	/// Background Worker dialog
	/// </summary>
	// Token: 0x02000047 RID: 71
	public partial class BackgroundWorkerDialog : MyForm
	{
		/// <summary>
		/// Background Worker Dialog
		/// </summary>
		// Token: 0x06000374 RID: 884 RVA: 0x0000ED1C File Offset: 0x0000CF1C
		public BackgroundWorkerDialog()
		{
			this.InitializeComponent();
		}

		/// <summary>
		/// Shows Dialog and starts with work
		/// </summary>
		/// <param name="doWork"></param>
		/// <returns></returns>
		// Token: 0x06000375 RID: 885 RVA: 0x0000ED35 File Offset: 0x0000CF35
		public Exception Start(DoWorkEventHandler doWork)
		{
			this.bw.DoWork += doWork;
			this.bw.RunWorkerAsync();
			base.ShowDialog();
			this.bw.DoWork -= doWork;
			return this.error;
		}

		/// <summary>
		/// Default Progress Text
		/// </summary>
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000376 RID: 886 RVA: 0x0000ED67 File Offset: 0x0000CF67
		// (set) Token: 0x06000377 RID: 887 RVA: 0x0000ED6F File Offset: 0x0000CF6F
		public string DefaultProgressText
		{
			get
			{
				return this._defaultProgressText;
			}
			set
			{
				this._defaultProgressText = value;
			}
		}

		// Token: 0x06000378 RID: 888 RVA: 0x0000ED78 File Offset: 0x0000CF78
		private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			string report = e.UserState as string;
			if (string.IsNullOrEmpty(report))
			{
				report = this.DefaultProgressText;
			}
			this.Text = report;
			this.progressBar1.Value = e.ProgressPercentage;
		}

		// Token: 0x06000379 RID: 889 RVA: 0x0000EDB8 File Offset: 0x0000CFB8
		private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Cancelled)
			{
				this.error = new Exception("Canceled!");
				this.Text = "Canceled!";
			}
			else if (e.Error != null)
			{
				this.error = e.Error;
				this.Text = "Error: " + e.Error.Message;
			}
			else
			{
				this.error = null;
				this.Text = "Done!";
			}
			base.Close();
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0000EE33 File Offset: 0x0000D033
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.error = new Exception("Canceled!");
			this.bw.CancelAsync();
		}

		// Token: 0x0600037B RID: 891 RVA: 0x0000EE50 File Offset: 0x0000D050
		private void BackgroundWorkerDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.bw.IsBusy)
			{
				this.error = new Exception("Canceled!");
				this.bw.CancelAsync();
			}
		}

		// Token: 0x04000041 RID: 65
		private string _defaultProgressText = "";

		// Token: 0x04000042 RID: 66
		private Exception error;
	}
}
