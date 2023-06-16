using System;
using Nuvo.Math.Interface;
using Nuvo.Math.Ndims.Interface;

namespace Nuvo.Math.Ndims
{
	/// <summary>
	/// Generic Numeric Library
	/// </summary>
	/// <typeparam name="T">Array Type</typeparam>
	/// <typeparam name="D">Element Type</typeparam>
	public class NumLib<T, D> where T : INArray<T, D>, new() where D : INumber<D>, new()
	{
		/// <summary>
		/// Fit polynomial to data
		/// </summary>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Polynom Order: 0 to Number of Points - 1</param>
		/// <returns>Polynomial coefficients in descending powers</returns>
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
