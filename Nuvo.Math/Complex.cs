using System;
using System.IO;
using System.Xml.Serialization;
using Nuvo.Math.Interface;
using Nuvo.Math.Misc;

namespace Nuvo.Math
{
	/// <summary>
	/// Generic Complex
	/// </summary>
	/// <typeparam name="T">Real Type</typeparam>
	[Serializable]
	public struct Complex<T> : IConsole where T: IRealNumber<T>, new()
	{
		/// <summary>
		/// Returns the square root of -1.
		/// </summary>
		/// <value></value>
		public Complex<T> J
		{
			get
			{
				return new Complex<T>(0.0, 1.0);
			}
		}

		/// <summary>
		/// Creates a new Complex
		/// </summary>
		/// <param name="r">Real Part</param>
		/// <param name="i">Imaginary Part</param>
		public Complex(T r, T i)
		{
			this.real = r;
			this.imag = i;
		}

		/// <summary>
		/// Creates a new Complex with Imaginary Part = 0
		/// </summary>
		/// <param name="r">Real Part</param>
		public Complex(T r)
		{
			this.real = r;
			T t = Activator.CreateInstance<T>();
			this.imag = t.Zero;
		}

		/// <summary>
		/// Creates a new Complex
		/// </summary>
		/// <param name="r">Real Part</param>
		/// <param name="i">Imaginary Part</param>
		public Complex(double r, double i = 0.0)
		{
			T _real = Activator.CreateInstance<T>();
			_real.InitDbl(r);
			T _imag = Activator.CreateInstance<T>();
			_imag.InitDbl(i);
			this.real = _real;
			this.imag = _imag;
		}

		/// <summary>
		/// From Polar Coordinates
		/// </summary>
		/// <param name="mag">Magnitude</param>
		/// <param name="phase">Phase</param>
		/// <returns>Complex Number</returns>
		public static Complex<T> FromPolarCoordinates(T mag, T phase)
		{
			return new Complex<T>
			{
				real = mag.Multiply(phase.Cos()),
				imag = mag.Multiply(phase.Sin())
			};
		}

		/// <summary>
		/// Convert double to Complex
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static implicit operator Complex<T>(double a)
		{
			return new Complex<T>(a, 0.0);
		}

		/// <summary>
		/// Convert Real Number to Complex Number
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public static implicit operator Complex<T>(T x)
		{
			Complex<T> result = default(Complex<T>);
			result.real = x;
			T t = Activator.CreateInstance<T>();
			result.imag = t.Zero;
			return result;
		}

		/// <summary>
		/// Overloading '+' operator
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public static Complex<T>operator +(Complex<T> x)
		{
			return x;
		}

		/// <summary>
		/// Overloading '-' operator
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public static Complex<T>operator -(Complex<T> x)
		{
			return new Complex<T>
			{
				real = x.real.Negative(),
				imag = x.imag.Negative()
			};
		}

		/// <summary>
		/// Overloading '+' operator
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public static Complex<T>operator +(Complex<T> x, Complex<T> y)
		{
			return new Complex<T>
			{
				real = x.real.Add(y.real),
				imag = x.imag.Add(y.imag)
			};
		}

		/// <summary>
		/// Overloading '-' operator
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public static Complex<T>operator -(Complex<T> x, Complex<T> y)
		{
			return new Complex<T>
			{
				real = x.real.Subtract(y.real),
				imag = x.imag.Subtract(y.imag)
			};
		}

		/// <summary>
		/// Overloading '*' operator
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public static Complex<T>operator *(Complex<T> x, Complex<T> y)
		{
			Complex<T> result = default(Complex<T>);
			T t = x.real.Multiply(y.real);
			result.real = t.Subtract(x.imag.Multiply(y.imag));
			t = x.real.Multiply(y.imag);
			result.imag = t.Add(y.real.Multiply(x.imag));
			return result;
		}

		/// <summary>
		/// Overloading '/' operator
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public static Complex<T>operator /(Complex<T> x, Complex<T> y)
		{
			T a = x.real;
			T b = x.imag;
			T c = y.real;
			T d = y.imag;
			T f;
			return new Complex<T>(Math.ComplexDivision<T>(a, b, c, d, out f), f);
		}

