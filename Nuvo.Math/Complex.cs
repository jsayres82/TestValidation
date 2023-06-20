using System;
using System.IO;
using System.Xml.Serialization;
using Nuvo.Math.Interface;
using Nuvo.Math.Misc;

namespace Nuvo.Math
{/// <summary>
 /// Generic Complex
 /// </summary>
 /// <typeparam name="T">Real Type</typeparam>
    // Token: 0x02000003 RID: 3
    [Serializable]
    public struct Complex<T> : IConsole where T : IRealNumber<T>, new()
    {
        /// <summary>
        /// Returns the square root of -1.
        /// </summary>
        /// <value></value>
        // Token: 0x17000001 RID: 1
        // (get) Token: 0x0600000C RID: 12 RVA: 0x000025CB File Offset: 0x000007CB
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
        // Token: 0x0600000D RID: 13 RVA: 0x000025E4 File Offset: 0x000007E4
        public Complex(T r, T i)
        {
            this.real = r;
            this.imag = i;
        }

        /// <summary>
        /// Creates a new Complex with Imaginary Part = 0
        /// </summary>
        /// <param name="r">Real Part</param>
        // Token: 0x0600000E RID: 14 RVA: 0x000025F4 File Offset: 0x000007F4
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
        // Token: 0x0600000F RID: 15 RVA: 0x00002624 File Offset: 0x00000824
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
        // Token: 0x06000010 RID: 16 RVA: 0x00002668 File Offset: 0x00000868
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
        // Token: 0x06000011 RID: 17 RVA: 0x000026C0 File Offset: 0x000008C0
        public static implicit operator Complex<T>(double a)
        {
            return new Complex<T>(a, 0.0);
        }

        /// <summary>
        /// Convert Real Number to Complex Number
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        // Token: 0x06000012 RID: 18 RVA: 0x000026D4 File Offset: 0x000008D4
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
        // Token: 0x06000013 RID: 19 RVA: 0x0000270C File Offset: 0x0000090C
        public static Complex<T> operator +(Complex<T> x)
        {
            return x;
        }

        /// <summary>
        /// Overloading '-' operator
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        // Token: 0x06000014 RID: 20 RVA: 0x00002710 File Offset: 0x00000910
        public static Complex<T> operator -(Complex<T> x)
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
        // Token: 0x06000015 RID: 21 RVA: 0x00002758 File Offset: 0x00000958
        public static Complex<T> operator +(Complex<T> x, Complex<T> y)
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
        // Token: 0x06000016 RID: 22 RVA: 0x000027AC File Offset: 0x000009AC
        public static Complex<T> operator -(Complex<T> x, Complex<T> y)
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
        // Token: 0x06000017 RID: 23 RVA: 0x00002800 File Offset: 0x00000A00
        public static Complex<T> operator *(Complex<T> x, Complex<T> y)
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
        // Token: 0x06000018 RID: 24 RVA: 0x000028A0 File Offset: 0x00000AA0
        public static Complex<T> operator /(Complex<T> x, Complex<T> y)
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
        // Token: 0x06000019 RID: 25 RVA: 0x000025E4 File Offset: 0x000007E4
        public void InitReIm(T real, T imag)
        {
            this.real = real;
            this.imag = imag;
        }

        /// <summary>
        /// Initializes a Complex Number with Imaginary Part = 0.
        /// </summary>
        /// <param name="real">Real Part</param>
        // Token: 0x0600001A RID: 26 RVA: 0x000028D8 File Offset: 0x00000AD8
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
        // Token: 0x0600001B RID: 27 RVA: 0x00002908 File Offset: 0x00000B08
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
        // Token: 0x0600001C RID: 28 RVA: 0x00002955 File Offset: 0x00000B55
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
        // Token: 0x0600001D RID: 29 RVA: 0x00002991 File Offset: 0x00000B91
        public double DblRealValue()
        {
            return this.real.Value;
        }

        /// <summary>
        /// Returns the imaginary value (expected value).
        /// </summary>
        /// <returns></returns>
        // Token: 0x0600001E RID: 30 RVA: 0x000029A4 File Offset: 0x00000BA4
        public double DblImagValue()
        {
            return this.imag.Value;
        }

        /// <summary>
        /// Returns the real expected value.
        /// </summary>
        /// <returns></returns>
        // Token: 0x0600001F RID: 31 RVA: 0x000029B7 File Offset: 0x00000BB7
        public double DblRealExpValue()
        {
            return this.real.ExpValue;
        }

