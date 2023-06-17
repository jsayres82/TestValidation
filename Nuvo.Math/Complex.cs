using System;
using System.IO;
using System.Xml.Serialization;
using Nuvo.Math.Interface;
using Nuvo.Math.Misc;

using Nuvo.Math.Ndims.Interface;
using Nuvo.Math.Ndims;

namespace Nuvo.Math
{
	/// <summary>
	/// Generic Complex
	/// </summary>
	/// <typeparam name="T">Real Type</typeparam>
	[Serializable]
	public class Complex<D> where D : INumber<D>
	{
		/// <summary>
		/// Returns the square root of -1.
		/// </summary>
		/// <value></value>
		public Complex<D> J
		{
			get
			{
				return new Complex<D>(0.0, 1.0);
			}
		}

		/// <summary>
		/// Creates a new Complex
		/// </summary>
		/// <param name="r">Real Part</param>
		/// <param name="i">Imaginary Part</param>
		public Complex()
		{
			var x = new Complex<D>(0.0, 1.0);
			this.real = x.real;
			this.imag = x.imag;
		}

		/// <summary>
		/// Creates a new Complex
		/// </summary>
		/// <param name="r">Real Part</param>
		/// <param name="i">Imaginary Part</param>
		public Complex(D r, D i)
		{
			this.real = r;
			this.imag = i;
		}

		/// <summary>
		/// Creates a new Complex with Imaginary Part = 0
		/// </summary>
		/// <param name="r">Real Part</param>
		public Complex(D r)
		{
			this.real = r;
			D d = Activator.CreateInstance<D>();
			this.imag = d.Zero;
		}

