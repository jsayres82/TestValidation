using System;

namespace Nuvo.Math.Interface
{
	/// <summary>
	/// Math Interface.
	/// </summary>
	/// <typeparam name="T">Type</typeparam>
	public interface IMath<T>
	{
		/// <summary>
		/// Returns e raised to the specified power.
		/// </summary>
		/// <returns></returns>
		T Exp();

		/// <summary>
		/// Returns the natural (base e) logarithm of a specified number.
		/// </summary>
		/// <returns></returns>
		T Log();

		/// <summary>
		/// Returns the logarithm of a specified number in a specified base.
		/// </summary>
		/// <param name="newBase"></param>
		/// <returns></returns>
		T Log(T newBase);

		/// <summary>
		/// Returns the base 10 logarithm of a specified number.
		/// </summary>
		/// <returns></returns>
		T Log10();

		/// <summary>
		/// Returns a specified number raised to the specified power.
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		T Pow(T b);

		/// <summary>
		/// Returns a specified number raised to the specified power.
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		T Pow(int b);

		/// <summary>
		/// Returns the square root of a specified number.
		/// </summary>
		/// <returns></returns>
		T Sqrt();

		/// <summary>
		/// Returns the sine of the specified angle.
		/// </summary>
		/// <returns></returns>
		T Sin();

		/// <summary>
		/// Returns the cosine of the specified angle.
		/// </summary>
		/// <returns></returns>
		T Cos();

		/// <summary>
		/// Returns the tangent of the specified angle.
		/// </summary>
		/// <returns></returns>
		T Tan();

		/// <summary>
		/// Returns the angle whose sine is the specified number.
		/// </summary>
		/// <returns></returns>
		T Asin();

		/// <summary>
		/// Returns the angle whose cosine is the specified number.
		/// </summary>
		/// <returns></returns>
		T Acos();

		/// <summary>
		/// Returns the angle whose tangent is the specified number.
		/// </summary>
		/// <returns></returns>
		T Atan();

		/// <summary>
		/// Returns the hyperbolic sine of the specified angle.
		/// </summary>
		/// <returns></returns>
		T Sinh();

		/// <summary>
		/// Returns the hyperbolic cosine of the specified angle.
		/// </summary>
		/// <returns></returns>
		T Cosh();

		/// <summary>
		/// Returns the hyperbolic tangent of the specified angle.
		/// </summary>
		/// <returns></returns>
		T Tanh();

		/// <summary>
		/// Returns the angle whose hyperbolic sine is the specified number.
		/// </summary>
		/// <returns></returns>
		T Asinh();

		/// <summary>
		/// Returns the angle whose hyperbolic cosine is the specified number.
		/// </summary>
		/// <returns></returns>
		T Acosh();

		/// <summary>
		/// Returns the angle whose hyperbolic tangent is the specified number.
		/// </summary>
		/// <returns></returns>
		T Atanh();

		/// <summary>
		/// Returns the complex conjugate.
		/// </summary>
		/// <returns></returns>
		T Conj();
	}
}