        /// <summary>
        /// Returns the imaginary expected value.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000020 RID: 32 RVA: 0x000029CA File Offset: 0x00000BCA
        public double DblImagExpValue()
        {
            return this.imag.ExpValue;
        }

        /// <summary>
        /// Returns the real function value.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000021 RID: 33 RVA: 0x000029DD File Offset: 0x00000BDD
        public double DblRealFcnValue()
        {
            return this.real.FcnValue;
        }

        /// <summary>
        /// Returns the imaginary function value.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000022 RID: 34 RVA: 0x000029F0 File Offset: 0x00000BF0
        public double DblImagFcnValue()
        {
            return this.imag.FcnValue;
        }

        /// <summary>
        /// Initializes a Complex Number with Imaginary Part = 0.
        /// </summary>
        /// <param name="value">Real part</param>
        // Token: 0x06000023 RID: 35 RVA: 0x00002A04 File Offset: 0x00000C04
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
        // Token: 0x06000024 RID: 36 RVA: 0x00002A47 File Offset: 0x00000C47
        public double DblSqrFcnValue()
        {
            return this.DblRealFcnValue() * this.DblRealFcnValue() + this.DblImagFcnValue() * this.DblImagFcnValue();
        }

        /// <summary>
        /// Returns the function value.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000025 RID: 37 RVA: 0x00002A64 File Offset: 0x00000C64
        public Complex<T> FcnValue2()
        {
            return new Complex<T>(this.real.FcnValue2(), this.imag.FcnValue2());
        }

        /// <summary>
        /// Number of bytes allocated for the Object.
        /// </summary>
        // Token: 0x17000002 RID: 2
        // (get) Token: 0x06000026 RID: 38 RVA: 0x00002A8D File Offset: 0x00000C8D
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
        // Token: 0x06000027 RID: 39 RVA: 0x00002AB4 File Offset: 0x00000CB4
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
        // Token: 0x06000028 RID: 40 RVA: 0x00002B4B File Offset: 0x00000D4B
        public void Debug()
        {
            //Nuvo.Math.Core.Misc.Console.Debug(this);
        }

        /// <summary>
        /// Write object data to Binary Writer.
        /// </summary>
        /// <param name="writer">Binary Writer</param>
        // Token: 0x06000029 RID: 41 RVA: 0x00002B60 File Offset: 0x00000D60
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
        // Token: 0x0600002A RID: 42 RVA: 0x00002B9C File Offset: 0x00000D9C
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
        // Token: 0x0600002B RID: 43 RVA: 0x00002BEA File Offset: 0x00000DEA
        public void BinarySerialize(string filepath)
        {
            Storage.BinarySerialize(this, filepath);
        }

        /// <summary>
        /// Binary Deserialize an Object from File.
        /// </summary>
        /// <param name="filepath">File Path</param>
        /// <returns>Object</returns>
        // Token: 0x0600002C RID: 44 RVA: 0x00002BFD File Offset: 0x00000DFD
        public Complex<T> BinaryDeserialize(string filepath)
        {
            return Storage.BinaryDeserialize<Complex<T>>(filepath);
        }

        /// <summary>
        /// Binary Serialize an Object to a byte array.
        /// </summary>
        /// <returns>Binary Data</returns>
        // Token: 0x0600002D RID: 45 RVA: 0x00002C05 File Offset: 0x00000E05
        public byte[] BinarySerializeToByteArray()
        {
            return Storage.BinarySerializeToByteArray(this);
        }

        /// <summary>
        /// Binary Deserialize an Object from a byte array.
        /// </summary>
        /// <param name="data">Binary Data</param>
        /// <returns>Object</returns>
        // Token: 0x0600002E RID: 46 RVA: 0x00002C17 File Offset: 0x00000E17
        public Complex<T> BinaryDeserializeFromByteArray(byte[] data)
        {
            return Storage.BinaryDeserializeFromByteArray<Complex<T>>(data);
        }

        /// <summary>
        /// Xml Serialize an Object to File.
        /// </summary>
        /// <param name="filepath">File Path</param>
        // Token: 0x0600002F RID: 47 RVA: 0x00002C1F File Offset: 0x00000E1F
        public void XmlSerialize(string filepath)
        {
            Storage.XmlSerialize(this, filepath);
        }

        /// <summary>
        /// Xml Deserialize an Object from File.
        /// </summary>
        /// <param name="filepath">Xml String</param>
        /// <returns>Object</returns>
        // Token: 0x06000030 RID: 48 RVA: 0x00002C32 File Offset: 0x00000E32
        public Complex<T> XmlDeserialize(string filepath)
        {
            return Storage.XmlDeserialize<Complex<T>>(filepath);
        }

