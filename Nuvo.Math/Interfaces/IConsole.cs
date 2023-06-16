using System;

namespace Nuvo.Math.Interface
{
	/// <summary>
	/// Console Interface
	/// </summary>
	public interface IConsole
	{
		/// <summary>
		/// Number of bytes allocated for the Object.
		/// </summary>
		int memsize { get; }

		/// <summary>
		/// Override ToString() to display an Object.
		/// </summary>
		/// <returns></returns>
		string ToString();

		/// <summary>
		/// Debug an Object
		/// </summary>
		void Debug();
	}
}
