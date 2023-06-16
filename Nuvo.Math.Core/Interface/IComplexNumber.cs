using System;

namespace Nuvo.Math.Core.Interface
{
	/// <summary>
	/// Interface Complex Number.
	/// </summary>
	/// <typeparam name="T1">Complex Type</typeparam>
	/// <typeparam name="T2">Real Type</typeparam>
	// Token: 0x0200001F RID: 31
	public interface IComplexNumber<T1, T2> where T1 : IComplexNumber<T1, T2> where T2 : IRealNumber<T2>
	{
		/// <summary>
		/// Initializes a Complex Number.
		/// </summary>
		/// <param name="real">Real Part</param>
		/// <param name="imag">Imaginary Part</param>
		// Token: 0x06000172 RID: 370
		void InitReIm(T2 real, T2 imag);

		/// <summary>
		/// Initializes a Complex Number with Imaginary Part = 0.
		/// </summary>
		/// <param name="real">Real part</param>
		// Token: 0x06000173 RID: 371
		void InitRe(T2 real);

		/// <summary>
		/// Initializes a Complex Number.
		/// </summary>
		/// <param name="mag">Magnitude</param>
		/// <param name="phase">Phase</param>
		// Token: 0x06000174 RID: 372
		void InitMagPhase(T2 mag, T2 phase);

		/// <summary>
		/// Initializes a Complex Number.
		/// </summary>
		/// <param name="real">Real Part</param>
		/// <param name="imag">Imaginary Part</param>
		// Token: 0x06000175 RID: 373
		void InitDblReIm(double real, double imag);

		/// <summary>
		/// Returns the real value (expected value).
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000176 RID: 374
		double DblRealValue();

		/// <summary>
		/// Returns the imaginary value (expected value).
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000177 RID: 375
		double DblImagValue();

		/// <summary>
		/// Returns the real expected value.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000178 RID: 376
		double DblRealExpValue();

		/// <summary>
		/// Returns the imaginary expected value.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000179 RID: 377
		double DblImagExpValue();

		/// <summary>
		/// Returns the real function value.
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600017A RID: 378
		double DblRealFcnValue();

		/// <summary>
		/// Returns the imaginary function value.
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600017B RID: 379
		double DblImagFcnValue();
	}
}
