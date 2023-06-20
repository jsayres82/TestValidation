using System;

namespace Nuvo.Math.Interface
{
    /// <summary>
    /// Array Arithmetic Interface.
    /// </summary>
    /// <typeparam name="T">Array Type</typeparam>
    /// <typeparam name="O">Element Type</typeparam>
    public interface IArrayArithmetic<T, O> : IArithmetic<T>
    {
		/// <summary>
		/// Returns the sum of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the sum</returns>
		T LAdd(O b);

		/// <summary>
		/// Returns the difference of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the difference</returns>
		T LSubtract(O b);

		/// <summary>
		/// Returns the product of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the product</returns>
		T LMultiply(O b);

		/// <summary>
		/// Returns the quotient of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the quotient</returns>
		T LDivide(O b);

		/// <summary>
		/// Returns the sum of <paramref name="a" /> and the object.
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns>the sum</returns>
		T RAdd(O a);

		/// <summary>
		/// Returns the difference of <paramref name="a" /> and the object.
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns>the difference</returns>
		T RSubtract(O a);

		/// <summary>
		/// Returns the product of the <paramref name="a" /> and the object.
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns>the product</returns>
		T RMultiply(O a);

		/// <summary>
		/// Returns the quotient of the <paramref name="a" /> and the object.
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns>the quotient</returns>
		T RDivide(O a);
	}
}
