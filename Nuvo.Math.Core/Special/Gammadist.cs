using System;

namespace Nuvo.Math.Core.Special
{
	// Token: 0x02000031 RID: 49
	internal class Gammadist : Gamma
	{
		// Token: 0x06000241 RID: 577 RVA: 0x0000B19C File Offset: 0x0000939C
		public Gammadist(double alph) : this(alph, 1.0)
		{
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0000B1B0 File Offset: 0x000093B0
		public Gammadist(double alph, double bet)
		{
			this.alph = alph;
			this.bet = bet;
			if (alph <= 0.0 || bet <= 0.0)
			{
				throw new Exception("bad alph,bet in Gammadist");
			}
			this.fac = alph * Math.Log(bet) - Special.Gammln(alph);
		}

		// Token: 0x06000243 RID: 579 RVA: 0x0000B20C File Offset: 0x0000940C
		public double p(double x)
		{
			if (x <= 0.0)
			{
				throw new Exception("bad x in Gammadist");
			}
			return Math.Exp(-this.bet * x + (this.alph - 1.0) * Math.Log(x) + this.fac);
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0000B25D File Offset: 0x0000945D
		public double cdf(double x)
		{
			if (x < 0.0)
			{
				throw new Exception("bad x in Gammadist");
			}
			return Gamma.Gammp(this.alph, this.bet * x);
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0000B289 File Offset: 0x00009489
		public double invcdf(double p)
		{
			if (p < 0.0 || p >= 1.0)
			{
				throw new Exception("bad p in Gammadist");
			}
			return Gamma.Invgammp(p, this.alph) / this.bet;
		}

		// Token: 0x04000026 RID: 38
		public double alph;

		// Token: 0x04000027 RID: 39
		public double bet;

		// Token: 0x04000028 RID: 40
		public double fac;
	}
}
