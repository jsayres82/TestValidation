using System;
using Nuvo.Math.Interface;

namespace Nuvo.Math.Ndims
{
	/// <summary>
	/// Generic Complex Linear Algebra
	/// </summary>
	/// <typeparam name="D">Real Element Type</typeparam>
	// Token: 0x02000040 RID: 64
	public class ComplexLinAlg<D> : LinAlg<ComplexLuResult<D>, ComplexNArray<D>, Complex<D>> where D : IRealNumber<D,D>, new()
	{
		/// <summary>
		/// Solve linear least-squares problem
		/// </summary>
		/// <param name="a">Input Matrix</param>
		/// <param name="y">Known Vector</param>
		/// <returns>Solution Vector</returns>
		// Token: 0x06000316 RID: 790 RVA: 0x0000E4BC File Offset: 0x0000C6BC
		public static ComplexNArray<D> LstSqrSolve(ComplexNArray<D> a, ComplexNArray<D> y)
		{
			ComplexNArray<D> at = a.CTranspose();
			return LinAlg<ComplexLuResult<D>, ComplexNArray<D>, Complex<D>>.Solve(LinAlg<ComplexLuResult<D>, ComplexNArray<D>, Complex<D>>.Dot(at, a), LinAlg<ComplexLuResult<D>, ComplexNArray<D>, Complex<D>>.Dot(at, y));
		}

		/// <summary>
		/// Solve linear weighted least-squares problem
		/// x = inv(A'(W'+W)A)A'(W'+W)y
		/// </summary>
		/// <param name="a">Input Matrix</param>
		/// <param name="y">Known Vector</param>
		/// <param name="w">Weight Matrix</param>
		/// <returns>Solution Vector</returns>
		// Token: 0x06000317 RID: 791 RVA: 0x0000E4E4 File Offset: 0x0000C6E4
		public static ComplexNArray<D> WeightedLstSqrSolve(ComplexNArray<D> a, ComplexNArray<D> y, RealNArray<D> w)
		{
			int n = a.size[0];
			int n2 = a.size[1];
			RealNArray<D> a2 = new RealNArray<D>();
			a2.Init2d(2 * n, 2 * n2);
			RealNArray<D> y2 = new RealNArray<D>();
			y2.Init1d(2 * n);
			for (int i = 0; i < n; i++)
			{
				for (int i2 = 0; i2 < n2; i2++)
				{
					a2[2 * i, 2 * i2] = a[i, i2].Real();
					a2[2 * i + 1, 2 * i2] = a[i, i2].Imag();
					NArray<RealNArray<D>, D> narray = a2;
					int index = 2 * i;
					int index2 = 2 * i2 + 1;
					D d = a[i, i2].Imag();
					narray[index, index2] = d.Negative();
					a2[2 * i + 1, 2 * i2 + 1] = a[i, i2].Real();
				}
				y2[2 * i] = y[i].Real();
				y2[2 * i + 1] = y[i].Imag();
			}
			RealNArray<D> x2 = RealLinAlg<D>.WeightedLstSqrSolve(a2, y2, w);
			ComplexNArray<D> x3 = new ComplexNArray<D>();
			x3.Init1d(n2);
			for (int i3 = 0; i3 < n2; i3++)
			{
				x3[i3] = new Complex<D>
				{
					real = x2[2 * i3],
					imag = x2[2 * i3 + 1]
				};
			}
			return x3;
		}
	}
}
