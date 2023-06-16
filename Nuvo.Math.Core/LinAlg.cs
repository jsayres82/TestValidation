using System;
using System.Threading.Tasks;
using Nuvo.IntelMKL;
using Nuvo.Math.Core.Interface;

namespace Nuvo.Math.Core
{
	/// <summary>
	/// Generic Linear Algebra
	/// </summary>
	// Token: 0x02000005 RID: 5
	public static class LinAlg
	{
		/// <summary>
		/// Matrix Multiplication c = Dot(a, a')
		/// </summary>
		/// <param name="a">Matrix</param>
		/// <returns>Matrix</returns>
		// Token: 0x0600005E RID: 94 RVA: 0x0000359C File Offset: 0x0000179C
		public static Number[][] ParallelDotMMt(Number[][] a)
		{
			int n = a.Length;
			int n2 = 0;
			if (n > 0)
			{
				n2 = a[0].Length;
			}
			Number[][] c = new Number[n][];
			for (int i = 0; i < n; i++)
			{
				c[i] = new Number[n];
			}
			Parallel.For(0, n, delegate(int i1)
			{
				for (int i2 = 0; i2 <= i1; i2++)
				{
					double temp = 0.0;
					for (int i3 = 0; i3 < n2; i3++)
					{
						temp += a[i1][i3].Value * a[i2][i3].Value;
					}
					c[i1][i2] = temp;
					c[i2][i1] = temp;
				}
			});
			return c;
		}

		/// <summary>
		/// Matrix Multiplication c = Dot(a, b)
		/// </summary>
		/// <param name="a">Matrix</param>
		/// <param name="b">Matrix</param>
		/// <returns>Matrix</returns>
		// Token: 0x0600005F RID: 95 RVA: 0x0000361C File Offset: 0x0000181C
		public static Number[][] ParallelDot(Number[][] a, Number[][] b)
		{
			int n = a.Length;
			int n2 = 0;
			if (n > 0)
			{
				n2 = a[0].Length;
			}
			int n3 = b.Length;
			int n4 = 0;
			if (n3 > 0)
			{
				n4 = b[0].Length;
			}
			if (n2 != n3)
			{
				throw new Exception("Inner matrix dimensions must agree");
			}
			Number[][] c = new Number[n][];
			for (int i = 0; i < n; i++)
			{
				c[i] = new Number[n4];
			}
			Parallel.For(0, n, delegate(int i1)
			{
				for (int i2 = 0; i2 < n4; i2++)
				{
					double temp = 0.0;
					for (int i3 = 0; i3 < n2; i3++)
					{
						temp += a[i1][i3].Value * b[i3][i2].Value;
					}
					c[i1][i2] = temp;
				}
			});
			return c;
		}

		/// <summary>
		/// Matrix Multiplication c = Dot(a, b)
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">Matrix</param>
		/// <param name="b">Matrix</param>
		/// <returns>Matrix</returns>
		// Token: 0x06000060 RID: 96 RVA: 0x000036E0 File Offset: 0x000018E0
		public static T[][] Dot<T>(T[][] a, T[][] b) where T : INumber<T>, new()
		{
			int n = a.Length;
			int n2 = 0;
			if (n > 0)
			{
				n2 = a[0].Length;
			}
			int n3 = b.Length;
			int n4 = 0;
			if (n3 > 0)
			{
				n4 = b[0].Length;
			}
			if (n2 != n3)
			{
				throw new Exception("Inner matrix dimensions must agree");
			}
			T t = Activator.CreateInstance<T>();
			T zero = t.Zero;
			T[][] c = new T[n][];
			for (int i = 0; i < n; i++)
			{
				T[] temp = new T[n4];
				for (int i2 = 0; i2 < n4; i2++)
				{
					T temp2 = zero;
					for (int i3 = 0; i3 < n2; i3++)
					{
						temp2 = temp2.Add(a[i][i3].Multiply(b[i3][i2]));
					}
					temp[i2] = temp2;
				}
				c[i] = temp;
			}
			return c;
		}

