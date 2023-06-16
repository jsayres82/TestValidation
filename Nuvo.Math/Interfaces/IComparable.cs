using System;

namespace Nuvo.Math.Interface
{
	/// <summary>
	/// Comparable Interface.
	/// </summary>
	public interface IComparable
	{
		/// <summary>
		/// Returns true if the Value of an Object is equal to zero.
		/// </summary>
		/// <returns></returns>
		bool IsZero();

		/// <summary>
		/// Returns true if the Value of an Object is not equal to zero.
		/// </summary>
		/// <returns></returns>
		bool IsNotZero();
	}
}
