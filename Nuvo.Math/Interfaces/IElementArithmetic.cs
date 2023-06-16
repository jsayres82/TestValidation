using System;

namespace Nuvo.Math.Interface
{
	/// <summary>
	/// Element Arithmetic Interface.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	// Token: 0x02000013 RID: 19
	public interface IElementArithmetic<T> : IArithmetic<T>
	{
		/// <summary>
		/// Returns the neutral element of addition
		/// </summary>
		/// <value>e</value>
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000135 RID: 309
		T Zero { get; }

		/// <summary>
		/// Returns the neutral element of multiplication
		/// </summary>
		/// <value>e</value>
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000136 RID: 310
		T One { get; }
	}
}
