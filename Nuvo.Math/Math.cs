using System;
using Nuvo.Math.Interface;

namespace Nuvo.Math
{
	/// <summary>
	/// Generic Math
	/// </summary>
	// Token: 0x02000006 RID: 6
	public static class Math
	{
		/// <summary>
		/// Returns the sum of <paramref name="a" /> and <paramref name="b" />.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">The first operand</param>
		/// <param name="b">The second operand</param>
		/// <returns>the sum</returns>
		// Token: 0x06000078 RID: 120 RVA: 0x000047ED File Offset: 0x000029ED
		public static T Add<T>(T a, T b)
		{
			return a.Add(b);
		}

		/// <summary>
		/// Returns the difference of <paramref name="a" /> and <paramref name="b" />.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">The first operand</param>
		/// <param name="b">The second operand</param>
		/// <returns>the difference</returns>
		// Token: 0x06000079 RID: 121 RVA: 0x000047FD File Offset: 0x000029FD
		public static T Subtract<T>(T a, T b)
		{
			return a.Subtract(b);
		}

		/// <summary>
		/// Returns the negative of <paramref name="a" />.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">The operand</param>
		/// <returns>The negative</returns>
		// Token: 0x0600007A RID: 122 RVA: 0x0000480D File Offset: 0x00002A0D
		public static T Negative<T>(T a) where T : INumber<T>
		{
			return a.Negative();
		}

		/// <summary>
		/// Returns the product of <paramref name="a" /> and <paramref name="b" />.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">The first operand</param>
		/// <param name="b">The second operand</param>
		/// <returns>the product</returns>
		// Token: 0x0600007B RID: 123 RVA: 0x0000481C File Offset: 0x00002A1C
		public static T Multiply<T>(T a, T b) where T : INumber<T>
		{
			return a.Multiply(b);
		}

		/// <summary>
		/// Returns the quotient of <paramref name="a" /> and <paramref name="b" />.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">The first operand</param>
		/// <param name="b">The second operand</param>
		/// <returns>the quotient</returns>
		// Token: 0x0600007C RID: 124 RVA: 0x0000482C File Offset: 0x00002A2C
		public static T Divide<T>(T a, T b) where T : INumber<T>
		{
			return a.Divide(b);
		}

		/// <summary>
		/// Returns e raised to the specified power.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x0600007D RID: 125 RVA: 0x0000483C File Offset: 0x00002A3C
		public static T Exp<T>(T a) where T : INumber<T>
		{
			return a.Exp();
		}

		/// <summary>
		/// Returns e raised to the specified power.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x0600007D RID: 125 RVA: 0x0000483C File Offset: 0x00002A3C
		public static T Exp2<T>(T a) where T : INumber<T>
		{
			return a.Exp();
		}

		/// <summary>
		/// Returns the natural (base e) logarithm of a specified number.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x0600007E RID: 126 RVA: 0x0000484B File Offset: 0x00002A4B
		public static T Log<T>(T a) where T : INumber<T>
		{
			return a.Log();
		}

		/// <summary>
		/// Returns the logarithm of a specified number in a specified base.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a"></param>
		/// <param name="newBase"></param>
		/// <returns></returns>
		// Token: 0x0600007F RID: 127 RVA: 0x0000485A File Offset: 0x00002A5A
		public static T Log<T>(T a, T newBase) where T : INumber<T>
		{
			return a.Log(newBase);
		}

		/// <summary>
		/// Returns the base 10 logarithm of a specified number.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x06000080 RID: 128 RVA: 0x0000486A File Offset: 0x00002A6A
		public static T Log10<T>(T a) where T : INumber<T>
		{
			return a.Log10();
		}

		/// <summary>
		/// Returns a specified number raised to the specified power.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		// Token: 0x06000081 RID: 129 RVA: 0x00004879 File Offset: 0x00002A79
		public static T Pow<T>(T a, T b) where T : INumber<T>
		{
			return a.Pow(b);
		}

		/// <summary>
		/// Returns a specified number raised to the specified power.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		// Token: 0x06000082 RID: 130 RVA: 0x00004889 File Offset: 0x00002A89
		public static T Pow<T>(T a, int b) where T : INumber<T>
		{
			return a.Pow(b);
		}

		/// <summary>
		/// Returns the square root of a specified number.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x06000083 RID: 131 RVA: 0x00004899 File Offset: 0x00002A99
		public static T Sqrt<T>(T a) where T : INumber<T>
		{
			return a.Sqrt();
		}

		/// <summary>
		/// Returns the sine of the specified angle.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x06000084 RID: 132 RVA: 0x000048A8 File Offset: 0x00002AA8
		public static T Sin<T>(T a) where T : INumber<T>
		{
			return a.Sin();
		}