		/// <summary>
		/// Initializes a Complex Number.
		/// </summary>
		/// <param name="real">Real Part</param>
		/// <param name="imag">Imaginary Part</param>
		public void InitReIm(T real, T imag)
		{
			this.real = real;
			this.imag = imag;
		}

		/// <summary>
		/// Initializes a Complex Number with Imaginary Part = 0.
		/// </summary>
		/// <param name="real">Real Part</param>
		public void InitRe(T real)
		{
			this.real = real;
			T t = Activator.CreateInstance<T>();
			this.imag = t.Zero;
		}

		/// <summary>
		/// Initializes a Complex Number.
		/// </summary>
		/// <param name="mag">Magnitude</param>
		/// <param name="phase">Phase</param>
		public void InitMagPhase(T mag, T phase)
		{
			this.real = mag.Multiply(phase.Cos());
			this.imag = mag.Multiply(phase.Sin());
		}

		/// <summary>
		/// Initializes a Complex Number.
		/// </summary>
		/// <param name="real">Real Part</param>
		/// <param name="imag">Imaginary Part</param>
		public void InitDblReIm(double real, double imag)
		{
			this.real = Activator.CreateInstance<T>();
			this.real.InitDbl(real);
			this.imag = Activator.CreateInstance<T>();
			this.imag.InitDbl(imag);
		}

		/// <summary>
		/// Returns the real value (expected value).
		/// </summary>
		/// <returns></returns>
		public double DblRealValue()
		{
			return this.real.Value;
		}

		/// <summary>
		/// Returns the imaginary value (expected value).
		/// </summary>
		/// <returns></returns>
		public double DblImagValue()
		{
			return this.imag.Value;
		}

		/// <summary>
		/// Returns the real expected value.
		/// </summary>
		/// <returns></returns>
		public double DblRealExpValue()
		{
			return this.real.ExpValue;
		}

		/// <summary>
		/// Returns the imaginary expected value.
		/// </summary>
		/// <returns></returns>
		public double DblImagExpValue()
		{
			return this.imag.ExpValue;
		}

		/// <summary>
		/// Returns the real function value.
		/// </summary>
		/// <returns></returns>
		public double DblRealFcnValue()
		{
			return this.real.FcnValue;
		}

		/// <summary>
		/// Returns the imaginary function value.
		/// </summary>
		/// <returns></returns>
		public double DblImagFcnValue()
		{
			return this.imag.FcnValue;
		}

		/// <summary>
		/// Initializes a Complex Number with Imaginary Part = 0.
		/// </summary>
		/// <param name="value">Real part</param>
		public void InitDbl(double value)
		{
			this.real = Activator.CreateInstance<T>();
			this.real.InitDbl(value);
			T t = Activator.CreateInstance<T>();
			this.imag = t.Zero;
		}

		/// <summary>
		/// Returns the square function value.
		/// </summary>
		/// <returns></returns>
		public double DblSqrFcnValue()
		{
			return this.DblRealFcnValue() * this.DblRealFcnValue() + this.DblImagFcnValue() * this.DblImagFcnValue();
		}

		/// <summary>
		/// Returns the function value.
		/// </summary>
		/// <returns></returns>
		public Complex<T> FcnValue2()
		{
			return new Complex<T>(this.real.FcnValue2(), this.imag.FcnValue2());
		}

		/// <summary>
		/// Number of bytes allocated for the Object.
		/// </summary>
		public int memsize
		{
			get
			{
				return 0 + this.real.memsize + this.imag.memsize;
			}
		}

		/// <summary>
		/// Override ToString() to display an Object.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			if (this.imag.Value < 0.0)
			{
				return string.Format("({0} - {1}i)", this.real.Value, -this.imag.Value);
			}
			return string.Format("({0} + {1}i)", this.real.Value, this.imag.Value);
		}

		/// <summary>
		/// Debug an Object
		/// </summary>
		public void Debug()
		{
			Nuvo.Math.Misc.Console.Debug(this);
		}

		/// <summary>
		/// Write object data to Binary Writer.
		/// </summary>
		/// <param name="writer">Binary Writer</param>
		public void BinaryWriteDataTo(BinaryWriter writer)
		{
			int version = 1;
			writer.Write(version);
			this.real.BinaryWriteDataTo(writer);
			this.imag.BinaryWriteDataTo(writer);
		}

