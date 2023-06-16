using System;
using Nuvo.Math.Core.Special;

namespace Nuvo.Math.Core.Unc
{
	/// <summary>
	/// Statistics functions
	/// </summary>
	// Token: 0x02000024 RID: 36
	public class Statistics
	{
		/// <summary>
		/// Mean
		/// </summary>
		/// <param name="x">Vector</param>
		/// <returns></returns>
		// Token: 0x060001FD RID: 509 RVA: 0x00009468 File Offset: 0x00007668
		public static Number Mean(Number[] x)
		{
			int i = x.Length;
			Number j = 0.0;
			for (int k = 0; k < i; k++)
			{
				j += x[k];
			}
			return j / (double)i;
		}

		/// <summary>
		/// Mean
		/// </summary>
		/// <param name="x">Matrix</param>
		/// <returns></returns>
		// Token: 0x060001FE RID: 510 RVA: 0x000094B0 File Offset: 0x000076B0
		public static Number[] Mean(Number[][] x)
		{
			int n = x.Length;
			int n2 = (n > 0) ? x[0].Length : 0;
			Number[] i = new Number[n2];
			for (int i2 = 0; i2 < n2; i2++)
			{
				i[i2] = 0.0;
				for (int i3 = 0; i3 < n; i3++)
				{
					i[i2] += x[i3][i2];
				}
				i[i2] /= (double)n;
			}
			return i;
		}

		/// <summary>
		/// Standard Deviation
		/// </summary>
		/// <param name="x">Vector</param>
		/// <returns></returns>
		// Token: 0x060001FF RID: 511 RVA: 0x00009544 File Offset: 0x00007744
		public static Number Std(Number[] x)
		{
			Number mean = Statistics.Mean(x);
			int i = x.Length;
			Number s = 0.0;
			for (int j = 0; j < i; j++)
			{
				s += Math.Pow<Number>(x[j] - mean, 2);
			}
			return Math.Sqrt<Number>(s / (double)(i - 1));
		}

		/// <summary>
		/// Covariance Matrix
		/// </summary>
		/// <param name="x">Matrix</param>
		/// <returns></returns>
		// Token: 0x06000200 RID: 512 RVA: 0x000095A8 File Offset: 0x000077A8
		public static Number[][] Cov(Number[][] x)
		{
			Number[] mean = Statistics.Mean(x);
			int n = x.Length;
			if (n < 2)
			{
				throw new Exception("Number of Samples must be at least 2");
			}
			int n2 = (n > 0) ? x[0].Length : 0;
			Number[][] cov = new Number[n2][];
			for (int i2a = 0; i2a < n2; i2a++)
			{
				cov[i2a] = new Number[n2];
				for (int i2b = 0; i2b <= i2a; i2b++)
				{
					Number temp = 0.0;
					for (int i = 0; i < n; i++)
					{
						temp += (x[i][i2a] - mean[i2a]) * (x[i][i2b] - mean[i2b]);
					}
					cov[i2a][i2b] = temp / (double)(n - 1);
					if (i2a != i2b)
					{
						cov[i2b][i2a] = cov[i2a][i2b];
					}
				}
			}
			return cov;
		}

		/// <summary>
		/// Standard Deviation of Sample Mean
		/// </summary>
		/// <param name="x">Samples</param>
		/// <param name="p">Probability</param>
		/// <returns></returns>
		// Token: 0x06000201 RID: 513 RVA: 0x000096B0 File Offset: 0x000078B0
		public static Number StandardDeviationOfSampleMean(Number[] x, double p)
		{
			int i = x.Length;
			if (i < 2)
			{
				throw new Exception("Number of Samples must be at least 2");
			}
			double num = Statistics.CoverageFactor(1.0 / (double)(i - 1), 1, p);
			double k2 = Statistics.CoverageFactor(0.0, 1, p);
			double factor = num / k2 / System.Math.Sqrt((double)i);
			return Statistics.Std(x) * factor;
		}

		/// <summary>
		/// Covariance Matrix of Sample Mean
		/// </summary>
		/// <param name="x">Samples</param>
		/// <param name="p">Probability</param>
		/// <returns></returns>
		// Token: 0x06000202 RID: 514 RVA: 0x00009714 File Offset: 0x00007914
		public static Number[][] CovarianceOfSampleMean(Number[][] x, double p)
		{
			int n = x.Length;
			if (n < 2)
			{
				throw new Exception("Number of Samples must be at least 2");
			}
			int n2 = (n > 0) ? x[0].Length : 0;
			if (n - 1 < n2)
			{
				throw new Exception("Number of Samples must be at least " + (n2 + 1).ToString());
			}
			double num = Statistics.CoverageFactor(1.0 / (double)(n - 1), n2, p);
			double k2 = Statistics.CoverageFactor(0.0, n2, p);
			double factor = num * num / (k2 * k2) / (double)n;
			Number[][] cov = Statistics.Cov(x);
			for (int i = 0; i < n2; i++)
			{
				for (int j = 0; j < n2; j++)
				{
					cov[i][j] *= factor;
				}
			}
			return cov;
		}

		/// <summary>
		/// Computes the Coverage Factor k.
		/// </summary>
		/// <param name="idof">Inverse of the Degrees of Freedom</param>
		/// <param name="dims">Dimensions</param>
		/// <param name="p">Probability</param>
		/// <returns></returns>
		// Token: 0x06000203 RID: 515 RVA: 0x000097E0 File Offset: 0x000079E0
		public static double CoverageFactor(double idof, int dims, double p)
		{
			if (idof < 0.0)
			{
				throw new Exception("Inverse DOF must lie between 0 and Inf");
			}
			if (dims < 1)
			{
				throw new Exception("Dimensions must lie between 1 and Inf");
			}
			if (p <= 0.0 || p >= 1.0)
			{
				throw new Exception("Probability must lie between 0 and 1");
			}
			double i;
			if (idof == 0.0)
			{
				if (dims == 1)
				{
					i = new Normaldist().invcdf(p / 2.0 + 0.5);
				}
				else
				{
					i = System.Math.Sqrt(new Chisqdist((double)dims).invcdf(p));
				}
			}
			else
			{
				double dof = 1.0 / idof;
				if (dims == 1)
				{
					i = new Studenttdist(dof).invcdf(p / 2.0 + 0.5);
				}
				else
				{
					double j = dof + 1.0 - (double)dims;
					double f = new Fdist((double)dims, j).invcdf(p);
					i = System.Math.Sqrt(dof * (double)dims * f / j);
				}
			}
			return i;
		}
	}
}
