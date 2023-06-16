using System;

namespace Nuvo.Math.Interface
{
	/// <summary>
	/// Base Arithmetic Interface.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IArithmetic<T>
	{
		/// <summary>
		/// Returns the sum of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the sum</returns>
		T Add(T b);

		/// <summary>
		/// Returns the difference of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the difference</returns>
		T Subtract(T b);

		/// <summary>
		/// Returns the negative of the object.
		/// </summary>
		/// <returns>The negative</returns>
		T Negative();

		/// <summary>
		/// Returns the product of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the product</returns>
		T Multiply(T b);

		/// <summary>
		/// Returns the quotient of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the quotient</returns>
		T Divide(T b);
	}
}
