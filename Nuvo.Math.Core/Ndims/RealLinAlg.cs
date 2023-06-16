using System;
using Nuvo.Math.Core.Interface;

namespace Nuvo.Math.Core.Ndims
{
	/// <summary>
	/// Generic Real Linear Algebra
	/// </summary>
	/// <typeparam name="D">Real Element Type</typeparam>
	// Token: 0x0200003F RID: 63
	public class RealLinAlg<D> : LinAlg<RealLuResult<D>, RealNArray<D>, D> where D : IRealNumber<D>, new()
	{
		/// <summary>
		/// Solve linear least-squares problem
		/// </summary>
		/// <param name="a">Input Matrix</param>
		/// <param name="y">Known Vector</param>
		/// <returns>Solution Vector</returns>
		// Token: 0x06000312 RID: 786 RVA: 0x0000E2EC File Offset: 0x0000C4EC
		public static RealNArray<D> LstSqrSolve(RealNArray<D> a, RealNArray<D> y)
		{
			RealNArray<D> at = a.Transpose();
			return LinAlg<RealLuResult<D>, RealNArray<D>, D>.Solve(LinAlg<RealLuResult<D>, RealNArray<D>, D>.Dot(at, a), LinAlg<RealLuResult<D>, RealNArray<D>, D>.Dot(at, y));
		}

		/// <summary>
		/// Solve linear weighted least-squares problem
		/// x = inv(A'(W'+W)A)A'(W'+W)y
		/// </summary>
		/// <param name="a">Input Matrix</param>
		/// <param name="y">Known Vector</param>
		/// <param name="w">Weight Matrix</param>
		/// <returns>Solution Vector</returns>
		// Token: 0x06000313 RID: 787 RVA: 0x0000E314 File Offset: 0x0000C514
		public static RealNArray<D> WeightedLstSqrSolve(RealNArray<D> a, RealNArray<D> y, RealNArray<D> w)
		{
			RealNArray<D> w2 = w.Transpose().Add(w);
			RealNArray<D> atw2 = LinAlg<RealLuResult<D>, RealNArray<D>, D>.Dot(a.Transpose(), w2);
			return LinAlg<RealLuResult<D>, RealNArray<D>, D>.Solve(LinAlg<RealLuResult<D>, RealNArray<D>, D>.Dot(atw2, a), LinAlg<RealLuResult<D>, RealNArray<D>, D>.Dot(atw2, y));
		}

		/// <summary>
		/// Cholesky decomposition l = Cholesky(a)
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x06000314 RID: 788 RVA: 0x0000E350 File Offset: 0x0000C550
		public static RealNArray<D> Cholesky(RealNArray<D> a)
		{
			if (!a.IsMatrix)
			{
				throw new Exception("Array must be a matrix");
			}
			int n = a.size[0];
			int n2 = a.size[1];
			if (n != n2)
			{
				throw new Exception("Matrix must be square");
			}
			RealNArray<D> i = new RealNArray<D>();
			i.Zeros2d(n, n2);
			for (int j = 0; j < n; j++)
			{
				for (int k = 0; k < j; k++)
				{
					D sum = a[j, k];
					for (int l = 0; l < k; l++)
					{
						D d = i[j, l];
						sum = sum.Subtract(d.Multiply(i[k, l]));
					}
					i[j, k] = sum.Divide(i[k, k]);
				}
				D sum2 = a[j, j];
				for (int m = 0; m < j; m++)
				{
					D d = i[j, m];
					sum2 = sum2.Subtract(d.Multiply(i[j, m]));
				}
				if (sum2.FcnValue <= 0.0)
				{
					throw new Exception("Matrix is not positiv definit");
				}
				i[j, j] = sum2.Sqrt();
			}
			return i;
		}
	}
}
