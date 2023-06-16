using System;

namespace Nuvo.Math.Core.Special
{
	// Token: 0x02000037 RID: 55
	internal class Fdist : Beta
	{
		// Token: 0x0600025D RID: 605 RVA: 0x0000BBA0 File Offset: 0x00009DA0
		public Fdist(double nu1, double nu2)
		{
			this.nu1 = nu1;
			this.nu2 = nu2;
			if (nu1 <= 0.0 || nu2 <= 0.0)
			{
				throw new Exception("bad nu1,nu2 in Fdist");
			}
			this.fac = 0.5 * (nu1 * Math.Log(nu1) + nu2 * Math.Log(nu2)) + Special.Gammln(0.5 * (nu1 + nu2)) - Special.Gammln(0.5 * nu1) - Special.Gammln(0.5 * nu2);
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000BC3C File Offset: 0x00009E3C
		public double p(double f)
		{
			if (f <= 0.0)
			{
				throw new Exception("bad f in Fdist");
			}
			return Math.Exp((0.5 * this.nu1 - 1.0) * Math.Log(f) - 0.5 * (this.nu1 + this.nu2) * Math.Log(this.nu2 + this.nu1 * f) + this.fac);
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000BCBC File Offset: 0x00009EBC
		public double cdf(double f)
		{
			if (f < 0.0)
			{
				throw new Exception("bad f in Fdist");
			}
			return Beta.Betai(0.5 * this.nu1, 0.5 * this.nu2, this.nu1 * f / (this.nu2 + this.nu1 * f));
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000BD20 File Offset: 0x00009F20
		public double invcdf(double p)
		{
			if (p <= 0.0 || p >= 1.0)
			{
				throw new Exception("bad p in Fdist");
			}
			double x = Beta.Invbetai(p, 0.5 * this.nu1, 0.5 * this.nu2);
			return this.nu2 * x / (this.nu1 * (1.0 - x));
		}

		// Token: 0x04000037 RID: 55
		public double nu1;

		// Token: 0x04000038 RID: 56
		public double nu2;

		// Token: 0x04000039 RID: 57
		public double fac;
	}
}
