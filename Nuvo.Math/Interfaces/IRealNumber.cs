using System;

namespace Nuvo.Math.Interface
{
	/// <summary>
	/// Interface Real Number.
	/// </summary>
	/// <typeparam name="T">Real Type</typeparam>
	public interface IRealNumber<T> : INumber<T>, IConsole, IStorage<T>, IComparable, IElementArithmetic<T>, IArithmetic<T>, IMath<T>, IRealMath<T> where T : IRealNumber<T>
	{
		/// <summary>
		/// Value (Expected Value)
		/// </summary>
		double Value { get; }

		/// <summary>
		/// Expected Value
		/// </summary>
		double ExpValue { get; }

		/// <summary>
		/// Function Value
		/// </summary>
		double FcnValue { get; }

		/// <summary>
		/// Returns true if it's a Const
		/// </summary>
		bool IsConst { get; }

		/// <summary>
		/// Computes the Standard Uncertainty
		/// </summary>
		double StdUnc { get; }

		/// <summary>
		/// Computes the Inverse of the Degrees of Freedom
		/// </summary>
		double IDof { get; }

		/// <summary>
		/// Computes the n-th Central Moment
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		double GetMoment(int n);

		/// <summary>
		/// Computes the Coverage Interval
		/// </summary>
		/// <param name="p">Probability</param>
		/// <returns></returns>
		double[] GetCoverageInterval(double p);
	}
}
