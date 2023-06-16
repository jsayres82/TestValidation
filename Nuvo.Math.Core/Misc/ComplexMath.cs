using System;
using Nuvo.Math.Core.Interface;

namespace Nuvo.Math.Core.Misc
{
	/// <summary>
	/// Static Complex Math Class.
	/// </summary>
	/// <typeparam name="T1">Complex Type</typeparam>
	/// <typeparam name="T2">Real Type</typeparam>
	// Token: 0x0200000F RID: 15
	internal class ComplexMath<T1, T2> where T1 : IArithmetic<T2>, IComplexMath<T1, T2> where T2 : IArithmetic<T2>, IRealMath<T2>
	{
		/// <summary>
		/// Returns the real part.
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x06000121 RID: 289 RVA: 0x000074FF File Offset: 0x000056FF
		public static T2 Real(T1 a)
		{
			return a.Real();
		}

		/// <summary>
		/// Returns the imaginary part.
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x06000122 RID: 290 RVA: 0x0000750E File Offset: 0x0000570E
		public static T2 Imag(T1 a)
		{
			return a.Imag();
		}

		/// <summary>
		/// Returns the absolute value.
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x06000123 RID: 291 RVA: 0x0000751D File Offset: 0x0000571D
		public static T2 Abs(T1 a)
		{
			return a.Abs();
		}

		/// <summary>
		/// Returns the angle.
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x06000124 RID: 292 RVA: 0x0000752C File Offset: 0x0000572C
		public static T2 Angle(T1 a)
		{
			return a.Angle();
		}
	}
}
