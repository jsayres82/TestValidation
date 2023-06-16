using System;
using Nuvo.Math.Interface;

namespace Nuvo.Math.Misc
{
	/// <summary>
	/// Static Console Class
	/// </summary>
	public static class Console
	{
		/// <summary>
		/// Writes the object to the console.
		/// </summary>
		/// <param name="a">Object</param>
		public static void Debug(IConsole a)
		{
			System.Console.WriteLine(a.ToString());
		}

		/// <summary>
		/// Writes the object type to the console.
		/// </summary>
		/// <param name="a">Object</param>
		public static void DebugType(IConsole a)
		{
			System.Console.WriteLine(a.GetType().ToString());
		}
	}
}
