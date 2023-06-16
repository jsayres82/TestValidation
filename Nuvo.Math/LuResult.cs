using System;

namespace Nuvo.Math
{
	/// <summary>
	/// Generic LU Decompostion Result
	/// </summary>
	/// <typeparam name="T">Data Type</typeparam>
	public struct LuResult<T>
	{
		/// <summary>
		/// Lower Matrix
		/// </summary>
		public T[][] l { get; set; }

		/// <summary>
		/// Upper Matrix
		/// </summary>
		public T[][] u { get; set; }

		/// <summary>
		/// Permutation Matrix
		/// </summary>
		public T[][] p { get; set; }

		/// <summary>
		/// Row Indices
		/// </summary>
		public int[] c { get; set; }

		/// <summary>
		/// Interchange row count
		/// </summary>
		public int d { get; set; }
	}
}
