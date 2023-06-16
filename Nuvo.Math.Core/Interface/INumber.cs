using System;

namespace Nuvo.Math.Core.Interface
{
	/// <summary>
	/// Interface Number.
	/// </summary>
	/// <typeparam name="T">Type</typeparam>
	// Token: 0x0200001D RID: 29
	public interface INumber<T> : IConsole, IStorage<T>, IComparable, IElementArithmetic<T>, IArithmetic<T>, IMath<T> where T : INumber<T>
	{
		/// <summary>
		/// Initializes a Number
		/// </summary>
		/// <param name="value"></param>
		// Token: 0x06000167 RID: 359
		void InitDbl(double value);

		/// <summary>
		/// Returns the square function value.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000168 RID: 360
		double DblSqrFcnValue();

		/// <summary>
		/// Returns the function value.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000169 RID: 361
		T FcnValue2();
	}
}