		/// <summary>
		/// Set object data from Binary Reader.
		/// </summary>
		/// <param name="reader">Binary Reader</param>
		public void BinarySetDataFrom(BinaryReader reader)
		{
			reader.ReadInt32();
			this.real = Activator.CreateInstance<T>();
			this.real.BinarySetDataFrom(reader);
			this.imag = Activator.CreateInstance<T>();
			this.imag.BinarySetDataFrom(reader);
		}

		/// <summary>
		/// Binary Serialize an Object to File.
		/// </summary>
		/// <param name="filepath">File Path</param>
		public void BinarySerialize(string filepath)
		{
			Storage.BinarySerialize(this, filepath);
		}

		/// <summary>
		/// Binary Deserialize an Object from File.
		/// </summary>
		/// <param name="filepath">File Path</param>
		/// <returns>Object</returns>
		public Complex<T> BinaryDeserialize(string filepath)
		{
			return Storage.BinaryDeserialize<Complex<T>>(filepath);
		}

		/// <summary>
		/// Binary Serialize an Object to a byte array.
		/// </summary>
		/// <returns>Binary Data</returns>
		public byte[] BinarySerializeToByteArray()
		{
			return Storage.BinarySerializeToByteArray(this);
		}

		/// <summary>
		/// Binary Deserialize an Object from a byte array.
		/// </summary>
		/// <param name="data">Binary Data</param>
		/// <returns>Object</returns>
		public Complex<T> BinaryDeserializeFromByteArray(byte[] data)
		{
			return Storage.BinaryDeserializeFromByteArray<Complex<T>>(data);
		}

		/// <summary>
		/// Xml Serialize an Object to File.
		/// </summary>
		/// <param name="filepath">File Path</param>
		public void XmlSerialize(string filepath)
		{
			Storage.XmlSerialize(this, filepath);
		}

		/// <summary>
		/// Xml Deserialize an Object from File.
		/// </summary>
		/// <param name="filepath">Xml String</param>
		/// <returns>Object</returns>
		public Complex<T> XmlDeserialize(string filepath)
		{
			return Storage.XmlDeserialize<Complex<T>>(filepath);
		}

		/// <summary>
		/// Xml Serialize an Object to String.
		/// </summary>
		/// <returns>XML String</returns>
		public string XmlSerializeToString()
		{
			return Storage.XmlSerializeToString(this);
		}

		/// <summary>
		/// Xml Deserialize an Object from String.
		/// </summary>
		/// <param name="xml_string">Xml String</param>
		/// <returns>Object</returns>
		public Complex<T> XmlDeserializeFromString(string xml_string)
		{
			return Storage.XmlDeserializeFromString<Complex<T>>(xml_string);
		}

		/// <summary>
		/// Returns true if the Value of an Object is equal to zero.
		/// </summary>
		/// <returns></returns>
		public bool IsZero()
		{
			return this.real.IsZero() & this.imag.IsZero();
		}

		/// <summary>
		/// Returns true if the Value of an Object is not equal to zero.
		/// </summary>
		/// <returns></returns>
		public bool IsNotZero()
		{
			return this.real.IsNotZero() | this.imag.IsNotZero();
		}

		/// <summary>
		/// Returns the neutral element of addition
		/// </summary>
		/// <value>e</value>
		public Complex<T> Zero
		{
			get
			{
				Complex<T> result = default(Complex<T>);
				T t = Activator.CreateInstance<T>();
				result.real = t.Zero;
				t = Activator.CreateInstance<T>();
				result.imag = t.Zero;
				return result;
			}
		}

		/// <summary>
		/// Returns the neutral element of multiplication
		/// </summary>
		/// <value>e</value>
		public Complex<T> One
		{
			get
			{
				Complex<T> result = default(Complex<T>);
				T t = Activator.CreateInstance<T>();
				result.real = t.One;
				t = Activator.CreateInstance<T>();
				result.imag = t.Zero;
				return result;
			}
		}

		/// <summary>
		/// Returns the sum of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the sum</returns>
		public Complex<T> Add(Complex<T> b)
		{
			return this + b;
		}

		/// <summary>
		/// Returns the difference of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the difference</returns>
		public Complex<T> Subtract(Complex<T> b)
		{
			return this - b;
		}

