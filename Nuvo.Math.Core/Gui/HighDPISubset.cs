using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nuvo.Math.Core.Gui
{
	/// <summary>
	/// High DPI Subset
	/// </summary>
	// Token: 0x02000049 RID: 73
	internal static class HighDPISubset
	{
		/// <summary>
		/// DPI X
		/// </summary>
		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000384 RID: 900 RVA: 0x0000F21D File Offset: 0x0000D41D
		public static float DpiX
		{
			get
			{
				return HighDPISubset.graphics.DpiX;
			}
		}

		/// <summary>
		/// DPI X
		/// </summary>
		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000385 RID: 901 RVA: 0x0000F229 File Offset: 0x0000D429
		public static float DpiY
		{
			get
			{
				return HighDPISubset.graphics.DpiY;
			}
		}

		/// <summary>
		/// Scales Value X
		/// </summary>
		/// <param name="value">Value</param>
		/// <returns>Scaled Value</returns>
		// Token: 0x06000386 RID: 902 RVA: 0x0000F235 File Offset: 0x0000D435
		public static int ScaleValueX(int value)
		{
			return (int)System.Math.Round((double)((float)value * HighDPISubset.DpiX / 96f));
		}

		/// <summary>
		/// Scales Value Y
		/// </summary>
		/// <param name="value">Value</param>
		/// <returns>Scaled Value</returns>
		// Token: 0x06000387 RID: 903 RVA: 0x0000F24C File Offset: 0x0000D44C
		public static int ScaleValueY(int value)
		{
			return (int)System.Math.Round((double)((float)value * HighDPISubset.DpiY / 96f));
		}

		/// <summary>
		/// Design DPI
		/// </summary>
		// Token: 0x0400004B RID: 75
		public const float DesignDPI = 96f;

		// Token: 0x0400004C RID: 76
		private static Control control = new Control();

		// Token: 0x0400004D RID: 77
		private static Graphics graphics = HighDPISubset.control.CreateGraphics();

		// Token: 0x0400004E RID: 78
		private static MyForm myForm = new MyForm();
	}
}
