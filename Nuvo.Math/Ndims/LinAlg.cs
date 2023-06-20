using System;
using Nuvo.Math.Interface;

namespace Nuvo.Math.Ndims
{
	/// <summary>
	/// Generic Linear Algebra
	/// </summary>
	/// <typeparam name="L">LU Result Type</typeparam>
	/// <typeparam name="T">Array Type</typeparam>
	/// <typeparam name="D">Element Type</typeparam>
	public class LinAlg<L, T, D> where L : LuResult<T, D>, new() where T : INArray<T, D>, new() where D : INumber<D>, new()
	{
		/// <summary>
		/// Matrix Multiplication c = Dot(a, b)
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static T Dot(T a, T b)
		{
			if (a.ndims == 1)
			{
				a.Reshape(new int[]
				{
					a.numel,
					1
				});
			}
			if (b.ndims == 1)
			{
				b.Reshape(new int[]
				{
					b.numel,
					1
				});
			}
			if (!a.IsMatrix)
			{
				throw new Exception("First array must be a matrix");
			}
			if (!b.IsMatrix)
			{
				throw new Exception("Second array must be a matrix");
			}
			int n = a.size[0];
			int n2 = a.size[1];
			int n3 = b.size[0];
			int n4 = b.size[1];
			T c = Activator.CreateInstance<T>();
			c.Init2d(n, n4);
			if (n2 != n3)
			{
				throw new Exception("Inner matrix dimensions must agree");
			}
			for (int i = 0; i < n; i++)
			{
				for (int i2 = 0; i2 < n4; i2++)
				{
					D d = Activator.CreateInstance<D>();
					D temp = d.Zero;
					for (int i3 = 0; i3 < n2; i3++)
					{
						d = a[i, i3];
						temp = temp.Add(d.Multiply(b[i3, i2]));
					}
					c[i, i2] = temp;
				}
			}
			return c;
		}

