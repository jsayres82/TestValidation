using System;

namespace Nuvo.Math
{
	/// <summary>
	/// Spline Boundary
	/// </summary>
	public enum SplineBoundary
	{
		/// <summary>
		/// Natural Spline (Default)
		/// </summary>
		Natural_Spline,
		/// <summary>
		/// Not a Knot
		/// </summary>
		Not_a_Knot,
		/// <summary>
		/// 1st Derivative
		/// </summary>
		First_Derivative,
		/// <summary>
		/// 2nd Derivative
		/// </summary>
		Second_Derivative
	}
}