		/// <summary>
		/// Matrix Multiplication c = Dot(a, b)
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">Matrix</param>
		/// <param name="b">Column Vector</param>
		/// <returns>Column Vector</returns>
		// Token: 0x06000061 RID: 97 RVA: 0x000037BC File Offset: 0x000019BC
		public static T[] Dot<T>(T[][] a, T[] b) where T : INumber<T>, new()
		{
			int n = a.Length;
			int n2 = 0;
			if (n > 0)
			{
				n2 = a[0].Length;
			}
			int n3 = b.Length;
			if (n2 != n3)
			{
				throw new Exception("Inner matrix dimensions must agree");
			}
			T t = Activator.CreateInstance<T>();
			T zero = t.Zero;
			T[] c = new T[n];
			for (int i = 0; i < n; i++)
			{
				T temp = zero;
				for (int i2 = 0; i2 < n2; i2++)
				{
					temp = temp.Add(a[i][i2].Multiply(b[i2]));
				}
				c[i] = temp;
			}
			return c;
		}

		/// <summary>
		/// Forward Substitution x = Fsub(l, y)
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="l">Matrix</param>
		/// <param name="y">Column Vector</param>
		/// <returns>Column Vector</returns>
		// Token: 0x06000062 RID: 98 RVA: 0x00003868 File Offset: 0x00001A68
		public static T[] Fsub<T>(T[][] l, T[] y) where T : INumber<T>, new()
		{
			int n = y.Length;
			int ii = -1;
			T[] x = Array.Zeros1d<T>(n);
			for (int i = 0; i < n; i++)
			{
				T temp = y[i];
				if (ii >= 0)
				{
					for (int i2 = ii; i2 < i; i2++)
					{
						temp = temp.Subtract(x[i2].Multiply(l[i][i2]));
					}
				}
				else if (temp.IsNotZero())
				{
					ii = i;
				}
				x[i] = temp;
			}
			return x;
		}

		/// <summary>
		/// Backward Substitution x = Bsub(u, y)
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="u">Matrix</param>
		/// <param name="y">Column Vector</param>
		/// <returns>Column Vector</returns>
		// Token: 0x06000063 RID: 99 RVA: 0x000038F8 File Offset: 0x00001AF8
		public static T[] Bsub<T>(T[][] u, T[] y) where T : INumber<T>, new()
		{
			int n = y.Length;
			T[] x = Array.Zeros1d<T>(n);
			for (int k = n - 1; k >= 0; k--)
			{
				T temp = y[k];
				for (int i2 = k + 1; i2 < n; i2++)
				{
					temp = temp.Subtract(x[i2].Multiply(u[k][i2]));
				}
				x[k] = temp.Divide(u[k][k]);
			}
			return x;
		}

		/// <summary>
		/// LU factorization Implement [l u p] = Lu(a)
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">Matrix</param>
		/// <returns>LU Result</returns>
		// Token: 0x06000064 RID: 100 RVA: 0x00003984 File Offset: 0x00001B84
		public static LuResult<T> Lu<T>(T[][] a) where T : INumber<T>, new()
		{
			int n = a.Length;
			int n2 = 0;
			if (n > 0)
			{
				n2 = a[0].Length;
			}
			if (n != n2)
			{
				throw new Exception("Matrix must be square");
			}
			int d = 0;
			T t = Activator.CreateInstance<T>();
			T zero = t.Zero;
			t = Activator.CreateInstance<T>();
			T one = t.One;
			int[] c = new int[n];
			for (int i = 0; i < n; i++)
			{
				c[i] = i;
			}
			T[][] j = Array.Zeros2d<T>(n, n);
			T[][] p = Array.Identity<T>(n);
			T[][] u = Array.Copy<T>(a);
			for (int k = 0; k < n; k++)
			{
				int l = k;
				double max = u[k][k].DblSqrFcnValue();
				for (int z = k + 1; z < n; z++)
				{
					double max2 = u[z][k].DblSqrFcnValue();
					if (max2 > max)
					{
						l = z;
						max = max2;
					}
				}
				if (max == 0.0)
				{
					throw new Exception("Matrix is singular");
				}
				if (l != k)
				{
					LinAlg.InterchangeRows<T>(j, l, k);
					LinAlg.InterchangeRows<T>(u, l, k);
					LinAlg.InterchangeRows<T>(p, l, k);
					LinAlg.InterchangeRows(c, l, k);
					d++;
				}
				for (int i2 = k + 1; i2 < n; i2++)
				{
					j[i2][k] = u[i2][k].Divide(u[k][k]);
					u[i2][k] = zero;
					for (int i3 = k + 1; i3 < n; i3++)
					{
						u[i2][i3] = u[i2][i3].Subtract(j[i2][k].Multiply(u[k][i3]));
					}
				}
			}
			for (int m = 0; m < n; m++)
			{
				j[m][m] = one;
			}
			return new LuResult<T>
			{
				l = j,
				u = u,
				p = p,
				c = c,
				d = d
			};
		}

