using System;

namespace Nuvo.Math.Core.Unc.Interface
{
	/// <summary>
	/// Interface Uncertainty List
	/// </summary>
	/// <typeparam name="T">Real Unc Type</typeparam>
	// Token: 0x02000025 RID: 37
	public interface IUncList<T> where T : IRealUncNumber<T>
	{
		/// <summary>
		/// Flat Uncertainty Array
		/// </summary>
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000205 RID: 517
		// (set) Token: 0x06000206 RID: 518
		T[] data { get; set; }

		/// <summary>
		/// Computes the Covariance Matrix of an Uncertainty Object.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000207 RID: 519
		Number[][] GetCovariance();

		/// <summary>
		/// Returns the Jacobi Matrix of an Uncertainty Object.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000208 RID: 520
		Number[][] GetJacobi();

		/// <summary>
		/// Computes the Sensitivities to intermediate steps.
		/// </summary>
		/// <param name="other">Intermediate Result Uncertainty Object</param>
		/// <returns></returns>
		// Token: 0x06000209 RID: 521
		Number[][] GetJacobi2(IUncList<T> other);

		/// <summary>
		/// Computes the Uncertainty Components.
		/// </summary>
		/// <param name="other">Intermediate Result Uncertainty Object</param>
		/// <returns></returns>
		// Token: 0x0600020A RID: 522
		Number[][] GetUncComponent(IUncList<T> other);
	}
}
