using System;

namespace Nuvo.Math.Interface
{
	/// <summary>
	/// Math Interface.
	/// </summary>
	/// <typeparam name="T">Type</typeparam>
	// Token: 0x02000017 RID: 23
	public interface IMath<T>
	{
		/// <summary>
		/// Returns e raised to the specified power.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000144 RID: 324
		T Exp();

		/// <summary>
		/// Returns the natural (base e) logarithm of a specified number.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000145 RID: 325
		T Log();

		/// <summary>
		/// Returns the logarithm of a specified number in a specified base.
		/// </summary>
		/// <param name="newBase"></param>
		/// <returns></returns>
		// Token: 0x06000146 RID: 326
		T Log(T newBase);

		/// <summary>
		/// Returns the base 10 logarithm of a specified number.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000147 RID: 327
		T Log10();

		/// <summary>
		/// Returns a specified number raised to the specified power.
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		// Token: 0x06000148 RID: 328
		T Pow(T b);

		/// <summary>
		/// Returns a specified number raised to the specified power.
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		// Token: 0x06000149 RID: 329
		T Pow(int b);

		/// <summary>
		/// Returns the square root of a specified number.
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600014A RID: 330
		T Sqrt();

		/// <summary>
		/// Returns the sine of the specified angle.
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600014B RID: 331
		T Sin();

		/// <summary>
		/// Returns the cosine of the specified angle.
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600014C RID: 332
		T Cos();

		/// <summary>
		/// Returns the tangent of the specified angle.
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600014D RID: 333
		T Tan();

		/// <summary>
		/// Returns the angle whose sine is the specified number.
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600014E RID: 334
		T Asin();

		/// <summary>
		/// Returns the angle whose cosine is the specified number.
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600014F RID: 335
		T Acos();

		/// <summary>
		/// Returns the angle whose tangent is the specified number.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000150 RID: 336
		T Atan();

		/// <summary>
		/// Returns the hyperbolic sine of the specified angle.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000151 RID: 337
		T Sinh();

		/// <summary>
		/// Returns the hyperbolic cosine of the specified angle.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000152 RID: 338
		T Cosh();

		/// <summary>
		/// Returns the hyperbolic tangent of the specified angle.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000153 RID: 339
		T Tanh();

		/// <summary>
		/// Returns the angle whose hyperbolic sine is the specified number.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000154 RID: 340
		T Asinh();

		/// <summary>
		/// Returns the angle whose hyperbolic cosine is the specified number.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000155 RID: 341
		T Acosh();

		/// <summary>
		/// Returns the angle whose hyperbolic tangent is the specified number.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000156 RID: 342
		T Atanh();

		/// <summary>
		/// Returns the complex conjugate.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000157 RID: 343
		T Conj();
	}
}
