using System;
using System.Text;
using System.Xml.Serialization;
using Nuvo.Math.Core.Interface;
using Nuvo.Math.Core.Misc;
using Nuvo.Math.Core.Ndims.Interface;

namespace Nuvo.Math.Core.Ndims
{
	/// <summary>
	/// Generic Complex Array
	/// </summary>
	/// <typeparam name="T">Real Element Type</typeparam>
	// Token: 0x0200003A RID: 58
	[XmlType("ComplexNArray")]
	[Serializable]
	public class ComplexNArray<T> : NArray<ComplexNArray<T>, Complex<T>>, IConsole, IStorage<ComplexNArray<T>>, IArrayArithmetic<ComplexNArray<T>, Complex<T>>, IArithmetic<ComplexNArray<T>>, IMath<ComplexNArray<T>>, IArrayComplexMath<ComplexNArray<T>, RealNArray<T>, Complex<T>, T>, IComplexMath<ComplexNArray<T>, RealNArray<T>> where D : new()
	{
		/// <summary>
		/// Initializes a Complex Array
		/// </summary>
		/// <param name="real">Real Part</param>
		/// <param name="imag">Imaginary Part</param>
		// Token: 0x060002EF RID: 751 RVA: 0x0000D3E8 File Offset: 0x0000B5E8
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
		// Token: 0x060002F0 RID: 752 RVA: 0x0000D48C File Offset: 0x0000B68C
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
		// Token: 0x060002F1 RID: 753 RVA: 0x0000D4E4 File Offset: 0x0000B6E4
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
		// Token: 0x060002F2 RID: 754 RVA: 0x0000D544 File Offset: 0x0000B744
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
		// Token: 0x060002F3 RID: 755 RVA: 0x0000D580 File Offset: 0x0000B780
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
		// Token: 0x060002F4 RID: 756 RVA: 0x0000D5BC File Offset: 0x0000B7BC
		public ComplexNArray<T> CTranspose()
		{
			return base.Conj().Transpose();
		}

		/// <summary>
		/// Override ToString() to display an Object.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060002F5 RID: 757 RVA: 0x0000D5CC File Offset: 0x0000B7CC
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

		// Token: 0x060002F6 RID: 758 RVA: 0x0000D7AC File Offset: 0x0000B9AC
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
		// Token: 0x060002F7 RID: 759 RVA: 0x0000D7F3 File Offset: 0x0000B9F3
		public RealNArray<T> Real()
		{
			return this.ElementUnOp2(new UnaryOperation2<T, Complex>(this.Real));
		}

		/// <summary>
		/// Returns the imaginary part.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060002F8 RID: 760 RVA: 0x0000D807 File Offset: 0x0000BA07
		public RealNArray<T> Imag()
		{
			return this.ElementUnOp2(new UnaryOperation2<T,T>(T.Imag()));
		}

		/// <summary>
		/// Returns the absolute value.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060002F9 RID: 761 RVA: 0x0000D81B File Offset: 0x0000BA1B
		public RealNArray<T> Abs()
		{
			return this.ElementUnOp2(new UnaryOperation2<T, T>(Complex<T>.Abs()));
		}

		/// <summary>
		/// Returns the angle.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060002FA RID: 762 RVA: 0x0000D82F File Offset: 0x0000BA2F
		public RealNArray<T> Angle()
		{
			return this.ElementUnOp2(new UnaryOperation2<T, T>(Complex<T>.FromPolarCoordinates().Angle()));
		}
	}
}
