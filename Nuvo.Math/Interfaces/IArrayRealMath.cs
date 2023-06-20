using System;

namespace Nuvo.Math.Interface
{
    /// <summary>
    /// Array Real Math Interface.
    /// </summary>
    /// <typeparam name="T">Array Type</typeparam>
    /// <typeparam name="O">Element Type</typeparam>
    public interface IArrayRealMath<T, O> : IArrayMath<T, O>, IMath<T>, IRealMath<T>
    {
        /// <summary>
        /// Returns the angle whose tangent is the quotient of the object and <paramref name="b" />.
        /// </summary>
        /// <param name="b">The second operand</param>
        /// <returns>the angle</returns>
        T LAtan2(O b);

		/// <summary>
		/// Returns the angle whose tangent is the quotient of <paramref name="a" /> and the object.
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns>the angle</returns>
		T RAtan2(O a);
	}
}
