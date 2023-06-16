using System;

namespace Nuvo.Math.Core.Special
{
	// Token: 0x0200002D RID: 45
	internal static class Special
	{
		// Token: 0x0600022B RID: 555 RVA: 0x0000A098 File Offset: 0x00008298
		public static double Gammln(double xx)
		{
			double[] cof = new double[]
			{
				57.15623566586292,
				-59.59796035547549,
				14.136097974741746,
				-0.4919138160976202,
				3.399464998481189E-05,
				4.652362892704858E-05,
				-9.837447530487956E-05,
				0.0001580887032249125,
				-0.00021026444172410488,
				0.00021743961811521265,
				-0.0001643181065367639,
				8.441822398385275E-05,
				-2.6190838401581408E-05,
				3.6899182659531625E-06
			};
			if (xx <= 0.0)
			{
				throw new Exception("bad arg in gammln");
			}
			double y = xx;
			double tmp = xx + 5.2421875;
			tmp = (xx + 0.5) * System.Math.Log(tmp) - tmp;
			double ser = 0.9999999999999971;
			for (int i = 0; i < 14; i++)
			{
				ser += cof[i] / (y += 1.0);
			}
			return tmp + System.Math.Log(2.5066282746310007 * ser / xx);
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0000A13C File Offset: 0x0000833C
		public static double Factrl(int n)
		{
			if (Special.init_a)
			{
				Special.init_a = false;
				Special.a[0] = 1.0;
				for (int i = 1; i < 171; i++)
				{
					Special.a[i] = (double)i * Special.a[i - 1];
				}
			}
			if (n < 0 || n > 170)
			{
				throw new Exception("factrl out of range");
			}
			return Special.a[n];
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0000A1A8 File Offset: 0x000083A8
		public static double Factln(int n)
		{
			if (Special.init_b)
			{
				Special.init_b = false;
				for (int i = 0; i < Special.NTOP; i++)
				{
					Special.b[i] = Special.Gammln((double)(i + 1));
				}
			}
			if (n < 0)
			{
				throw new Exception("negative arg in factln");
			}
			if (n < Special.NTOP)
			{
				return Special.b[n];
			}
			return Special.Gammln((double)(n + 1));
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0000A20C File Offset: 0x0000840C
		public static double Bico(int n, int k)
		{
			if (n < 0 || k < 0 || k > n)
			{
				throw new Exception("bad args in bico");
			}
			if (n < 171)
			{
				return System.Math.Floor(0.5 + Special.Factrl(n) / (Special.Factrl(k) * Special.Factrl(n - k)));
			}
			return System.Math.Floor(0.5 + System.Math.Exp(Special.Factln(n) - Special.Factln(k) - Special.Factln(n - k)));
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0000A288 File Offset: 0x00008488
		public static double Beta(double z, double w)
		{
			return System.Math.Exp(Special.Gammln(z) + Special.Gammln(w) - Special.Gammln(z + w));
		}

		// Token: 0x04000019 RID: 25
		private static double[] a = new double[171];

		// Token: 0x0400001A RID: 26
		private static bool init_a = true;

		// Token: 0x0400001B RID: 27
		private static int NTOP = 2000;

		// Token: 0x0400001C RID: 28
		private static double[] b = new double[Special.NTOP];

		// Token: 0x0400001D RID: 29
		private static bool init_b = true;
	}
}
