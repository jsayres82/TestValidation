using System;
using System.IO;
using System.Xml.Serialization;
using Nuvo.Math.Interface;
using Nuvo.Math.Misc;

namespace Nuvo.Math
{
	/// <summary>
	/// Real Number
	/// </summary>    
	[XmlType("Number")]
	[Serializable]
	public struct Number : IRealNumber<Number>, INumber<Number>, IConsole, IStorage<Number>, Interface.IComparable, IElementArithmetic<Number>, IArithmetic<Number>, IMath<Number>, IRealMath<Number>
	{
		/// <summary>
		/// Value
		/// </summary>
		[XmlElement("Value")]
		public double Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
			}
		}

		/// <summary>
		/// Creates a new Real Number
		/// </summary>
		/// <param name="value"></param>
		public Number(double value)
		{
			this._value = value;
		}

		/// <summary>
		/// Convert double to Real Number
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static implicit operator Number(double a)
		{
			return new Number
			{
				_value = a
			};
		}

		/// <summary>
		/// Overloading '+' operator
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static Number operator +(Number a)
		{
			return a;
		}

		/// <summary>
		/// Overloading '-' operator
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static Number operator -(Number a)
		{
			return new Number
			{
				_value = -a._value
			};
		}

		/// <summary>
		/// Overloading '+' operator
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static Number operator +(Number a, Number b)
		{
			return new Number
			{
				_value = a._value + b._value
			};
		}

		/// <summary>
		/// Overloading '-' operator
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static Number operator -(Number a, Number b)
		{
			return new Number
			{
				_value = a._value - b._value
			};
		}

		/// <summary>
		/// Overloading '*' operator
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static Number operator *(Number a, Number b)
		{
			return new Number
			{
				_value = a._value * b._value
			};
		}

		/// <summary>
		/// Overloading '/' operator
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static Number operator /(Number a, Number b)
		{
			return new Number
			{
				_value = a._value / b._value
			};
		}

		/// <summary>
		/// Expected Value
		/// </summary>
		public double ExpValue
		{
			get
			{
				return this._value;
			}
		}

		/// <summary>
		/// Function Value
		/// </summary>
		public double FcnValue
		{
			get
			{
				return this._value;
			}
		}

		/// <summary>
		/// Returns true if it's a Const
		/// </summary>
		public bool IsConst
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// Computes the Standard Uncertainty
		/// </summary>
		public double StdUnc
		{
			get
			{
				return 0.0;
			}
		}

		/// <summary>
		/// Computes the Inverse of the Degrees of Freedom
		/// </summary>
		public double IDof
		{
			get
			{
				return 0.0;
			}
		}

		/// <summary>
		/// Computes the n-th Central Moment
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		public double GetMoment(int n)
		{
			return 0.0;
		}

		/// <summary>
		/// Computes the Coverage Interval
		/// </summary>
		/// <param name="p">Probability</param>
		/// <returns></returns>
		public double[] GetCoverageInterval(double p)
		{
			return new double[]
			{
				this.Value,
				this.Value
			};
		}

		/// <summary>
		/// Initializes a Real Number
		/// </summary>
		/// <param name="value"></param>
		public void InitDbl(double value)
		{
			this._value = value;
		}

		/// <summary>
		/// Returns the square function value.
		/// </summary>
		/// <returns></returns>
		public double DblSqrFcnValue()
		{
			return this._value * this._value;
		}

		/// <summary>
		/// Returns the function value.
		/// </summary>
		/// <returns></returns>
		public Number FcnValue2()
		{
			return new Number(this.FcnValue);
		}

		/// <summary>
		/// Number of bytes allocated for the Object.
		/// </summary>
		public int memsize
		{
			get
			{
				return 8;
			}
		}

		/// <summary>
		/// Override ToString() to display an Object.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return this._value.ToString();
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
			writer.Write(this._value);
		}

		/// <summary>
		/// Set object data from Binary Reader.
		/// </summary>
		/// <param name="reader">Binary Reader</param>
		public void BinarySetDataFrom(BinaryReader reader)
		{
			this._value = reader.ReadDouble();
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
		public Number BinaryDeserialize(string filepath)
		{
			return Storage.BinaryDeserialize<Number>(filepath);
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
		public Number BinaryDeserializeFromByteArray(byte[] data)
		{
			return Storage.BinaryDeserializeFromByteArray<Number>(data);
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
		/// <param name="filepath">File Path</param>
		/// <returns>Object</returns>
		public Number XmlDeserialize(string filepath)
		{
			return Storage.XmlDeserialize<Number>(filepath);
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
		public Number XmlDeserializeFromString(string xml_string)
		{
			return Storage.XmlDeserializeFromString<Number>(xml_string);
		}

		/// <summary>
		/// Returns true if the Value of an Object is equal to zero.
		/// </summary>
		/// <returns></returns>
		public bool IsZero()
		{
			return this._value == 0.0;
		}

		/// <summary>
		/// Returns true if the Value of an Object is not equal to zero.
		/// </summary>
		/// <returns></returns>
		public bool IsNotZero()
		{
			return this._value != 0.0;
		}

		/// <summary>
		/// Returns the neutral element of addition
		/// </summary>
		/// <value>e</value>
		public Number Zero
		{
			get
			{
				return 0.0;
			}
		}

		/// <summary>
		/// Returns the neutral element of multiplication
		/// </summary>
		/// <value>e</value>
		public Number One
		{
			get
			{
				return 1.0;
			}
		}

		/// <summary>
		/// Returns the sum of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the sum</returns>
		public Number Add(Number b)
		{
			return this + b;
		}

		/// <summary>
		/// Returns the difference of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the difference</returns>
		public Number Subtract(Number b)
		{
			return this - b;
		}

		/// <summary>
		/// Returns the negative of the object.
		/// </summary>
		/// <returns>The negative</returns>
		public Number Negative()
		{
			return -this;
		}

		/// <summary>
		/// Returns the product of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the product</returns>
		public Number Multiply(Number b)
		{
			return this * b;
		}

		/// <summary>
		/// Returns the quotient of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the quotient</returns>
		public Number Divide(Number b)
		{
			return this / b;
		}

		/// <summary>
		/// Returns e raised to the specified power.
		/// </summary>
		/// <returns></returns>
		public Number Exp()
		{
			return System.Math.Exp(this._value);
		}

		/// <summary>
		/// Returns the natural (base e) logarithm of a specified number.
		/// </summary>
		/// <returns></returns>
		public Number Log()
		{
			return System.Math.Log(this._value);
		}

		/// <summary>
		/// Returns the logarithm of a specified number in a specified base.
		/// </summary>
		/// <param name="newBase"></param>
		/// <returns></returns>
		public Number Log(Number newBase)
		{
			return System.Math.Log(this._value) / System.Math.Log(newBase._value);
		}

		/// <summary>
		/// Returns the base 10 logarithm of a specified number.
		/// </summary>
		/// <returns></returns>
		public Number Log10()
		{
			return System.Math.Log10(this._value);
		}

		/// <summary>
		/// Returns a specified number raised to the specified power.
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		public Number Pow(Number b)
		{
			return System.Math.Pow(this._value, b._value);
		}

		/// <summary>
		/// Returns a specified number raised to the specified power.
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		public Number Pow(int b)
		{
			return System.Math.Pow(this._value, (double)b);
		}

		/// <summary>
		/// Returns the square root of a specified number.
		/// </summary>
		/// <returns></returns>
		public Number Sqrt()
		{
			return System.Math.Sqrt(this._value);
		}

		/// <summary>
		/// Returns the sine of the specified angle.
		/// </summary>
		/// <returns></returns>
		public Number Sin()
		{
			return System.Math.Sin(this._value);
		}

		/// <summary>
		/// Returns the cosine of the specified angle.
		/// </summary>
		/// <returns></returns>
		public Number Cos()
		{
			return System.Math.Cos(this._value);
		}

		/// <summary>
		/// Returns the tangent of the specified angle.
		/// </summary>
		/// <returns></returns>
		public Number Tan()
		{
			return System.Math.Tan(this._value);
		}

		/// <summary>
		/// Returns the angle whose sine is the specified number.
		/// </summary>
		/// <returns></returns>
		public Number Asin()
		{
			return System.Math.Asin(this._value);
		}

		/// <summary>
		/// Returns the angle whose cosine is the specified number.
		/// </summary>
		/// <returns></returns>
		public Number Acos()
		{
			return System.Math.Acos(this._value);
		}

		/// <summary>
		/// Returns the angle whose tangent is the specified number.
		/// </summary>
		/// <returns></returns>
		public Number Atan()
		{
			return System.Math.Atan(this._value);
		}

		/// <summary>
		/// Returns the hyperbolic sine of the specified angle.
		/// </summary>
		/// <returns></returns>
		public Number Sinh()
		{
			return System.Math.Sinh(this._value);
		}

		/// <summary>
		/// Returns the hyperbolic cosine of the specified angle.
		/// </summary>
		/// <returns></returns>
		public Number Cosh()
		{
			return System.Math.Cosh(this._value);
		}

		/// <summary>
		/// Returns the hyperbolic tangent of the specified angle.
		/// </summary>
		/// <returns></returns>
		public Number Tanh()
		{
			return System.Math.Tanh(this._value);
		}

		/// <summary>
		/// Returns the angle whose hyperbolic sine is the specified number.
		/// </summary>
		/// <returns></returns>
		public Number Asinh()
		{
			return (this + (this * this + 1.0).Sqrt()).Log();
		}

		/// <summary>
		/// Returns the angle whose hyperbolic cosine is the specified number.
		/// </summary>
		/// <returns></returns>
		public Number Acosh()
		{
			return (this + (this * this - 1.0).Sqrt()).Log();
		}

		/// <summary>
		/// Returns the angle whose hyperbolic tangent is the specified number.
		/// </summary>
		/// <returns></returns>
		public Number Atanh()
		{
			return ((1.0 + this) / (1.0 - this)).Log() / 2.0;
		}

		/// <summary>
		/// Returns the complex conjugate.
		/// </summary>
		/// <returns></returns>
		public Number Conj()
		{
			return this;
		}

		/// <summary>
		/// Returns the absolute value.
		/// </summary>
		/// <returns></returns>
		public Number Abs()
		{
			return System.Math.Abs(this._value);
		}

		/// <summary>
		/// Returns a value indicating the sign of a number.
		/// </summary>
		/// <returns></returns>
		public Number Sign()
		{
			return (double)System.Math.Sign(this._value);
		}

		/// <summary>
		/// Returns the angle whose tangent is the quotient of two specified numbers.
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		public Number Atan2(Number b)
		{
			return System.Math.Atan2(this._value, b._value);
		}

		/// <summary>
		/// Complex division
		/// </summary>
		/// <param name="_b">Numerator imag part</param>
		/// <param name="_c">Denominator real part</param>
		/// <param name="_d">Denominator imag part</param>
		/// <param name="_f">Result imag part</param>
		/// <returns>Result real part</returns>
		public Number ComplexDivision(Number _b, Number _c, Number _d, out Number _f)
		{
			return Math.StandardComplexDivision<Number>(this, _b, _c, _d, out _f);
		}

		/// <summary>
		/// Complex absolute value
		/// </summary>
		/// <param name="_b">Imag part</param>
		/// <returns></returns>
		public Number ComplexAbs(Number _b)
		{
			return Math.StandardComplexAbs<Number>(this, _b);
		}

		private double _value;
	}
}
