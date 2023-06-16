using System;

namespace Nuvo.Math.Core.Interface
{
	/// <summary>
	/// Interface Real Number.
	/// </summary>
	/// <typeparam name="T">Real Type</typeparam>
	// Token: 0x0200001E RID: 30
	public interface IRealNumber<T> : INumber<T>, IConsole, IStorage<T>, IComparable, IElementArithmetic<T>, IArithmetic<T>, IMath<T>, IRealMath<T> where T : IRealNumber<T>
	{
		/// <summary>
		/// Value (Expected Value)
		/// </summary>
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600016A RID: 362
		double Value { get; }

		/// <summary>
		/// Expected Value
		/// </summary>
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600016B RID: 363
		double ExpValue { get; }

		/// <summary>
		/// Function Value
		/// </summary>
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600016C RID: 364
		double FcnValue { get; }

		/// <summary>
		/// Returns true if it's a Const
		/// </summary>
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600016D RID: 365
		bool IsConst { get; }

		/// <summary>
		/// Computes the Standard Uncertainty
		/// </summary>
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600016E RID: 366
		double StdUnc { get; }

		/// <summary>
		/// Computes the Inverse of the Degrees of Freedom
		/// </summary>
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600016F RID: 367
		double IDof { get; }

		/// <summary>
		/// Computes the n-th Central Moment
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		// Token: 0x06000170 RID: 368
		double GetMoment(int n);

		/// <summary>
		/// Computes the Coverage Interval
		/// </summary>
		/// <param name="p">Probability</param>
		/// <returns></returns>
		// Token: 0x06000171 RID: 369
		double[] GetCoverageInterval(double p);
	}
}
