using System;

namespace Nuvo.Math.Core.Special
{
	/// <summary>
	/// Ellipitc
	/// </summary>
	// Token: 0x02000029 RID: 41
	public static class Elliptic
	{
		/// <summary>
		/// Complete elliptic integrals
		/// </summary>
		/// <param name="m"></param>
		/// <param name="e"></param>
		/// <returns></returns>
		// Token: 0x06000218 RID: 536 RVA: 0x00009AF0 File Offset: 0x00007CF0
		public static double Ellipke(double m, out double e)
		{
			double result = alglib.ellipticintegralk(m);
			e = alglib.ellipticintegrale(m);
			return result;
		}
	}
}
