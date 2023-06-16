using System;
using Nuvo.Math.Interface;

namespace Nuvo.Math.Ndims
{
	/// <summary>
	/// Generic Complex Numeric Library
	/// </summary>
	/// <typeparam name="D">Real Element Type</typeparam>
	public class ComplexNumLib<D> : NumLib<ComplexNArray<D>, Complex<D>> where D : IRealNumber<D>, new()
	{
		/// <summary>
		/// Interpolation with linear uncertainty interpolation
		/// </summary>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Interpolation Order: 1 to Number of Points - 1</param>
		/// <param name="xx">XX Value</param>
		/// <returns>YY Value</returns>
		public static Complex<D> Interpolation2(double[] x, ComplexNArray<D> y, int n, double xx)
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
		public static ComplexNArray<D> Interpolation2(double[] x, ComplexNArray<D> y, int n, double[] xx)
		{
			if (!(y.IsColVector | y.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			ComplexNArray<D> complexNArray = new ComplexNArray<D>();
			complexNArray.Init1dData(NumLib.Interpolation2<D>(x, y.data, n, xx));
			return complexNArray;
		}

		/// <summary>
		/// Interpolation in mag phase with linear uncertainty interpolation
		/// </summary>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Interpolation Order: 1 to Number of Points - 1</param>
		/// <param name="xx">XX Values</param>
		/// <returns>YY Values</returns>
		public static ComplexNArray<D> InterpolationMagPhase2(double[] x, ComplexNArray<D> y, int n, double[] xx)
		{
			if (!(y.IsColVector | y.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			ComplexNArray<D> complexNArray = new ComplexNArray<D>();
			complexNArray.Init1dData(NumLib.InterpolationMagPhase2<D>(x, y.data, n, xx));
			return complexNArray;
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
		public static ComplexNArray<D> SplineInterpolation2(double[] x, ComplexNArray<D> y, double[] xx, SplineBoundary startBoundary = SplineBoundary.Natural_Spline, Complex<D> startDerivativeValue = default(Complex<D>), SplineBoundary endBoundary = SplineBoundary.Natural_Spline, Complex<D> endDerivativeValue = default(Complex<D>))
		{
			if (!(y.IsColVector | y.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			ComplexNArray<D> complexNArray = new ComplexNArray<D>();
			complexNArray.Init1dData(NumLib.SplineInterpolation2<D>(x, y.data, xx, startBoundary, startDerivativeValue, endBoundary, endDerivativeValue));
			return complexNArray;
		}

		/// <summary>
		/// Spline interpolation in mag phase with linear uncertainty interpolation
		/// </summary>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="xx">XX Values</param>
		/// <param name="startBoundary">Start Boundary</param>
		/// <param name="startDerivativeValue">Start Derivative Value</param>
		/// <param name="endBoundary">End Boundary</param>
		/// <param name="endDerivativeValue">End Derivative Value</param>
		/// <returns>YY Values</returns>
		public static ComplexNArray<D> SplineInterpolationMagPhase2(double[] x, ComplexNArray<D> y, double[] xx, SplineBoundary startBoundary = SplineBoundary.Natural_Spline, Complex<D> startDerivativeValue = default(Complex<D>), SplineBoundary endBoundary = SplineBoundary.Natural_Spline, Complex<D> endDerivativeValue = default(Complex<D>))
		{
			if (!(y.IsColVector | y.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			ComplexNArray<D> complexNArray = new ComplexNArray<D>();
			complexNArray.Init1dData(NumLib.SplineInterpolationMagPhase2<D>(x, y.data, xx, startBoundary, startDerivativeValue, endBoundary, endDerivativeValue));
			return complexNArray;
		}

		/// <summary>
		/// Fast Fourier transform
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static ComplexNArray<D> Fft(ComplexNArray<D> a)
		{
			if (!(a.IsColVector | a.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			int i = a.numel;
			ComplexNArray<D> complexNArray = new ComplexNArray<D>();
			complexNArray.Init1d(i);
			complexNArray.data = NumLib.Fft<D>(a.data, false);
			return complexNArray;
		}

		/// <summary>
		/// Inverse Fast Fourier transform
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static ComplexNArray<D> Ifft(ComplexNArray<D> a)
		{
			if (!(a.IsColVector | a.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			int i = a.numel;
			ComplexNArray<D> complexNArray = new ComplexNArray<D>();
			complexNArray.Init1d(i);
			complexNArray.data = NumLib.Ifft<D>(a.data, false);
			return complexNArray;
		}
	}
}
