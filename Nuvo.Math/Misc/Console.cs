using System;
using Nuvo.Math.Interface;

namespace Nuvo.Math.Misc
{
	/// <summary>
	/// Static Console Class
	/// </summary>
	// Token: 0x0200000A RID: 10
	public static class Console
	{
		/// <summary>
		/// Writes the object to the console.
		/// </summary>
		/// <param name="a">Object</param>
		// Token: 0x0600010F RID: 271 RVA: 0x000074E0 File Offset: 0x000056E0
		public static void Debug(IConsole a)
		{
			System.Console.WriteLine(a.ToString());
		}

		/// <summary>
		/// Writes the object type to the console.
		/// </summary>
		/// <param name="a">Object</param>
		// Token: 0x06000110 RID: 272 RVA: 0x000074ED File Offset: 0x000056ED
		public static void DebugType(IConsole a)
		{
			System.Console.WriteLine(a.GetType().ToString());
		}
	}
}
