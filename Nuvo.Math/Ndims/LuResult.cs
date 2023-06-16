using System;
using Nuvo.Math.Interface;
using Nuvo.Math.Ndims.Interface;

namespace Nuvo.Math.Ndims
{
	/// <summary>
	/// Generic LU Decomposition Result
	/// </summary>
	/// <typeparam name="T">Array Type</typeparam>
	/// <typeparam name="D">Element Type</typeparam>
	public class LuResult<T, D> where T : INArray<T, D>, new() where D : INumber<D>, new()
	{
		/// <summary>
		/// Lower Matrix
		/// </summary>
		public T l { get; set; }

		/// <summary>
		/// Upper Matrix
		/// </summary>
		public T u { get; set; }

		/// <summary>
		/// Permutation Matrix
		/// </summary>
		public T p { get; set; }

		/// <summary>
		/// Interchange row count
		/// </summary>
		public int d { get; set; }
	}
}