		/// <summary>
		/// Returns the negative of the object.
		/// </summary>
		/// <returns>The negative</returns>
		public Complex<T> Negative()
		{
			return -this;
		}

		/// <summary>
		/// Returns the product of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the product</returns>
		public Complex<T> Multiply(Complex<T> b)
		{
			return this * b;
		}

		/// <summary>
		/// Returns the quotient of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the quotient</returns>
		public Complex<T> Divide(Complex<T> b)
		{
			return this / b;
		}

		/// <summary>
		/// Returns e raised to the specified power.
		/// </summary>
		/// <returns></returns>
		public Complex<T> Exp()
		{
			return this.real.Exp() * (this.imag.Cos() + this.imag.Sin() * this.J);
		}

		/// <summary>
		/// Returns e raised to the specified power.
		/// </summary>
		/// <returns></returns>
		public Complex<T> Exp(T a) 
		{
			Complex<T> val = a;
			return val.real.Exp() * (val.imag.Cos() + val.imag.Sin() * val.J);
		}

		/// <summary>
		/// Returns the natural (base e) logarithm of a specified number.
		/// </summary>
		/// <returns></returns>
		public Complex<T> Log()
		{
			T t = this.Abs();
			return t.Log() + this.Angle() * this.J;
		}

		/// <summary>
		/// Returns the logarithm of a specified number in a specified base.
		/// </summary>
		/// <param name="newBase"></param>
		/// <returns></returns>
		public Complex<T> Log(Complex<T> newBase)
		{
			return this.Log() / newBase.Log();
		}

		/// <summary>
		/// Returns the base 10 logarithm of a specified number.
		/// </summary>
		/// <returns></returns>
		public Complex<T> Log10()
		{
			return this.Log(10.0);
		}

		/// <summary>
		/// Returns a specified number raised to the specified power.
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		public Complex<T> Pow(Complex<T> b)
		{
			return (b * this.Log()).Exp();
		}

		/// <summary>
		/// Returns a specified number raised to the specified power.
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		public Complex<T> Pow(int b)
		{
			if (b == 0)
			{
				return 1.0;
			}
			T c = Activator.CreateInstance<T>();
			c.InitDbl((double)b);
			T rho = this.Abs();
			T theta = this.imag.Atan2(this.real);
			T newRho = c.Multiply(theta);
			T t = rho.Pow(b);
			return new Complex<T>
			{
				real = t.Multiply(newRho.Cos()),
				imag = t.Multiply(newRho.Sin())
			};
		}

		/// <summary>
		/// Returns the square root of a specified number.
		/// </summary>
		/// <returns></returns>
		public Complex<T> Sqrt()
		{
			T r = this.Abs();
			T a = this.Angle();
			T r_sqrt = r.Sqrt();
			T two = Activator.CreateInstance<T>();
			two.InitDbl(2.0);
			T a_2 = a.Divide(two);
			return new Complex<T>
			{
				real = r_sqrt.Multiply(a_2.Cos()),
				imag = r_sqrt.Multiply(a_2.Sin())
			};
		}

		/// <summary>
		/// Returns the sine of the specified angle.
		/// </summary>
		/// <returns></returns>
		public Complex<T> Sin()
		{
			T a = this.real;
			T b = this.imag;
			T t = a.Sin();
			T r = t.Multiply(b.Cosh());
			t = a.Cos();
			return new Complex<T>(r, t.Multiply(b.Sinh()));
		}

		/// <summary>
		/// Returns the cosine of the specified angle.
		/// </summary>
		/// <returns></returns>
		public Complex<T> Cos()
		{
			T a = this.real;
			T b = this.imag;
			T t = a.Cos();
			T r = t.Multiply(b.Cosh());
			t = a.Sin();
			t = t.Multiply(b.Sinh());
			return new Complex<T>(r, t.Negative());
		}

		/// <summary>
		/// Returns the tangent of the specified angle.
		/// </summary>
		/// <returns></returns>
		public Complex<T> Tan()
		{
			T t = Activator.CreateInstance<T>();
			T one = t.One;
			T a = this.real;
			T b = this.imag;
			T tan_a = a.Tan();
			T tanh_b = b.Tanh();
			Complex<T> x = new Complex<T>(tan_a, tanh_b);
			T r = one;
			t = tan_a.Multiply(tanh_b);
			Complex<T> den = new Complex<T>(r, t.Negative());
			return x / den;
		}

