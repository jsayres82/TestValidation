using System;

namespace Nuvo.Math.Core.Special
{
	// Token: 0x0200002C RID: 44
	internal class Lognormaldist : Erf28
	{
		// Token: 0x06000226 RID: 550 RVA: 0x00009F08 File Offset: 0x00008108
		public Lognormaldist() : this(0.0, 1.0)
		{
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00009F22 File Offset: 0x00008122
		public Lognormaldist(double mu, double sig)
		{
			this.mu = mu;
			this.sig = sig;
			if (sig <= 0.0)
			{
				throw new Exception("bad sig in Lognormaldist");
			}
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00009F50 File Offset: 0x00008150
		public double p(double x)
		{
			if (x < 0.0)
			{
				throw new Exception("bad x in Lognormaldist");
			}
			if (x == 0.0)
			{
				return 0.0;
			}
			return 0.3989422804014327 / (this.sig * x) * Math.Exp(-0.5 * Math.Pow((Math.Log(x) - this.mu) / this.sig, 2.0));
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00009FD0 File Offset: 0x000081D0
		public double cdf(double x)
		{
			if (x < 0.0)
			{
				throw new Exception("bad x in Lognormaldist");
			}
			if (x == 0.0)
			{
				return 0.0;
			}
			return 0.5 * Erf28.Erfc(-0.7071067811865476 * (Math.Log(x) - this.mu) / this.sig);
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000A038 File Offset: 0x00008238
		public double invcdf(double p)
		{
			if (p <= 0.0 || p >= 1.0)
			{
				throw new Exception("bad p in Lognormaldist");
			}
			return Math.Exp(-1.4142135623730951 * this.sig * Erf28.Inverfc(2.0 * p) + this.mu);
		}

		// Token: 0x04000017 RID: 23
		public double mu;

		// Token: 0x04000018 RID: 24
		public double sig;
	}
}
