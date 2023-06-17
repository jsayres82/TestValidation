using System;
using Nuvo.Math.Interface;

namespace Nuvo.Math.Ndims
{
	/// <summary>
	/// Generic Complex Numeric Library
	/// </summary>
	/// <typeparam name="D">Real Element Type</typeparam>
	public class ComplexNumLib<T,D> : NumLib<ComplexNArray<T,D>, Complex<D>> where D : IRealNumber<D>, new()
	{
		/// <summary>
		/// Interpolation with linear uncertainty interpolation
		/// </summary>
		/// <param name="x">X Values</param>
		/// <param name="y">Y Values</param>
		/// <param name="n">Interpolation Order: 1 to Number of Points - 1</param>
		/// <param name="xx">XX Value</param>
		/// <returns>YY Value</returns>
		public static Complex<T> Interpolation2(double[] x, ComplexNArray<Complex<T>,D> y, int n, double xx)
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
		public static ComplexNArray<Complex<T>,D>Interpolation2(double[] x, ComplexNArray<Complex<T>,D>y, int n, double[] xx)
		{
			if (!(y.IsColVector | y.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			ComplexNArray<Complex<T>,D>complexNArray = new ComplexNArray<T>();
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
		public static ComplexNArray<Complex<D>,D>InterpolationMagPhase2(double[] x, ComplexNArray<Complex<D>,D>y, int n, double[] xx)
		{
			if (!(y.IsColVector | y.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			ComplexNArray<Complex<T>,D>complexNArray = new ComplexNArray<T>();
			complexNArray.Init1dData(NumLib.InterpolationMagPhase2<T>(x, y.data, n, xx));
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
		public static ComplexNArray<Complex<T>,D>SplineInterpolation2(double[] x, ComplexNArray<Complex<T>, D> y, double[] xx, SplineBoundary startBoundary = SplineBoundary.Natural_Spline, Complex<T> startDerivativeValue = default(Complex<D>), SplineBoundary endBoundary = SplineBoundary.Natural_Spline, Complex<T> endDerivativeValue = default(Complex<T>))
		{
			if (!(y.IsColVector | y.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			ComplexNArray<Complex<T>, D> complexNArray = new ComplexNArray<Complex<T>,D>();
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
		public static ComplexNArray<Complex<T>, D> SplineInterpolationMagPhase2(double[] x, ComplexNArray<Complex<D>, D> y, double[] xx, SplineBoundary startBoundary = SplineBoundary.Natural_Spline, Complex<T> startDerivativeValue = default(Complex<T>), SplineBoundary endBoundary = SplineBoundary.Natural_Spline, Complex<D> endDerivativeValue = default(Complex<T>))
		{
			if (!(y.IsColVector | y.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			ComplexNArray<Complex<T>, D> complexNArray = new ComplexNArray<Complex<T>, D>();
			complexNArray.Init1dData(NumLib.SplineInterpolationMagPhase2<D>(x, y.data, xx, startBoundary, startDerivativeValue, endBoundary, endDerivativeValue));
			return complexNArray;
		}

		/// <summary>
		/// Fast Fourier transform
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static ComplexNArray<Complex<T>, D> Fft(ComplexNArray<Complex<T>, D> a)
		{
			if (!(a.IsColVector | a.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			int i = a.numel;
			ComplexNArray<Complex<T>, D> complexNArray = new ComplexNArray<Complex<T>, D>();
			complexNArray.Init1d(i);
			complexNArray.data = NumLib.Fft<D>(a.data, false);
			return complexNArray;
		}

		/// <summary>
		/// Inverse Fast Fourier transform
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static ComplexNArray<Complex<T>,D>Ifft(ComplexNArray<Complex<T>,D> a)
		{
			if (!(a.IsColVector | a.IsRowVector))
			{
				throw new Exception("Array must be a vector");
			}
			int i = a.numel;
			ComplexNArray<Complex<T>, D> complexNArray = new ComplexNArray<Complex<T>, D>();
			complexNArray.Init1d(i);
			complexNArray.data = NumLib.Ifft<D>(a.data, false);
			return complexNArray;
		}
	}
}
