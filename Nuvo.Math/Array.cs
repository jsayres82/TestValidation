using System;
using System.Text;
using Nuvo.Math.Interface;

namespace Nuvo.Math
{
	/// <summary>
	/// Generic Array
	/// </summary>
	// Token: 0x02000002 RID: 2
	public static class Array
	{
		/// <summary>
		/// Creates a 1D-Array (Vector) with all values = 0
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="n1">Dim: 1, Number of elements</param>
		/// <returns></returns>
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static T[] Zeros1d<T>(int n1) where T : INumber<T>, new()
		{
			T t = Activator.CreateInstance<T>();
			T zero = t.Zero;
			T[] x = new T[n1];
			for (int i = 0; i < n1; i++)
			{
				x[i] = zero;
			}
			return x;
		}

		/// <summary>
		/// Creates a 2D-Array (Matrix) with all values = 0
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="n1">Dim: 1, Number of elements (rows)</param>
		/// <param name="n2">Dim: 2, Number of elements (cols)</param>
		/// <returns></returns>
		// Token: 0x06000002 RID: 2 RVA: 0x00002090 File Offset: 0x00000290
		public static T[][] Zeros2d<T>(int n1, int n2) where T : INumber<T>, new()
		{
			T t = Activator.CreateInstance<T>();
			T zero = t.Zero;
			T[][] x = new T[n1][];
			for (int i = 0; i < n1; i++)
			{
				T[] x2 = new T[n2];
				for (int i2 = 0; i2 > n2; i2++)
				{
					x2[i2] = zero;
				}
				x[i] = x2;
			}
			return x;
		}

		/// <summary>
		/// Creates a 1D-Array (Vector) with all values = 1
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="n1">Dim: 1, Number of elements</param>
		/// <returns></returns>
		// Token: 0x06000003 RID: 3 RVA: 0x000020EC File Offset: 0x000002EC
		public static T[] Ones1d<T>(int n1) where T : INumber<T>, new()
		{
			T t = Activator.CreateInstance<T>();
			T one = t.One;
			T[] x = new T[n1];
			for (int i = 0; i < n1; i++)
			{
				x[i] = one;
			}
			return x;
		}

		/// <summary>
		/// Creates a 2D-Array (Matrix) with all values = 1
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="n1">Dim: 1, Number of elements (rows)</param>
		/// <param name="n2">Dim: 2, Number of elements (cols)</param>
		/// <returns></returns>
		// Token: 0x06000004 RID: 4 RVA: 0x0000212C File Offset: 0x0000032C
		public static T[][] Ones2d<T>(int n1, int n2) where T : INumber<T>, new()
		{
			T t = Activator.CreateInstance<T>();
			T one = t.One;
			T[][] x = new T[n1][];
			for (int i = 0; i < n1; i++)
			{
				T[] x2 = new T[n2];
				for (int i2 = 0; i2 < n2; i2++)
				{
					x2[i2] = one;
				}
				x[i] = x2;
			}
			return x;
		}

		/// <summary>
		/// Creates a Identity 2D-Array (Matrix)
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="n">Number of Rows and Cols</param>
		/// <returns></returns>
		// Token: 0x06000005 RID: 5 RVA: 0x00002188 File Offset: 0x00000388
		public static T[][] Identity<T>(int n) where T : INumber<T>, new()
		{
			T t = Activator.CreateInstance<T>();
			T zero = t.Zero;
			t = Activator.CreateInstance<T>();
			T one = t.One;
			T[][] x = new T[n][];
			for (int i = 0; i < n; i++)
			{
				T[] x2 = new T[n];
				for (int i2 = 0; i2 < n; i2++)
				{
					if (i == i2)
					{
						x2[i2] = one;
					}
					else
					{
						x2[i2] = zero;
					}
				}
				x[i] = x2;
			}
			return x;
		}

		/// <summary>
		/// Creates a copy of the 1D-Array (Vector)
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">Vector</param>
		/// <returns></returns>
		// Token: 0x06000006 RID: 6 RVA: 0x00002210 File Offset: 0x00000410
		public static T[] Copy<T>(T[] a) where T : new()
		{
			T[] b = new T[a.Length];
			a.CopyTo(b, 0);
			return b;
		}

		/// <summary>
		/// Creates a copy of the 2D-Array (Matrix)
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">Matrix</param>
		/// <returns></returns>
		// Token: 0x06000007 RID: 7 RVA: 0x00002230 File Offset: 0x00000430
		public static T[][] Copy<T>(T[][] a) where T : new()
		{
			int n = a.Length;
			T[][] b = new T[n][];
			for (int i = 0; i < n; i++)
			{
				int n2 = a[i].Length;
				b[i] = new T[n2];
				a[i].CopyTo(b[i], 0);
			}
			return b;
		}

