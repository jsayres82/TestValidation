using System;
using Nuvo.Math.Core.Interface;

namespace Nuvo.Math.Core.Ndims.Interface
{
	/// <summary>
	/// Interface Real Array.
	/// </summary>
	/// <typeparam name="T">Real Array Type</typeparam>
	/// <typeparam name="D">Real Element Type</typeparam>
	// Token: 0x02000045 RID: 69
	public interface IRealNArray<T, D> : INArray<T, D>, IConsole, IStorage<D>, IArrayArithmetic<T, D>, IArithmetic<D>, IArrayMath<T, D>, IMath<D>, IArrayRealMath<T, D>, IRealMath<D> where T : IRealNArray<T, D> where D : IRealNumber<D>
	{
		/// <summary>
		/// Returns the value.
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600036D RID: 877
		double[] DblValue();
	}
}
