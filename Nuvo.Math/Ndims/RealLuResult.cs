using System;
using Nuvo.Math.Interface;

namespace Nuvo.Math.Ndims
{
	/// <summary>
	/// Real LU Decomposition Result
	/// </summary>
	/// <typeparam name="D">Real Element Type</typeparam>
	public class RealLuResult<D> : LuResult<RealNArray<D>, D> where D : IRealNumber<D>, new()
	{
	}
}
