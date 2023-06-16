using System;

namespace Nuvo.Math.Interface
{
	/// <summary>
	/// Real Math Interface.
	/// </summary>
	/// <typeparam name="T">Real Type</typeparam>
	public interface IRealMath<T> : IMath<T>
	{
		/// <summary>
		/// Returns the absolute value.
		/// </summary>
		/// <returns></returns>
		T Abs();

		/// <summary>
		/// Returns a value indicating the sign of a number.
		/// </summary>
		/// <returns></returns>
		T Sign();

		/// <summary>
		/// Returns the angle whose tangent is the quotient of two specified numbers.
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		T Atan2(T b);

		/// <summary>
		/// Complex division
		/// </summary>
		/// <param name="_b">Numerator imag part</param>
		/// <param name="_c">Denominator real part</param>
		/// <param name="_d">Denominator imag part</param>
		/// <param name="_f">Result imag part</param>
		/// <returns>Result real part</returns>
		T ComplexDivision(T _b, T _c, T _d, out T _f);

		/// <summary>
		/// Complex absolute value
		/// </summary>
		/// <param name="_b">Imag part</param>
		/// <returns></returns>
		T ComplexAbs(T _b);
	}
}
