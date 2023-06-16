using System;

namespace Nuvo.Math.Core.Interface
{
	/// <summary>
	/// Array Real Math Interface.
	/// </summary>
	/// <typeparam name="T">Array Type</typeparam>
	/// <typeparam name="O">Element Type</typeparam>
	// Token: 0x0200001B RID: 27
	public interface IArrayRealMath<T, O> 
	{
		/// <summary>
		/// Returns the angle whose tangent is the quotient of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the angle</returns>
		// Token: 0x06000165 RID: 357
		T LAtan2(O b);

		/// <summary>
		/// Returns the angle whose tangent is the quotient of <paramref name="a" /> and the object.
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns>the angle</returns>
		// Token: 0x06000166 RID: 358
		T RAtan2(O a);
	}
}
