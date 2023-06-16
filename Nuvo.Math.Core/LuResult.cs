using System;

namespace Nuvo.Math.Core
{
	/// <summary>
	/// Generic LU Decompostion Result
	/// </summary>
	/// <typeparam name="T">Data Type</typeparam>
	// Token: 0x02000004 RID: 4
	public struct LuResult<T>
	{
		/// <summary>
		/// Lower Matrix
		/// </summary>
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00003547 File Offset: 0x00001747
		// (set) Token: 0x06000055 RID: 85 RVA: 0x0000354F File Offset: 0x0000174F
		public T[][] l { get; set; }

		/// <summary>
		/// Upper Matrix
		/// </summary>
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00003558 File Offset: 0x00001758
		// (set) Token: 0x06000057 RID: 87 RVA: 0x00003560 File Offset: 0x00001760
		public T[][] u { get; set; }

		/// <summary>
		/// Permutation Matrix
		/// </summary>
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00003569 File Offset: 0x00001769
		// (set) Token: 0x06000059 RID: 89 RVA: 0x00003571 File Offset: 0x00001771
		public T[][] p { get; set; }

		/// <summary>
		/// Row Indices
		/// </summary>
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600005A RID: 90 RVA: 0x0000357A File Offset: 0x0000177A
		// (set) Token: 0x0600005B RID: 91 RVA: 0x00003582 File Offset: 0x00001782
		public int[] c { get; set; }

		/// <summary>
		/// Interchange row count
		/// </summary>
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600005C RID: 92 RVA: 0x0000358B File Offset: 0x0000178B
		// (set) Token: 0x0600005D RID: 93 RVA: 0x00003593 File Offset: 0x00001793
		public int d { get; set; }
	}
}
