using System;

namespace Nuvo.Math.Interface
{
	/// <summary>
	/// Complex Math Interface.
	/// </summary>
	/// <typeparam name="T1">Complex Type</typeparam>
	/// <typeparam name="T2">Real Type</typeparam>
	public interface IComplexMath<T1, T2>
	{
		/// <summary>
		/// Returns the real part.
		/// </summary>
		/// <returns></returns>
		T2 Real();

		/// <summary>
		/// Returns the imaginary part.
		/// </summary>
		/// <returns></returns>
		T2 Imag();

		/// <summary>
		/// Returns the absolute value.
		/// </summary>
		/// <returns></returns>
		T2 Abs();

		/// <summary>
		/// Returns the angle.
		/// </summary>
		/// <returns></returns>
		T2 Angle();
	}
}
