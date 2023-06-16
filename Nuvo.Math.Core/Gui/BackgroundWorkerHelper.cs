using System;
using System.ComponentModel;
using System.Threading;

namespace Nuvo.Math.Core.Gui
{
	/// <summary>
	/// Background Worker Helper
	/// </summary>
	// Token: 0x02000048 RID: 72
	public class BackgroundWorkerHelper
	{
		/// <summary>
		/// Background Worker Helper
		/// </summary>
		// Token: 0x0600037E RID: 894 RVA: 0x0000F0A0 File Offset: 0x0000D2A0
		public BackgroundWorkerHelper()
		{
			this.bw = new BackgroundWorker();
			this.bw.WorkerReportsProgress = true;
			this.bw.WorkerSupportsCancellation = true;
			this.bw.ProgressChanged += this.bw_ProgressChanged;
			this.bw.RunWorkerCompleted += this.bw_RunWorkerCompleted;
		}

		/// <summary>
		/// Starts with work
		/// </summary>
		/// <param name="doWork"></param>
		/// <param name="showDialog"></param>
		/// <returns></returns>
		// Token: 0x0600037F RID: 895 RVA: 0x0000F110 File Offset: 0x0000D310
		public Exception Start(DoWorkEventHandler doWork, bool showDialog)
		{
			if (showDialog)
			{
				return new BackgroundWorkerDialog
				{
					DefaultProgressText = this.DefaultProgressText
				}.Start(doWork);
			}
			this.bw.DoWork += doWork;
			this.bw.RunWorkerAsync();
			this._isbusy = true;
			while (this._isbusy)
			{
				Thread.Sleep(1);
			}
			this.bw.DoWork -= doWork;
			return this.error;
		}

		/// <summary>
		/// Default Progress Text
		/// </summary>
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000380 RID: 896 RVA: 0x0000F178 File Offset: 0x0000D378
		// (set) Token: 0x06000381 RID: 897 RVA: 0x0000F180 File Offset: 0x0000D380
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

		// Token: 0x06000382 RID: 898 RVA: 0x0000F189 File Offset: 0x0000D389
		private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (string.IsNullOrEmpty(e.UserState as string))
			{
				string defaultProgressText = this.DefaultProgressText;
			}
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0000F1A4 File Offset: 0x0000D3A4
		private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Cancelled)
			{
				this.error = new Exception("Canceled!");
				Console.WriteLine("Canceled!");
			}
			else if (e.Error != null)
			{
				this.error = e.Error;
				Console.WriteLine("Error: " + e.Error.Message);
			}
			else
			{
				this.error = null;
				Console.WriteLine("Done!");
			}
			this._isbusy = false;
		}

		// Token: 0x04000047 RID: 71
		private BackgroundWorker bw;

		// Token: 0x04000048 RID: 72
		private bool _isbusy;

		// Token: 0x04000049 RID: 73
		private Exception error;

		// Token: 0x0400004A RID: 74
		private string _defaultProgressText = "";
	}
}
