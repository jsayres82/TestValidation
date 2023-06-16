using System;
using Nuvo.Math.Core.Interface;

namespace Nuvo.Math.Core.Ndims
{
	/// <summary>
	/// Complex LU Decomposition Result
	/// </summary>
	/// <typeparam name="D">Real Element Type</typeparam>
	// Token: 0x0200003D RID: 61
	public class ComplexLuResult<D> : LuResult<ComplexNArray<D>, Complex<D>> where D : IRealNumber<D>, new()
	{
	}
}
