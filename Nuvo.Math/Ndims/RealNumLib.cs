using System;
using Nuvo.Math.Interface;

namespace Nuvo.Math.Ndims
{
	/// <summary>
	/// Generic Real Numeric Library
	/// </summary>
	/// <typeparam name="D">Real Element Type</typeparam>
	public class RealNumLib<D> : NumLib<RealNArray<D>, D> where D : IRealNumber<D>, new()
	{
		/// <summary>
		/// Interpolation with linear uncertainty interpolation
		/// </summary>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Interpolation Order: 1 to Number of Points - 1</param>
		/// <param name="xx">XX Value</param>
		/// <returns>YY Value</returns>
		public static D Interpolation2(double[] x, RealNArray<D> y, int n, double xx)
		{
			if (!(y.IsColVector | y.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			return NumLib.Interpolation2<D>(x, y.data, n, xx);
		}

		/// <summary>
		/// Interpolation with linear uncertainty interpolation
		/// </summary>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Interpolation Order: 1 to Number of Points - 1</param>
		/// <param name="xx">XX Values</param>
		/// <returns>YY Values</returns>
		public static RealNArray<D> Interpolation2(double[] x, RealNArray<D> y, int n, double[] xx)
		{
			if (!(y.IsColVector | y.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			RealNArray<D> realNArray = new RealNArray<D>();
			realNArray.Init1dData(NumLib.Interpolation2<D>(x, y.data, n, xx));
			return realNArray;
		}

		/// <summary>
		/// Spline interpolation with linear uncertainty interpolation
		/// </summary>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="xx">XX Values</param>
		/// <param name="startBoundary">Start Boundary</param>
		/// <param name="startDerivativeValue">Start Derivative Value</param>
		/// <param name="endBoundary">End Boundary</param>
		/// <param name="endDerivativeValue">End Derivative Value</param>
		/// <returns>YY Values</returns>
		public static RealNArray<D> SplineInterpolation2(double[] x, RealNArray<D> y, double[] xx, SplineBoundary startBoundary = SplineBoundary.Natural_Spline, D startDerivativeValue = default(D), SplineBoundary endBoundary = SplineBoundary.Natural_Spline, D endDerivativeValue = default(D))
		{
			if (!(y.IsColVector | y.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			RealNArray<D> realNArray = new RealNArray<D>();
			realNArray.Init1dData(NumLib.SplineInterpolation2<D>(x, y.data, xx, startBoundary, startDerivativeValue, endBoundary, endDerivativeValue));
			return realNArray;
		}
	}
}
