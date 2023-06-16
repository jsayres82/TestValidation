using System;

namespace Nuvo.Math.Interface
{
	/// <summary>
	/// Interface Complex Number.
	/// </summary>
	/// <typeparam name="T1">Complex Type</typeparam>
	/// <typeparam name="T2">Real Type</typeparam>
	public interface IComplexNumber<T1, T2> where T1 : IComplexNumber<T1, T2> where T2 : IRealNumber<T2>
	{
		/// <summary>
		/// Initializes a Complex Number.
		/// </summary>
		/// <param name="real">Real Part</param>
		/// <param name="imag">Imaginary Part</param>
		void InitReIm(T2 real, T2 imag);

		/// <summary>
		/// Initializes a Complex Number with Imaginary Part = 0.
		/// </summary>
		/// <param name="real">Real part</param>
		void InitRe(T2 real);

		/// <summary>
		/// Initializes a Complex Number.
		/// </summary>
		/// <param name="mag">Magnitude</param>
		/// <param name="phase">Phase</param>
		void InitMagPhase(T2 mag, T2 phase);

		/// <summary>
		/// Initializes a Complex Number.
		/// </summary>
		/// <param name="real">Real Part</param>
		/// <param name="imag">Imaginary Part</param>
		void InitDblReIm(double real, double imag);

		/// <summary>
		/// Returns the real value (expected value).
		/// </summary>
		/// <returns></returns>
		double DblRealValue();

		/// <summary>
		/// Returns the imaginary value (expected value).
		/// </summary>
		/// <returns></returns>
		double DblImagValue();

		/// <summary>
		/// Returns the real expected value.
		/// </summary>
		/// <returns></returns>
		double DblRealExpValue();

		/// <summary>
		/// Returns the imaginary expected value.
		/// </summary>
		/// <returns></returns>
		double DblImagExpValue();

		/// <summary>
		/// Returns the real function value.
		/// </summary>
		/// <returns></returns>
		double DblRealFcnValue();

		/// <summary>
		/// Returns the imaginary function value.
		/// </summary>
		/// <returns></returns>
		double DblImagFcnValue();
	}
}
