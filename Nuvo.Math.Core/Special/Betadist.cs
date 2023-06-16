using System;

namespace Nuvo.Math.Core.Special
{
	// Token: 0x02000032 RID: 50
	internal class Betadist : Beta
	{
		// Token: 0x06000246 RID: 582 RVA: 0x0000B2C4 File Offset: 0x000094C4
		public Betadist(double alph, double bet)
		{
			this.alph = alph;
			this.bet = bet;
			if (alph <= 0.0 || bet <= 0.0)
			{
				throw new Exception("bad alph,bet in Betadist");
			}
			this.fac = Special.Gammln(alph + bet) - Special.Gammln(alph) - Special.Gammln(bet);
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0000B324 File Offset: 0x00009524
		public double p(double x)
		{
			if (x <= 0.0 || x >= 1.0)
			{
				throw new Exception("bad x in Betadist");
			}
			return Math.Exp((this.alph - 1.0) * Math.Log(x) + (this.bet - 1.0) * Math.Log(1.0 - x) + this.fac);
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000B399 File Offset: 0x00009599
		public double cdf(double x)
		{
			if (x < 0.0 || x > 1.0)
			{
				throw new Exception("bad x in Betadist");
			}
			return Beta.Betai(this.alph, this.bet, x);
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000B3D0 File Offset: 0x000095D0
		public double invcdf(double p)
		{
			if (p < 0.0 || p > 1.0)
			{
				throw new Exception("bad p in Betadist");
			}
			return Beta.Invbetai(p, this.alph, this.bet);
		}

		// Token: 0x04000029 RID: 41
		public double alph;

		// Token: 0x0400002A RID: 42
		public double bet;

		// Token: 0x0400002B RID: 43
		public double fac;
	}
}
