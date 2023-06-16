using System;

namespace Nuvo.Math.Interface
{
	/// <summary>
	/// Real Math Interface.
	/// </summary>
	/// <typeparam name="T">Real Type</typeparam>
	// Token: 0x02000018 RID: 24
	public interface IRealMath<T> : IMath<T>
	{
		/// <summary>
		/// Returns the absolute value.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000158 RID: 344
		T Abs();

		/// <summary>
		/// Returns a value indicating the sign of a number.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000159 RID: 345
		T Sign();

		/// <summary>
		/// Returns the angle whose tangent is the quotient of two specified numbers.
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		// Token: 0x0600015A RID: 346
		T Atan2(T b);

		/// <summary>
		/// Complex division
		/// </summary>
		/// <param name="_b">Numerator imag part</param>
		/// <param name="_c">Denominator real part</param>
		/// <param name="_d">Denominator imag part</param>
		/// <param name="_f">Result imag part</param>
		/// <returns>Result real part</returns>
		// Token: 0x0600015B RID: 347
		T ComplexDivision(T _b, T _c, T _d, out T _f);

		/// <summary>
		/// Complex absolute value
		/// </summary>
		/// <param name="_b">Imag part</param>
		/// <returns></returns>
		// Token: 0x0600015C RID: 348
		T ComplexAbs(T _b);
	}
}
