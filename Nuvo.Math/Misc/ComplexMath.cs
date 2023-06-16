using System;
using Nuvo.Math.Interface;

namespace Nuvo.Math.Misc
{
	/// <summary>
	/// Static Complex Math Class.
	/// </summary>
	/// <typeparam name="T1">Complex Type</typeparam>
	/// <typeparam name="T2">Real Type</typeparam>
	internal class ComplexMath<T1, T2> where T1 : IArithmetic<T2>, IComplexMath<T1, T2> where T2 : IArithmetic<T2>, IRealMath<T2>
	{
		/// <summary>
		/// Returns the real part.
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static T2 Real(T1 a)
		{
			return a.Real();
		}

		/// <summary>
		/// Returns the imaginary part.
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static T2 Imag(T1 a)
		{
			return a.Imag();
		}

		/// <summary>
		/// Returns the absolute value.
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static T2 Abs(T1 a)
		{
			return a.Abs();
		}

		/// <summary>
		/// Returns the angle.
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static T2 Angle(T1 a)
		{
			return a.Angle();
		}
	}
}
