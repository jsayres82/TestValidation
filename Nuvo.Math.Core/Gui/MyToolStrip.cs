using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Nuvo.Math.Core.Gui
{
	/// <summary>
	/// My ToolStrip
	/// Workaround for inheritable ToolStrip
	/// http://stackoverflow.com/questions/6689738/winforms-toolstrip-not-available-in-visual-inheritence
	/// </summary>
	// Token: 0x0200004B RID: 75
	[Designer(typeof(ControlDesigner))]
	public class MyToolStrip : ToolStrip
	{
		/// <summary>
		/// On Resize
		/// </summary>
		/// <param name="e"></param>
		// Token: 0x0600038A RID: 906 RVA: 0x0000F2B0 File Offset: 0x0000D4B0
		protected override void OnResize(EventArgs e)
		{
			if (base.Size.Height != MyToolStrip.height)
			{
				base.Size = new Size(base.Size.Width, MyToolStrip.height);
			}
			base.OnResize(e);
		}

		/// <summary>
		/// Display Rectangle
		/// </summary>
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600038B RID: 907 RVA: 0x0000F2F8 File Offset: 0x0000D4F8
		public override Rectangle DisplayRectangle
		{
			get
			{
				Rectangle rect = base.DisplayRectangle;
				int gripWidth = (base.GripStyle == ToolStripGripStyle.Visible) ? (base.GripMargin.Horizontal + MyToolStrip.gripTickness) : 0;
				rect.Width = base.Size.Width - gripWidth - 1;
				return rect;
			}
		}

		/// <summary>
		/// My ToolStrip
		/// </summary>
		// Token: 0x0600038C RID: 908 RVA: 0x0000F347 File Offset: 0x0000D547
		public MyToolStrip()
		{
			base.GripStyle = ToolStripGripStyle.Hidden;
		}

		// Token: 0x0400004F RID: 79
		private static readonly int height = HighDPISubset.ScaleValueY(25);

		// Token: 0x04000050 RID: 80
		private static readonly int gripTickness = HighDPISubset.ScaleValueX(5);
	}
}
