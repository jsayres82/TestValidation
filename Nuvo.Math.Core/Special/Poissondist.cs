using System;

namespace Nuvo.Math.Core.Special
{
	// Token: 0x02000034 RID: 52
	internal class Poissondist : Gamma
	{
		// Token: 0x06000251 RID: 593 RVA: 0x0000B713 File Offset: 0x00009913
		public Poissondist(double lam)
		{
			this.lam = lam;
			if (lam <= 0.0)
			{
				throw new Exception("bad lam in Poissondist");
			}
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000B739 File Offset: 0x00009939
		public double p(int n)
		{
			if (n < 0)
			{
				throw new Exception("bad n in Poissondist");
			}
			return Math.Exp(-this.lam + (double)n * Math.Log(this.lam) - Special.Gammln((double)(n + 1)));
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000B76F File Offset: 0x0000996F
		public double cdf(int n)
		{
			if (n < 0)
			{
				throw new Exception("bad n in Poissondist");
			}
			if (n == 0)
			{
				return 0.0;
			}
			return Gamma.Gammq((double)n, this.lam);
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000B79C File Offset: 0x0000999C
		public int invcdf(double p)
		{
			int inc = 1;
			if (p <= 0.0 || p >= 1.0)
			{
				throw new Exception("bad p in Poissondist");
			}
			if (p < Math.Exp(-this.lam))
			{
				return 0;
			}
			int i = (int)Math.Max(Math.Sqrt(this.lam), 5.0);
			int nl;
			int nu;
			if (p < this.cdf(i))
			{
				do
				{
					i = Math.Max(i - inc, 0);
					inc *= 2;
				}
				while (p < this.cdf(i));
				nl = i;
				nu = i + inc / 2;
			}
			else
			{
				do
				{
					i += inc;
					inc *= 2;
				}
				while (p > this.cdf(i));
				nu = i;
				nl = i - inc / 2;
			}
			while (nu - nl > 1)
			{
				i = (nl + nu) / 2;
				if (p < this.cdf(i))
				{
					nu = i;
				}
				else
				{
					nl = i;
				}
			}
			return nl;
		}

		// Token: 0x04000031 RID: 49
		public double lam;
	}
}