		/// <summary>
		/// Returns the angle whose sine is the specified number.
		/// </summary>
		/// <returns></returns>
		public Complex<T> Asin()
		{
			return -this.J * (this.J * this + (1.0 - this * this).Sqrt()).Log();
		}

		/// <summary>
		/// Returns the angle whose cosine is the specified number.
		/// </summary>
		/// <returns></returns>
		public Complex<T> Acos()
		{
			return -this.J * (this + this.J * (1.0 - this * this).Sqrt()).Log();
		}

		/// <summary>
		/// Returns the angle whose tangent is the specified number.
		/// </summary>
		/// <returns></returns>
		public Complex<T> Atan()
		{
			return ((1.0 + this.J * this) / (1.0 - this.J * this)).Log() / (this.J * 2.0);
		}

		/// <summary>
		/// Returns the hyperbolic sine of the specified angle.
		/// </summary>
		/// <returns></returns>
		public Complex<T> Sinh()
		{
			T a = this.real;
			T b = this.imag;
			T t = a.Sinh();
			T r = t.Multiply(b.Cos());
			t = a.Cosh();
			return new Complex<T>(r, t.Multiply(b.Sin()));
		}

		/// <summary>
		/// Returns the hyperbolic cosine of the specified angle.
		/// </summary>
		/// <returns></returns>
		public Complex<T> Cosh()
		{
			T a = this.real;
			T b = this.imag;
			T t = a.Cosh();
			T r = t.Multiply(b.Cos());
			t = a.Sinh();
			return new Complex<T>(r, t.Multiply(b.Sin()));
		}

		/// <summary>
		/// Returns the hyperbolic tangent of the specified angle.
		/// </summary>
		/// <returns></returns>
		public Complex<T> Tanh()
		{
			T t = Activator.CreateInstance<T>();
			T one = t.One;
			T a = this.real;
			T b = this.imag;
			T tanh_a = a.Tanh();
			T tan_b = b.Tan();
			Complex<T> x = new Complex<T>(tanh_a, tan_b);
			Complex<T> den = new Complex<T>(one, tanh_a.Multiply(tan_b));
			return x / den;
		}

		/// <summary>
		/// Returns the angle whose hyperbolic sine is the specified number.
		/// </summary>
		/// <returns></returns>
		public Complex<T> Asinh()
		{
			return (this + (this * this + 1.0).Sqrt()).Log();
		}

		/// <summary>
		/// Returns the angle whose hyperbolic cosine is the specified number.
		/// </summary>
		/// <returns></returns>
		public Complex<T> Acosh()
		{
			return (this + (this * this - 1.0).Sqrt()).Log();
		}

		/// <summary>
		/// Returns the angle whose hyperbolic tangent is the specified number.
		/// </summary>
		/// <returns></returns>
		public Complex<T> Atanh()
		{
			return ((1.0 + this) / (1.0 - this)).Log() / 2.0;
		}

		/// <summary>
		/// Returns the complex conjugate.
		/// </summary>
		/// <returns></returns>
		public Complex<T> Conj()
		{
			return this.real - this.imag * this.J;
		}

		/// <summary>
		/// Returns the real part.
		/// </summary>
		/// <returns></returns>
		public T Real()
		{
			return this.real;
		}

		/// <summary>
		/// Returns the imaginary part.
		/// </summary>
		/// <returns></returns>
		public T Imag()
		{
			return this.imag;
		}

		/// <summary>
		/// Returns the absolute value.
		/// </summary>
		/// <returns></returns>
		public T Abs()
		{
			return Math.ComplexAbs<T>(this.real, this.imag);
		}

		/// <summary>
		/// Returns the angle.
		/// </summary>
		/// <returns></returns>
		public T Angle()
		{
			return this.imag.Atan2(this.real);
		}

		/// <summary>
		/// Real Part
		/// </summary>
		[XmlElement("Real")]
		public T real;

		/// <summary>
		/// Imaginary Part
		/// </summary>
		[XmlElement("Imag")]
		public T imag;
	}
}
