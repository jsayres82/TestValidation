using System;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Nuvo.Math.Interface;
using Nuvo.Math.Misc;
using Nuvo.Math.Ndims;
using Nuvo.Math.Ndims.Interface;

namespace Nuvo.Math.Ndims
{
	/// <summary>
	/// Generic Complex Array
	/// </summary>
	/// <typeparam name="T">Real Element Type</typeparam>
	[XmlType("ComplexNArray")]
	[Serializable]
	public class ComplexNArray<T, D> : NArray<ComplexNArray<T, D>, Complex<T>>, IComplexNArray<ComplexNArray<T, D>, RealNArray<T>, Complex<T>, T>
	where T : IRealNumber<T>, new()
	where D : IComplexNumber<Complex<T>, T>, new()
	{
		public T[] data
		{
			get { return base.data.DblRealValue().Select(x => (T)x).ToArray(); }
			set { base.data = value.Select(x => (Complex<T>)(T)x).ToArray(); }
		}
		// Rest of the class implementation
		/// <summary>
		/// Initializes a Complex Array
		/// </summary>
		/// <param name="real">Real Part</param>
		/// <param name="imag">Imaginary Part</param>
		public void InitReIm(RealNArray<T> real, RealNArray<T> imag)
		{
			int d = real.ndims;
			if (d != imag.ndims)
			{
				throw new Exception("Array dimensions must agree");
			}
			for (int i = 0; i < d; i++)
			{
				if (real.size[i] != imag.size[i])
				{
					throw new Exception("Array dimensions must agree");
				}
			}
			int n = real.numel;
			base.InitNd(real.size);
			for (int j = 0; j < n; j++)
			{
				base.data[j] = default(Complex<T>);
				base.data[j].InitReIm(real[j], imag[j]);
			}
		}

		/// <summary>
		/// Initializes a Complex Array with all Imaginary Parts = 0
		/// </summary>
		/// <param name="real">Real Part</param>
		public void InitRe(RealNArray<T> real)
		{
			int i = real.numel;
			base.InitNd(real.size);
			for (int j = 0; j < i; j++)
			{
				base.data[j] = default(Complex<T>);
				base.data[j].InitRe(real[j]);
			}
		}

		/// <summary>
		/// Initializes a Complex Array.
		/// </summary>
		/// <param name="real">Real Part</param>
		/// <param name="imag">Imaginary Part</param>
		public void InitDblReIm(double[] real, double[] imag)
		{
			int n = real.Length;
			int n2 = imag.Length;
			if (n != n2)
			{
				throw new Exception("Array dimensions must agree");
			}
			base.Init1d(n);
			for (int i = 0; i < n; i++)
			{
				base.data[i] = default(Complex<T>);
				base.data[i].InitDblReIm(real[i], imag[i]);
			}
		}

		/// <summary>
		/// Returns the real value.
		/// </summary>
		/// <returns></returns>
		public double[] DblRealValue()
		{
			int i = base.numel;
			double[] values = new double[i];
			for (int j = 0; j < i; j++)
			{
				values[j] = base.data[j].DblRealValue();
			}
			return values;
		}

		/// <summary>
		/// Returns the imaginary value.
		/// </summary>
		/// <returns></returns>
		public double[] DblImagValue()
		{
			int i = base.numel;
			double[] values = new double[i];
			for (int j = 0; j < i; j++)
			{
				values[j] = base.data[j].DblImagValue();
			}
			return values;
		}

		/// <summary>
		/// Complex conjugate transpose 2D-Array (Matrix)
		/// </summary>
		/// <returns></returns>
		public ComplexNArray<T, D> CTranspose()
		{
			return base.Conj().Transpose();
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
					sb.Append(base[j].DblRealValue().ToString(" ( 0.000E+00 ; (-0.000E+00 "));
					sb.Append(base[j].DblImagValue().ToString(" +0.000E+00i); -0.000E+00i)"));
					sb.Append("\n");
				}
			}
			else if (d == 2)
			{
				int n_cols = 3;
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
							sb.Append(base[i3, i4].DblRealValue().ToString(" ( 0.000E+00 ; (-0.000E+00 "));
							sb.Append(base[i3, i4].DblImagValue().ToString(" +0.000E+00i); -0.000E+00i)"));
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

		internal RealNArray<T> ElementUnOp2(UnaryOperation2<Complex<T>, T> op)
		{
			int n = base.numel;
			RealNArray<T> b = new RealNArray<T>();
			b.InitNd(base.size);
			for (int i = 0; i < n; i++)
			{
				b[i] = op(base[i]);
			}
			return b;
		}

		/// <summary>
		/// Returns the real part.
		/// </summary>
		/// <returns></returns>
		public RealNArray<T> Real()
		{
			return this.ElementUnOp2(new UnaryOperation2<Complex<T>, T>(T.Value));
		}

		/// <summary>
		/// Returns the imaginary part.
		/// </summary>
		/// <returns></returns>
		public RealNArray<T> Imag()
		{
			return this.ElementUnOp2(new UnaryOperation2<T,T>(T.Value));
		}

		/// <summary>
		/// Returns the absolute value.
		/// </summary>
		/// <returns></returns>
		public RealNArray<T> Abs()
		{
			return this.ElementUnOp2(new UnaryOperation2<Complex<T>, T>(this.Vector[].Abs()));
		}

		/// <summary>
		/// Returns the angle.
		/// </summary>
		/// <returns></returns>
		public RealNArray<T> Angle()
		{
			return this.ElementUnOp2(new UnaryOperation2<T, T>(Complex<T>.FromPolarCoordinates().Angle()));
		}
	}
}
