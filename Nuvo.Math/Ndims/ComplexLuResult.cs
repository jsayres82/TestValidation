using System;
using Nuvo.Math.Interface;
using Nuvo.Math.Ndims.Interface;

namespace Nuvo.Math.Ndims
{
	/// <summary>
	/// Complex LU Decomposition Result
	/// </summary>
	/// <typeparam name="D">Real Element Type</typeparam>
	public class ComplexLuResult<T, D> : LuResult<T, D>
	where T : INArray<T, Complex<D>>
	where D : INumber<D>, new()
	{
	}
}
