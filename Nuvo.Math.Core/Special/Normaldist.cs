using System;

namespace Nuvo.Math.Core.Special
{
	// Token: 0x0200002B RID: 43
	internal class Normaldist : Erf28
	{
		// Token: 0x06000221 RID: 545 RVA: 0x00009DFD File Offset: 0x00007FFD
		public Normaldist() : this(0.0, 1.0)
		{
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00009E17 File Offset: 0x00008017
		public Normaldist(double mu, double sig)
		{
			this.mu = mu;
			this.sig = sig;
			if (sig <= 0.0)
			{
				throw new Exception("bad sig in Normaldist");
			}
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00009E44 File Offset: 0x00008044
		public double p(double x)
		{
			return 0.3989422804014327 / this.sig * Math.Exp(-0.5 * Math.Pow((x - this.mu) / this.sig, 2.0));
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00009E83 File Offset: 0x00008083
		public double cdf(double x)
		{
			return 0.5 * Erf28.Erfc(-0.7071067811865476 * (x - this.mu) / this.sig);
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00009EB0 File Offset: 0x000080B0
		public double invcdf(double p)
		{
			if (p <= 0.0 || p >= 1.0)
			{
				throw new Exception("bad p in Normaldist");
			}
			return -1.4142135623730951 * this.sig * Erf28.Inverfc(2.0 * p) + this.mu;
		}

		// Token: 0x04000015 RID: 21
		public double mu;

		// Token: 0x04000016 RID: 22
		public double sig;
	}
}
