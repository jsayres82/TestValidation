using System;

namespace Nuvo.Math.Interface
{
	/// <summary>
	/// Complex Math Interface.
	/// </summary>
	/// <typeparam name="T1">Complex Type</typeparam>
	/// <typeparam name="T2">Real Type</typeparam>
	// Token: 0x02000019 RID: 25
	public interface IComplexMath<T1, T2>
	{
		/// <summary>
		/// Returns the real part.
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600015D RID: 349
		T2 Real();

		/// <summary>
		/// Returns the imaginary part.
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600015E RID: 350
		T2 Imag();

		/// <summary>
		/// Returns the absolute value.
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600015F RID: 351
		T2 Abs();

		/// <summary>
		/// Returns the angle.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000160 RID: 352
		T2 Angle();
	}
}
