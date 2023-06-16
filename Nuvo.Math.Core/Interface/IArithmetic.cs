using System;

namespace Nuvo.Math.Core.Interface
{
	/// <summary>
	/// Base Arithmetic Interface.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	// Token: 0x02000012 RID: 18
	public interface IArithmetic<T>
	{
		/// <summary>
		/// Returns the sum of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the sum</returns>
		// Token: 0x06000130 RID: 304
		T Add(T b);

		/// <summary>
		/// Returns the difference of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the difference</returns>
		// Token: 0x06000131 RID: 305
		T Subtract(T b);

		/// <summary>
		/// Returns the negative of the object.
		/// </summary>
		/// <returns>The negative</returns>
		// Token: 0x06000132 RID: 306
		T Negative();

		/// <summary>
		/// Returns the product of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the product</returns>
		// Token: 0x06000133 RID: 307
		T Multiply(T b);

		/// <summary>
		/// Returns the quotient of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the quotient</returns>
		// Token: 0x06000134 RID: 308
		T Divide(T b);
	}
}