		/// <summary>
		/// Determinant of a square matrix
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">Matrix</param>
		/// <returns></returns>
		// Token: 0x06000065 RID: 101 RVA: 0x00003BDC File Offset: 0x00001DDC
		public static T Det<T>(T[][] a) where T : INumber<T>, new()
		{
			int n = a.Length;
			int n2 = 0;
			if (n > 0)
			{
				n2 = a[0].Length;
			}
			if (n != n2)
			{
				throw new Exception("Matrix must be square");
			}
			T result;
			try
			{
				LuResult<T> lup = LinAlg.Lu<T>(a);
				result = Activator.CreateInstance<T>();
				T d = result.One;
				for (int i = 0; i < n; i++)
				{
					d = d.Multiply(lup.u[i][i]);
				}
				if (lup.d % 2 == 1)
				{
					d = d.Negative();
				}
				result = d;
			}
			catch
			{
				T t = Activator.CreateInstance<T>();
				result = t.Zero;
			}
			return result;
		}

		/// <summary>
		/// Is determinant of a square matrix equal to zero
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">Matrix</param>
		/// <returns></returns>
		// Token: 0x06000066 RID: 102 RVA: 0x00003CA0 File Offset: 0x00001EA0
		public static bool IsDetZero<T>(T[][] a) where T : INumber<T>, new()
		{
			int n = a.Length;
			int n2 = 0;
			if (n > 0)
			{
				n2 = a[0].Length;
			}
			T[][] b = new T[n][];
			for (int i = 0; i < n; i++)
			{
				b[i] = new T[n2];
				for (int i2 = 0; i2 < n2; i2++)
				{
					b[i][i2] = a[i][i2].FcnValue2();
				}
			}
			T det = LinAlg.Det<T>(b);
			return det.IsZero();
		}

		/// <summary>
		/// Solve a linear system of equations
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">Input Matrix</param>
		/// <param name="y">Known Vector</param>
		/// <returns>Solution Vector</returns>
		// Token: 0x06000067 RID: 103 RVA: 0x00003D28 File Offset: 0x00001F28
		public static T[] Solve<T>(T[][] a, T[] y) where T : INumber<T>, new()
		{
			LuResult<T> lup = LinAlg.Lu<T>(a);
			int i = y.Length;
			T[] y2 = new T[i];
			for (int j = 0; j < i; j++)
			{
				y2[j] = y[lup.c[j]];
			}
			return LinAlg.Bsub<T>(lup.u, LinAlg.Fsub<T>(lup.l, y2));
		}

