using System;
using Nuvo.Math.Interface;

namespace Nuvo.Math.Ndims.Interface
{
    /// <summary>
    /// Interface Real Array.
    /// </summary>
    /// <typeparam name="T">Real Array Type</typeparam>
    /// <typeparam name="D">Real Element Type</typeparam>
    public interface IRealNArray<T, D> : INArray<T, D>, IConsole, IStorage<T>, IArrayArithmetic<T, D>, IArithmetic<T>, IArrayMath<T, D>, IMath<T>, IArrayRealMath<T, D>, IRealMath<T> where T : IRealNArray<T, D> where D : IRealNumber<D>
    {
        /// <summary>
        /// Returns the value.
        /// </summary>
        /// <returns></returns>
        double[] DblValue();
	}
}
