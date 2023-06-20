using System;
using System.Text;
using System.Xml.Serialization;
using Nuvo.Math.Interface;
using Nuvo.Math.Misc;
using Nuvo.Math.Ndims.Interface;

namespace Nuvo.Math.Ndims
{
	/// <summary>
	/// Generic Real Array
	/// </summary>
	/// <typeparam name="D">Real Element Type</typeparam>
	[XmlType("RealNArray")]
	[Serializable]
    public class RealNArray<D> : NArray<RealNArray<D>, D>, IRealNArray<RealNArray<D>, D>, INArray<RealNArray<D>, D>, IConsole, IStorage<RealNArray<D>>, IArrayArithmetic<RealNArray<D>, D>, IArithmetic<RealNArray<D>>, IArrayMath<RealNArray<D>, D>, IMath<RealNArray<D>>, IArrayRealMath<RealNArray<D>, D>, IRealMath<RealNArray<D>> where D : IRealNumber<D>, new()
    {
        /// <summary>
        /// Returns the value.
        /// </summary>
        /// <returns></returns>
        public double[] DblValue()
		{
			int i = base.numel;
			double[] values = new double[i];
			for (int j = 0; j < i; j++)
			{
				values[j] = base.data[j].Value;
			}
			return values;
		}

		/// <summary>
		/// Override ToString() to display an Object.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			int d = base.ndims;
			if (d == 1)
			{
				int i = base.numel;
				for (int j = 0; j < i; j++)
				{
					StringBuilder stringBuilder = sb;
					D d2 = base[j];
					stringBuilder.Append(d2.Value.ToString("  0.000E+00  ; -0.000E+00  "));
					sb.Append("\n");
				}
			}
			else if (d == 2)
			{
				int n_cols = 6;
				int n = base.size[0];
				int n2 = base.size[1];
				int n3 = (n2 + n_cols - 1) / n_cols;
				for (int i2 = 0; i2 < n3; i2++)
				{
					int col_ = i2 * n_cols;
					int col_2 = col_ + n_cols;
					if (col_2 > n2)
					{
						col_2 = n2;
					}
					if (n3 > 1)
					{
						sb.Append("Columns ");
						sb.Append(col_.ToString());
						sb.Append(" through ");
						sb.Append((col_2 - 1).ToString());
						sb.Append("\n");
					}
					for (int i3 = 0; i3 < n; i3++)
					{
						for (int i4 = col_; i4 < col_2; i4++)
						{
							StringBuilder stringBuilder2 = sb;
							D d2 = base[i3, i4];
							stringBuilder2.Append(d2.Value.ToString("  0.000E+00  ; -0.000E+00  "));
						}
						sb.Append("\n");
					}
					sb.Append("\n");
				}
			}
			else
			{
				sb.Append(d.ToString());
				sb.Append("d-Array");
			}
			return sb.ToString();
		}

		/// <summary>
		/// Returns the absolute value.
		/// </summary>
		/// <returns></returns>
		public RealNArray<D> Abs()
        {
            return ElementUnOp(Math.Abs);
        }

		/// <summary>
		/// Returns a value indicating the sign of a number.
		/// </summary>
		/// <returns></returns>
		public RealNArray<D> Sign()
        {
            return ElementUnOp(Math.Sign);
        }

		/// <summary>
		/// Returns the angle whose tangent is the quotient of two specified numbers.
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		public RealNArray<D> Atan2(RealNArray<D> b)
        {
            return ElementBinOp(Math.Atan2, b);
        }

		/// <summary>
		/// Complex division
		/// </summary>
		/// <param name="_b">Numerator imag part</param>
		/// <param name="_c">Denominator real part</param>
		/// <param name="_d">Denominator imag part</param>
		/// <param name="_f">Result imag part</param>
		/// <returns>Result real part</returns>
		public RealNArray<D> ComplexDivision(RealNArray<D> _b, RealNArray<D> _c, RealNArray<D> _d, out RealNArray<D> _f)
		{
			int d = base.ndims;
			if (d != _b.ndims || d != _c.ndims || d != _d.ndims)
			{
				throw new Exception("Array dimensions must agree");
			}
			for (int i = 0; i < d; i++)
			{
				if (base.size[i] != _b.size[i] || base.size[i] != _c.size[i] || base.size[i] != _d.size[i])
				{
					throw new Exception("Array dimensions must agree");
				}
			}
			int n = base.numel;
			RealNArray<D> _e = new RealNArray<D>();
			_e.InitNd(base.size);
			_f = new RealNArray<D>();
			_f.InitNd(base.size);
			for (int j = 0; j < n; j++)
			{
				NArray<RealNArray<D>, D> narray = _e;
				int index = j;
				D d2 = base[j];
				D _fi;
				narray[index] = d2.ComplexDivision(_b[j], _c[j], _d[j], out _fi);
				_f[j] = _fi;
			}
			return _e;
		}

		/// <summary>
		/// Complex absolute value
		/// </summary>
		/// <param name="_b">Imag part</param>
		/// <returns></returns>
		public RealNArray<D> ComplexAbs(RealNArray<D> _b)
        {
            return ElementBinOp(Math.ComplexAbs, _b);
        }

		/// <summary>
		/// Returns the angle whose tangent is the quotient of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the angle</returns>
		public RealNArray<D> LAtan2(D b)
        {
            return LElementBinOp(Math.Atan2, b);
        }

		/// <summary>
		/// Returns the angle whose tangent is the quotient of <paramref name="a" /> and the object.
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns>the angle</returns>
		public RealNArray<D> RAtan2(D a)
        {
            return RElementBinOp(Math.Atan2, a);
        }
	}
}
