using System;
using Nuvo.Math.Interface;

namespace Nuvo.Math.Ndims
{
	/// <summary>
	/// Complex LU Decomposition Result
	/// </summary>
	/// <typeparam name="D">Real Element Type</typeparam>
	public class ComplexLuResult<D> : LuResult<ComplexNArray<D>, Complex<D>> where D : INumber<D>, new()
	{
	}
}
