using System;

namespace Nuvo.Math.Core.Special
{
	/// <summary>
	/// Erf 28
	/// </summary>
	// Token: 0x0200002A RID: 42
	public class Erf28
	{
		/// <summary>
		/// Erf
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x06000219 RID: 537 RVA: 0x00009B00 File Offset: 0x00007D00
		public static double Erf(double x)
		{
			if (x >= 0.0)
			{
				return 1.0 - Erf28.Erfccheb(x);
			}
			return Erf28.Erfccheb(-x) - 1.0;
		}

		/// <summary>
		/// Erfc
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x0600021A RID: 538 RVA: 0x00009B30 File Offset: 0x00007D30
		public static double Erfc(double x)
		{
			if (x >= 0.0)
			{
				return Erf28.Erfccheb(x);
			}
			return 2.0 - Erf28.Erfccheb(-x);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00009B58 File Offset: 0x00007D58
		private static double Erfccheb(double z)
		{
			double d = 0.0;
			double dd = 0.0;
			if (z < 0.0)
			{
				throw new Exception("erfccheb requires nonnegative argument");
			}
			double t = 2.0 / (2.0 + z);
			double ty = 4.0 * t - 2.0;
			for (int i = Erf28.ncof - 1; i > 0; i--)
			{
				double num = d;
				d = ty * d - dd + Erf28.cof[i];
				dd = num;
			}
			return t * System.Math.Exp(-z * z + 0.5 * (Erf28.cof[0] + ty * d) - dd);
		}

		/// <summary>
		/// Inverfc
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		// Token: 0x0600021C RID: 540 RVA: 0x00009C08 File Offset: 0x00007E08
		public static double Inverfc(double p)
		{
			if (p >= 2.0)
			{
				return -100.0;
			}
			if (p <= 0.0)
			{
				return 100.0;
			}
			double pp = (p < 1.0) ? p : (2.0 - p);
			double t = System.Math.Sqrt(-2.0 * System.Math.Log(pp / 2.0));
			double x = -0.70711 * ((2.30753 + t * 0.27061) / (1.0 + t * (0.99229 + t * 0.04481)) - t);
			for (int i = 0; i < 2; i++)
			{
				double err = Erf28.Erfc(x) - pp;
				x += err / (1.1283791670955126 * System.Math.Exp(-(x * x)) - x * err);
			}
			if (p >= 1.0)
			{
				return -x;
			}
			return x;
		}

		/// <summary>
		/// Inverf
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		// Token: 0x0600021D RID: 541 RVA: 0x00009D05 File Offset: 0x00007F05
		public static double Inverf(double p)
		{
			return Erf28.Inverfc(1.0 - p);
		}

		/// <summary>
		/// Erfcc
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x0600021E RID: 542 RVA: 0x00009D18 File Offset: 0x00007F18
		public static double Erfcc(double x)
		{
			double z = System.Math.Abs(x);
			double t = 2.0 / (2.0 + z);
			double ans = t * System.Math.Exp(-z * z - 1.26551223 + t * (1.00002368 + t * (0.37409196 + t * (0.09678418 + t * (-0.18628806 + t * (0.27886807 + t * (-1.13520398 + t * (1.48851587 + t * (-0.82215223 + t * 0.17087277)))))))));
			if (x < 0.0)
			{
				return 2.0 - ans;
			}
			return ans;
		}

		// Token: 0x04000013 RID: 19
		private static int ncof = 28;

		// Token: 0x04000014 RID: 20
		private static double[] cof = new double[]
		{
			-1.3026537197817094,
			0.6419697923564902,
			0.019476473204185836,
			-0.00956151478680863,
			-0.000946595344482036,
			0.000366839497852761,
			4.2523324806907E-05,
			-2.0278578112534E-05,
			-1.624290004647E-06,
			1.30365583558E-06,
			1.5626441722E-08,
			-8.5238095915E-08,
			6.529054439E-09,
			5.059343495E-09,
			-9.91364156E-10,
			-2.27365122E-10,
			9.6467911E-11,
			2.394038E-12,
			-6.886027E-12,
			8.94487E-13,
			3.13092E-13,
			-1.12708E-13,
			3.81E-16,
			7.106E-15,
			-1.523E-15,
			-9.4E-17,
			1.21E-16,
			-2.8E-17
		};
	}
}
