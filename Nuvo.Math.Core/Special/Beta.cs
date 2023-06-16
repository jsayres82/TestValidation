using System;

namespace Nuvo.Math.Core.Special
{
	// Token: 0x02000030 RID: 48
	internal class Beta : Gauleg18
	{
		// Token: 0x0600023B RID: 571 RVA: 0x0000A9BC File Offset: 0x00008BBC
		public static double Betai(double a, double b, double x)
		{
			if (a <= 0.0 || b <= 0.0)
			{
				throw new Exception("Bad a or b in routine betai");
			}
			if (x < 0.0 || x > 1.0)
			{
				throw new Exception("Bad x in routine betai");
			}
			if (x == 0.0 || x == 1.0)
			{
				return x;
			}
			if (a > (double)Beta.SWITCH && b > (double)Beta.SWITCH)
			{
				return Beta.Betaiapprox(a, b, x);
			}
			double bt = Math.Exp(Special.Gammln(a + b) - Special.Gammln(a) - Special.Gammln(b) + a * Math.Log(x) + b * Math.Log(1.0 - x));
			if (x < (a + 1.0) / (a + b + 2.0))
			{
				return bt * Beta.Betacf(a, b, x) / a;
			}
			return 1.0 - bt * Beta.Betacf(b, a, 1.0 - x) / b;
		}

		// Token: 0x0600023C RID: 572 RVA: 0x0000AAC8 File Offset: 0x00008CC8
		private static double Betacf(double a, double b, double x)
		{
			double qab = a + b;
			double qap = a + 1.0;
			double qam = a - 1.0;
			double c = 1.0;
			double d = 1.0 - qab * x / qap;
			if (Math.Abs(d) < Gauleg18.FPMIN)
			{
				d = Gauleg18.FPMIN;
			}
			d = 1.0 / d;
			double h = d;
			for (int i = 1; i < 10000; i++)
			{
				int m2 = 2 * i;
				double aa = (double)i * (b - (double)i) * x / ((qam + (double)m2) * (a + (double)m2));
				d = 1.0 + aa * d;
				if (Math.Abs(d) < Gauleg18.FPMIN)
				{
					d = Gauleg18.FPMIN;
				}
				c = 1.0 + aa / c;
				if (Math.Abs(c) < Gauleg18.FPMIN)
				{
					c = Gauleg18.FPMIN;
				}
				d = 1.0 / d;
				h *= d * c;
				aa = -(a + (double)i) * (qab + (double)i) * x / ((a + (double)m2) * (qap + (double)m2));
				d = 1.0 + aa * d;
				if (Math.Abs(d) < Gauleg18.FPMIN)
				{
					d = Gauleg18.FPMIN;
				}
				c = 1.0 + aa / c;
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
			}
			return h;
		}

		// Token: 0x0600023D RID: 573 RVA: 0x0000AC50 File Offset: 0x00008E50
		private static double Betaiapprox(double a, double b, double x)
		{
			double a2 = a - 1.0;
			double b2 = b - 1.0;
			double mu = a / (a + b);
			double lnmu = Math.Log(mu);
			double lnmuc = Math.Log(1.0 - mu);
			double t = Math.Sqrt(a * b / (Math.Pow(a + b, 2.0) * (a + b + 1.0)));
			double xu;
			if (x > a / (a + b))
			{
				if (x >= 1.0)
				{
					return 1.0;
				}
				xu = Math.Min(1.0, Math.Max(mu + 10.0 * t, x + 5.0 * t));
			}
			else
			{
				if (x <= 0.0)
				{
					return 0.0;
				}
				xu = Math.Max(0.0, Math.Min(mu - 10.0 * t, x - 5.0 * t));
			}
			double sum = 0.0;
			for (int i = 0; i < 18; i++)
			{
				t = x + (xu - x) * Gauleg18.y[i];
				sum += Gauleg18.w[i] * Math.Exp(a2 * (Math.Log(t) - lnmu) + b2 * (Math.Log(1.0 - t) - lnmuc));
			}
			double ans = sum * (xu - x) * Math.Exp(a2 * lnmu - Special.Gammln(a) + b2 * lnmuc - Special.Gammln(b) + Special.Gammln(a + b));
			if (ans <= 0.0)
			{
				return -ans;
			}
			return 1.0 - ans;
		}

		// Token: 0x0600023E RID: 574 RVA: 0x0000AE00 File Offset: 0x00009000
		public static double Invbetai(double p, double a, double b)
		{
			double EPS2 = 1E-08;
			double a2 = a - 1.0;
			double b2 = b - 1.0;
			if (p <= 0.0)
			{
				return 0.0;
			}
			if (p >= 1.0)
			{
				return 1.0;
			}
			double x;
			if (a >= 1.0 && b >= 1.0)
			{
				double pp = (p < 0.5) ? p : (1.0 - p);
				double t = Math.Sqrt(-2.0 * Math.Log(pp));
				x = (2.30753 + t * 0.27061) / (1.0 + t * (0.99229 + t * 0.04481)) - t;
				if (p < 0.5)
				{
					x = -x;
				}
				double al = (x * x - 3.0) / 6.0;
				double h = 2.0 / (1.0 / (2.0 * a - 1.0) + 1.0 / (2.0 * b - 1.0));
				double w = x * Math.Sqrt(al + h) / h - (1.0 / (2.0 * b - 1.0) - 1.0 / (2.0 * a - 1.0)) * (al + 0.8333333333333334 - 2.0 / (3.0 * h));
				x = a / (a + b * Math.Exp(2.0 * w));
			}
			else
			{
				double lna = Math.Log(a / (a + b));
				double lnb = Math.Log(b / (a + b));
				double t = Math.Exp(a * lna) / a;
				double u = Math.Exp(b * lnb) / b;
				double w = t + u;
				if (p < t / w)
				{
					x = Math.Pow(a * w * p, 1.0 / a);
				}
				else
				{
					x = 1.0 - Math.Pow(b * w * (1.0 - p), 1.0 / b);
				}
			}
			double afac = -Special.Gammln(a) - Special.Gammln(b) + Special.Gammln(a + b);
			for (int i = 0; i < 10; i++)
			{
				if (x == 0.0 || x == 1.0)
				{
					return x;
				}
				double num = Beta.Betai(a, b, x) - p;
				double t = Math.Exp(a2 * Math.Log(x) + b2 * Math.Log(1.0 - x) + afac);
				double u = num / t;
				x -= (t = u / (1.0 - 0.5 * Math.Min(1.0, u * (a2 / x - b2 / (1.0 - x)))));
				if (x <= 0.0)
				{
					x = 0.5 * (x + t);
				}
				if (x >= 1.0)
				{
					x = 0.5 * (x + t + 1.0);
				}
				if (Math.Abs(t) < EPS2 * x && i > 0)
				{
					break;
				}
			}
			return x;
		}

		// Token: 0x04000025 RID: 37
		private static int SWITCH = 3000;
	}
}
