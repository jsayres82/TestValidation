using System;

namespace Nuvo.Math.Core.Special
{
	// Token: 0x02000036 RID: 54
	internal class Chisqdist : Gamma
	{
		// Token: 0x06000259 RID: 601 RVA: 0x0000BA64 File Offset: 0x00009C64
		public Chisqdist(double nu)
		{
			this.nu = nu;
			if (nu <= 0.0)
			{
				throw new Exception("bad nu in Chisqdist");
			}
			this.fac = 0.6931471805599453 * (0.5 * nu) + Special.Gammln(0.5 * nu);
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000BAC4 File Offset: 0x00009CC4
		public double p(double x2)
		{
			if (x2 <= 0.0)
			{
				throw new Exception("bad x2 in Chisqdist");
			}
			return Math.Exp(-0.5 * (x2 - (this.nu - 2.0) * Math.Log(x2)) - this.fac);
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0000BB17 File Offset: 0x00009D17
		public double cdf(double x2)
		{
			if (x2 < 0.0)
			{
				throw new Exception("bad x2 in Chisqdist");
			}
			return Gamma.Gammp(0.5 * this.nu, 0.5 * x2);
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000BB50 File Offset: 0x00009D50
		public double invcdf(double p)
		{
			if (p < 0.0 || p >= 1.0)
			{
				throw new Exception("bad p in Chisqdist");
			}
			return 2.0 * Gamma.Invgammp(p, 0.5 * this.nu);
		}

		// Token: 0x04000035 RID: 53
		public double nu;

		// Token: 0x04000036 RID: 54
		public double fac;
	}
}