		/// <summary>
		/// Matrix Multiplication c = Dot(Inv(a), b)
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">Matrix</param>
		/// <param name="b">Matrix</param>
		/// <returns>Matrix</returns>
		// Token: 0x06000068 RID: 104 RVA: 0x00003D84 File Offset: 0x00001F84
		public static T[][] Dot_invA_B<T>(T[][] a, T[][] b) where T : INumber<T>, new()
		{
			int n = a.Length;
			int n2 = 0;
			if (n > 0)
			{
				n2 = a[0].Length;
			}
			int n3 = b.Length;
			int n4 = 0;
			if (n3 > 0)
			{
				n4 = b[0].Length;
			}
			if (n2 != n3)
			{
				throw new Exception("Inner matrix dimensions must agree");
			}
			LuResult<T> lup = LinAlg.Lu<T>(a);
			T[][] c = new T[n][];
			for (int i = 0; i < n; i++)
			{
				c[i] = new T[n4];
			}
			for (int i2 = 0; i2 < n4; i2++)
			{
				T[] temp = new T[n];
				for (int i3 = 0; i3 < n; i3++)
				{
					temp[i3] = b[lup.c[i3]][i2];
				}
				T[] ci = LinAlg.Bsub<T>(lup.u, LinAlg.Fsub<T>(lup.l, temp));
				for (int i4 = 0; i4 < n; i4++)
				{
					c[i4][i2] = ci[i4];
				}
			}
			return c;
		}

		/// <summary>
		/// Matrix Multiplication c = Dot(a, Inv(b))
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">Matrix</param>
		/// <param name="b">Matrix</param>
		/// <returns>Matrix</returns>
		// Token: 0x06000069 RID: 105 RVA: 0x00003E74 File Offset: 0x00002074
		public static T[][] Dot_A_invB<T>(T[][] a, T[][] b) where T : INumber<T>, new()
		{
			int n = a.Length;
			int n2 = 0;
			if (n > 0)
			{
				n2 = a[0].Length;
			}
			int n3 = b.Length;
			int n4 = 0;
			if (n3 > 0)
			{
				n4 = b[0].Length;
			}
			if (n2 != n3)
			{
				throw new Exception("Inner matrix dimensions must agree");
			}
			LuResult<T> lup = LinAlg.Lu<T>(LinAlg.Transpose<T>(b));
			T[][] c = new T[n][];
			for (int i = 0; i < n; i++)
			{
				T[] temp = new T[n4];
				for (int i2 = 0; i2 < n4; i2++)
				{
					temp[i2] = a[i][lup.c[i2]];
				}
				c[i] = LinAlg.Bsub<T>(lup.u, LinAlg.Fsub<T>(lup.l, temp));
			}
			return c;
		}

		/// <summary>
		/// Inverse of a square matrix
		/// </summary>
		/// <param name="a">Matrix</param>
		/// <returns></returns>
		// Token: 0x0600006A RID: 106 RVA: 0x00003F2C File Offset: 0x0000212C
		public static T[][] Inv<T>(T[][] a) where T : INumber<T>, new()
		{
			LuResult<T> lup = LinAlg.Lu<T>(a);
			int i = a.Length;
			T[][] x = new T[i][];
			for (int i2 = 0; i2 < i; i2++)
			{
				x[i2] = new T[i];
			}
			T[] temp = new T[i];
			for (int i3 = 0; i3 < i; i3++)
			{
				for (int i4 = 0; i4 < i; i4++)
				{
					temp[i4] = lup.p[i4][i3];
				}
				T[] xi = LinAlg.Bsub<T>(lup.u, LinAlg.Fsub<T>(lup.l, temp));
				for (int i5 = 0; i5 < i; i5++)
				{
					x[i5][i3] = xi[i5];
				}
			}
			return x;
		}

		/// <summary>
		/// Transpose 2D-Array (Matrix)
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">Matrix</param>
		/// <returns>Matrix</returns>
		// Token: 0x0600006B RID: 107 RVA: 0x00003FE8 File Offset: 0x000021E8
		public static T[][] Transpose<T>(T[][] a) where T : INumber<T>, new()
		{
			int n = a.Length;
			int n2 = 0;
			if (n > 0)
			{
				n2 = a[0].Length;
			}
			T[][] b = new T[n2][];
			for (int i2 = 0; i2 < n2; i2++)
			{
				b[i2] = new T[n];
				for (int i3 = 0; i3 < n; i3++)
				{
					b[i2][i3] = a[i3][i2];
				}
			}
			return b;
		}

