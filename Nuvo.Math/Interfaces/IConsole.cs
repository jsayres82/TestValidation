using System;

namespace Nuvo.Math.Interface
{
	/// <summary>
	/// Console Interface
	/// </summary>
	// Token: 0x02000016 RID: 22
	public interface IConsole
	{
		/// <summary>
		/// Number of bytes allocated for the Object.
		/// </summary>
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000141 RID: 321
		int memsize { get; }

		/// <summary>
		/// Override ToString() to display an Object.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000142 RID: 322
		string ToString();

		/// <summary>
		/// Debug an Object
		/// </summary>
		// Token: 0x06000143 RID: 323
		void Debug();
	}
}
