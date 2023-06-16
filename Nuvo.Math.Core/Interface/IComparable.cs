using System;

namespace Nuvo.Math.Core.Interface
{
	/// <summary>
	/// Comparable Interface.
	/// </summary>
	// Token: 0x02000015 RID: 21
	public interface IComparable
	{
		/// <summary>
		/// Returns true if the Value of an Object is equal to zero.
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600013F RID: 319
		bool IsZero();

		/// <summary>
		/// Returns true if the Value of an Object is not equal to zero.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000140 RID: 320
		bool IsNotZero();
	}
}
