using System;

namespace Nuvo.Math.Interface
{
	/// <summary>
	/// Element Arithmetic Interface.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IElementArithmetic<T> : IArithmetic<T>
	{
		/// <summary>
		/// Returns the neutral element of addition
		/// </summary>
		/// <value>e</value>
		T Zero { get; }

		/// <summary>
		/// Returns the neutral element of multiplication
		/// </summary>
		/// <value>e</value>
		T One { get; }
	}
}
