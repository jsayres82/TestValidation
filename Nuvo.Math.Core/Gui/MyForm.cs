using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nuvo.Math.Core.Gui
{
	/// <summary>
	/// My Form
	/// </summary>
	// Token: 0x0200004A RID: 74
	public partial class MyForm : Form
	{
		/// <summary>
		/// My Form
		/// </summary>
		// Token: 0x06000389 RID: 905 RVA: 0x0000F288 File Offset: 0x0000D488
		public MyForm()
		{
			if (Control.DefaultFont.Height > 13)
			{
				this.Font = new Font(SystemFonts.MessageBoxFont, FontStyle.Regular);
			}
		}
	}
}