        /// <summary>
        /// Xml Serialize an Object to String.
        /// </summary>
        /// <returns>XML String</returns>
        // Token: 0x06000031 RID: 49 RVA: 0x00002C3A File Offset: 0x00000E3A
        public string XmlSerializeToString()
        {
            return Storage.XmlSerializeToString(this);
        }

        /// <summary>
        /// Xml Deserialize an Object from String.
        /// </summary>
        /// <param name="xml_string">Xml String</param>
        /// <returns>Object</returns>
        // Token: 0x06000032 RID: 50 RVA: 0x00002C4C File Offset: 0x00000E4C
        public Complex<T> XmlDeserializeFromString(string xml_string)
        {
            return Storage.XmlDeserializeFromString<Complex<T>>(xml_string);
        }

        /// <summary>
        /// Returns true if the Value of an Object is equal to zero.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000033 RID: 51 RVA: 0x00002C54 File Offset: 0x00000E54
        public bool IsZero()
        {
            return this.real.IsZero() & this.imag.IsZero();
        }

        /// <summary>
        /// Returns true if the Value of an Object is not equal to zero.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000034 RID: 52 RVA: 0x00002C79 File Offset: 0x00000E79
        public bool IsNotZero()
        {
            return this.real.IsNotZero() | this.imag.IsNotZero();
        }

        /// <summary>
        /// Returns the neutral element of addition
        /// </summary>
        /// <value>e</value>
        // Token: 0x17000003 RID: 3
        // (get) Token: 0x06000035 RID: 53 RVA: 0x00002CA0 File Offset: 0x00000EA0
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
        // Token: 0x17000004 RID: 4
        // (get) Token: 0x06000036 RID: 54 RVA: 0x00002CEC File Offset: 0x00000EEC
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
        // Token: 0x06000037 RID: 55 RVA: 0x00002D36 File Offset: 0x00000F36
        public Complex<T> Add(Complex<T> b)
        {
            return this + b;
        }

        /// <summary>
        /// Returns the difference of the object and <paramref name="b" />.
        /// </summary>
        /// <param name="b">The second operand</param>
        /// <returns>the difference</returns>
        // Token: 0x06000038 RID: 56 RVA: 0x00002D44 File Offset: 0x00000F44
        public Complex<T> Subtract(Complex<T> b)
        {
            return this - b;
        }

        /// <summary>
        /// Returns the negative of the object.
        /// </summary>
        /// <returns>The negative</returns>
        // Token: 0x06000039 RID: 57 RVA: 0x00002D52 File Offset: 0x00000F52
        public Complex<T> Negative()
        {
            return -this;
        }

        /// <summary>
        /// Returns the product of the object and <paramref name="b" />.
        /// </summary>
        /// <param name="b">The second operand</param>
        /// <returns>the product</returns>
        // Token: 0x0600003A RID: 58 RVA: 0x00002D5F File Offset: 0x00000F5F
        public Complex<T> Multiply(Complex<T> b)
        {
            return this * b;
        }

        /// <summary>
        /// Returns the quotient of the object and <paramref name="b" />.
        /// </summary>
        /// <param name="b">The second operand</param>
        /// <returns>the quotient</returns>
        // Token: 0x0600003B RID: 59 RVA: 0x00002D6D File Offset: 0x00000F6D
        public Complex<T> Divide(Complex<T> b)
        {
            return this / b;
        }

        /// <summary>
        /// Returns e raised to the specified power.
        /// </summary>
        /// <returns></returns>
        // Token: 0x0600003C RID: 60 RVA: 0x00002D7C File Offset: 0x00000F7C
        public Complex<T> Exp()
        {
            return this.real.Exp() * (this.imag.Cos() + this.imag.Sin() * this.J);
        }

        /// <summary>
        /// Returns the natural (base e) logarithm of a specified number.
        /// </summary>
        /// <returns></returns>
        // Token: 0x0600003D RID: 61 RVA: 0x00002DE0 File Offset: 0x00000FE0
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
        // Token: 0x0600003E RID: 62 RVA: 0x00002E21 File Offset: 0x00001021
        public Complex<T> Log(Complex<T> newBase)
        {
            return this.Log() / newBase.Log();
        }

        /// <summary>
        /// Returns the base 10 logarithm of a specified number.
        /// </summary>
        /// <returns></returns>
        // Token: 0x0600003F RID: 63 RVA: 0x00002E35 File Offset: 0x00001035
        public Complex<T> Log10()
        {
            return this.Log(10.0);
        }

