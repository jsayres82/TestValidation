using System;

namespace Nuvo.Math.Interface
{
	/// <summary>
	/// Array Math Interface.
	/// </summary>
	/// <typeparam name="T">Array Type</typeparam>
	/// <typeparam name="O">Element Type</typeparam>
	public interface IArrayMath<T, O> : IMath<O>
	{
		/// <summary>
		/// Returns the logarithm of a specified number (object) in a specified base (<paramref name="b" />).
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns></returns>
		T LLog(O b);

		/// <summary>
		/// Returns the logarithm of a specified number (<paramref name="a" />) in a specified base (object).
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns></returns>
		T RLog(O a);

		/// <summary>
		/// Returns a specified number (object) raised to the specified power (<paramref name="b" />).
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns></returns>
		T LPow(O b);

		/// <summary>
		/// Returns a specified number (<paramref name="a" />) raised to the specified power (object).
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns></returns>
		T RPow(O a);
	}
}
