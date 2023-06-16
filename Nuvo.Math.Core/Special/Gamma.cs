using System;

namespace Nuvo.Math.Core.Special
{
	// Token: 0x0200002F RID: 47
	internal class Gamma : Gauleg18
	{
		// Token: 0x06000233 RID: 563 RVA: 0x0000A34C File Offset: 0x0000854C
		public static double Gammp(double a, double x)
		{
			if (x < 0.0 || a <= 0.0)
			{
				throw new Exception("bad args in gammp");
			}
			if (x == 0.0)
			{
				return 0.0;
			}
			if ((int)a >= Gamma.ASWITCH)
			{
				return Gamma.Gammpapprox(a, x, 1);
			}
			if (x < a + 1.0)
			{
				return Gamma.Gser(a, x);
			}
			return 1.0 - Gamma.Gcf(a, x);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0000A3CC File Offset: 0x000085CC
		public static double Gammq(double a, double x)
		{
			if (x < 0.0 || a <= 0.0)
			{
				throw new Exception("bad args in gammq");
			}
			if (x == 0.0)
			{
				return 1.0;
			}
			if ((int)a >= Gamma.ASWITCH)
			{
				return Gamma.Gammpapprox(a, x, 0);
			}
			if (x < a + 1.0)
			{
				return 1.0 - Gamma.Gser(a, x);
			}
			return Gamma.Gcf(a, x);
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000A44C File Offset: 0x0000864C
		private static double Gser(double a, double x)
		{
			double gln = Special.Gammln(a);
			double ap = a;
			double del;
			double sum = del = 1.0 / a;
			do
			{
				ap += 1.0;
				del *= x / ap;
				sum += del;
			}
			while (Math.Abs(del) >= Math.Abs(sum) * Gauleg18.EPS);
			return sum * Math.Exp(-x + a * Math.Log(x) - gln);
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000A4B0 File Offset: 0x000086B0
		private static double Gcf(double a, double x)
		{
			double gln = Special.Gammln(a);
			double b = x + 1.0 - a;
			double c = 1.0 / Gauleg18.FPMIN;
			double d = 1.0 / b;
			double h = d;
			int i = 1;
			for (;;)
			{
				double an = (double)(-(double)i) * ((double)i - a);
				b += 2.0;
				d = an * d + b;
				if (Math.Abs(d) < Gauleg18.FPMIN)
				{
					d = Gauleg18.FPMIN;
				}
				c = b + an / c;
				if (Math.Abs(c) < Gauleg18.FPMIN)
				{
					c = Gauleg18.FPMIN;
				}
				d = 1.0 / d;
				double del = d * c;
				h *= del;
				if (Math.Abs(del - 1.0) <= Gauleg18.EPS)
				{
					break;
				}
				i++;
			}
			return Math.Exp(-x + a * Math.Log(x) - gln) * h;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0000A590 File Offset: 0x00008790
		private static double Gammpapprox(double a, double x, int psig)
		{
			double a2 = a - 1.0;
			double lna = Math.Log(a2);
			double sqrta = Math.Sqrt(a2);
			double gln = Special.Gammln(a);
			double xu;
			if (x > a2)
			{
				xu = Math.Max(a2 + 11.5 * sqrta, x + 6.0 * sqrta);
			}
			else
			{
				xu = Math.Max(0.0, Math.Min(a2 - 7.5 * sqrta, x - 5.0 * sqrta));
			}
			double sum = 0.0;
			for (int i = 0; i < Gauleg18.ngau; i++)
			{
				double t = x + (xu - x) * Gauleg18.y[i];
				sum += Gauleg18.w[i] * Math.Exp(-(t - a2) + a2 * (Math.Log(t) - lna));
			}
			double ans = sum * (xu - x) * Math.Exp(a2 * (lna - 1.0) - gln);
			if (psig != 1)
			{
				if (ans < 0.0)
				{
					return 1.0 + ans;
				}
				return ans;
			}
			else
			{
				if (ans <= 0.0)
				{
					return -ans;
				}
				return 1.0 - ans;
			}
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000A6C8 File Offset: 0x000088C8
		public static double Invgammp(double p, double a)
		{
			double lna = 0.0;
			double afac = 0.0;
			double a2 = a - 1.0;
			double EPS2 = 1E-08;
			double gln = Special.Gammln(a);
			if (a <= 0.0)
			{
				throw new Exception("a must be pos in invgammap");
			}
			if (p >= 1.0)
			{
				return Math.Max(100.0, a + 100.0 * Math.Sqrt(a));
			}
			if (p <= 0.0)
			{
				return 0.0;
			}
			double x;
			if (a > 1.0)
			{
				lna = Math.Log(a2);
				afac = Math.Exp(a2 * (lna - 1.0) - gln);
				double pp = (p < 0.5) ? p : (1.0 - p);
				double t = Math.Sqrt(-2.0 * Math.Log(pp));
				x = (2.30753 + t * 0.27061) / (1.0 + t * (0.99229 + t * 0.04481)) - t;
				if (p < 0.5)
				{
					x = -x;
				}
				x = Math.Max(0.001, a * Math.Pow(1.0 - 1.0 / (9.0 * a) - x / (3.0 * Math.Sqrt(a)), 3.0));
			}
			else
			{
				double t = 1.0 - a * (0.253 + a * 0.12);
				if (p < t)
				{
					x = Math.Pow(p / t, 1.0 / a);
				}
				else
				{
					x = 1.0 - Math.Log(1.0 - (p - t) / (1.0 - t));
				}
			}
			for (int i = 0; i < 12; i++)
			{
				if (x <= 0.0)
				{
					return 0.0;
				}
				double num = Gamma.Gammp(a, x) - p;
				double t;
				if (a > 1.0)
				{
					t = afac * Math.Exp(-(x - a2) + a2 * (Math.Log(x) - lna));
				}
				else
				{
					t = Math.Exp(-x + a2 * Math.Log(x) - gln);
				}
				double u = num / t;
				x -= (t = u / (1.0 - 0.5 * Math.Min(1.0, u * ((a - 1.0) / x - 1.0))));
				if (x <= 0.0)
				{
					x = 0.5 * (x + t);
				}
				if (Math.Abs(t) < EPS2 * x)
				{
					break;
				}
			}
			return x;
		}

		// Token: 0x04000024 RID: 36
		private static int ASWITCH = 100;
	}
}