		/// <summary>
		/// Returns the cosine of the specified angle.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x06000085 RID: 133 RVA: 0x000048B7 File Offset: 0x00002AB7
		public static T Cos<T>(T a) where T : INumber<T>
		{
			return a.Cos();
		}

		/// <summary>
		/// Returns the tangent of the specified angle.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x06000086 RID: 134 RVA: 0x000048C6 File Offset: 0x00002AC6
		public static T Tan<T>(T a) where T : INumber<T>
		{
			return a.Tan();
		}

		/// <summary>
		/// Returns the angle whose sine is the specified number.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x06000087 RID: 135 RVA: 0x000048D5 File Offset: 0x00002AD5
		public static T Asin<T>(T a) where T : INumber<T>
		{
			return a.Asin();
		}

		/// <summary>
		/// Returns the angle whose cosine is the specified number.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x06000088 RID: 136 RVA: 0x000048E4 File Offset: 0x00002AE4
		public static T Acos<T>(T a) where T : INumber<T>
		{
			return a.Acos();
		}

		/// <summary>
		/// Returns the angle whose tangent is the specified number.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x06000089 RID: 137 RVA: 0x000048F3 File Offset: 0x00002AF3
		public static T Atan<T>(T a) where T : INumber<T>
		{
			return a.Atan();
		}

		/// <summary>
		/// Returns the hyperbolic sine of the specified angle.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x0600008A RID: 138 RVA: 0x00004902 File Offset: 0x00002B02
		public static T Sinh<T>(T a) where T : INumber<T>
		{
			return a.Sinh();
		}

		/// <summary>
		/// Returns the hyperbolic cosine of the specified angle.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x0600008B RID: 139 RVA: 0x00004911 File Offset: 0x00002B11
		public static T Cosh<T>(T a) where T : INumber<T>
		{
			return a.Cosh();
		}

		/// <summary>
		/// Returns the hyperbolic tangent of the specified angle.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x0600008C RID: 140 RVA: 0x00004920 File Offset: 0x00002B20
		public static T Tanh<T>(T a) where T : INumber<T>
		{
			return a.Tanh();
		}

		/// <summary>
		/// Returns the hyperbolic angle whose sine is the specified number.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x0600008D RID: 141 RVA: 0x0000492F File Offset: 0x00002B2F
		public static T Asinh<T>(T a) where T : INumber<T>
		{
			return a.Asinh();
		}

		/// <summary>
		/// Returns the hyperbolic angle whose cosine is the specified number.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x0600008E RID: 142 RVA: 0x0000493E File Offset: 0x00002B3E
		public static T Acosh<T>(T a) where T : INumber<T>
		{
			return a.Acosh();
		}

		/// <summary>
		/// Returns the hyperbolic angle whose tangent is the specified number.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x0600008F RID: 143 RVA: 0x0000494D File Offset: 0x00002B4D
		public static T Atanh<T>(T a) where T : INumber<T>
		{
			return a.Atanh();
		}

		/// <summary>
		/// Returns the complex conjugate.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x06000090 RID: 144 RVA: 0x0000495C File Offset: 0x00002B5C
		public static T Conj<T>(T a) where T : INumber<T>, new()
		{
			return a.Conj();
		}

		/// <summary>
		/// Returns the absolute value.
		/// </summary>
		/// <typeparam name="T">Real Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x06000091 RID: 145 RVA: 0x0000496B File Offset: 0x00002B6B
		public static T Abs<T>(T a) where T : IRealNumber<T>
		{
			return a.Abs();
		}

		/// <summary>
		/// Returns a value indicating the sign of a number.
		/// </summary>
		/// <typeparam name="T">Real Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x06000092 RID: 146 RVA: 0x0000497A File Offset: 0x00002B7A
		public static T Sign<T>(T a) where T : IRealNumber<T>
		{
			return a.Sign();
		}

		/// <summary>
		/// Returns the angle whose tangent is the quotient of two specified numbers.
		/// </summary>
		/// <typeparam name="T">Real Type</typeparam>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		// Token: 0x06000093 RID: 147 RVA: 0x00004989 File Offset: 0x00002B89
		public static T Atan2<T>(T a, T b) where T : IRealNumber<T>
		{
			return a.Atan2(b);
		}

		/// <summary>
		/// Complex division
		/// </summary>
		/// <typeparam name="T">Real Type</typeparam>
		/// <param name="a">Numerator real part</param>
		/// <param name="b">Numerator imag part</param>
		/// <param name="c">Denominator real part</param>
		/// <param name="d">Denominator imag part</param>
		/// <param name="f">Result imag part</param>
		/// <returns>Result real part</returns>
		// Token: 0x06000094 RID: 148 RVA: 0x00004999 File Offset: 0x00002B99
		public static T ComplexDivision<T>(T a, T b, T c, T d, out T f) where T : IRealNumber<T>
		{
			return a.ComplexDivision(b, c, d, out f);
		}

