using System;

namespace Nuvo.Math.Core.Interface
{
	/// <summary>
	/// Array Arithmetic Interface.
	/// </summary>
	/// <typeparam name="T">Array Type</typeparam>
	/// <typeparam name="O">Element Type</typeparam>
	// Token: 0x02000014 RID: 20
	public interface IArrayArithmetic<T, O> 
	{
		/// <summary>
		/// Returns the sum of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the sum</returns>
		// Token: 0x06000137 RID: 311
		T LAdd(O b);

		/// <summary>
		/// Returns the difference of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the difference</returns>
		// Token: 0x06000138 RID: 312
		T LSubtract(O b);

		/// <summary>
		/// Returns the product of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the product</returns>
		// Token: 0x06000139 RID: 313
		T LMultiply(O b);

		/// <summary>
		/// Returns the quotient of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the quotient</returns>
		// Token: 0x0600013A RID: 314
		T LDivide(O b);

		/// <summary>
		/// Returns the sum of <paramref name="a" /> and the object.
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns>the sum</returns>
		// Token: 0x0600013B RID: 315
		T RAdd(O a);

		/// <summary>
		/// Returns the difference of <paramref name="a" /> and the object.
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns>the difference</returns>
		// Token: 0x0600013C RID: 316
		T RSubtract(O a);

		/// <summary>
		/// Returns the product of the <paramref name="a" /> and the object.
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns>the product</returns>
		// Token: 0x0600013D RID: 317
		T RMultiply(O a);

		/// <summary>
		/// Returns the quotient of the <paramref name="a" /> and the object.
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns>the quotient</returns>
		// Token: 0x0600013E RID: 318
		T RDivide(O a);
	}
}
