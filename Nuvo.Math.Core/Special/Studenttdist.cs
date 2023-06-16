using System;

namespace Nuvo.Math.Core.Special
{
	// Token: 0x02000033 RID: 51
	internal class Studenttdist : Beta
	{
		// Token: 0x0600024A RID: 586 RVA: 0x0000B407 File Offset: 0x00009607
		public Studenttdist(double nu) : this(nu, 0.0, 1.0)
		{
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0000B424 File Offset: 0x00009624
		public Studenttdist(double nu, double mu, double sig)
		{
			this.nu = nu;
			this.mu = mu;
			this.sig = sig;
			if (sig <= 0.0 || nu <= 0.0)
			{
				throw new Exception("bad sig,nu in Studentdist");
			}
			this.np = 0.5 * (nu + 1.0);
			this.fac = Special.Gammln(this.np) - Special.Gammln(0.5 * nu);
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0000B4AC File Offset: 0x000096AC
		public double p(double t)
		{
			return System.Math.Exp(-this.np * System.Math.Log(1.0 + System.Math.Pow((t - this.mu) / this.sig, 2.0) / this.nu) + this.fac) / (System.Math.Sqrt(3.141592653589793 * this.nu) * this.sig);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000B520 File Offset: 0x00009720
		public double cdf(double t)
		{
			double p = 0.5 * Beta.Betai(0.5 * this.nu, 0.5, this.nu / (this.nu + System.Math.Pow((t - this.mu) / this.sig, 2.0)));
			if (t >= this.mu)
			{
				return 1.0 - p;
			}
			return p;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000B598 File Offset: 0x00009798
		public double invcdf(double p)
		{
			if (p <= 0.0 || p >= 1.0)
			{
				throw new Exception("bad p in Studentdist");
			}
			double x = Beta.Invbetai(2.0 * System.Math.Min(p, 1.0 - p), 0.5 * this.nu, 0.5);
			x = this.sig * System.Math.Sqrt(this.nu * (1.0 - x) / x);
			if (p < 0.5)
			{
				return this.mu - x;
			}
			return this.mu + x;
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000B640 File Offset: 0x00009840
		public double aa(double t)
		{
			if (t < 0.0)
			{
				throw new Exception("bad t in Studentdist");
			}
			return 1.0 - Beta.Betai(0.5 * this.nu, 0.5, this.nu / (this.nu + t * t));
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000B6A0 File Offset: 0x000098A0
		public double invaa(double p)
		{
			if (p < 0.0 || p >= 1.0)
			{
				throw new Exception("bad p in Studentdist");
			}
			double x = Beta.Invbetai(1.0 - p, 0.5 * this.nu, 0.5);
			return System.Math.Sqrt(this.nu * (1.0 - x) / x);
		}

		// Token: 0x0400002C RID: 44
		public double nu;

		// Token: 0x0400002D RID: 45
		public double mu;

		// Token: 0x0400002E RID: 46
		public double sig;

		// Token: 0x0400002F RID: 47
		public double np;

		// Token: 0x04000030 RID: 48
		public double fac;
	}
}
