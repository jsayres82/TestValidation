using System;
using Nuvo.Math.Core.Interface;

namespace Nuvo.Math.Core.Ndims
{
	/// <summary>
	/// Real LU Decomposition Result
	/// </summary>
	/// <typeparam name="D">Real Element Type</typeparam>
	// Token: 0x0200003C RID: 60
	public class RealLuResult<D> : LuResult<RealNArray<D>, D> where D : IRealNumber<D>, new()
	{
	}
}
