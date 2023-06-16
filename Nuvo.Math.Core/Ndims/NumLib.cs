using System;
using Nuvo.Math.Core.Interface;
using Nuvo.Math.Core.Ndims.Interface;

namespace Nuvo.Math.Core.Ndims
{
	/// <summary>
	/// Generic Numeric Library
	/// </summary>
	/// <typeparam name="T">Array Type</typeparam>
	/// <typeparam name="D">Element Type</typeparam>
	// Token: 0x02000041 RID: 65
	public class NumLib<T, D> where T : INArray<T, D>, new() where D : INumber<D>, new()
	{
		/// <summary>
		/// Fit polynomial to data
		/// </summary>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Polynom Order: 0 to Number of Points - 1</param>
		/// <returns>Polynomial coefficients in descending powers</returns>
		// Token: 0x06000319 RID: 793 RVA: 0x0000E690 File Offset: 0x0000C890
		public static T PolyFit(T x, T y, int n)
		{
			if (!(x.IsColVector | x.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			if (!(y.IsColVector | y.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			T p = Activator.CreateInstance<T>();
			p.Init1dData(NumLib.PolyFit<D>(x.data, y.data, n));
			return p;
		}

		/// <summary>
		/// Evaluate polynomial
		/// </summary>
		/// <param name="p">Polynomial coefficients in descending powers</param>
		/// <param name="x">X-Value</param>
		/// <returns>Y-Value</returns>
		// Token: 0x0600031A RID: 794 RVA: 0x0000E721 File Offset: 0x0000C921
		public static D PolyVal(T p, D x)
		{
			if (!(p.IsColVector | p.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			return NumLib.PolyVal<D>(p.data, x);
		}

		/// <summary>
		/// Evaluate polynomial
		/// </summary>
		/// <param name="p">Polynomial coefficients in descending powers</param>
		/// <param name="x">X-Values</param>
		/// <returns>Y-Values</returns>
		// Token: 0x0600031B RID: 795 RVA: 0x0000E760 File Offset: 0x0000C960
		public static T PolyVal(T p, T x)
		{
			if (!(p.IsColVector | p.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			if (!(x.IsColVector | x.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			T y = Activator.CreateInstance<T>();
			y.Init1dData(NumLib.PolyVal<D>(p.data, x.data));
			return y;
		}

		/// <summary>
		/// Interpolation
		/// </summary>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Interpolation Order: 1 to Number of Points - 1</param>
		/// <param name="xx">XX Value</param>
		/// <returns>YY Value</returns>
		// Token: 0x0600031C RID: 796 RVA: 0x0000E7F0 File Offset: 0x0000C9F0
		public static D Interpolation(double[] x, T y, int n, double xx)
		{
			if (!(y.IsColVector | y.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			return NumLib.Interpolation<D>(x, y.data, n, xx);
		}

		/// <summary>
		/// Interpolation
		/// </summary>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Interpolation Order: 1 to Number of Points - 1</param>
		/// <param name="xx">XX Values</param>
		/// <returns>YY Values</returns>
		// Token: 0x0600031D RID: 797 RVA: 0x0000E830 File Offset: 0x0000CA30
		public static T Interpolation(double[] x, T y, int n, double[] xx)
		{
			if (!(y.IsColVector | y.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			T yy = Activator.CreateInstance<T>();
			yy.Init1dData(NumLib.Interpolation<D>(x, y.data, n, xx));
			return yy;
		}

		/// <summary>
		/// Spline interpolation
		/// </summary>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="xx">XX Values</param>
		/// <param name="startBoundary">Start Boundary</param>
		/// <param name="startDerivativeValue">Start Derivative Value</param>
		/// <param name="endBoundary">End Boundary</param>
		/// <param name="endDerivativeValue">End Derivative Value</param>
		/// <returns>YY Values</returns>
		// Token: 0x0600031E RID: 798 RVA: 0x0000E890 File Offset: 0x0000CA90
		public static T SplineInterpolation(double[] x, T y, double[] xx, SplineBoundary startBoundary = SplineBoundary.Natural_Spline, D startDerivativeValue = default(D), SplineBoundary endBoundary = SplineBoundary.Natural_Spline, D endDerivativeValue = default(D))
		{
			if (!(y.IsColVector | y.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			T yy = Activator.CreateInstance<T>();
			yy.Init1dData(NumLib.SplineInterpolation<D>(x, y.data, xx, startBoundary, startDerivativeValue, endBoundary, endDerivativeValue));
			return yy;
		}

		/// <summary>
		/// Spline coefs
		/// </summary>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="startBoundary">Start Boundary</param>
		/// <param name="startDerivativeValue">Start Derivative Value</param>
		/// <param name="endBoundary">End Boundary</param>
		/// <param name="endDerivativeValue">End Derivative Value</param>
		/// <returns>Spline Coefs</returns>
		// Token: 0x0600031F RID: 799 RVA: 0x0000E8F4 File Offset: 0x0000CAF4
		public static T SplineCoefs(double[] x, T y, SplineBoundary startBoundary = SplineBoundary.Natural_Spline, D startDerivativeValue = default(D), SplineBoundary endBoundary = SplineBoundary.Natural_Spline, D endDerivativeValue = default(D))
		{
			if (!(y.IsColVector | y.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			T yy = Activator.CreateInstance<T>();
			yy.Init2dData(NumLib.SplineCoefs<D>(x, y.data, startBoundary, startDerivativeValue, endBoundary, endDerivativeValue));
			return yy;
		}

		/// <summary>
		/// Integrate
		/// </summary>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Order</param>
		/// <returns>Integral</returns>
		// Token: 0x06000320 RID: 800 RVA: 0x0000E958 File Offset: 0x0000CB58
		public static T Integrate(double[] x, T y, int n)
		{
			if (!(y.IsColVector | y.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			T a = Activator.CreateInstance<T>();
			a.Init1dData(NumLib.Integrate<D>(x, y.data, n));
			return a;
		}

		/// <summary>
		/// Integrate
		/// </summary>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Order</param>
		/// <returns>Integral</returns>
		// Token: 0x06000321 RID: 801 RVA: 0x0000E9B5 File Offset: 0x0000CBB5
		public static D Integrate2(double[] x, T y, int n)
		{
			if (!(y.IsColVector | y.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			return NumLib.Integrate2<D>(x, y.data, n);
		}

		/// <summary>
		/// Spline integrate
		/// </summary>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="startBoundary">Start Boundary</param>
		/// <param name="startDerivativeValue">Start Derivative Value</param>
		/// <param name="endBoundary">End Boundary</param>
		/// <param name="endDerivativeValue">End Derivative Value</param>
		/// <returns>Integral</returns>
		// Token: 0x06000322 RID: 802 RVA: 0x0000E9F4 File Offset: 0x0000CBF4
		public static T SplineIntegrate(double[] x, T y, SplineBoundary startBoundary = SplineBoundary.Natural_Spline, D startDerivativeValue = default(D), SplineBoundary endBoundary = SplineBoundary.Natural_Spline, D endDerivativeValue = default(D))
		{
			if (!(y.IsColVector | y.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			T a = Activator.CreateInstance<T>();
			a.Init1dData(NumLib.SplineIntegrate<D>(x, y.data, startBoundary, startDerivativeValue, endBoundary, endDerivativeValue));
			return a;
		}

		/// <summary>
		/// Spline integrate
		/// </summary>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="startBoundary">Start Boundary</param>
		/// <param name="startDerivativeValue">Start Derivative Value</param>
		/// <param name="endBoundary">End Boundary</param>
		/// <param name="endDerivativeValue">End Derivative Value</param>
		/// <returns>Integral</returns>
		// Token: 0x06000323 RID: 803 RVA: 0x0000EA58 File Offset: 0x0000CC58
		public static D SplineIntegrate2(double[] x, T y, SplineBoundary startBoundary = SplineBoundary.Natural_Spline, D startDerivativeValue = default(D), SplineBoundary endBoundary = SplineBoundary.Natural_Spline, D endDerivativeValue = default(D))
		{
			if (!(y.IsColVector | y.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			return NumLib.SplineIntegrate2<D>(x, y.data, startBoundary, startDerivativeValue, endBoundary, endDerivativeValue);
		}
	}
}
