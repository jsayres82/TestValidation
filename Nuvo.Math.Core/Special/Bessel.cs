using System;

namespace Nuvo.Math.Core.Special
{
	/// <summary>
	/// Bessel
	/// </summary>
	// Token: 0x02000027 RID: 39
	public static class Bessel
	{
		/// <summary>
		/// Modified Bessel function of order zero
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x06000211 RID: 529 RVA: 0x000098DD File Offset: 0x00007ADD
		public static double BesselI0(double x)
		{
			return alglib.besseli0(x);
		}
	}
}