        /// <summary>
        /// Returns a specified number raised to the specified power.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        // Token: 0x06000040 RID: 64 RVA: 0x00002E4C File Offset: 0x0000104C
        public Complex<T> Pow(Complex<T> b)
        {
            return (b * this.Log()).Exp();
        }

        /// <summary>
        /// Returns a specified number raised to the specified power.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        // Token: 0x06000041 RID: 65 RVA: 0x00002E70 File Offset: 0x00001070
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
        // Token: 0x06000042 RID: 66 RVA: 0x00002F30 File Offset: 0x00001130
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
        // Token: 0x06000043 RID: 67 RVA: 0x00002FD4 File Offset: 0x000011D4
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
        // Token: 0x06000044 RID: 68 RVA: 0x00003044 File Offset: 0x00001244
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
        // Token: 0x06000045 RID: 69 RVA: 0x000030C4 File Offset: 0x000012C4
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
        // Token: 0x06000046 RID: 70 RVA: 0x00003148 File Offset: 0x00001348
        public Complex<T> Asin()
        {
            return -this.J * (this.J * this + (1.0 - this * this).Sqrt()).Log();
        }

        /// <summary>
        /// Returns the angle whose cosine is the specified number.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000047 RID: 71 RVA: 0x000031B0 File Offset: 0x000013B0
        public Complex<T> Acos()
        {
            return -this.J * (this + this.J * (1.0 - this * this).Sqrt()).Log();
        }

        /// <summary>
        /// Returns the angle whose tangent is the specified number.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000048 RID: 72 RVA: 0x00003218 File Offset: 0x00001418
        public Complex<T> Atan()
        {
            return ((1.0 + this.J * this) / (1.0 - this.J * this)).Log() / (this.J * 2.0);
        }

        /// <summary>
        /// Returns the hyperbolic sine of the specified angle.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000049 RID: 73 RVA: 0x00003298 File Offset: 0x00001498
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
        // Token: 0x0600004A RID: 74 RVA: 0x00003308 File Offset: 0x00001508
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
        // Token: 0x0600004B RID: 75 RVA: 0x00003378 File Offset: 0x00001578
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
        // Token: 0x0600004C RID: 76 RVA: 0x000033EC File Offset: 0x000015EC
        public Complex<T> Asinh()
        {
            return (this + (this * this + 1.0).Sqrt()).Log();
        }

        /// <summary>
        /// Returns the angle whose hyperbolic cosine is the specified number.
        /// </summary>
        /// <returns></returns>
        // Token: 0x0600004D RID: 77 RVA: 0x00003438 File Offset: 0x00001638
        public Complex<T> Acosh()
        {
            return (this + (this * this - 1.0).Sqrt()).Log();
        }

        /// <summary>
        /// Returns the angle whose hyperbolic tangent is the specified number.
        /// </summary>
        /// <returns></returns>
        // Token: 0x0600004E RID: 78 RVA: 0x00003484 File Offset: 0x00001684
        public Complex<T> Atanh()
        {
            return ((1.0 + this) / (1.0 - this)).Log() / 2.0;
        }

        /// <summary>
        /// Returns the complex conjugate.
        /// </summary>
        /// <returns></returns>
        // Token: 0x0600004F RID: 79 RVA: 0x000034E3 File Offset: 0x000016E3
        public Complex<T> Conj()
        {
            return this.real - this.imag * this.J;
        }

        /// <summary>
        /// Returns the real part.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000050 RID: 80 RVA: 0x0000350B File Offset: 0x0000170B
        public T Real()
        {
            return this.real;
        }

        /// <summary>
        /// Returns the imaginary part.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000051 RID: 81 RVA: 0x00003513 File Offset: 0x00001713
        public T Imag()
        {
            return this.imag;
        }

        /// <summary>
        /// Returns the absolute value.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000052 RID: 82 RVA: 0x0000351B File Offset: 0x0000171B
        public T Abs()
        {
            return Math.ComplexAbs<T>(this.real, this.imag);
        }

        /// <summary>
        /// Returns the angle.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000053 RID: 83 RVA: 0x0000352E File Offset: 0x0000172E
        public T Angle()
        {
            return this.imag.Atan2(this.real);
        }

        /// <summary>
        /// Real Part
        /// </summary>
        // Token: 0x04000001 RID: 1
        [XmlElement("Real")]
        public T real;

        /// <summary>
        /// Imaginary Part
        /// </summary>
        // Token: 0x04000002 RID: 2
        [XmlElement("Imag")]
        public T imag;
    }
}