		/// <summary>
		/// Creates a new Complex
		/// </summary>
		/// <param name="r">Real Part</param>
		/// <param name="i">Imaginary Part</param>
		public Complex(double r, double i = 0.0)
		{
			D _real = Activator.CreateInstance<D>();
			_real.InitDbl(r);
			D _imag = Activator.CreateInstance<D>();
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
		public static Complex<D> FromPolarCoordinates(D mag, D phase)
		{
			return new Complex<D>
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
		public static implicit operator Complex<D>(double a)
		{
			return new Complex<D>(a, 0.0);
		}

		/// <summary>
		/// Convert Real Number to Complex Number
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public static implicit operator Complex<D>(D x)
		{
			Complex<D> result = default(Complex<D>);
			result.real = x;
			D d = Activator.CreateInstance<D>();
			result.imag = d.Zero;
			return result;
		}

		/// <summary>
		/// Overloading '+' operator
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public static Complex<D>operator +(Complex<D> x)
		{
			return x;
		}

		/// <summary>
		/// Overloading '-' operator
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public static Complex<D>operator -(Complex<D> x)
		{
			return new Complex<D>
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
		public static Complex<D>operator +(Complex<D> x, Complex<D> y)
		{
			return new Complex<D>
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
		public static Complex<D>operator -(Complex<D> x, Complex<D> y)
		{
			return new Complex<D>
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
		public static Complex<D>operator *(Complex<D> x, Complex<D> y)
		{
			Complex<D> result = default(Complex<D>);
			D t = x.real.Multiply(y.real);
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
		public static Complex<D>operator /(Complex<D> x, Complex<D> y)
		{
			D a = x.real;
			D b = x.imag;
			D c = y.real;
			D d = y.imag;
			D g;
			return new Complex<D>(Math.ComplexDivision<Complex<D>>(a, b, c, d, out g),g);
		}

		/// <summary>
		/// Initializes a Complex Number.
		/// </summary>
		/// <param name="real">Real Part</param>
		/// <param name="imag">Imaginary Part</param>
		public void InitReIm(D real, D imag)
		{
			this.real = real;
			this.imag = imag;
		}

		/// <summary>
		/// Initializes a Complex Number with Imaginary Part = 0.
		/// </summary>
		/// <param name="real">Real Part</param>
		public void InitRe(D real)
		{
			this.real = real;
			D d = Activator.CreateInstance<D>();
			this.imag = d.Zero;
		}

		/// <summary>
		/// Initializes a Complex Number.
		/// </summary>
		/// <param name="mag">Magnitude</param>
		/// <param name="phase">Phase</param>
		public void InitMagPhase(D mag, D phase)
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
			this.real = Activator.CreateInstance<D>();
			this.real.InitDbl(real);
			this.imag = Activator.CreateInstance<D>();
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
			this.real = Activator.CreateInstance<D>();
			this.real.InitDbl(value);
			D d = Activator.CreateInstance<D>();
			this.imag = d.Zero;
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
		public Complex<D> FcnValue2()
		{
			return new Complex<D>(this.real.FcnValue2(), this.imag.FcnValue2());
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
			//Nuvo.Math.Misc.Console.Debug(this);
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
			this.real = Activator.CreateInstance<D>();
			this.real.BinarySetDataFrom(reader);
			this.imag = Activator.CreateInstance<D>();
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
		public Complex<D> BinaryDeserialize(string filepath)
		{
			return Storage.BinaryDeserialize<Complex<D>>(filepath);
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
		public Complex<D> BinaryDeserializeFromByteArray(byte[] data)
		{
			return Storage.BinaryDeserializeFromByteArray<Complex<D>>(data);
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
		public Complex<D> XmlDeserialize(string filepath)
		{
			return Storage.XmlDeserialize<Complex<D>>(filepath);
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
		public Complex<D> XmlDeserializeFromString(string xml_string)
		{
			return Storage.XmlDeserializeFromString<Complex<D>>(xml_string);
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
		public Complex<D> Zero
		{
			get
			{
				Complex<D> result = default(Complex<D>);
				D t = Activator.CreateInstance<D>();
				result.real = t.Zero;
				t = Activator.CreateInstance<D>();
				result.imag = t.Zero;
				return result;
			}
		}

		/// <summary>
		/// Returns the neutral element of multiplication
		/// </summary>
		/// <value>e</value>
		public Complex<D> One
		{
			get
			{
				Complex<D> result = default(Complex<D>);
				D t = Activator.CreateInstance<D>();
				result.real = t.One;
				t = Activator.CreateInstance<D>();
				result.imag = t.Zero;
				return result;
			}
		}

		/// <summary>
		/// Returns the sum of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the sum</returns>
		public Complex<D> Add(Complex<D> b)
		{
			return this + b;
		}

		/// <summary>
		/// Returns the difference of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the difference</returns>
		public Complex<D> Subtract(Complex<D> b)
		{
			return this - b;
		}

		/// <summary>
		/// Returns the negative of the object.
		/// </summary>
		/// <returns>The negative</returns>
		public Complex<D> Negative()
		{
			return -this;
		}

		/// <summary>
		/// Returns the product of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the product</returns>
		public Complex<D> Multiply(Complex<D> b)
		{
			return this * b;
		}

		/// <summary>
		/// Returns the quotient of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the quotient</returns>
		public Complex<D> Divide(Complex<D> b)
		{
			return this / b;
		}

		/// <summary>
		/// Returns e raised to the specified power.
		/// </summary>
		/// <returns></returns>
		public Complex<D> Exp()
		{
			return this.real.Exp() * (this.imag.Cos() + this.imag.Sin() * this.J);
		}

		/// <summary>
		/// Returns e raised to the specified power.
		/// </summary>
		/// <returns></returns>
		public Complex<D> Exp(D a) 
		{
			Complex<D> val = a;
			return val.real.Exp() * (val.imag.Cos() + val.imag.Sin() * val.J);
		}

		/// <summary>
		/// Returns the natural (base e) logarithm of a specified number.
		/// </summary>
		/// <returns></returns>
		public Complex<D> Log()
		{
			D t = this.Abs();
			return t.Log() + this.Angle() * this.J;
		}

		/// <summary>
		/// Returns the logarithm of a specified number in a specified base.
		/// </summary>
		/// <param name="newBase"></param>
		/// <returns></returns>
		public Complex<D> Log(Complex<D> newBase)
		{
			return this.Log() / newBase.Log();
		}

		/// <summary>
		/// Returns the base 10 logarithm of a specified number.
		/// </summary>
		/// <returns></returns>
		public Complex<D> Log10()
		{
			return this.Log(10.0);
		}

		/// <summary>
		/// Returns a specified number raised to the specified power.
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		public Complex<D> Pow(Complex<D> b)
		{
			return (b * this.Log()).Exp();
		}

		/// <summary>
		/// Returns a specified number raised to the specified power.
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		public Complex<D> Pow(int b)
		{
			if (b == 0)
			{
				return 1.0;
			}
			D c = Activator.CreateInstance<D>();
			c.InitDbl((double)b);
			D rho = this.Abs();
			D theta = this.imag.Atan2(this.real);
			D newRho = c.Multiply(theta);
			D t = rho.Pow(b);
			return new Complex<D>
			{
				real = t.Multiply(newRho.Cos()),
				imag = t.Multiply(newRho.Sin())
			};
		}

		/// <summary>
		/// Returns the square root of a specified number.
		/// </summary>
		/// <returns></returns>
		public Complex<D> Sqrt()
		{
			D r = this.Abs();
			D a = this.Angle();
			D r_sqrt = r.Sqrt();
			D two = Activator.CreateInstance<D>();
			two.InitDbl(2.0);
			D a_2 = a.Divide(two);
			return new Complex<D>
			{
				real = r_sqrt.Multiply(a_2.Cos()),
				imag = r_sqrt.Multiply(a_2.Sin())
			};
		}

		/// <summary>
		/// Returns the sine of the specified angle.
		/// </summary>
		/// <returns></returns>
		public Complex<D> Sin()
		{
			D a = this.real;
			D b = this.imag;
			D t = a.Sin();
			D r = t.Multiply(b.Cosh());
			t = a.Cos();
			return new Complex<D>(r, t.Multiply(b.Sinh()));
		}

		/// <summary>
		/// Returns the cosine of the specified angle.
		/// </summary>
		/// <returns></returns>
		public Complex<D> Cos()
		{
			D a = this.real;
			D b = this.imag;
			D t = a.Cos();
			D r = t.Multiply(b.Cosh());
			t = a.Sin();
			t = t.Multiply(b.Sinh());
			return new Complex<D>(r, t.Negative());
		}

		/// <summary>
		/// Returns the tangent of the specified angle.
		/// </summary>
		/// <returns></returns>
		public Complex<D> Tan()
		{
			D t = Activator.CreateInstance<D>();
			D one = t.One;
			D a = this.real;
			D b = this.imag;
			D tan_a = a.Tan();
			D tanh_b = b.Tanh();
			Complex<D> x = new Complex<D>(tan_a, tanh_b);
			D r = one;
			t = tan_a.Multiply(tanh_b);
			Complex<D> den = new Complex<D>(r, t.Negative());
			return x / den;
		}

		/// <summary>
		/// Returns the angle whose sine is the specified number.
		/// </summary>
		/// <returns></returns>
		public Complex<D> Asin()
		{
			return -this.J * (this.J * this + (1.0 - this * this).Sqrt()).Log();
		}

		/// <summary>
		/// Returns the angle whose cosine is the specified number.
		/// </summary>
		/// <returns></returns>
		public Complex<D> Acos()
		{
			return -this.J * (this + this.J * (1.0 - this * this).Sqrt()).Log();
		}

		/// <summary>
		/// Returns the angle whose tangent is the specified number.
		/// </summary>
		/// <returns></returns>
		public Complex<D> Atan()
		{
			return ((1.0 + this.J * this) / (1.0 - this.J * this)).Log() / (this.J * 2.0);
		}

		/// <summary>
		/// Returns the hyperbolic sine of the specified angle.
		/// </summary>
		/// <returns></returns>
		public Complex<D> Sinh()
		{
			D a = this.real;
			D b = this.imag;
			D t = a.Sinh();
			D r = t.Multiply(b.Cos());
			t = a.Cosh();
			return new Complex<D>(r, t.Multiply(b.Sin()));
		}

		/// <summary>
		/// Returns the hyperbolic cosine of the specified angle.
		/// </summary>
		/// <returns></returns>
		public Complex<D> Cosh()
		{
			D a = this.real;
			D b = this.imag;
			D t = a.Cosh();
			D r = t.Multiply(b.Cos());
			t = a.Sinh();
			return new Complex<D>(r, t.Multiply(b.Sin()));
		}

		/// <summary>
		/// Returns the hyperbolic tangent of the specified angle.
		/// </summary>
		/// <returns></returns>
		public Complex<D> Tanh()
		{
			D t = Activator.CreateInstance<D>();
			D one = t.One;
			D a = this.real;
			D b = this.imag;
			D tanh_a = a.Tanh();
			D tan_b = b.Tan();
			Complex<D> x = new Complex<D>(tanh_a, tan_b);
			Complex<D> den = new Complex<D>(one, tanh_a.Multiply(tan_b));
			return x / den;
		}

		/// <summary>
		/// Returns the angle whose hyperbolic sine is the specified number.
		/// </summary>
		/// <returns></returns>
		public Complex<D> Asinh()
		{
			return (this + (this * this + 1.0).Sqrt()).Log();
		}

		/// <summary>
		/// Returns the angle whose hyperbolic cosine is the specified number.
		/// </summary>
		/// <returns></returns>
		public Complex<D> Acosh()
		{
			return (this + (this * this - 1.0).Sqrt()).Log();
		}

		/// <summary>
		/// Returns the angle whose hyperbolic tangent is the specified number.
		/// </summary>
		/// <returns></returns>
		public Complex<Number> Atanh()
		{
			return ((1.0 + this) / (1.0 - this)).Log() / 2.0;
		}

		/// <summary>
		/// Returns the complex conjugate.
		/// </summary>
		/// <returns></returns>
		public Complex<Number> Conj()
		{
			return this.real - this.imag * this.J;
		}

		/// <summary>
		/// Returns the real part.
		/// </summary>
		/// <returns></returns>
		public Number Real()
		{
			return this.real;
		}

		/// <summary>
		/// Returns the imaginary part.
		/// </summary>
		/// <returns></returns>
		public Number Imag()
		{
			return this.imag;
		}

		/// <summary>
		/// Returns the absolute value.
		/// </summary>
		/// <returns></returns>
		public Number Abs()
		{
			return Math.ComplexAbs(this.real, this.imag);
		}

		/// <summary>
		/// Returns the angle.
		/// </summary>
		/// <returns></returns>
		public Number Angle()
		{
			return this.imag.Atan2(this.real);
		}

		/// <summary>
		/// Real Part
		/// </summary>
		[XmlElement("Real")]
		public Number real;

		/// <summary>
		/// Imaginary Part
		/// </summary>
		[XmlElement("Imag")]
		public Number imag;
	}
}
