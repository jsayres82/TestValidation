using System;

namespace Nuvo.Math.Core.Special
{
	// Token: 0x02000035 RID: 53
	internal class Binomialdist : Beta
	{
		// Token: 0x06000255 RID: 597 RVA: 0x0000B860 File Offset: 0x00009A60
		public Binomialdist(int n, double pe)
		{
			this.n = n;
			this.pe = pe;
			if (n <= 0 || pe <= 0.0 || pe >= 1.0)
			{
				throw new Exception("bad args in Binomialdist");
			}
			this.fac = Special.Gammln((double)(n + 1));
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000B8B8 File Offset: 0x00009AB8
		public double p(int k)
		{
			if (k < 0)
			{
				throw new Exception("bad k in Binomialdist");
			}
			if (k > this.n)
			{
				return 0.0;
			}
			return Math.Exp((double)k * Math.Log(this.pe) + (double)(this.n - k) * Math.Log(1.0 - this.pe) + this.fac - Special.Gammln((double)(k + 1)) - Special.Gammln((double)(this.n - k + 1)));
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000B93C File Offset: 0x00009B3C
		public double cdf(int k)
		{
			if (k < 0)
			{
				throw new Exception("bad k in Binomialdist");
			}
			if (k == 0)
			{
				return 0.0;
			}
			if (k > this.n)
			{
				return 1.0;
			}
			return 1.0 - Beta.Betai((double)k, (double)(this.n - k + 1), this.pe);
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000B99C File Offset: 0x00009B9C
		public int invcdf(double p)
		{
			int inc = 1;
			if (p <= 0.0 || p >= 1.0)
			{
				throw new Exception("bad p in Binomialdist");
			}
			int i = Math.Max(0, Math.Min(this.n, (int)((double)this.n * this.pe)));
			int kl;
			int ku;
			if (p < this.cdf(i))
			{
				do
				{
					i = Math.Max(i - inc, 0);
					inc *= 2;
				}
				while (p < this.cdf(i));
				kl = i;
				ku = i + inc / 2;
			}
			else
			{
				do
				{
					i = Math.Min(i + inc, this.n + 1);
					inc *= 2;
				}
				while (p > this.cdf(i));
				ku = i;
				kl = i - inc / 2;
			}
			while (ku - kl > 1)
			{
				i = (kl + ku) / 2;
				if (p < this.cdf(i))
				{
					ku = i;
				}
				else
				{
					kl = i;
				}
			}
			return kl;
		}

		// Token: 0x04000032 RID: 50
		public int n;

		// Token: 0x04000033 RID: 51
		public double pe;

		// Token: 0x04000034 RID: 52
		public double fac;
	}
}
