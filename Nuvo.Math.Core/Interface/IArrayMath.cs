using System;

namespace Nuvo.Math.Core.Interface
{
	/// <summary>
	/// Array Math Interface.
	/// </summary>
	/// <typeparam name="T">Array Type</typeparam>
	/// <typeparam name="O">Element Type</typeparam>
	// Token: 0x0200001A RID: 26
	public interface IArrayMath<T, O> : IMath<O>
	{
		/// <summary>
		/// Returns the logarithm of a specified number (object) in a specified base (<paramref name="b" />).
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns></returns>
		// Token: 0x06000161 RID: 353
		T LLog(O b);

		/// <summary>
		/// Returns the logarithm of a specified number (<paramref name="a" />) in a specified base (object).
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns></returns>
		// Token: 0x06000162 RID: 354
		T RLog(O a);

		/// <summary>
		/// Returns a specified number (object) raised to the specified power (<paramref name="b" />).
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns></returns>
		// Token: 0x06000163 RID: 355
		T LPow(O b);

		/// <summary>
		/// Returns a specified number (<paramref name="a" />) raised to the specified power (object).
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns></returns>
		// Token: 0x06000164 RID: 356
		T RPow(O a);
	}
}
