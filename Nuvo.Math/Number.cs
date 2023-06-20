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
    // Token: 0x02000009 RID: 9
    [XmlType("Number")]
    [Serializable]
    public struct Number : IRealNumber<Number>, INumber<Number>, IConsole, IStorage<Number>, Interface.IComparable, IElementArithmetic<Number>, IArithmetic<Number>, IMath<Number>, IRealMath<Number>
    {
        /// <summary>
        /// Value
        /// </summary>
        // Token: 0x1700000A RID: 10
        // (get) Token: 0x060000CC RID: 204 RVA: 0x00006FD1 File Offset: 0x000051D1
        // (set) Token: 0x060000CD RID: 205 RVA: 0x00006FD9 File Offset: 0x000051D9
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
        // Token: 0x060000CE RID: 206 RVA: 0x00006FD9 File Offset: 0x000051D9
        public Number(double value)
        {
            this._value = value;
        }

        /// <summary>
        /// Convert double to Real Number
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        // Token: 0x060000CF RID: 207 RVA: 0x00006FE4 File Offset: 0x000051E4
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
        // Token: 0x060000D0 RID: 208 RVA: 0x0000270C File Offset: 0x0000090C
        public static Number operator +(Number a)
        {
            return a;
        }

        /// <summary>
        /// Overloading '-' operator
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        // Token: 0x060000D1 RID: 209 RVA: 0x00007004 File Offset: 0x00005204
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
        // Token: 0x060000D2 RID: 210 RVA: 0x00007028 File Offset: 0x00005228
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
        // Token: 0x060000D3 RID: 211 RVA: 0x00007054 File Offset: 0x00005254
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
        // Token: 0x060000D4 RID: 212 RVA: 0x00007080 File Offset: 0x00005280
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
        // Token: 0x060000D5 RID: 213 RVA: 0x000070AC File Offset: 0x000052AC
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
        // Token: 0x1700000B RID: 11
        // (get) Token: 0x060000D6 RID: 214 RVA: 0x00006FD1 File Offset: 0x000051D1
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
        // Token: 0x1700000C RID: 12
        // (get) Token: 0x060000D7 RID: 215 RVA: 0x00006FD1 File Offset: 0x000051D1
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
        // Token: 0x1700000D RID: 13
        // (get) Token: 0x060000D8 RID: 216 RVA: 0x000070D6 File Offset: 0x000052D6
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
        // Token: 0x1700000E RID: 14
        // (get) Token: 0x060000D9 RID: 217 RVA: 0x000070D9 File Offset: 0x000052D9
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
        // Token: 0x1700000F RID: 15
        // (get) Token: 0x060000DA RID: 218 RVA: 0x000070D9 File Offset: 0x000052D9
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
        // Token: 0x060000DB RID: 219 RVA: 0x000070D9 File Offset: 0x000052D9
        public double GetMoment(int n)
        {
            return 0.0;
        }

        /// <summary>
        /// Computes the Coverage Interval
        /// </summary>
        /// <param name="p">Probability</param>
        /// <returns></returns>
        // Token: 0x060000DC RID: 220 RVA: 0x000070E4 File Offset: 0x000052E4
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
        // Token: 0x060000DD RID: 221 RVA: 0x00006FD9 File Offset: 0x000051D9
        public void InitDbl(double value)
        {
            this._value = value;
        }

        /// <summary>
        /// Returns the square function value.
        /// </summary>
        /// <returns></returns>
        // Token: 0x060000DE RID: 222 RVA: 0x000070FE File Offset: 0x000052FE
        public double DblSqrFcnValue()
        {
            return this._value * this._value;
        }

        /// <summary>
        /// Returns the function value.
        /// </summary>
        /// <returns></returns>
        // Token: 0x060000DF RID: 223 RVA: 0x0000710D File Offset: 0x0000530D
        public Number FcnValue2()
        {
            return new Number(this.FcnValue);
        }

        /// <summary>
        /// Number of bytes allocated for the Object.
        /// </summary>
        // Token: 0x17000010 RID: 16
        // (get) Token: 0x060000E0 RID: 224 RVA: 0x0000711A File Offset: 0x0000531A
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
        // Token: 0x060000E1 RID: 225 RVA: 0x0000711D File Offset: 0x0000531D
        public override string ToString()
        {
            return this._value.ToString();
        }

        /// <summary>
        /// Debug an Object
        /// </summary>
        // Token: 0x060000E2 RID: 226 RVA: 0x0000712A File Offset: 0x0000532A
        public void Debug()
        {
            //Nuvo.Math.Core.Misc.Console.Debug(this);
        }

        /// <summary>
        /// Write object data to Binary Writer.
        /// </summary>
        /// <param name="writer">Binary Writer</param>
        // Token: 0x060000E3 RID: 227 RVA: 0x0000713C File Offset: 0x0000533C
        public void BinaryWriteDataTo(BinaryWriter writer)
        {
            writer.Write(this._value);
        }

        /// <summary>
        /// Set object data from Binary Reader.
        /// </summary>
        /// <param name="reader">Binary Reader</param>
        // Token: 0x060000E4 RID: 228 RVA: 0x0000714A File Offset: 0x0000534A
        public void BinarySetDataFrom(BinaryReader reader)
        {
            this._value = reader.ReadDouble();
        }

        /// <summary>
        /// Binary Serialize an Object to File.
        /// </summary>
        /// <param name="filepath">File Path</param>
        // Token: 0x060000E5 RID: 229 RVA: 0x00007158 File Offset: 0x00005358
        public void BinarySerialize(string filepath)
        {
            Storage.BinarySerialize(this, filepath);
        }

        /// <summary>
        /// Binary Deserialize an Object from File.
        /// </summary>
        /// <param name="filepath">File Path</param>
        /// <returns>Object</returns>
        // Token: 0x060000E6 RID: 230 RVA: 0x0000716B File Offset: 0x0000536B
        public Number BinaryDeserialize(string filepath)
        {
            return Storage.BinaryDeserialize<Number>(filepath);
        }

        /// <summary>
        /// Binary Serialize an Object to a byte array.
        /// </summary>
        /// <returns>Binary Data</returns>
        // Token: 0x060000E7 RID: 231 RVA: 0x00007173 File Offset: 0x00005373
        public byte[] BinarySerializeToByteArray()
        {
            return Storage.BinarySerializeToByteArray(this);
        }

        /// <summary>
        /// Binary Deserialize an Object from a byte array.
        /// </summary>
        /// <param name="data">Binary Data</param>
        /// <returns>Object</returns>
        // Token: 0x060000E8 RID: 232 RVA: 0x00007185 File Offset: 0x00005385
        public Number BinaryDeserializeFromByteArray(byte[] data)
        {
            return Storage.BinaryDeserializeFromByteArray<Number>(data);
        }

        /// <summary>
        /// Xml Serialize an Object to File.
        /// </summary>
        /// <param name="filepath">File Path</param>
        // Token: 0x060000E9 RID: 233 RVA: 0x0000718D File Offset: 0x0000538D
        public void XmlSerialize(string filepath)
        {
            Storage.XmlSerialize(this, filepath);
        }

        /// <summary>
        /// Xml Deserialize an Object from File.
        /// </summary>
        /// <param name="filepath">File Path</param>
        /// <returns>Object</returns>
        // Token: 0x060000EA RID: 234 RVA: 0x000071A0 File Offset: 0x000053A0
        public Number XmlDeserialize(string filepath)
        {
            return Storage.XmlDeserialize<Number>(filepath);
        }

        /// <summary>
        /// Xml Serialize an Object to String.
        /// </summary>
        /// <returns>XML String</returns>
        // Token: 0x060000EB RID: 235 RVA: 0x000071A8 File Offset: 0x000053A8
        public string XmlSerializeToString()
        {
            return Storage.XmlSerializeToString(this);
        }

        /// <summary>
        /// Xml Deserialize an Object from String.
        /// </summary>
        /// <param name="xml_string">Xml String</param>
        /// <returns>Object</returns>
        // Token: 0x060000EC RID: 236 RVA: 0x000071BA File Offset: 0x000053BA
        public Number XmlDeserializeFromString(string xml_string)
        {
            return Storage.XmlDeserializeFromString<Number>(xml_string);
        }

        /// <summary>
        /// Returns true if the Value of an Object is equal to zero.
        /// </summary>
        /// <returns></returns>
        // Token: 0x060000ED RID: 237 RVA: 0x000071C2 File Offset: 0x000053C2
        public bool IsZero()
        {
            return this._value == 0.0;
        }

        /// <summary>
        /// Returns true if the Value of an Object is not equal to zero.
        /// </summary>
        /// <returns></returns>
        // Token: 0x060000EE RID: 238 RVA: 0x000071D5 File Offset: 0x000053D5
        public bool IsNotZero()
        {
            return this._value != 0.0;
        }

        /// <summary>
        /// Returns the neutral element of addition
        /// </summary>
        /// <value>e</value>
        // Token: 0x17000011 RID: 17
        // (get) Token: 0x060000EF RID: 239 RVA: 0x000071EB File Offset: 0x000053EB
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
        // Token: 0x17000012 RID: 18
        // (get) Token: 0x060000F0 RID: 240 RVA: 0x000071FB File Offset: 0x000053FB
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
        // Token: 0x060000F1 RID: 241 RVA: 0x0000720B File Offset: 0x0000540B
        public Number Add(Number b)
        {
            return this + b;
        }

        /// <summary>
        /// Returns the difference of the object and <paramref name="b" />.
        /// </summary>
        /// <param name="b">The second operand</param>
        /// <returns>the difference</returns>
        // Token: 0x060000F2 RID: 242 RVA: 0x00007219 File Offset: 0x00005419
        public Number Subtract(Number b)
        {
            return this - b;
        }

        /// <summary>
        /// Returns the negative of the object.
        /// </summary>
        /// <returns>The negative</returns>
        // Token: 0x060000F3 RID: 243 RVA: 0x00007227 File Offset: 0x00005427
        public Number Negative()
        {
            return -this;
        }

        /// <summary>
        /// Returns the product of the object and <paramref name="b" />.
        /// </summary>
        /// <param name="b">The second operand</param>
        /// <returns>the product</returns>
        // Token: 0x060000F4 RID: 244 RVA: 0x00007234 File Offset: 0x00005434
        public Number Multiply(Number b)
        {
            return this * b;
        }

        /// <summary>
        /// Returns the quotient of the object and <paramref name="b" />.
        /// </summary>
        /// <param name="b">The second operand</param>
        /// <returns>the quotient</returns>
        // Token: 0x060000F5 RID: 245 RVA: 0x00007242 File Offset: 0x00005442
        public Number Divide(Number b)
        {
            return this / b;
        }

        /// <summary>
        /// Returns e raised to the specified power.
        /// </summary>
        /// <returns></returns>
        // Token: 0x060000F6 RID: 246 RVA: 0x00007250 File Offset: 0x00005450
        public Number Exp()
        {
            return System.Math.Exp(this._value);
        }

        /// <summary>
        /// Returns the natural (base e) logarithm of a specified number.
        /// </summary>
        /// <returns></returns>
        // Token: 0x060000F7 RID: 247 RVA: 0x00007262 File Offset: 0x00005462
        public Number Log()
        {
            return System.Math.Log(this._value);
        }

        /// <summary>
        /// Returns the logarithm of a specified number in a specified base.
        /// </summary>
        /// <param name="newBase"></param>
        /// <returns></returns>
        // Token: 0x060000F8 RID: 248 RVA: 0x00007274 File Offset: 0x00005474
        public Number Log(Number newBase)
        {
            return System.Math.Log(this._value) / System.Math.Log(newBase._value);
        }

        /// <summary>
        /// Returns the base 10 logarithm of a specified number.
        /// </summary>
        /// <returns></returns>
        // Token: 0x060000F9 RID: 249 RVA: 0x00007292 File Offset: 0x00005492
        public Number Log10()
        {
            return System.Math.Log10(this._value);
        }

        /// <summary>
        /// Returns a specified number raised to the specified power.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        // Token: 0x060000FA RID: 250 RVA: 0x000072A4 File Offset: 0x000054A4
        public Number Pow(Number b)
        {
            return System.Math.Pow(this._value, b._value);
        }

        /// <summary>
        /// Returns a specified number raised to the specified power.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        // Token: 0x060000FB RID: 251 RVA: 0x000072BC File Offset: 0x000054BC
        public Number Pow(int b)
        {
            return System.Math.Pow(this._value, (double)b);
        }

        /// <summary>
        /// Returns the square root of a specified number.
        /// </summary>
        /// <returns></returns>
        // Token: 0x060000FC RID: 252 RVA: 0x000072D0 File Offset: 0x000054D0
        public Number Sqrt()
        {
            return System.Math.Sqrt(this._value);
        }

        /// <summary>
        /// Returns the sine of the specified angle.
        /// </summary>
        /// <returns></returns>
        // Token: 0x060000FD RID: 253 RVA: 0x000072E2 File Offset: 0x000054E2
        public Number Sin()
        {
            return System.Math.Sin(this._value);
        }

        /// <summary>
        /// Returns the cosine of the specified angle.
        /// </summary>
        /// <returns></returns>
        // Token: 0x060000FE RID: 254 RVA: 0x000072F4 File Offset: 0x000054F4
        public Number Cos()
        {
            return System.Math.Cos(this._value);
        }

        /// <summary>
        /// Returns the tangent of the specified angle.
        /// </summary>
        /// <returns></returns>
        // Token: 0x060000FF RID: 255 RVA: 0x00007306 File Offset: 0x00005506
        public Number Tan()
        {
            return System.Math.Tan(this._value);
        }

        /// <summary>
        /// Returns the angle whose sine is the specified number.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000100 RID: 256 RVA: 0x00007318 File Offset: 0x00005518
        public Number Asin()
        {
            return System.Math.Asin(this._value);
        }

        /// <summary>
        /// Returns the angle whose cosine is the specified number.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000101 RID: 257 RVA: 0x0000732A File Offset: 0x0000552A
        public Number Acos()
        {
            return System.Math.Acos(this._value);
        }

        /// <summary>
        /// Returns the angle whose tangent is the specified number.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000102 RID: 258 RVA: 0x0000733C File Offset: 0x0000553C
        public Number Atan()
        {
            return System.Math.Atan(this._value);
        }

        /// <summary>
        /// Returns the hyperbolic sine of the specified angle.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000103 RID: 259 RVA: 0x0000734E File Offset: 0x0000554E
        public Number Sinh()
        {
            return System.Math.Sinh(this._value);
        }

        /// <summary>
        /// Returns the hyperbolic cosine of the specified angle.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000104 RID: 260 RVA: 0x00007360 File Offset: 0x00005560
        public Number Cosh()
        {
            return System.Math.Cosh(this._value);
        }

        /// <summary>
        /// Returns the hyperbolic tangent of the specified angle.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000105 RID: 261 RVA: 0x00007372 File Offset: 0x00005572
        public Number Tanh()
        {
            return System.Math.Tanh(this._value);
        }

        /// <summary>
        /// Returns the angle whose hyperbolic sine is the specified number.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000106 RID: 262 RVA: 0x00007384 File Offset: 0x00005584
        public Number Asinh()
        {
            return (this + (this * this + 1.0).Sqrt()).Log();
        }

        /// <summary>
        /// Returns the angle whose hyperbolic cosine is the specified number.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000107 RID: 263 RVA: 0x000073D0 File Offset: 0x000055D0
        public Number Acosh()
        {
            return (this + (this * this - 1.0).Sqrt()).Log();
        }

        /// <summary>
        /// Returns the angle whose hyperbolic tangent is the specified number.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000108 RID: 264 RVA: 0x0000741C File Offset: 0x0000561C
        public Number Atanh()
        {
            return ((1.0 + this) / (1.0 - this)).Log() / 2.0;
        }

        /// <summary>
        /// Returns the complex conjugate.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000109 RID: 265 RVA: 0x0000747B File Offset: 0x0000567B
        public Number Conj()
        {
            return this;
        }

        /// <summary>
        /// Returns the absolute value.
        /// </summary>
        /// <returns></returns>
        // Token: 0x0600010A RID: 266 RVA: 0x00007483 File Offset: 0x00005683
        public Number Abs()
        {
            return System.Math.Abs(this._value);
        }

        /// <summary>
        /// Returns a value indicating the sign of a number.
        /// </summary>
        /// <returns></returns>
        // Token: 0x0600010B RID: 267 RVA: 0x00007495 File Offset: 0x00005695
        public Number Sign()
        {
            return (double)System.Math.Sign(this._value);
        }

        /// <summary>
        /// Returns the angle whose tangent is the quotient of two specified numbers.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        // Token: 0x0600010C RID: 268 RVA: 0x000074A8 File Offset: 0x000056A8
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
        // Token: 0x0600010D RID: 269 RVA: 0x000074C0 File Offset: 0x000056C0
        public Number ComplexDivision(Number _b, Number _c, Number _d, out Number _f)
        {
            return Math.StandardComplexDivision<Number>(this, _b, _c, _d, out _f);
        }

        /// <summary>
        /// Complex absolute value
        /// </summary>
        /// <param name="_b">Imag part</param>
        /// <returns></returns>
        // Token: 0x0600010E RID: 270 RVA: 0x000074D2 File Offset: 0x000056D2
        public Number ComplexAbs(Number _b)
        {
            return Math.StandardComplexAbs<Number>(this, _b);
        }

        // Token: 0x0400000D RID: 13
        private double _value;
    }
}
