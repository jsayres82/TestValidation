using System;
using Nuvo.IntelMKL;
using Nuvo.Math.Core.Interface;
using Nuvo.Math.Core.Special;

namespace Nuvo.Math.Core
{
	/// <summary>
	/// Generic Numeric Library
	/// </summary>
	// Token: 0x02000007 RID: 7
	public static class NumLib
	{
		/// <summary>
		/// Linspace
		/// </summary>
		/// <param name="start">Start value</param>
		/// <param name="stop">Stop value</param>
		/// <param name="points">Number of points</param>
		/// <returns>Linearly spaced vector</returns>
		// Token: 0x0600009C RID: 156 RVA: 0x00004C90 File Offset: 0x00002E90
		public static double[] Linspace(double start, double stop, int points)
		{
			double[] data = new double[points];
			double step = (stop - start) / (double)(points - 1);
			for (int i = 0; i < points; i++)
			{
				data[i] = start + step * (double)i;
			}
			return data;
		}

		/// <summary>
		/// Logspace
		/// </summary>
		/// <param name="start">Start Value</param>
		/// <param name="stop">Stop Value</param>
		/// <param name="points">Number of points</param>
		/// <returns>Logarithmically spaced vector</returns>
		// Token: 0x0600009D RID: 157 RVA: 0x00004CC4 File Offset: 0x00002EC4
		public static double[] Logspace(double start, double stop, int points)
		{
			double[] data = new double[points];
			double step = (stop - start) / (double)(points - 1);
			for (int i = 0; i < points; i++)
			{
				data[i] = System.Math.Pow(10.0, start + step * (double)i);
			}
			return data;
		}

		/// <summary>
		/// Fit polynomial to data
		/// </summary>
		/// <typeparam name="T">Number Type</typeparam>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Polynom Order: 0 to Number of Points - 1</param>
		/// <returns>Polynomial coefficients in descending powers</returns>
		// Token: 0x0600009E RID: 158 RVA: 0x00004D08 File Offset: 0x00002F08
		public static T[] PolyFit<T>(T[] x, T[] y, int n) where T : INumber<T>, new()
		{
			if (x.Length != y.Length)
			{
				throw new Exception("Vector dimensions must agree");
			}
			int n2 = x.Length;
			int n3 = n + 1;
			if (1 > n3 || n3 > n2)
			{
				throw new Exception("Polynom order out of range");
			}
			T[][] A = new T[n2][];
			for (int i = 0; i < n2; i++)
			{
				A[i] = new T[n3];
				T temp = Activator.CreateInstance<T>();
				temp.InitDbl(1.0);
				for (int i2 = n3 - 1; i2 >= 0; i2--)
				{
					A[i][i2] = temp;
					if (i2 > 0)
					{
						temp = temp.Multiply(x[i]);
					}
				}
			}
			T[] p;
			if (n2 == n3)
			{
				p = LinAlg.Solve<T>(A, y);
			}
			else
			{
				p = LinAlg.LstSqrSolve<T>(A, y);
			}
			return p;
		}

		/// <summary>
		/// Evaluate polynomial
		/// </summary>
		/// <typeparam name="T">Number Type</typeparam>
		/// <param name="p">Polynomial coefficients in descending powers</param>
		/// <param name="x">X-Value</param>
		/// <returns>Y-Value</returns>
		// Token: 0x0600009F RID: 159 RVA: 0x00004DD4 File Offset: 0x00002FD4
		public static T PolyVal<T>(T[] p, T x) where T : INumber<T>, new()
		{
			int num = p.Length;
			T temp = Activator.CreateInstance<T>();
			temp.InitDbl(1.0);
			T y = Activator.CreateInstance<T>();
			y.InitDbl(0.0);
			for (int i2 = num - 1; i2 >= 0; i2--)
			{
				y = y.Add(temp.Multiply(p[i2]));
				if (i2 > 0)
				{
					temp = temp.Multiply(x);
				}
			}
			return y;
		}

