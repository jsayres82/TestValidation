using System;

namespace Nuvo.Math.Interface
{
	/// <summary>
	/// Interface Number.
	/// </summary>
	/// <typeparam name="T">Type</typeparam>
	public interface INumber<T> : IConsole, IStorage<T>, IComparable, IElementArithmetic<T>, IArithmetic<T>, IMath<T> where T : INumber<T>
	{
		/// <summary>
		/// Initializes a Number
		/// </summary>
		/// <param name="value"></param>
		void InitDbl(double value);

		/// <summary>
		/// Returns the square function value.
		/// </summary>
		/// <returns></returns>
		double DblSqrFcnValue();

		/// <summary>
		/// Returns the function value.
		/// </summary>
		/// <returns></returns>
		T FcnValue2();
	}
}