		/// <summary>
		/// Conjugate Transpose 2D-Array (Matrix)
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">Matrix</param>
		/// <returns>Matrix</returns>
		// Token: 0x0600006C RID: 108 RVA: 0x00004048 File Offset: 0x00002248
		public static T[][] CTranspose<T>(T[][] a) where T : INumber<T>, new()
		{
			int n = a.Length;
			int n2 = 0;
			if (n > 0)
			{
				n2 = a[0].Length;
			}
			T[][] b = new T[n2][];
			for (int i2 = 0; i2 < n2; i2++)
			{
				b[i2] = new T[n];
				for (int i3 = 0; i3 < n; i3++)
				{
					b[i2][i3] = a[i3][i2].Conj();
				}
			}
			return b;
		}

		/// <summary>
		/// Solve linear least-squares problem
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">Input Matrix</param>
		/// <param name="y">Known Vector</param>
		/// <returns>Solution Vector</returns>
		// Token: 0x0600006D RID: 109 RVA: 0x000040B4 File Offset: 0x000022B4
		public static T[] LstSqrSolve<T>(T[][] a, T[] y) where T : INumber<T>, new()
		{
			T[][] at = LinAlg.CTranspose<T>(a);
			return LinAlg.Solve<T>(LinAlg.Dot<T>(at, a), LinAlg.Dot<T>(at, y));
		}