		/// <summary>
		/// Forward Substitution x = Fsub(l, y)
		/// </summary>
		/// <param name="l"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public static T Fsub(T l, T y)
		{
			if (!l.IsMatrix)
			{
				throw new Exception("First array must be a matrix");
			}
			if (!y.IsColVector)
			{
				throw new Exception("Second array must be a column vector");
			}
			int n = y.numel;
			int ii = -1;
			T x = Activator.CreateInstance<T>();
			x.Zeros1d(n);
			for (int i = 0; i < n; i++)
			{
				D temp = y[i];
				if (ii >= 0)
				{
					for (int i2 = ii; i2 < i; i2++)
					{
						D d = x[i2];
						temp = temp.Subtract(d.Multiply(l[i, i2]));
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
		/// <param name="u"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public static T Bsub(T u, T y)
		{
			if (!u.IsMatrix)
			{
				throw new Exception("First array must be a matrix");
			}
			if (!y.IsColVector)
			{
				throw new Exception("Second array must be a column vector");
			}
			int n = y.numel;
			T x = Activator.CreateInstance<T>();
			x.Zeros1d(n);
			for (int k = n - 1; k >= 0; k--)
			{
				D temp = y[k];
				for (int i2 = k + 1; i2 < n; i2++)
				{
					D d = x[i2];
					temp = temp.Subtract(d.Multiply(u[k, i2]));
				}
				x[k] = temp.Divide(u[k, k]);
			}
			return x;
		}

		/// <summary>
		/// LU factorization Implement [l u p] = Lu(a)
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static L Lu(T a)
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
			int d = 0;
			D d2 = Activator.CreateInstance<D>();
			D zero = d2.Zero;
			d2 = Activator.CreateInstance<D>();
			D one = d2.One;
			T i = Activator.CreateInstance<T>();
			i.Zeros2d(n, n);
			T p = Activator.CreateInstance<T>();
			p.Identity(n);
			T u = a.Copy();
			for (int j = 0; j < n; j++)
			{
				int k = j;
				d2 = u[j, j];
				double max = d2.DblSqrFcnValue();
				for (int z = j + 1; z < n; z++)
				{
					d2 = u[z, j];
					double max2 = d2.DblSqrFcnValue();
					if (max2 > max)
					{
						k = z;
						max = max2;
					}
				}
				if (max == 0.0)
				{
					throw new Exception("Matrix is singular");
				}
				if (k != j)
				{
					i.InterchangeRows(k, j);
					u.InterchangeRows(k, j);
					p.InterchangeRows(k, j);
					d++;
				}
				D i_u_kk = one.Divide(u[j, j]);
				for (int i2 = j + 1; i2 < n; i2++)
				{
					int index = i2;
					int index2 = j;
					d2 = u[i2, j];
					i[index, index2] = d2.Multiply(i_u_kk);
					u[i2, j] = zero;
					for (int i3 = j + 1; i3 < n; i3++)
					{
						int index3 = i2;
						int index4 = i3;
						d2 = u[i2, i3];
						D d3 = i[i2, j];
						u[index3, index4] = d2.Subtract(d3.Multiply(u[j, i3]));
					}
				}
			}
			for (int l = 0; l < n; l++)
			{
				i[l, l] = one;
			}
			L l2 = Activator.CreateInstance<L>();
			l2.l = i;
			l2.u = u;
			l2.p = p;
			l2.d = d;
			return l2;
		}

		/// <summary>
		/// Determinant of a square matrix
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static D Det(T a)
		{
			L lup = LinAlg<L, T, D>.Lu(a);
			D d2 = Activator.CreateInstance<D>();
			D d = d2.One;
			int i = a.size[1];
			for (int j = 0; j < i; j++)
			{
				T u = lup.u;
				d = d.Multiply(u[j, j]);
			}
			if (lup.d % 2 == 1)
			{
				d = d.Negative();
			}
			return d;
		}

		/// <summary>
		/// Solve a linear system of equations
		/// </summary>
		/// <param name="a">Input Matrix</param>
		/// <param name="y">Known Vector</param>
		/// <returns>Solution Vector</returns>
		public static T Solve(T a, T y)
		{
			L lup = LinAlg<L, T, D>.Lu(a);
			return LinAlg<L, T, D>.Bsub(lup.u, LinAlg<L, T, D>.Fsub(lup.l, LinAlg<L, T, D>.Dot(lup.p, y)));
		}

		/// <summary>
		/// Inverse of a square matrix
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static T Inv(T a)
		{
			L lup = LinAlg<L, T, D>.Lu(a);
			int i = a.size[0];
			T x = Activator.CreateInstance<T>();
			x.Init2d(i, i);
			T temp = Activator.CreateInstance<T>();
			temp.Init1d(i);
			for (int i2 = 0; i2 < i; i2++)
			{
				for (int i3 = 0; i3 < i; i3++)
				{
					int index = i3;
					T p = lup.p;
					temp[index] = p[i3, i2];
				}
				T xi = LinAlg<L, T, D>.Bsub(lup.u, LinAlg<L, T, D>.Fsub(lup.l, temp));
				for (int i4 = 0; i4 < i; i4++)
				{
					x[i4, i2] = xi[i4];
				}
			}
			return x;
		}

		/// <summary>
		/// Sum of elements along the dimension dim
		/// </summary>
		/// <param name="a"></param>
		/// <param name="dim"></param>
		/// <returns></returns>
		public static T Sum(T a, int dim)
		{
			int i = a.numel;
			int nd = a.ndims;
			int[] s = new int[nd];
			a.size.CopyTo(s, 0);
			s[dim] = 1;
			T b = Activator.CreateInstance<T>();
			b.ZerosNd(s);
			for (int j = 0; j < i; j++)
			{
				int[] index_a = LinAlg<L, T, D>.NdimIndex(a.size, j);
				int[] index_b = new int[nd];
				index_a.CopyTo(index_b, 0);
				index_b[dim] = 0;
				int[] indices = index_b;
				D d = b[index_b];
				b[indices] = d.Add(a[index_a]);
			}
			return b;
		}

		/// <summary>
		/// Product of elements along the dimension dim
		/// </summary>
		/// <param name="a"></param>
		/// <param name="dim"></param>
		/// <returns></returns>
		public static T Prod(T a, int dim)
		{
			int i = a.numel;
			int nd = a.ndims;
			int[] s = new int[nd];
			a.size.CopyTo(s, 0);
			s[dim] = 1;
			T b = Activator.CreateInstance<T>();
			b.OnesNd(s);
			for (int j = 0; j < i; j++)
			{
				int[] index_a = LinAlg<L, T, D>.NdimIndex(a.size, j);
				int[] index_b = new int[nd];
				index_a.CopyTo(index_b, 0);
				index_b[dim] = 0;
				int[] indices = index_b;
				D d = b[index_b];
				b[indices] = d.Multiply(a[index_a]);
			}
			return b;
		}

		private static int[] NdimIndex(int[] s, int flat_index)
		{
			int i = s.Length;
			int[] ndim_index = new int[i];
			int temp = 1;
			for (int j = 0; j < i; j++)
			{
				ndim_index[j] = flat_index / temp % s[j];
				temp *= s[j];
			}
			return ndim_index;
		}
	}
}