		/// <summary>
		/// Evaluate polynomial
		/// </summary>
		/// <typeparam name="T">Number Type</typeparam>
		/// <param name="p">Polynomial coefficients in descending powers</param>
		/// <param name="x">X-Values</param>
		/// <returns>Y-Values</returns>
		// Token: 0x060000A0 RID: 160 RVA: 0x00004E60 File Offset: 0x00003060
		public static T[] PolyVal<T>(T[] p, T[] x) where T : INumber<T>, new()
		{
			int i = x.Length;
			T[] y = new T[i];
			for (int j = 0; j < i; j++)
			{
				y[j] = NumLib.PolyVal<T>(p, x[j]);
			}
			return y;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00004E9C File Offset: 0x0000309C
		private static double[] InterpolationSensitivities<T>(double[] x, double xx, int n)
		{
			int n2 = x.Length;
			int n3 = n + 1;
			Number[][] A = new Number[n2][];
			for (int i = 0; i < n2; i++)
			{
				A[i] = new Number[n3];
				Number temp = 1.0;
				for (int i2 = n3 - 1; i2 >= 0; i2--)
				{
					A[i][i2] = temp;
					if (i2 > 0)
					{
						temp *= x[i];
					}
				}
			}
			Number[][] b = new Number[][]
			{
				new Number[n3]
			};
			Number temp2 = 1.0;
			for (int i3 = n3 - 1; i3 >= 0; i3--)
			{
				b[0][i3] = temp2;
				if (i3 > 0)
				{
					temp2 *= xx;
				}
			}
			Number[][] s = LinAlg.Dot<Number>(b, LinAlg.Inv<Number>(A));
			double[] s2 = new double[n2];
			for (int i4 = 0; i4 < n2; i4++)
			{
				s2[i4] = s[0][i4].Value;
			}
			return s2;
		}

		/// <summary>
		/// Interpolation (obsolete)
		/// </summary>
		/// <typeparam name="T">Real Number Type</typeparam>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Interpolation Order: 1 to Number of Points - 1</param>
		/// <param name="xx">XX Value</param>
		/// <param name="m">Interpolation Error Factor</param>
		/// <returns>YY Value</returns>
		// Token: 0x060000A2 RID: 162 RVA: 0x00004FA7 File Offset: 0x000031A7
		private static T Interpolation<T>(double[] x, T[] y, int n, double xx, double m) where T : IRealNumber<T>, new()
		{
			throw new Exception("This interpolation function is obsolete, use interpolation2 instead");
		}

		/// <summary>
		/// Interpolation (obsolete)
		/// </summary>
		/// <typeparam name="T">Real Number Type</typeparam>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Interpolation Order: 1 to Number of Points - 1</param>
		/// <param name="xx">XX Value</param>
		/// <param name="m">Interpolation Error Factor</param>
		/// <returns>YY Value</returns>
		// Token: 0x060000A3 RID: 163 RVA: 0x00004FB4 File Offset: 0x000031B4
		private static Complex<T> Interpolation<T>(double[] x, Complex<T>[] y, int n, double xx, double m) where T : IRealNumber<T>, new()
		{
			int n2 = y.Length;
			T[] yreal = new T[n2];
			T[] yimag = new T[n2];
			for (int i = 0; i < n2; i++)
			{
				yreal[i] = y[i].real;
				yimag[i] = y[i].imag;
			}
			T yyreal = NumLib.Interpolation<T>(x, yreal, n, xx, m);
			T yyimag = NumLib.Interpolation<T>(x, yimag, n, xx, m);
			return new Complex<T>(yyreal, yyimag);
		}

		/// <summary>
		/// Interpolation (obsolete)
		/// </summary>
		/// <typeparam name="T">Real Number Type</typeparam>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Interpolation Order: 1 to Number of Points - 1</param>
		/// <param name="xx">XX Values</param>
		/// <param name="m">Interpolation Error Factor</param>
		/// <returns>YY Values</returns>
		// Token: 0x060000A4 RID: 164 RVA: 0x00005030 File Offset: 0x00003230
		private static T[] Interpolation<T>(double[] x, T[] y, int n, double[] xx, double m) where T : IRealNumber<T>, new()
		{
			int n2 = xx.Length;
			T[] yy = new T[n2];
			for (int i2 = 0; i2 < n2; i2++)
			{
				yy[i2] = NumLib.Interpolation<T>(x, y, n, xx[i2], m);
			}
			return yy;
		}

		/// <summary>
		/// Interpolation (obsolete)
		/// </summary>
		/// <typeparam name="T">Real Number Type</typeparam>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Interpolation Order: 1 to Number of Points - 1</param>
		/// <param name="xx">XX Values</param>
		/// <param name="m">Interpolation Error Factor</param>
		/// <returns>YY Values</returns>
		// Token: 0x060000A5 RID: 165 RVA: 0x0000506C File Offset: 0x0000326C
		private static Complex<T>[] Interpolation<T>(double[] x, Complex<T>[] y, int n, double[] xx, double m) where T : IRealNumber<T>, new()
		{
			int n2 = xx.Length;
			Complex<T>[] yy = new Complex<T>[n2];
			for (int i2 = 0; i2 < n2; i2++)
			{
				yy[i2] = NumLib.Interpolation<T>(x, y, n, xx[i2], m);
			}
			return yy;
		}

		/// <summary>
		/// Interpolation
		/// </summary>
		/// <typeparam name="T">Number Type</typeparam>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Interpolation Order: 1 to Number of Points - 1</param>
		/// <param name="xx">XX Value</param>
		/// <returns>YY Value</returns>
		// Token: 0x060000A6 RID: 166 RVA: 0x000050A8 File Offset: 0x000032A8
		public static T Interpolation<T>(double[] x, T[] y, int n, double xx) where T : INumber<T>, new()
		{
			if (x.Length != y.Length)
			{
				throw new Exception("Vector dimensions must agree");
			}
			int n2 = x.Length;
			int n3 = n + 1;
			if (2 > n3 || n3 > n2)
			{
				throw new Exception("Interpolation order out of range");
			}
			T nan = Activator.CreateInstance<T>();
			nan.InitDbl(double.NaN);
			if (xx < x[0])
			{
				return nan;
			}
			int i = Array.FindIndex<double>(x, (double item) => DoubleHelper.IsLessOrApproximatelyEqual(xx, item, 1E-15));
			if (i < 0)
			{
				return nan;
			}
			return NumLib.PolyFitData<T>(x, y, n, i, xx)[n];
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000514C File Offset: 0x0000334C
		private static T[] PolyFitData<T>(double[] x, T[] y, int n, int i, double x_offset = 0.0) where T : INumber<T>, new()
		{
			int n2 = x.Length;
			int n3 = n + 1;
			int nhalf = n3 / 2;
			int nhalf2 = n3 - nhalf;
			int istart;
			if (i - nhalf < 0)
			{
				istart = 0;
			}
			else if (i + nhalf2 > n2 - 1)
			{
				istart = n2 - n3;
			}
			else
			{
				istart = i - nhalf;
			}
			T[] tx = new T[n3];
			T[] ty = new T[n3];
			for (int i2 = 0; i2 < n3; i2++)
			{
				tx[i2] = Activator.CreateInstance<T>();
				tx[i2].InitDbl(x[i2 + istart] - x_offset);
				ty[i2] = y[i2 + istart];
			}
			return NumLib.PolyFit<T>(tx, ty, n);
		}

		/// <summary>
		/// Interpolation
		/// </summary>
		/// <typeparam name="T">Number Type</typeparam>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Interpolation Order: 1 to Number of Points - 1</param>
		/// <param name="xx">XX Values</param>
		/// <returns>YY Values</returns>
		// Token: 0x060000A8 RID: 168 RVA: 0x000051F4 File Offset: 0x000033F4
		public static T[] Interpolation<T>(double[] x, T[] y, int n, double[] xx) where T : INumber<T>, new()
		{
			if (DoubleHelper.IsApproximatelyEqual(x, xx, 1E-15))
			{
				return y;
			}
			int n2 = xx.Length;
			T[] yy = new T[n2];
			for (int i2 = 0; i2 < n2; i2++)
			{
				yy[i2] = NumLib.Interpolation<T>(x, y, n, xx[i2]);
			}
			return yy;
		}

		/// <summary>
		/// Interpolation with linear uncertainty interpolation
		/// </summary>
		/// <typeparam name="T">Real Number Type</typeparam>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Interpolation Order: 1 to Number of Points - 1</param>
		/// <param name="xx">XX Value</param>
		/// <returns>YY Value</returns>
		// Token: 0x060000A9 RID: 169 RVA: 0x00005240 File Offset: 0x00003440
		public static T Interpolation2<T>(double[] x, T[] y, int n, double xx) where T : IRealNumber<T>, new()
		{
			int istart = 0;
			return NumLib.Interpolation2Sub<T>(x, y, n, xx, ref istart);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000525C File Offset: 0x0000345C
		private static T Interpolation2Sub<T>(double[] x, T[] y, int n, double xx, ref int istart) where T : IRealNumber<T>, new()
		{
			T nan = Activator.CreateInstance<T>();
			nan.InitDbl(double.NaN);
			int n2 = x.Length;
			int n3 = n + 1;
			if (2 > n3 || n3 > n2)
			{
				return nan;
			}
			if (!DoubleHelper.IsLessOrApproximatelyEqual(x[0], xx, 1E-15) || !DoubleHelper.IsLessOrApproximatelyEqual(xx, x[n2 - 1], 1E-15))
			{
				return nan;
			}
			for (int i = istart; i < n2; i++)
			{
				if (DoubleHelper.IsApproximatelyEqual(x[i], xx, 1E-15))
				{
					istart = i;
					return y[i];
				}
			}
			T yy = NumLib.Interpolation<T>(x, y, n, xx);
			double yy_u = yy.StdUnc;
			if (yy_u == 0.0)
			{
				return yy;
			}
			Number[] y_u = new Number[y.Length];
			for (int j = 0; j < y.Length; j++)
			{
				y_u[j] = y[j].StdUnc;
			}
			double yy_value = yy.Value;
			double yy2_u = NumLib.Interpolation<Number>(x, y_u, 1, xx).Value;
			T t_yy_value = Activator.CreateInstance<T>();
			t_yy_value.InitDbl(yy_value);
			T t_f = Activator.CreateInstance<T>();
			t_f.InitDbl(yy2_u / yy_u);
			T t = yy.Subtract(t_yy_value);
			t = t.Multiply(t_f);
			return t.Add(t_yy_value);
		}

		/// <summary>
		/// Interpolation with linear uncertainty interpolation
		/// </summary>
		/// <typeparam name="T">Real Number Type</typeparam>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Interpolation Order: 1 to Number of Points - 1</param>
		/// <param name="xx">XX Value</param>
		/// <returns>YY Value</returns>
		// Token: 0x060000AB RID: 171 RVA: 0x000053E4 File Offset: 0x000035E4
		public static Complex<T> Interpolation2<T>(double[] x, Complex<T>[] y, int n, double xx) where T : IRealNumber<T>, new()
		{
			int n2 = y.Length;
			T[] yreal = new T[n2];
			T[] yimag = new T[n2];
			for (int i = 0; i < n2; i++)
			{
				yreal[i] = y[i].real;
				yimag[i] = y[i].imag;
			}
			T yyreal = NumLib.Interpolation2<T>(x, yreal, n, xx);
			T yyimag = NumLib.Interpolation2<T>(x, yimag, n, xx);
			return new Complex<T>(yyreal, yyimag);
		}

		/// <summary>
		/// Interpolation with linear uncertainty interpolation
		/// </summary>
		/// <typeparam name="T">Real Number Type</typeparam>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Interpolation Order: 1 to Number of Points - 1</param>
		/// <param name="xx">XX Values</param>
		/// <returns>YY Values</returns>
		// Token: 0x060000AC RID: 172 RVA: 0x0000545C File Offset: 0x0000365C
		public static T[] Interpolation2<T>(double[] x, T[] y, int n, double[] xx) where T : IRealNumber<T>, new()
		{
			if (DoubleHelper.IsApproximatelyEqual(x, xx, 1E-15))
			{
				return y;
			}
			int n2 = xx.Length;
			T[] yy = new T[n2];
			int istart = 0;
			for (int i2 = 0; i2 < n2; i2++)
			{
				yy[i2] = NumLib.Interpolation2Sub<T>(x, y, n, xx[i2], ref istart);
			}
			return yy;
		}

		/// <summary>
		/// Interpolation with linear uncertainty interpolation
		/// </summary>
		/// <typeparam name="T">Real Number Type</typeparam>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Interpolation Order: 1 to Number of Points - 1</param>
		/// <param name="xx">XX Values</param>
		/// <returns>YY Values</returns>
		// Token: 0x060000AD RID: 173 RVA: 0x000054AC File Offset: 0x000036AC
		public static Complex<T>[] Interpolation2<T>(double[] x, Complex<T>[] y, int n, double[] xx) where T : IRealNumber<T>, new()
		{
			if (DoubleHelper.IsApproximatelyEqual(x, xx, 1E-15))
			{
				return y;
			}
			int n2 = y.Length;
			int n3 = xx.Length;
			T[] yreal = new T[n2];
			T[] yimag = new T[n2];
			for (int i = 0; i < n2; i++)
			{
				yreal[i] = y[i].real;
				yimag[i] = y[i].imag;
			}
			T[] yyreal = NumLib.Interpolation2<T>(x, yreal, n, xx);
			T[] yyimag = NumLib.Interpolation2<T>(x, yimag, n, xx);
			Complex<T>[] yy = new Complex<T>[n3];
			for (int i2 = 0; i2 < n3; i2++)
			{
				yy[i2] = new Complex<T>(yyreal[i2], yyimag[i2]);
			}
			return yy;
		}

		/// <summary>
		/// Interpolation in mag phase with linear uncertainty interpolation
		/// </summary>
		/// <typeparam name="T">Real Number Type</typeparam>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Interpolation Order: 1 to Number of Points - 1</param>
		/// <param name="xx">XX Values</param>
		/// <returns>YY Values</returns>
		// Token: 0x060000AE RID: 174 RVA: 0x00005570 File Offset: 0x00003770
		public static Complex<T>[] InterpolationMagPhase2<T>(double[] x, Complex<T>[] y, int n, double[] xx) where T : IRealNumber<T>, new()
		{
			if (DoubleHelper.IsApproximatelyEqual(x, xx, 1E-15))
			{
				return y;
			}
			int n2 = y.Length;
			T[] ym = new T[n2];
			T[] yp = new T[n2];
			for (int i = 0; i < n2; i++)
			{
				ym[i] = y[i].Abs();
				yp[i] = y[i].Angle();
			}
			yp = NumLib.UnwrapPhase<T>(yp);
			Complex<T> j = default(Complex<T>).J;
			int n3 = xx.Length;
			Complex<T>[] yy = new Complex<T>[n3];
			for (int i2 = 0; i2 < n3; i2++)
			{
				T yym = NumLib.Interpolation2<T>(x, ym, n, xx[i2]);
				T yyp = NumLib.Interpolation2<T>(x, yp, n, xx[i2]);
				yy[i2] = yym * Math.Exp<Complex<T>>(j * yyp);
			}
			return yy;
		}

		/// <summary>
		/// Spline coefficients
		/// </summary>
		/// <typeparam name="T">Number Type</typeparam>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="startBoundary">Start Boundary</param>
		/// <param name="startDerivativeValue">Start Derivative Value</param>
		/// <param name="endBoundary">End Boundary</param>
		/// <param name="endDerivativeValue">End Derivative Value</param>
		/// <returns>Spline Coefficients</returns>
		// Token: 0x060000AF RID: 175 RVA: 0x0000565C File Offset: 0x0000385C
		public static T[][] SplineCoefs<T>(double[] x, T[] y, SplineBoundary startBoundary = SplineBoundary.Natural_Spline, T startDerivativeValue = default(T), SplineBoundary endBoundary = SplineBoundary.Natural_Spline, T endDerivativeValue = default(T)) where T : INumber<T>, new()
		{
			if (x.Length != y.Length)
			{
				throw new Exception("Vector dimensions must agree");
			}
			int i = x.Length;
			if (i < 4)
			{
				throw new Exception("Length must be more than 3");
			}
			T[] r = new T[i];
			double[] A = new double[i];
			double[] B = new double[i];
			double[] C = new double[i];
			switch (startBoundary)
			{
			case SplineBoundary.Natural_Spline:
			{
				double dx10 = x[1] - x[0];
				T dy10 = y[1].Subtract(y[0]);
				C[0] = 1.0 / dx10;
				B[0] = 2.0 * C[0];
				T[] array = r;
				int num = 0;
				T t = NumLib.TNum<T>(3.0 / (dx10 * dx10));
				array[num] = t.Multiply(dy10);
				break;
			}
			case SplineBoundary.Not_a_Knot:
			{
				double dx10 = x[1] - x[0];
				double dx11 = x[2] - x[1];
				double dx12 = x[2] - x[0];
				T dy10 = y[1].Subtract(y[0]);
				T dy11 = y[2].Subtract(y[1]);
				C[0] = dx12 / dx10;
				B[0] = dx11 / dx10;
				T[] array2 = r;
				int num2 = 0;
				T t = NumLib.TNum<T>(dx11 / dx10 * (1.0 / dx12 + 2.0 / dx10));
				t = t.Multiply(dy10);
				T t2 = NumLib.TNum<T>(dx10 / (dx11 * dx12));
				array2[num2] = t.Add(t2.Multiply(dy11));
				break;
			}
			case SplineBoundary.First_Derivative:
				B[0] = 1.0;
				r[0] = startDerivativeValue;
				break;
			case SplineBoundary.Second_Derivative:
			{
				double dx10 = x[1] - x[0];
				T dy10 = y[1].Subtract(y[0]);
				C[0] = 1.0 / dx10;
				B[0] = 2.0 * C[0];
				T[] array3 = r;
				int num3 = 0;
				T t = NumLib.TNum<T>(3.0 / (dx10 * dx10));
				t = t.Multiply(dy10);
				array3[num3] = t.Add(startDerivativeValue.Divide(NumLib.TNum<T>(2.0)));
				break;
			}
			}
			for (int j = 1; j < i - 1; j++)
			{
				double dx10 = x[j] - x[j - 1];
				double dx11 = x[j + 1] - x[j];
				A[j] = 1.0 / dx10;
				C[j] = 1.0 / dx11;
				B[j] = 2.0 * (A[j] + C[j]);
				T dy10 = y[j].Subtract(y[j - 1]);
				T dy11 = y[j + 1].Subtract(y[j]);
				T[] array4 = r;
				int num4 = j;
				T t = NumLib.TNum<T>(3.0 / (dx10 * dx10));
				t = t.Multiply(dy10);
				T t2 = NumLib.TNum<T>(3.0 / (dx11 * dx11));
				array4[num4] = t.Add(t2.Multiply(dy11));
			}
			switch (endBoundary)
			{
			case SplineBoundary.Natural_Spline:
			{
				double dx10 = x[i - 1] - x[i - 2];
				T dy10 = y[i - 1].Subtract(y[i - 2]);
				A[i - 1] = 1.0 / dx10;
				B[i - 1] = 2.0 * A[i - 1];
				T[] array5 = r;
				int num5 = i - 1;
				T t = NumLib.TNum<T>(3.0 / (dx10 * dx10));
				array5[num5] = t.Multiply(dy10);
				break;
			}
			case SplineBoundary.Not_a_Knot:
			{
				double dx10 = x[i - 2] - x[i - 3];
				double dx11 = x[i - 1] - x[i - 2];
				double dx12 = x[i - 1] - x[i - 3];
				T dy10 = y[i - 2].Subtract(y[i - 3]);
				T dy11 = y[i - 1].Subtract(y[i - 2]);
				A[i - 1] = dx12 / dx11;
				B[i - 1] = dx10 / dx11;
				T[] array6 = r;
				int num6 = i - 1;
				T t = NumLib.TNum<T>(dx10 / dx11 * (1.0 / dx12 + 2.0 / dx11));
				t = t.Multiply(dy11);
				T t2 = NumLib.TNum<T>(dx11 / (dx10 * dx12));
				array6[num6] = t.Add(t2.Multiply(dy10));
				break;
			}
			case SplineBoundary.First_Derivative:
				B[i - 1] = 1.0;
				r[i - 1] = endDerivativeValue;
				break;
			case SplineBoundary.Second_Derivative:
			{
				double dx10 = x[i - 1] - x[i - 2];
				T dy10 = y[i - 1].Subtract(y[i - 2]);
				A[i - 1] = 1.0 / dx10;
				B[i - 1] = 2.0 * A[i - 1];
				T[] array7 = r;
				int num7 = i - 1;
				T t = NumLib.TNum<T>(3.0 / (dx10 * dx10));
				t = t.Multiply(dy10);
				array7[num7] = t.Add(endDerivativeValue.Divide(NumLib.TNum<T>(2.0)));
				break;
			}
			}
			double[] cPrime = new double[i];
			cPrime[0] = C[0] / B[0];
			for (int k = 1; k < i; k++)
			{
				cPrime[k] = C[k] / (B[k] - cPrime[k - 1] * A[k]);
			}
			T[] dPrime = new T[i];
			dPrime[0] = r[0].Divide(NumLib.TNum<T>(B[0]));
			for (int l = 1; l < i; l++)
			{
				T[] array8 = dPrime;
				int num8 = l;
				T t = r[l].Subtract(dPrime[l - 1].Multiply(NumLib.TNum<T>(A[l])));
				array8[num8] = t.Divide(NumLib.TNum<T>(B[l] - cPrime[l - 1] * A[l]));
			}
			T[] m = new T[i];
			m[i - 1] = dPrime[i - 1];
			for (int n = i - 2; n >= 0; n--)
			{
				T[] array9 = m;
				int num9 = n;
				T[] array10 = dPrime;
				int num10 = n;
				T t = NumLib.TNum<T>(cPrime[n]);
				array9[num9] = array10[num10].Subtract(t.Multiply(m[n + 1]));
			}
			T[] a = new T[i - 1];
			T[] b = new T[i - 1];
			T[][] coefs = new T[i - 1][];
			for (int i2 = 1; i2 < i; i2++)
			{
				double dx10 = x[i2] - x[i2 - 1];
				T dy10 = y[i2].Subtract(y[i2 - 1]);
				T[] array11 = a;
				int num11 = i2 - 1;
				T t = m[i2 - 1].Multiply(NumLib.TNum<T>(dx10));
				array11[num11] = t.Subtract(dy10);
				b[i2 - 1] = dy10.Subtract(m[i2].Multiply(NumLib.TNum<T>(dx10)));
				coefs[i2 - 1] = new T[4];
				coefs[i2 - 1][3] = y[i2 - 1];
				T[] array12 = coefs[i2 - 1];
				int num12 = 2;
				t = dy10.Add(a[i2 - 1]);
				array12[num12] = t.Divide(NumLib.TNum<T>(dx10));
				T[] array13 = coefs[i2 - 1];
				int num13 = 1;
				T[] array14 = b;
				int num14 = i2 - 1;
				t = NumLib.TNum<T>(2.0);
				t = array14[num14].Subtract(t.Multiply(a[i2 - 1]));
				array13[num13] = t.Divide(NumLib.TNum<T>(dx10 * dx10));
				T[] array15 = coefs[i2 - 1];
				int num15 = 0;
				t = a[i2 - 1].Subtract(b[i2 - 1]);
				array15[num15] = t.Divide(NumLib.TNum<T>(dx10 * dx10 * dx10));
			}
			return coefs;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00005F68 File Offset: 0x00004168
		private static T TNum<T>(double x) where T : INumber<T>, new()
		{
			T y = Activator.CreateInstance<T>();
			y.InitDbl(x);
			return y;
		}

		/// <summary>
		/// Evaluate piecewise polynomial 
		/// </summary>
		/// <typeparam name="T">Number Type</typeparam>
		/// <param name="x">X Values</param>
		/// <param name="c">Piecewise Polynomial Coefficients</param>
		/// <param name="xx">XX Values</param>
		/// <returns>YY Values</returns>
		// Token: 0x060000B1 RID: 177 RVA: 0x00005F8C File Offset: 0x0000418C
		public static T[] PiecewisePolyVal<T>(double[] x, T[][] c, double[] xx) where T : INumber<T>, new()
		{
			int n = (x != null) ? x.Length : 0;
			int n2 = (xx != null) ? xx.Length : 0;
			T[] yy = new T[n2];
			T nan = Activator.CreateInstance<T>();
			nan.InitDbl(double.NaN);
			int i2;
			Predicate<double> s9__0;
			int i3;
			for (i2 = 0; i2 < n2; i2 = i3 + 1)
			{
				if (xx[i2] < x[0] || x[n - 1] < xx[i2])
				{
					yy[i2] = nan;
				}
				else
				{
					Predicate<double> match;
					if (match = (s9__0 == null))
					{
						match = s9__0 = ((double item) => xx[i2] <= item));
					}
					int i = Array.FindIndex<double>(x, match);
					if (i > 0)
					{
						i--;
					}
					if (i < 0)
					{
						yy[i2] = nan;
					}
					else
					{
						T txx = Activator.CreateInstance<T>();
						txx.InitDbl(xx[i2] - x[i]);
						yy[i2] = NumLib.PolyVal<T>(c[i], txx);
					}
				}
				i3 = i2;
			}
			return yy;
		}

		/// <summary>
		/// Spline interpolation
		/// </summary>
		/// <typeparam name="T">Number Type</typeparam>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="xx">XX Values</param>
		/// <param name="startBoundary">Start Boundary</param>
		/// <param name="startDerivativeValue">Start Derivative Value</param>
		/// <param name="endBoundary">End Boundary</param>
		/// <param name="endDerivativeValue">End Derivative Value</param>
		/// <returns>YY Values</returns>
		// Token: 0x060000B2 RID: 178 RVA: 0x000060D4 File Offset: 0x000042D4
		public static T[] SplineInterpolation<T>(double[] x, T[] y, double[] xx, SplineBoundary startBoundary = SplineBoundary.Natural_Spline, T startDerivativeValue = default(T), SplineBoundary endBoundary = SplineBoundary.Natural_Spline, T endDerivativeValue = default(T)) where T : INumber<T>, new()
		{
			if (DoubleHelper.IsApproximatelyEqual(x, xx, 1E-15))
			{
				return y;
			}
			T[][] c = NumLib.SplineCoefs<T>(x, y, startBoundary, startDerivativeValue, endBoundary, endDerivativeValue);
			return NumLib.PiecewisePolyVal<T>(x, c, xx);
		}

		/// <summary>
		/// Spline interpolation with linear uncertainty interpolation
		/// </summary>
		/// <typeparam name="T">Real Number Type</typeparam>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="xx">XX Values</param>
		/// <param name="startBoundary">Start Boundary</param>
		/// <param name="startDerivativeValue">Start Derivative Value</param>
		/// <param name="endBoundary">End Boundary</param>
		/// <param name="endDerivativeValue">End Derivative Value</param>
		/// <returns>YY Values</returns>
		// Token: 0x060000B3 RID: 179 RVA: 0x0000610C File Offset: 0x0000430C
		public static T[] SplineInterpolation2<T>(double[] x, T[] y, double[] xx, SplineBoundary startBoundary = SplineBoundary.Natural_Spline, T startDerivativeValue = default(T), SplineBoundary endBoundary = SplineBoundary.Natural_Spline, T endDerivativeValue = default(T)) where T : IRealNumber<T>, new()
		{
			if (DoubleHelper.IsApproximatelyEqual(x, xx, 1E-15))
			{
				return y;
			}
			int n = x.Length;
			int n2 = xx.Length;
			if (n < 4)
			{
				T[] nan = new T[n2];
				T nani = Activator.CreateInstance<T>();
				nani.InitDbl(double.NaN);
				for (int i2 = 0; i2 < n2; i2++)
				{
					nan[i2] = nani;
				}
				return nan;
			}
			Number[] y_value = new Number[n];
			for (int i3 = 0; i3 < n; i3++)
			{
				y_value[i3] = y[i3].Value;
			}
			Number[] yy_value = NumLib.SplineInterpolation<Number>(x, y_value, xx, startBoundary, startDerivativeValue.Value, endBoundary, endDerivativeValue.Value);
			T[] yy_lin = NumLib.Interpolation2<T>(x, y, 1, xx);
			T[] yy = new T[n2];
			for (int i4 = 0; i4 < n2; i4++)
			{
				bool exists = false;
				for (int i5 = 0; i5 < n; i5++)
				{
					if (DoubleHelper.IsApproximatelyEqual(x[i5], xx[i4], 1E-15))
					{
						yy[i4] = y[i5];
						exists = true;
						break;
					}
				}
				if (!exists)
				{
					double temp = yy_value[i4].Value - yy_lin[i4].Value;
					yy[i4] = yy_lin[i4].Add(NumLib.TNum<T>(temp));
				}
			}
			return yy;
		}

		/// <summary>
		/// Spline interpolation with linear uncertainty interpolation
		/// </summary>
		/// <typeparam name="T">Real Number Type</typeparam>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="xx">XX Values</param>
		/// <param name="startBoundary">Start Boundary</param>
		/// <param name="startDerivativeValue">Start Derivative Value</param>
		/// <param name="endBoundary">End Boundary</param>
		/// <param name="endDerivativeValue">End Derivative Value</param>
		/// <returns>YY Values</returns>
		// Token: 0x060000B4 RID: 180 RVA: 0x000062A4 File Offset: 0x000044A4
		public static Complex<T>[] SplineInterpolation2<T>(double[] x, Complex<T>[] y, double[] xx, SplineBoundary startBoundary = SplineBoundary.Natural_Spline, Complex<T> startDerivativeValue = default(Complex<T>), SplineBoundary endBoundary = SplineBoundary.Natural_Spline, Complex<T> endDerivativeValue = default(Complex<T>)) where T : IRealNumber<T>, new()
		{
			if (DoubleHelper.IsApproximatelyEqual(x, xx, 1E-15))
			{
				return y;
			}
			int n = y.Length;
			T[] yreal = new T[n];
			T[] yimag = new T[n];
			for (int i = 0; i < n; i++)
			{
				yreal[i] = y[i].real;
				yimag[i] = y[i].imag;
			}
			T[] yyreal = NumLib.SplineInterpolation2<T>(x, yreal, xx, startBoundary, startDerivativeValue.real, endBoundary, endDerivativeValue.real);
			T[] yyimag = NumLib.SplineInterpolation2<T>(x, yimag, xx, startBoundary, startDerivativeValue.imag, endBoundary, endDerivativeValue.imag);
			int n2 = xx.Length;
			Complex<T>[] yy = new Complex<T>[n2];
			for (int i2 = 0; i2 < n2; i2++)
			{
				yy[i2] = new Complex<T>(yyreal[i2], yyimag[i2]);
			}
			return yy;
		}

		/// <summary>
		/// Spline interpolation in mag phase with linear uncertainty interpolation
		/// </summary>
		/// <typeparam name="T">Real Number Type</typeparam>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="xx">XX Values</param>
		/// <param name="startBoundary">Start Boundary</param>
		/// <param name="startDerivativeValue">Start Derivative Value</param>
		/// <param name="endBoundary">End Boundary</param>
		/// <param name="endDerivativeValue">End Derivative Value</param>
		/// <returns>YY Values</returns>
		// Token: 0x060000B5 RID: 181 RVA: 0x00006388 File Offset: 0x00004588
		public static Complex<T>[] SplineInterpolationMagPhase2<T>(double[] x, Complex<T>[] y, double[] xx, SplineBoundary startBoundary = SplineBoundary.Natural_Spline, Complex<T> startDerivativeValue = default(Complex<T>), SplineBoundary endBoundary = SplineBoundary.Natural_Spline, Complex<T> endDerivativeValue = default(Complex<T>)) where T : IRealNumber<T>, new()
		{
			if (DoubleHelper.IsApproximatelyEqual(x, xx, 1E-15))
			{
				return y;
			}
			int n = y.Length;
			T[] ym = new T[n];
			T[] yp = new T[n];
			for (int i = 0; i < n; i++)
			{
				ym[i] = y[i].Abs();
				yp[i] = y[i].Angle();
			}
			yp = NumLib.UnwrapPhase<T>(yp);
			Complex<T> j = default(Complex<T>).J;
			int n2 = xx.Length;
			Complex<T>[] yy = new Complex<T>[n2];
			T[] yym = NumLib.SplineInterpolation2<T>(x, ym, xx, startBoundary, startDerivativeValue.Abs(), endBoundary, endDerivativeValue.Abs());
			T[] yyp = NumLib.SplineInterpolation2<T>(x, yp, xx, startBoundary, startDerivativeValue.Angle(), endBoundary, endDerivativeValue.Angle());
			for (int i2 = 0; i2 < n2; i2++)
			{
				yy[i2] = yym[i2] * Math.Exp<Complex<T>>(j * yyp[i2]);
			}
			return yy;
		}

		/// <summary>
		/// Integrate
		/// </summary>
		/// <typeparam name="T">Number Type</typeparam>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Order</param>
		/// <returns>Integral</returns>
		// Token: 0x060000B6 RID: 182 RVA: 0x0000649C File Offset: 0x0000469C
		public static T[] Integrate<T>(double[] x, T[] y, int n = 1) where T : INumber<T>, new()
		{
			if (x.Length != y.Length)
			{
				throw new Exception("Vector dimensions must agree");
			}
			int n2 = x.Length;
			int n3 = n + 1;
			if (2 > n3 || n3 > n2)
			{
				throw new Exception("Order out of range");
			}
			T t = Activator.CreateInstance<T>();
			T zero = t.Zero;
			T[] res = new T[n2];
			res[0] = zero;
			for (int i = 1; i < n2; i++)
			{
				T[] p = NumLib.PolyInt<T>(NumLib.PolyFitData<T>(x, y, n, i, 0.0));
				T txb = Activator.CreateInstance<T>();
				txb.InitDbl(x[i]);
				T txa = Activator.CreateInstance<T>();
				txa.InitDbl(x[i - 1]);
				T b = NumLib.PolyVal<T>(p, txb);
				T a = NumLib.PolyVal<T>(p, txa);
				res[i] = res[i - 1].Add(b.Subtract(a));
			}
			return res;
		}

		/// <summary>
		/// Integrate
		/// </summary>
		/// <typeparam name="T">Number Type</typeparam>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Order</param>
		/// <returns>Integral</returns>
		// Token: 0x060000B7 RID: 183 RVA: 0x000065A0 File Offset: 0x000047A0
		public static T Integrate2<T>(double[] x, T[] y, int n = 1) where T : INumber<T>, new()
		{
			T[] array = NumLib.Integrate<T>(x, y, n);
			int nres = array.Length;
			return array[nres - 1];
		}

		/// <summary>
		/// Spline integrate
		/// </summary>
		/// <typeparam name="T">Number Type</typeparam>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="startBoundary">Start Boundary</param>
		/// <param name="startDerivativeValue">Start Derivative Value</param>
		/// <param name="endBoundary">End Boundary</param>
		/// <param name="endDerivativeValue">End Derivative Value</param>
		/// <returns>Integral</returns>
		// Token: 0x060000B8 RID: 184 RVA: 0x000065C4 File Offset: 0x000047C4
		public static T[] SplineIntegrate<T>(double[] x, T[] y, SplineBoundary startBoundary = SplineBoundary.Natural_Spline, T startDerivativeValue = default(T), SplineBoundary endBoundary = SplineBoundary.Natural_Spline, T endDerivativeValue = default(T)) where T : INumber<T>, new()
		{
			if (x.Length != y.Length)
			{
				throw new Exception("Vector dimensions must agree");
			}
			int n = x.Length;
			T[][] c = NumLib.SplineCoefs<T>(x, y, startBoundary, startDerivativeValue, endBoundary, endDerivativeValue);
			T t = Activator.CreateInstance<T>();
			T zero = t.Zero;
			T[] res = new T[n];
			res[0] = zero;
			for (int i = 1; i < n; i++)
			{
				T[] p = NumLib.PolyInt<T>(c[i - 1]);
				T txb = Activator.CreateInstance<T>();
				txb.InitDbl(x[i] - x[i - 1]);
				T txa = Activator.CreateInstance<T>();
				txa.InitDbl(0.0);
				T b = NumLib.PolyVal<T>(p, txb);
				res[i] = res[i - 1].Add(b);
			}
			return res;
		}

		/// <summary>
		/// Spline integrate
		/// </summary>
		/// <typeparam name="T">Number Type</typeparam>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="startBoundary">Start Boundary</param>
		/// <param name="startDerivativeValue">Start Derivative Value</param>
		/// <param name="endBoundary">End Boundary</param>
		/// <param name="endDerivativeValue">End Derivative Value</param>
		/// <returns>Integral</returns>
		// Token: 0x060000B9 RID: 185 RVA: 0x0000669C File Offset: 0x0000489C
		public static T SplineIntegrate2<T>(double[] x, T[] y, SplineBoundary startBoundary = SplineBoundary.Natural_Spline, T startDerivativeValue = default(T), SplineBoundary endBoundary = SplineBoundary.Natural_Spline, T endDerivativeValue = default(T)) where T : INumber<T>, new()
		{
			T[] array = NumLib.SplineIntegrate<T>(x, y, startBoundary, startDerivativeValue, endBoundary, endDerivativeValue);
			int nres = array.Length;
			return array[nres - 1];
		}

		/// <summary>
		/// Integrate polynomial analytically
		/// </summary>
		/// <typeparam name="T">Number Type</typeparam>
		/// <param name="p">Polynomial coefficients in descending powers</param>
		/// <returns>Integrated polynomial coefficients in descending powers</returns>
		// Token: 0x060000BA RID: 186 RVA: 0x000066C4 File Offset: 0x000048C4
		public static T[] PolyInt<T>(T[] p) where T : INumber<T>, new()
		{
			T t = Activator.CreateInstance<T>();
			T i = t.Zero;
			return NumLib.PolyInt<T>(p, i);
		}

		/// <summary>
		/// Integrate polynomial analytically
		/// </summary>
		/// <typeparam name="T">Number Type</typeparam>
		/// <param name="p">Polynomial coefficients in descending powers</param>
		/// <param name="k">Constant of integration</param>
		/// <returns>Integrated polynomial coefficients in descending powers</returns>
		// Token: 0x060000BB RID: 187 RVA: 0x000066EC File Offset: 0x000048EC
		public static T[] PolyInt<T>(T[] p, T k) where T : INumber<T>, new()
		{
			int i = (p != null) ? p.Length : 0;
			T[] p2 = new T[i + 1];
			for (int j = 0; j < i; j++)
			{
				T torder = Activator.CreateInstance<T>();
				torder.InitDbl((double)(i - j));
				p2[j] = p[j].Divide(torder);
			}
			p2[i] = k;
			return p2;
		}

		/// <summary>
		/// Unwrap Phase
		/// </summary>
		/// <typeparam name="T">Real Number Type</typeparam>
		/// <param name="p">Phase</param>
		/// <returns></returns>
		// Token: 0x060000BC RID: 188 RVA: 0x00006754 File Offset: 0x00004954
		public static T[] UnwrapPhase<T>(T[] p) where T : IRealNumber<T>, new()
		{
			int i = p.Length;
			double[] pv = new double[i];
			for (int j = 0; j < i; j++)
			{
				pv[j] = p[j].Value;
			}
			double[] pv2 = NumLib.UnwrapPhase(pv);
			T[] p2 = new T[i];
			for (int k = 0; k < i; k++)
			{
				T temp = Activator.CreateInstance<T>();
				temp.InitDbl(pv2[k] - pv[k]);
				p2[k] = p[k].Add(temp);
			}
			return p2;
		}

		/// <summary>
		/// Unwrap Phase
		/// </summary>
		/// <param name="p">Phase</param>
		/// <returns></returns>
		// Token: 0x060000BD RID: 189 RVA: 0x000067F0 File Offset: 0x000049F0
		public static double[] UnwrapPhase(double[] p)
		{
			double pi = 3.141592653589793;
			double tol = pi;
			double plast = 0.0;
			double offset = 0.0;
			int i = p.Length;
			double[] p2 = new double[i];
			for (int j = 0; j < i; j++)
			{
				if (p[j] + offset - plast >= tol)
				{
					offset -= 2.0 * pi;
				}
				else if (p[j] + offset - plast <= -tol)
				{
					offset += 2.0 * pi;
				}
				p2[j] = p[j] + offset;
				plast = p2[j];
			}
			return p2;
		}

		/// <summary>
		/// Wrap Phase
		/// </summary>
		/// <typeparam name="T">Real Number Type</typeparam>
		/// <param name="p">Phase</param>
		/// <returns></returns>
		// Token: 0x060000BE RID: 190 RVA: 0x00006884 File Offset: 0x00004A84
		public static T[] WrapPhase<T>(T[] p) where T : IRealNumber<T>, new()
		{
			int i = p.Length;
			T[] p2 = new T[i];
			for (int j = 0; j < i; j++)
			{
				p2[j] = NumLib.WrapPhase<T>(p[j]);
			}
			return p2;
		}

		/// <summary>
		/// Wrap Phase
		/// </summary>
		/// <param name="p">Phase</param>
		/// <returns></returns>
		// Token: 0x060000BF RID: 191 RVA: 0x000068BC File Offset: 0x00004ABC
		public static double[] WrapPhase(double[] p)
		{
			int i = p.Length;
			double[] p2 = new double[i];
			for (int j = 0; j < i; j++)
			{
				p2[j] = NumLib.WrapPhase(p[j]);
			}
			return p2;
		}

		/// <summary>
		/// Wrap Phase
		/// </summary>
		/// <typeparam name="T">Real Number Type</typeparam>
		/// <param name="p">Phase</param>
		/// <returns></returns>
		// Token: 0x060000C0 RID: 192 RVA: 0x000068EC File Offset: 0x00004AEC
		public static T WrapPhase<T>(T p) where T : IRealNumber<T>, new()
		{
			double pv = p.Value;
			double pv2 = NumLib.WrapPhase(pv);
			T temp = Activator.CreateInstance<T>();
			temp.InitDbl(pv2 - pv);
			return p.Add(temp);
		}

		/// <summary>
		/// Wrap Phase
		/// </summary>
		/// <param name="p">Phase</param>
		/// <returns></returns>
		// Token: 0x060000C1 RID: 193 RVA: 0x00006934 File Offset: 0x00004B34
		public static double WrapPhase(double p)
		{
			double pi = 3.141592653589793;
			return NumLib.Mod(p + pi, 2.0 * pi) - pi;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00006960 File Offset: 0x00004B60
		private static double Mod(double x, double y)
		{
			return x - System.Math.Floor(x / y) * y;
		}

		/// <summary>
		/// Fast Fourier transform
		/// </summary>
		/// <typeparam name="T">Real Type</typeparam>
		/// <param name="a">Vector time domain</param>
		/// <param name="withoutUnc">Without uncertainties</param>
		/// <returns>Vector frequency domain</returns>
		// Token: 0x060000C3 RID: 195 RVA: 0x00006970 File Offset: 0x00004B70
		public static Complex<T>[] Fft<T>(Complex<T>[] a, bool withoutUnc = false) where T : IRealNumber<T>, new()
		{
			int i = a.Length;
			if (withoutUnc)
			{
				ComplexDouble[] a2 = new ComplexDouble[i];
				for (int j = 0; j < i; j++)
				{
					a2[j] = new ComplexDouble(a[j].real.Value, a[j].imag.Value);
				}
				ComplexDouble[] b2 = MKL.FFT(a2);
				Complex<T>[] b3 = new Complex<T>[i];
				for (int k = 0; k < i; k++)
				{
					b3[k] = default(Complex<T>);
					b3[k].InitDblReIm(b2[k].real, b2[k].imag);
				}
				return b3;
			}
			if ((i & i - 1) == 0 & i != 0)
			{
				return NumLib.Fft2<T>(a);
			}
			return NumLib.Chirp<T>(a);
		}

		/// <summary>
		/// Inverse Fast Fourier transform
		/// </summary>
		/// <typeparam name="T">Real Type</typeparam>
		/// <param name="a">Vector frequency domain</param>
		/// <param name="withoutUnc">Without uncertainties</param>
		/// <returns>Vector time domain</returns>
		// Token: 0x060000C4 RID: 196 RVA: 0x00006A4C File Offset: 0x00004C4C
		public static Complex<T>[] Ifft<T>(Complex<T>[] a, bool withoutUnc = false) where T : IRealNumber<T>, new()
		{
			int i = a.Length;
			if (withoutUnc)
			{
				ComplexDouble[] a2 = new ComplexDouble[i];
				for (int j = 0; j < i; j++)
				{
					a2[j] = new ComplexDouble(a[j].real.Value, a[j].imag.Value);
				}
				ComplexDouble[] b2 = MKL.IFFT(a2);
				Complex<T>[] b3 = new Complex<T>[i];
				for (int k = 0; k < i; k++)
				{
					b3[k] = default(Complex<T>);
					b3[k].InitDblReIm(b2[k].real, b2[k].imag);
				}
				return b3;
			}
			Complex<T> temp = default(Complex<T>);
			temp.InitDbl((double)i);
			Complex<T>[] a3 = new Complex<T>[i];
			for (int l = 0; l < i; l++)
			{
				a3[l] = a[l].Conj();
			}
			Complex<T>[] b4 = NumLib.Fft<T>(a3, false);
			Complex<T>[] b5 = new Complex<T>[i];
			for (int m = 0; m < i; m++)
			{
				b5[m] = b4[m].Conj().Divide(temp);
			}
			return b5;
		}

		/// <summary>
		/// Internal Fast Fourier transform.
		/// </summary>
		/// <typeparam name="T">Real Type</typeparam>
		/// <param name="a">Vector time domain</param>
		/// <returns>Vector frequency domain</returns>
		// Token: 0x060000C5 RID: 197 RVA: 0x00006B94 File Offset: 0x00004D94
		private static Complex<T>[] Fft2<T>(Complex<T>[] a) where T : IRealNumber<T>, new()
		{
			int i = a.Length;
			if (i == 1)
			{
				return a;
			}
			int n2 = i / 2;
			Complex<T>[] f0 = new Complex<T>[n2];
			Complex<T>[] f = new Complex<T>[n2];
			for (int j = 0; j < n2; j++)
			{
				f0[j] = a[2 * j];
				f[j] = a[2 * j + 1];
			}
			Complex<T>[] g = NumLib.Fft2<T>(f0);
			Complex<T>[] u = NumLib.Fft2<T>(f);
			Complex<T>[] c = new Complex<T>[i];
			double temp = -6.283185307179586 / (double)i;
			Complex<T> temp2 = default(Complex<T>);
			Complex<T> temp3 = default(Complex<T>);
			for (int k = 0; k < n2; k++)
			{
				temp2.InitDblReIm(0.0, temp * (double)k);
				temp3 = u[k].Multiply(temp2.Exp());
				c[k] = g[k].Add(temp3);
				c[k + n2] = g[k].Subtract(temp3);
			}
			return c;
		}

		/// <summary>
		/// Internal Chirp Z-Transform (or Bluestein's algorithm)
		/// Computes an arbitrary-length DFT with the chirp z transform algorithm.
		/// The linear convolution then required is done with FFTs.
		/// </summary>
		/// <typeparam name="T">Real Type</typeparam>
		/// <param name="a">Vector time domain</param>
		/// <returns>Vector frequency domain</returns>
		// Token: 0x060000C6 RID: 198 RVA: 0x00006C9C File Offset: 0x00004E9C
		private static Complex<T>[] Chirp<T>(Complex<T>[] a) where T : IRealNumber<T>, new()
		{
			int i = a.Length;
			int j = (int)System.Math.Pow(2.0, System.Math.Ceiling(System.Math.Log((double)(2 * i - 1)) / System.Math.Log(2.0)));
			int l2 = j - 2 * i + 1;
			Complex<T> zero = default(Complex<T>).Zero;
			Complex<T>[] w = new Complex<T>[i];
			for (int k = 0; k < i; k++)
			{
				w[k] = default(Complex<T>);
				w[k].InitDblReIm(0.0, -3.141592653589793 * (double)k * (double)k / (double)i);
				w[k] = w[k].Exp();
			}
			Complex<T>[] w2 = new Complex<T>[j];
			for (int m = 0; m < i; m++)
			{
				w2[m] = w[m].Conj();
			}
			for (int n = 0; n < l2; n++)
			{
				w2[n + i] = zero;
			}
			for (int i2 = 0; i2 < i - 1; i2++)
			{
				w2[i2 + i + l2] = w[i - i2 - 1].Conj();
			}
			Complex<T>[] fw = NumLib.Fft<T>(w2, false);
			Complex<T>[] xw = new Complex<T>[j];
			for (int i3 = 0; i3 < i; i3++)
			{
				xw[i3] = a[i3].Multiply(w[i3]);
			}
			for (int i4 = i; i4 < j; i4++)
			{
				xw[i4] = zero;
			}
			Complex<T>[] temp = NumLib.Fft<T>(xw, false);
			Complex<T>[] temp2 = new Complex<T>[j];
			for (int i5 = 0; i5 < j; i5++)
			{
				temp2[i5] = fw[i5].Multiply(temp[i5]);
			}
			Complex<T>[] y = NumLib.Ifft<T>(temp2, false);
			Complex<T>[] y2 = new Complex<T>[i];
			for (int i6 = 0; i6 < i; i6++)
			{
				y2[i6] = y[i6].Multiply(w[i6]);
			}
			return y2;
		}

		/// <summary>
		/// Internal Discrete Fourier transform.
		/// </summary>
		/// <typeparam name="T">Real Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x060000C7 RID: 199 RVA: 0x00006EBC File Offset: 0x000050BC
		private static Complex<T>[] Dft<T>(Complex<T>[] a) where T : IRealNumber<T>, new()
		{
			int i = a.Length;
			Complex<T>[] b = Array.Zeros1d<Complex<T>>(i);
			double temp = -6.283185307179586 / (double)i;
			Complex<T> temp2 = default(Complex<T>);
			for (int i2 = 0; i2 < i; i2++)
			{
				for (int i3 = 0; i3 < i; i3++)
				{
					temp2.InitDblReIm(0.0, temp * (double)i2 * (double)i3);
					b[i2] = b[i2].Add(a[i3].Multiply(temp2.Exp()));
				}
			}
			return b;
		}

		/// <summary>
		/// Shifts Array to center
		/// 0 1 2 3 --&gt; 2 3 0 1 and
		/// 0 1 2 3 4 --&gt; 3 4 0 1 2
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">Array</param>
		/// <returns></returns>
		// Token: 0x060000C8 RID: 200 RVA: 0x00006F4C File Offset: 0x0000514C
		public static T[] FftShift<T>(T[] a) where T : new()
		{
			int num = (a != null) ? a.Length : 0;
			int n = num / 2;
			int n2 = num - n;
			T[] b = new T[num];
			System.Array.Copy(a, n2, b, 0, n);
			System.Array.Copy(a, 0, b, n, n2);
			return b;
		}

		/// <summary>
		/// Shifts Array to center
		/// 0 1 2 3 --&gt; 2 3 0 1 and
		/// 0 1 2 3 4 --&gt; 3 4 0 1 2
		/// </summary>
		/// <param name="a">Array</param>
		/// <returns></returns>
		// Token: 0x060000C9 RID: 201 RVA: 0x00006F85 File Offset: 0x00005185
		public static double[] FftShift(double[] a)
		{
			return NumLib.FftShift<double>(a);
		}

		/// <summary>
		/// Shifts Array back from center
		/// 2 3 0 1 --&gt; 0 1 2 3 and
		/// 3 4 0 1 2 --&gt; 0 1 2 3 4
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">Array</param>
		/// <returns></returns>
		// Token: 0x060000CA RID: 202 RVA: 0x00006F90 File Offset: 0x00005190
		public static T[] IfftShift<T>(T[] a) where T : new()
		{
			int num = (a != null) ? a.Length : 0;
			int n = num / 2;
			int n2 = num - n;
			T[] b = new T[num];
			System.Array.Copy(a, 0, b, n2, n);
			System.Array.Copy(a, n, b, 0, n2);
			return b;
		}

		/// <summary>
		/// Shifts Array back from center
		/// 2 3 0 1 --&gt; 0 1 2 3 and
		/// 3 4 0 1 2 --&gt; 0 1 2 3 4
		/// </summary>
		/// <param name="a">Array</param>
		/// <returns></returns>
		// Token: 0x060000CB RID: 203 RVA: 0x00006FC9 File Offset: 0x000051C9
		public static double[] IfftShift(double[] a)
		{
			return NumLib.IfftShift<double>(a);
		}
	}
}