		/// <summary>
		/// Complex division
		/// </summary>
		/// <typeparam name="T">Real Type</typeparam>
		/// <param name="a">Numerator real part</param>
		/// <param name="b">Numerator imag part</param>
		/// <param name="b">Numerator imag part</param>
		/// <param name="c">Denominator real part</param>
		/// <param name="d">Denominator imag part</param>
		/// <param name="f">Result imag part</param>
		/// <returns>Result real part</returns>
		// Token: 0x06000095 RID: 149 RVA: 0x000049B0 File Offset: 0x00002BB0
		public static Number StandardComplexDivision(Number a, Number b, Number c, Number d, out  Number f)
		{
			Complex<T> num = default(Complex<T>);
			Complex<T> denominator = default(Complex<T>);
			num.real = a;
			num.imag = b;
			denominator.real = c;
			denominator.imag = d;

			T e;
			if (System.Math.Abs(c) >= System.Math.Abs(d))
			{
				T d_c = num.real.Divide(denominator.real);
				T den = denominator.real.Add(d.Multiply(d_c));
				T t = num.real.Add(num.imag.Multiply(d_c));
				e = t.Divide(den);
				t = num.imag.Subtract(num.real.Multiply(d_c));
				f = t.Divide(den);
			}
			else
			{
				T c_d = denominator.real.Divide(denominator.imag);
				T t = denominator.real.Multiply(c_d);
				T den2 = t.Add(denominator.imag);
				t = num.real.Multiply(c_d);
				t = t.Add(num.imag);
				e = t.Divide(den2);
				t = num.imag.Multiply(c_d);
				t = t.Subtract(num.real);
				f = t.Divide(den2);
			}
			return e;
		}

		/// <summary>
		/// Complex absolute value
		/// </summary>
		/// <typeparam name="T">Real Type</typeparam>
		/// <param name="a">Real part</param>
		/// <param name="b">Imag part</param>
		/// <returns></returns>
		// Token: 0x06000096 RID: 150 RVA: 0x00004B07 File Offset: 0x00002D07
		public static Number ComplexAbs(Number a, Number b)
		{
			return a.ComplexAbs(b);
		}

		/// <summary>
		/// Complex absolute value
		/// </summary>
		/// <typeparam name="T">Real Type</typeparam>
		/// <param name="a">Real part</param>
		/// <param name="b">Imag part</param>
		/// <returns></returns>
		// Token: 0x06000097 RID: 151 RVA: 0x00004B18 File Offset: 0x00002D18
		public static Number StandardComplexAbs(Number a, Number b) 
		{
			Number one = a.One;
			Number t;
			if (a.Value == 0.0 && b.Value == 0.0)
			{
				t = a.Pow(2);
				t = t.Add(b.Pow(2));
				return t.Sqrt();
			}
			Number t2;
			if (System.Math.Abs(a.Value) >= System.Math.Abs(b.Value))
			{
				t = a.Abs();
				t2 = b.Divide(a);
				t2 = one.Add(t2.Pow(2));
				return t.Multiply(t2.Sqrt());
			}
			t = b.Abs();
			t2 = a.Divide(b);
			t2 = one.Add(t2.Pow(2));
			return t.Multiply(t2.Sqrt());
		}

		/// <summary>
		/// Returns the real part.
		/// </summary>
		/// <typeparam name="T">Real Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x06000098 RID: 152 RVA: 0x00004C69 File Offset: 0x00002E69
		public static T Real<T>(Complex<T> a) where T : IRealNumber<T>, new()
		{
			return a.Real();
		}

		/// <summary>
		/// Returns the imaginary part.
		/// </summary>
		/// <typeparam name="T">Real Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x06000099 RID: 153 RVA: 0x00004C72 File Offset: 0x00002E72
		public static T Imag<T>(Complex<T> a) where T : IRealNumber<T>, new()
		{
			return a.Imag();
		}

		/// <summary>
		/// Returns the absolute value.
		/// </summary>
		/// <typeparam name="T">Real Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x0600009A RID: 154 RVA: 0x00004C7B File Offset: 0x00002E7B
		public static T Abs<T>(Complex<T> a) where T : IRealNumber<T>, new()
		{
			return a.Abs();
		}

		/// <summary>
		/// Returns the angle.
		/// </summary>
		/// <typeparam name="T">Real Type</typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x0600009B RID: 155 RVA: 0x00004C84 File Offset: 0x00002E84
		public static T Angle<T>(Complex<T> a) where T : IRealNumber<T>, new()
		{
			return a.Angle();
		}
	}
}
