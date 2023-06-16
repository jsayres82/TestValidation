using System;

namespace Nuvo.Math.Core
{
	/// <summary>
	/// Spline Boundary
	/// </summary>
	// Token: 0x02000008 RID: 8
	public enum SplineBoundary
	{
		/// <summary>
		/// Natural Spline (Default)
		/// </summary>
		// Token: 0x04000009 RID: 9
		Natural_Spline,
		/// <summary>
		/// Not a Knot
		/// </summary>
		// Token: 0x0400000A RID: 10
		Not_a_Knot,
		/// <summary>
		/// 1st Derivative
		/// </summary>
		// Token: 0x0400000B RID: 11
		First_Derivative,
		/// <summary>
		/// 2nd Derivative
		/// </summary>
		// Token: 0x0400000C RID: 12
		Second_Derivative
	}
}
