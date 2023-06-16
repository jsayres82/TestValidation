using System;
using Nuvo.Math.Core.Interface;

namespace Nuvo.Math.Core.Unc.Interface
{
	/// <summary>
	/// Interface Real Unc Number.
	/// </summary>
	/// <typeparam name="T">Real Unc Type</typeparam>
	// Token: 0x02000026 RID: 38
	public interface IRealUncNumber<T> : IRealNumber<T>, INumber<T>, IConsole, IStorage<T>, Nuvo.Math.Core.Interface.IComparable, IElementArithmetic<T>, IArithmetic<T>, IMath<T>, IRealMath<T> where T : IRealUncNumber<T>
	{
		/// <summary>
		/// Initializes a Real Unc Number (Value = 0, StdUnc = 1, IDof = 0)
		/// </summary>
		/// <param name="id">Input Id</param>
		// Token: 0x0600020B RID: 523
		void Init(InputId id);

		/// <summary>
		/// Initializes a Real Unc Number
		/// </summary>
		/// <param name="value">Value</param>
		/// <param name="stdunc">Standard Uncertainty</param>
		/// <param name="idof">Inverse of Dof (Degrees of Freedom)</param>
		/// <param name="id">Input Id</param>
		/// <param name="desc">Description</param>
		// Token: 0x0600020C RID: 524
		void Init(double value, double stdunc, double idof, InputId id, string desc);

		/// <summary>
		/// Initializes a Real Unc Number
		/// </summary>
		/// <param name="value">Value</param>
		/// <param name="stdunc">Standard Uncertainty</param>
		/// <param name="idof">Inverse of Dof (Degrees of Freedom)</param>
		/// <param name="id">Input Id</param>
		// Token: 0x0600020D RID: 525
		void Init(double value, double stdunc, double idof, InputId id);

		/// <summary>
		/// Initializes a Real Unc Number
		/// </summary>
		/// <param name="value">Value</param>
		/// <param name="stdunc">Standard Uncertainty</param>
		/// <param name="idof">Inverse of Dof (Degrees of Freedom)</param>
		// Token: 0x0600020E RID: 526
		void Init(double value, double stdunc, double idof);

		/// <summary>
		/// Initializes a Real Unc Number
		/// </summary>
		/// <param name="value">Value</param>
		/// <param name="stdunc">Standard Uncertainty</param>
		// Token: 0x0600020F RID: 527
		void Init(double value, double stdunc);

		/// <summary>
		/// Initializes a Real Unc Number with Standard Uncertainty = 0
		/// </summary>
		/// <param name="value">Value</param>
		// Token: 0x06000210 RID: 528
		void Init(double value);
	}
}
