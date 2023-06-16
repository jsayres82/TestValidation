using System;
using Nuvo.Math.Interface;

namespace Nuvo.Math.Ndims.Interface
{
	/// <summary>
	/// Interface Complex Array.
	/// </summary>
	/// <typeparam name="T1">Complex Array Type</typeparam>
	/// <typeparam name="T2">Real Array Type</typeparam>
	/// <typeparam name="D1">Complex Element Type</typeparam>
	/// <typeparam name="D2">Real Element Type</typeparam>
	public interface IComplexNArray<T1, T2, D1, D2> : INArray<T2, D2>, IConsole, IStorage<D2>, IArrayArithmetic<T2, D2>, IArithmetic<D2>, IArrayMath<T2, D2>, IMath<D2>, IArrayComplexMath<T1, T2, D1, D2>, IComplexMath<D1, D2> where T1 : IComplexNArray<T1, T2, D1, D2> where T2 : IRealNArray<T2, D2> where D1 : IComplexNumber<D1, D2> where D2 : IRealNumber<D2>
	{
		/// <summary>
		/// Initializes a Complex Array
		/// </summary>
		/// <param name="real">Real Part</param>
		/// <param name="imag">Imaginary Part</param>
		void InitReIm(T2 real, T2 imag);

		/// <summary>
		/// Initializes a Complex Array with all Imaginary Parts = 0
		/// </summary>
		/// <param name="real">Real Part</param>
		void InitRe(T2 real);

		/// <summary>
		/// Initializes a Complex Array.
		/// </summary>
		/// <param name="real">Real Part</param>
		/// <param name="imag">Imaginary Part</param>
		void InitDblReIm(double[] real, double[] imag);

		/// <summary>
		/// Returns the real value.
		/// </summary>
		/// <returns></returns>
		double[] DblRealValue();

		/// <summary>
		/// Returns the imaginary value.
		/// </summary>
		/// <returns></returns>
		double[] DblImagValue();

		/// <summary>
		/// Complex conjugate transpose 2D-Array (Matrix)
		/// </summary>
		/// <returns></returns>
		T1 CTranspose();
	}
}