		/// <summary>
		/// Pretty prints Real 1D-Array (Vector) to Console
		/// </summary>
		/// <typeparam name="T">Real Type</typeparam>
		/// <param name="a"></param>
		// Token: 0x06000008 RID: 8 RVA: 0x00002270 File Offset: 0x00000470
		public static void PrettyPrint<T>(T[] a) where T : IRealNumber<T>, new()
		{
			StringBuilder sb = new StringBuilder();
			int i = a.Length;
			for (int j = 0; j < i; j++)
			{
				sb.Append(a[j].Value.ToString("  0.000E+00  ; -0.000E+00  "));
				sb.Append("\n");
			}
			Console.WriteLine(sb.ToString());
		}

		/// <summary>
		/// Pretty prints Real 2D-Array (Matrix) to Console
		/// </summary>
		/// <typeparam name="T">Real Type</typeparam>
		/// <param name="a"></param>
		// Token: 0x06000009 RID: 9 RVA: 0x000022D4 File Offset: 0x000004D4
		public static void PrettyPrint<T>(T[][] a) where T : IRealNumber<T>, new()
		{
			StringBuilder sb = new StringBuilder();
			int n_cols = 6;
			int n = a.Length;
			int n2 = 0;
			if (n > 0)
			{
				n2 = a[0].Length;
			}
			int n3 = (n2 + n_cols - 1) / n_cols;
			for (int i3 = 0; i3 < n3; i3++)
			{
				int col_ = i3 * n_cols;
				int col_2 = col_ + n_cols;
				if (col_2 > n2)
				{
					col_2 = n2;
				}
				if (n3 > 1)
				{
					sb.Append("Columns ");
					sb.Append(col_.ToString());
					sb.Append(" through ");
					sb.Append((col_2 - 1).ToString());
					sb.Append("\n");
				}
				for (int i4 = 0; i4 < n; i4++)
				{
					for (int i5 = col_; i5 < col_2; i5++)
					{
						sb.Append(a[i4][i5].Value.ToString("  0.000E+00  ; -0.000E+00  "));
					}
					sb.Append("\n");
				}
				sb.Append("\n");
			}
			Console.WriteLine(sb.ToString());
		}

		/// <summary>
		/// Pretty prints Complex 1D-Array (Vector) to Console
		/// </summary>
		/// <typeparam name="T">Complex Type</typeparam>
		/// <param name="a"></param>
		// Token: 0x0600000A RID: 10 RVA: 0x000023EC File Offset: 0x000005EC
		public static void PrettyPrint<T>(Complex<T>[] a) where T : IRealNumber<T>, new()
		{
			StringBuilder sb = new StringBuilder();
			int i = a.Length;
			for (int j = 0; j < i; j++)
			{
				sb.Append(a[j].real.Value.ToString(" ( 0.000E+00 ; (-0.000E+00 "));
				sb.Append(a[j].imag.Value.ToString(" +0.000E+00i); -0.000E+00i)"));
				sb.Append("\n");
			}
			Console.WriteLine(sb.ToString());
		}

		/// <summary>
		/// Pretty prints Complex 2D-Array (Matrix) to Console
		/// </summary>
		/// <typeparam name="T">Real Type</typeparam>
		/// <param name="a"></param>
		// Token: 0x0600000B RID: 11 RVA: 0x0000247C File Offset: 0x0000067C
		public static void PrettyPrint<T>(Complex<T>[][] a ) where T : IRealNumber<T>, new()
		{
			StringBuilder sb = new StringBuilder();
			int n_cols = 6;
			int n = a.Length;
			int n2 = 0;
			if (n > 0)
			{
				n2 = a[0].Length;
			}
			int n3 = (n2 + n_cols - 1) / n_cols;
			for (int i3 = 0; i3 < n3; i3++)
			{
				int col_ = i3 * n_cols;
				int col_2 = col_ + n_cols;
				if (col_2 > n2)
				{
					col_2 = n2;
				}
				if (n3 > 1)
				{
					sb.Append("Columns ");
					sb.Append(col_.ToString());
					sb.Append(" through ");
					sb.Append((col_2 - 1).ToString());
					sb.Append("\n");
				}
				for (int i4 = 0; i4 < n; i4++)
				{
					for (int i5 = col_; i5 < col_2; i5++)
					{
						sb.Append(a[i4][i5].real.Value.ToString(" ( 0.000E+00 ; (-0.000E+00 "));
						sb.Append(a[i4][i5].imag.Value.ToString(" +0.000E+00i); -0.000E+00i)"));
					}
					sb.Append("\n");
				}
				sb.Append("\n");
			}
			Console.WriteLine(sb.ToString());
		}
	}
}
