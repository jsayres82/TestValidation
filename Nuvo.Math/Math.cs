using System;
using Nuvo.Math.Interface;

namespace Nuvo.Math
{
	/// <summary>
	/// Generic Math
	/// </summary>
	public static class Math
	{
		/// <summary>
		/// Returns the sum of <paramref name="a" /> and <paramref name="b" />.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">The first operand</param>
		/// <param name="b">The second operand</param>
		/// <returns>the sum</returns>
		public static T Add<T>(T a, T b) where T : INumber<T>
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
		public static T Subtract<T>(T a, T b) where T : INumber<T>
		{
			return a.Subtract(b);
		}

		/// <summary>
		/// Returns the negative of <paramref name="a" />.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="a">The operand</param>
		/// <returns>The negative</returns>
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
		/// <param name="c">Denominator real part</param>
		/// <param name="d">Denominator imag part</param>
		/// <param name="f">Result imag part</param>
		/// <returns>Result real part</returns>
		public static T StandardComplexDivision<T>(T a, T b, T c, T d, out T f) where T : IRealNumber<T>, new()
		{
			T e;
			if (System.Math.Abs(c.Value) >= System.Math.Abs(d.Value))
			{
				T d_c = d.Divide(c);
				T den = c.Add(d.Multiply(d_c));
				T t = a.Add(b.Multiply(d_c));
				e = t.Divide(den);
				t = b.Subtract(a.Multiply(d_c));
				f = t.Divide(den);
			}
			else
			{
				T c_d = c.Divide(d);
				T t = c.Multiply(c_d);
				T den2 = t.Add(d);
				t = a.Multiply(c_d);
				t = t.Add(b);
				e = t.Divide(den2);
				t = b.Multiply(c_d);
				t = t.Subtract(a);
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
		public static T ComplexAbs<T>(T a, T b) where T : IRealNumber<T>
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
		public static T StandardComplexAbs<T>(T a, T b) where T : IRealNumber<T>
		{
			T one = a.One;
			T t;
			if (a.Value == 0.0 && b.Value == 0.0)
			{
				t = a.Pow(2);
				t = t.Add(b.Pow(2));
				return t.Sqrt();
			}
			T t2;
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
		public static T Angle<T>(Complex<T> a) where T : IRealNumber<T>, new()
		{
			return a.Angle();
		}
	}
}