		/// <summary>
		/// Interchange Rows in 2D-Array (Matrix)
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">Matrix</param>
		/// <param name="index_1">Row Index 1</param>
		/// <param name="index_2">Row Index 2</param>
		// Token: 0x0600006E RID: 110 RVA: 0x000040DC File Offset: 0x000022DC
		private static void InterchangeRows<T>(T[][] a, int index_1, int index_2) where T : INumber<T>, new()
		{
			T[] temp = a[index_1];
			a[index_1] = a[index_2];
			a[index_2] = temp;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000040F8 File Offset: 0x000022F8
		private static void InterchangeRows(int[] a, int index_1, int index_2)
		{
			int temp = a[index_1];
			a[index_1] = a[index_2];
			a[index_2] = temp;
		}

		/// <summary>
		/// Solve linear weighted least-squares problem
		/// x = inv(A'(W'+W)A)A'(W'+W)y
		/// </summary>
		/// <typeparam name="T">Real Type</typeparam>
		/// <param name="a">Input Matrix</param>
		/// <param name="y">Known Vector</param>
		/// <param name="w">Weight Matrix</param>
		/// <returns>Solution Vector</returns>
		// Token: 0x06000070 RID: 112 RVA: 0x00004114 File Offset: 0x00002314
		public static T[] WeightedLstSqrSolve<T>(T[][] a, T[] y, T[][] w) where T : IRealNumber<T>, new()
		{
			int n = w.Length;
			int n2 = 0;
			if (n > 0)
			{
				n2 = w[0].Length;
			}
			if (n != n2)
			{
				throw new Exception("Weight Matrix must be square");
			}
			T[][] w2 = new T[n][];
			for (int i = 0; i < n; i++)
			{
				w2[i] = new T[n2];
				for (int i2 = 0; i2 < n2; i2++)
				{
					w2[i][i2] = w[i][i2].Add(w[i2][i]);
				}
			}
			T[][] atw2 = LinAlg.Dot<T>(LinAlg.Transpose<T>(a), w2);
			return LinAlg.Solve<T>(LinAlg.Dot<T>(atw2, a), LinAlg.Dot<T>(atw2, y));
		}

		/// <summary>
		/// Cholesky decomposition l = Cholesky(a)
		/// </summary>
		/// <typeparam name="T">Real Type</typeparam>
		/// <param name="a">Matrix</param>
		/// <returns>Matrix</returns>
		// Token: 0x06000071 RID: 113 RVA: 0x000041C0 File Offset: 0x000023C0
		public static T[][] Cholesky<T>(T[][] a) where T : IRealNumber<T>, new()
		{
			int n = a.Length;
			int n2 = 0;
			if (n > 0)
			{
				n2 = a[0].Length;
			}
			if (n != n2)
			{
				throw new Exception("Matrix must be square");
			}
			T[][] i = Array.Zeros2d<T>(n, n2);
			for (int j = 0; j < n; j++)
			{
				for (int k = 0; k < j; k++)
				{
					T sum = a[j][k];
					for (int l = 0; l < k; l++)
					{
						sum = sum.Subtract(i[j][l].Multiply(i[k][l]));
					}
					i[j][k] = sum.Divide(i[k][k]);
				}
				T sum2 = a[j][j];
				for (int m = 0; m < j; m++)
				{
					sum2 = sum2.Subtract(i[j][m].Multiply(i[j][m]));
				}
				if (sum2.FcnValue <= 0.0)
				{
					throw new Exception("Matrix is not positiv definit");
				}
				i[j][j] = sum2.Sqrt();
			}
			return i;
		}

		/// <summary>
		/// Computes Jacobi Matrix using Eigenvalue Decomposition
		/// </summary>
		/// <typeparam name="T">Real Number Type</typeparam>
		/// <param name="m">Covariance Matrix</param>
		/// <returns>Jacobi Matrix</returns>
		// Token: 0x06000072 RID: 114 RVA: 0x0000430C File Offset: 0x0000250C
		public static T[][] ComputeJacobiEig<T>(T[][] m) where T : IRealNumber<T>, new()
		{
			int num;
			return LinAlg.ComputeJacobiEig<T>(m, out num);
		}

		/// <summary>
		/// Computes Jacobi Matrix using Eigenvalue Decomposition
		/// </summary>
		/// <typeparam name="T">Real Number Type</typeparam>
		/// <param name="m">Covariance Matrix</param>
		/// <param name="n2">Number of non zero Eigenvalues</param>
		/// <returns>Jacobi Matrix</returns>
		// Token: 0x06000073 RID: 115 RVA: 0x00004324 File Offset: 0x00002524
		public static T[][] ComputeJacobiEig<T>(T[][] m, out int n2) where T : IRealNumber<T>, new()
		{
			int i = m.Length;
			double[,] m2 = new double[i, i];
			for (int i2 = 0; i2 < i; i2++)
			{
				for (int i3 = 0; i3 < i; i3++)
				{
					m2[i2, i3] = m[i2][i3].Value;
				}
			}
			double[,] j2 = LinAlg.ComputeJacobiEig(m2, out n2);
			T[][] k = new T[i][];
			for (int i4 = 0; i4 < i; i4++)
			{
				k[i4] = new T[i];
				for (int i5 = 0; i5 < i; i5++)
				{
					T temp = Activator.CreateInstance<T>();
					temp.InitDbl(j2[i4, i5]);
					k[i4][i5] = temp;
				}
			}
			return k;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000043E4 File Offset: 0x000025E4
		private static double[,] ComputeJacobiEig(double[,] m, out int n2)
		{
			int i = m.GetLength(0);
			n2 = 0;
			double[] d = new double[i];
			double[,] z = MKL.SymmetricEig(m, out d);
			double[] d2 = new double[i];
			double largest = 0.0;
			for (int j = 0; j < i; j++)
			{
				largest = System.Math.Max(largest, d[j]);
			}
			for (int k = 0; k < i; k++)
			{
				if (d[k] > 1E-15 * largest)
				{
					d2[k] = System.Math.Sqrt(d[k]);
					n2++;
				}
			}
			double[,] l = new double[i, i];
			for (int i2 = 0; i2 < i; i2++)
			{
				for (int i3 = 0; i3 < i; i3++)
				{
					l[i2, i3] = z[i2, i3] * d2[i3];
				}
			}
			return l;
		}

		/// <summary>
		/// Computes Inverse Jacobi Matrix using Eigenvalue Decomposition
		/// </summary>
		/// <typeparam name="T">Real Number Type</typeparam>
		/// <param name="m">Covariance Matrix</param>
		/// <param name="n2">Number of non zero Eigenvalues</param>
		/// <returns>Inverse Jacobi Matrix</returns>
		// Token: 0x06000075 RID: 117 RVA: 0x000044B8 File Offset: 0x000026B8
		public static T[][] ComputeInvJacobiEig<T>(T[][] m, out int n2) where T : IRealNumber<T>, new()
		{
			int i = m.Length;
			double[,] m2 = new double[i, i];
			for (int i2 = 0; i2 < i; i2++)
			{
				for (int i3 = 0; i3 < i; i3++)
				{
					m2[i2, i3] = m[i2][i3].Value;
				}
			}
			double[,] j2 = LinAlg.ComputeInvJacobiEig(m2, out n2);
			T[][] k = new T[i][];
			for (int i4 = 0; i4 < i; i4++)
			{
				k[i4] = new T[i];
				for (int i5 = 0; i5 < i; i5++)
				{
					T temp = Activator.CreateInstance<T>();
					temp.InitDbl(j2[i4, i5]);
					k[i4][i5] = temp;
				}
			}
			return k;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00004578 File Offset: 0x00002778
		private static double[,] ComputeInvJacobiEig(double[,] m, out int n2)
		{
			int i = m.GetLength(0);
			n2 = 0;
			double[] d = new double[i];
			double[,] z = MKL.SymmetricEig(m, out d);
			double[] d2 = new double[i];
			double largest = 0.0;
			for (int j = 0; j < i; j++)
			{
				largest = System.Math.Max(largest, d[j]);
			}
			for (int k = 0; k < i; k++)
			{
				if (d[k] > 1E-15 * largest)
				{
					d2[k] = System.Math.Sqrt(1.0 / d[k]);
					n2++;
				}
			}
			double[,] l = new double[i, i];
			for (int i2 = 0; i2 < i; i2++)
			{
				for (int i3 = 0; i3 < i; i3++)
				{
					l[i2, i3] = z[i2, i3] * d2[i3];
				}
			}
			return l;
		}

		/// <summary>
		/// Solve linear weighted least-squares problem
		/// x = inv(A'(W'+W)A)A'(W'+W)y
		/// </summary>
		/// <typeparam name="T">Real Type</typeparam>
		/// <param name="a">Input Matrix</param>
		/// <param name="y">Known Vector</param>
		/// <param name="w">Weight Matrix</param>
		/// <returns>Solution Vector</returns>
		// Token: 0x06000077 RID: 119 RVA: 0x00004654 File Offset: 0x00002854
		public static Complex<T>[] WeightedLstSqrSolve<T>(Complex<T>[][] a, Complex<T>[] y, T[][] w) where T : IRealNumber<T>, new()
		{
			int n = a.Length;
			int n2 = 0;
			if (n > 0)
			{
				n2 = a[0].Length;
			}
			T[][] a2 = new T[2 * n][];
			T[] y2 = new T[2 * n];
			for (int i = 0; i < n; i++)
			{
				a2[2 * i] = new T[2 * n2];
				a2[2 * i + 1] = new T[2 * n2];
				for (int i2 = 0; i2 < n2; i2++)
				{
					a2[2 * i][2 * i2] = a[i][i2].Real();
					a2[2 * i + 1][2 * i2] = a[i][i2].Imag();
					T[] array = a2[2 * i];
					int num = 2 * i2 + 1;
					T t = a[i][i2].Imag();
					array[num] = t.Negative();
					a2[2 * i + 1][2 * i2 + 1] = a[i][i2].Real();
				}
				y2[2 * i] = y[i].Real();
				y2[2 * i + 1] = y[i].Imag();
			}
			T[] x2 = LinAlg.WeightedLstSqrSolve<T>(a2, y2, w);
			Complex<T>[] x3 = new Complex<T>[n2];
			for (int i3 = 0; i3 < n2; i3++)
			{
				x3[i3] = new Complex<T>
				{
					real = x2[2 * i3],
					imag = x2[2 * i3 + 1]
				};
			}
			return x3;
		}
	}
}
