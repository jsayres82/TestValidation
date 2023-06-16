using System;
using Nuvo.Math.Core.Interface;
using Nuvo.Math.Core.Ndims.Interface;

namespace Nuvo.Math.Core.Ndims
{
	/// <summary>
	/// Generic LU Decomposition Result
	/// </summary>
	/// <typeparam name="T">Array Type</typeparam>
	/// <typeparam name="D">Element Type</typeparam>
	// Token: 0x0200003B RID: 59
	public class LuResult<T, D> where T : INArray<T, D>, new() where D : INumber<D>, new()
	{
		/// <summary>
		/// Lower Matrix
		/// </summary>
		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060002FC RID: 764 RVA: 0x0000D84B File Offset: 0x0000BA4B
		// (set) Token: 0x060002FD RID: 765 RVA: 0x0000D853 File Offset: 0x0000BA53
		public T l { get; set; }

		/// <summary>
		/// Upper Matrix
		/// </summary>
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060002FE RID: 766 RVA: 0x0000D85C File Offset: 0x0000BA5C
		// (set) Token: 0x060002FF RID: 767 RVA: 0x0000D864 File Offset: 0x0000BA64
		public T u { get; set; }

		/// <summary>
		/// Permutation Matrix
		/// </summary>
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000300 RID: 768 RVA: 0x0000D86D File Offset: 0x0000BA6D
		// (set) Token: 0x06000301 RID: 769 RVA: 0x0000D875 File Offset: 0x0000BA75
		public T p { get; set; }

		/// <summary>
		/// Interchange row count
		/// </summary>
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000302 RID: 770 RVA: 0x0000D87E File Offset: 0x0000BA7E
		// (set) Token: 0x06000303 RID: 771 RVA: 0x0000D886 File Offset: 0x0000BA86
		public int d { get; set; }
	}
}
