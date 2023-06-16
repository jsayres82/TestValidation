using System;
using Nuvo.Math.Core.Ndims;
using Nuvo.Math.Core.Unc.Interface;

namespace Nuvo.Math.Core.Unc
{
	/// <summary>
	/// Generic Uncertainty functions
	/// </summary>
	/// <typeparam name="T1">Unc List Type</typeparam>
	/// <typeparam name="T2">Real Unc Type</typeparam>
	// Token: 0x02000021 RID: 33
	public class GenericUnc<T1, T2> where T1 :  new() where T2 : new()
	{
		/// <summary>
		/// Build Correlated Base Inputs from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <param name="p">Probability</param>
		/// <returns></returns>
		// Token: 0x06000186 RID: 390 RVA: 0x000077F8 File Offset: 0x000059F8
		public static T2[] BuildCorrBaseInputsFromSamples(Number[][] samples, double p)
		{
			Number[] values = Statistics.Mean(samples);
			Number[][] covariance = Statistics.CovarianceOfSampleMean(samples, p);
			int n2 = values.Length;
			Number[] idof = new Number[n2];
			for (int i = 0; i < n2; i++)
			{
				idof[i] = 0.0;
			}
			return GenericUnc<T1, T2>.BuildCorrBaseInputs(values, covariance, idof);
		}

		/// <summary>
		/// Build Correlated Base Inputs from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <param name="id">Input Id</param>
		/// <param name="desc">Description</param>
		/// <param name="p">Probability</param>
		/// <returns></returns>
		// Token: 0x06000187 RID: 391 RVA: 0x00007850 File Offset: 0x00005A50
		public static T2[] BuildCorrBaseInputsFromSamples(Number[][] samples, InputId id, string desc, double p)
		{
			Number[] values = Statistics.Mean(samples);
			Number[][] covariance = Statistics.CovarianceOfSampleMean(samples, p);
			return GenericUnc<T1, T2>.BuildCorrBaseInputs(values, covariance, id, desc);
		}

		/// <summary>
		/// Build Correlated Base Inputs
		/// </summary>
		/// <param name="values">Values</param>
		/// <param name="covariance">Covariance</param>
		/// <param name="idof">Inverse Degrees of Freedom (IDof)</param>
		/// <returns></returns>
		// Token: 0x06000188 RID: 392 RVA: 0x00007874 File Offset: 0x00005A74
		public static T2[] BuildCorrBaseInputs(Number[] values, Number[][] covariance, Number[] idof)
		{
			int i = values.Length;
			if (GenericUnc<T1, T2>.IsDiagonalMatrix(covariance))
			{
				T2[] unc = new T2[i];
				for (int i2 = 0; i2 < i; i2++)
				{
					unc[i2] = GenericUnc<T1, T2>.RealUncNumber(values[i2], covariance[i2][i2].Sqrt().Value, idof[i2].Value);
				}
				return unc;
			}
			Number[][] jacobi = LinAlg.ComputeJacobiEig<Number>(covariance);
			T2[] unc_in = new T2[i];
			T2[] unc_out = new T2[i];
			for (int i3 = 0; i3 < i; i3++)
			{
				unc_in[i3] = GenericUnc<T1, T2>.RealUncNumber(0.0, 1.0, 0.0);
				unc_out[i3] = GenericUnc<T1, T2>.RealUncNumber(values[i3]);
			}
			for (int i4 = 0; i4 < i; i4++)
			{
				for (int i5 = 0; i5 < i; i5++)
				{
					if (jacobi[i4][i5].Value != 0.0)
					{
						unc_out[i4] = unc_out[i4].Add(unc_in[i5].Multiply(GenericUnc<T1, T2>.RealUncNumber(jacobi[i4][i5])));
					}
				}
			}
			return unc_out;
		}

		/// <summary>
		/// Build Correlated Base Inputs
		/// </summary>
		/// <param name="values">Values</param>
		/// <param name="covariance">Covariance</param>
		/// <param name="id">Input Id</param>
		/// <param name="desc">Description</param>
		/// <returns></returns>
		// Token: 0x06000189 RID: 393 RVA: 0x000079C8 File Offset: 0x00005BC8
		public static T2[] BuildCorrBaseInputs(Number[] values, Number[][] covariance, InputId id, string desc)
		{
			string sep = '\t'.ToString();
			int i = values.Length;
			if (GenericUnc<T1, T2>.IsDiagonalMatrix(covariance))
			{
				T2[] unc = new T2[i];
				for (int i2 = 0; i2 < i; i2++)
				{
					string desc2 = string.IsNullOrEmpty(desc) ? null : (desc + sep + "Contribution: " + i2.ToString());
					T2[] array = unc;
					int num = i2;
					Number value = values[i2];
					double value2 = covariance[i2][i2].Sqrt().Value;
					InputId id2 = id;
					id = ++id2;
					array[num] = GenericUnc<T1, T2>.RealUncNumber(value, value2, id2, desc2);
				}
				return unc;
			}
			Number[][] jacobi = LinAlg.ComputeJacobiEig<Number>(covariance);
			T2[] unc_in = new T2[i];
			T2[] unc_out = new T2[i];
			for (int i3 = 0; i3 < i; i3++)
			{
				string desc3 = string.IsNullOrEmpty(desc) ? null : (desc + sep + "Contribution: " + i3.ToString());
				T2[] array2 = unc_in;
				int num2 = i3;
				Number value3 = 0.0;
				double stdunc = 1.0;
				InputId id3 = id;
				id = ++id3;
				array2[num2] = GenericUnc<T1, T2>.RealUncNumber(value3, stdunc, id3, desc3);
				unc_out[i3] = GenericUnc<T1, T2>.RealUncNumber(values[i3]);
			}
			for (int i4 = 0; i4 < i; i4++)
			{
				for (int i5 = 0; i5 < i; i5++)
				{
					if (jacobi[i4][i5].Value != 0.0)
					{
						unc_out[i4] = unc_out[i4].Add(unc_in[i5].Multiply(GenericUnc<T1, T2>.RealUncNumber(jacobi[T2][T2])));
					}
				}
			}
			return unc_out;
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00007B70 File Offset: 0x00005D70
		private static bool IsDiagonalMatrix(Number[][] covariance)
		{
			bool diagonal = true;
			int i = covariance.Length;
			for (int i2 = 0; i2 < i; i2++)
			{
				for (int i3 = 0; i3 < i; i3++)
				{
					if (i2 != i3 && covariance[i2][i3].IsNotZero())
					{
						diagonal = false;
						break;
					}
				}
				if (!diagonal)
				{
					break;
				}
			}
			return diagonal;
		}

		/// <summary>
		/// Creates a new Real Uncertainty Number from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <param name="id">Input Id</param>
		/// <param name="desc">Description</param>
		/// <param name="p">Probability</param>
		/// <returns></returns>
		// Token: 0x0600018B RID: 395 RVA: 0x00007BB8 File Offset: 0x00005DB8
		public static T2 RealUncNumberFromSamples(Number[] samples, InputId id, string desc, double p)
		{
			return GenericUnc<T1, T2>.RealUncNumber(Statistics.Mean(samples), Statistics.StandardDeviationOfSampleMean(samples, p).Value, id, desc);
		}

		/// <summary>
		/// Creates a new Real Uncertainty Number from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <param name="p">Probability</param>
		/// <returns></returns>
		// Token: 0x0600018C RID: 396 RVA: 0x00007BE4 File Offset: 0x00005DE4
		public static T2 RealUncNumberFromSamples(Number[] samples, double p)
		{
			return GenericUnc<T1, T2>.RealUncNumber(Statistics.Mean(samples), Statistics.StandardDeviationOfSampleMean(samples, p).Value, 0.0);
		}

		/// <summary>
		/// Creates a new Real Uncertainty Number from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <param name="id">Input Id</param>
		/// <param name="desc">Description</param>
		/// <returns></returns>
		// Token: 0x0600018D RID: 397 RVA: 0x00007C14 File Offset: 0x00005E14
		public static T2 RealUncNumberFromSamples(Number[] samples, InputId id, string desc)
		{
			return GenericUnc<T1, T2>.RealUncNumberFromSamples(samples, id, desc, 0.95);
		}

		/// <summary>
		/// Creates a new Real Uncertainty Number from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <returns></returns>
		// Token: 0x0600018E RID: 398 RVA: 0x00007C27 File Offset: 0x00005E27
		public static T2 RealUncNumberFromSamples(Number[] samples)
		{
			return GenericUnc<T1, T2>.RealUncNumberFromSamples(samples, 0.95);
		}

		/// <summary>
		/// Creates a new Real Uncertainty Number
		/// </summary>
		/// <param name="value">Value</param>
		/// <param name="stdunc">Standard Uncertainty</param>
		/// <param name="id">Input Id</param>
		/// <param name="desc">Description</param>
		/// <returns></returns>
		// Token: 0x0600018F RID: 399 RVA: 0x00007C38 File Offset: 0x00005E38
		public static T2 RealUncNumber(Number value, double stdunc, InputId id, string desc)
		{
			T2 x = Activator.CreateInstance<T2>();
			x.Init(value.Value, stdunc, 0.0, id, desc);
			return x;
		}

		/// <summary>
		/// Creates a new Real Uncertainty Number
		/// </summary>
		/// <param name="value">Value</param>
		/// <param name="stdunc">Standard Uncertainty</param>
		/// <param name="idof">Inverse of the Degrees of Freedom</param>
		/// <returns></returns>
		// Token: 0x06000190 RID: 400 RVA: 0x00007C6C File Offset: 0x00005E6C
		public static T2 RealUncNumber(Number value, double stdunc, double idof)
		{
			T2 x = Activator.CreateInstance<T2>();
			x.Init(value.Value, stdunc, idof);
			return x;
		}

		/// <summary>
		/// Creates a new Real Uncertainty Number
		/// </summary>
		/// <param name="value">Value</param>
		/// <returns></returns>
		// Token: 0x06000191 RID: 401 RVA: 0x00007C98 File Offset: 0x00005E98
		public static T2 RealUncNumber(Number value)
		{
			T2 x = Activator.CreateInstance<T2>();
			x.Init(value.Value);
			return x;
		}

		/// <summary>
		/// Creates a new Complex Uncertainty Number from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <param name="id">Input Id</param>
		/// <param name="desc">Description</param>
		/// <param name="p">Probability</param>
		/// <returns></returns>
		// Token: 0x06000192 RID: 402 RVA: 0x00007CC0 File Offset: 0x00005EC0
		public static Complex<T2> ComplexUncNumberFromSamples(Complex<Number>[] samples, InputId id, string desc, double p)
		{
			int i = samples.Length;
			Number[][] samples2 = new Number[i][];
			for (int j = 0; j < i; j++)
			{
				samples2[j] = new Number[]
				{
					samples[j].real,
					samples[j].imag
				};
			}
			T2[] data = GenericUnc<T1, T2>.BuildCorrBaseInputsFromSamples(samples2, id, desc, p);
			return new Complex<T2>(data[0], data[1]);
		}

		/// <summary>
		/// Creates a new Complex Uncertainty Number from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <param name="p">Probability</param>
		/// <returns></returns>
		// Token: 0x06000193 RID: 403 RVA: 0x00007D30 File Offset: 0x00005F30
		public static Complex<T2> ComplexUncNumberFromSamples(Complex<Number>[] samples, double p)
		{
			int i = samples.Length;
			Number[][] samples2 = new Number[i][];
			for (int j = 0; j < i; j++)
			{
				samples2[j] = new Number[]
				{
					samples[j].real,
					samples[j].imag
				};
			}
			T2[] data = GenericUnc<T1, T2>.BuildCorrBaseInputsFromSamples(samples2, p);
			return new Complex<T2>(data[0], data[1]);
		}

		/// <summary>
		/// Creates a new Complex Uncertainty Number from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <param name="id">Input Id</param>
		/// <param name="desc">Description</param>
		/// <returns></returns>
		// Token: 0x06000194 RID: 404 RVA: 0x00007D9E File Offset: 0x00005F9E
		public static Complex<T2> ComplexUncNumberFromSamples(Complex<Number>[] samples, InputId id, string desc)
		{
			return GenericUnc<T1, T2>.ComplexUncNumberFromSamples(samples, id, desc, 0.95);
		}

		/// <summary>
		/// Creates a new Complex Uncertainty Number from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <returns></returns>
		// Token: 0x06000195 RID: 405 RVA: 0x00007DB1 File Offset: 0x00005FB1
		public static Complex<T2> ComplexUncNumberFromSamples(Complex<Number>[] samples)
		{
			return GenericUnc<T1, T2>.ComplexUncNumberFromSamples(samples, 0.95);
		}

		/// <summary>
		/// Creates a new Complex Uncertainty Number
		/// </summary>
		/// <param name="value">Value</param>
		/// <param name="covariance">Covariance</param>
		/// <param name="id">Input Id</param>
		/// <param name="desc">Description</param>
		/// <returns></returns>
		// Token: 0x06000196 RID: 406 RVA: 0x00007DC4 File Offset: 0x00005FC4
		public static Complex<T2> ComplexUncNumber(Complex<Number> value, Number[][] covariance, InputId id, string desc)
		{
			T2[] data = GenericUnc<T1, T2>.BuildCorrBaseInputs(new Number[]
			{
				value.real,
				value.imag
			}, covariance, id, desc);
			return new Complex<T2>(data[0], data[1]);
		}

		/// <summary>
		/// Creates a new Complex Uncertainty Number
		/// </summary>
		/// <param name="value">Value</param>
		/// <param name="covariance">Covariance</param>
		/// <param name="idof">Inverse of the Degrees of Freedom</param>
		/// <returns></returns>
		// Token: 0x06000197 RID: 407 RVA: 0x00007E10 File Offset: 0x00006010
		public static Complex<T2> ComplexUncNumber(Complex<Number> value, Number[][] covariance, Complex<Number> idof)
		{
			Number[] values2 = new Number[]
			{
				value.real,
				value.imag
			};
			Number[] idof2 = new Number[]
			{
				idof.real,
				idof.imag
			};
			T2[] data = GenericUnc<T1, T2>.BuildCorrBaseInputs(values2, covariance, idof2);
			return new Complex<T2>(data[0], data[1]);
		}

		/// <summary>
		/// Creates a new Complex Uncertainty Number
		/// </summary>
		/// <param name="value">Value</param>
		/// <param name="covariance">Covariance</param>
		/// <param name="idof">Inverse of the Degrees of Freedom</param>
		/// <returns></returns>
		// Token: 0x06000198 RID: 408 RVA: 0x00007E7C File Offset: 0x0000607C
		public static Complex<T2> ComplexUncNumber(Complex<Number> value, Number[][] covariance, double idof)
		{
			Complex<Number> idof2 = new Complex<Number>(idof, idof);
			return GenericUnc<T1, T2>.ComplexUncNumber(value, covariance, idof2);
		}

		/// <summary>
		/// Creates a new Complex Uncertainty Number
		/// </summary>
		/// <param name="value">Value</param>
		/// <returns></returns>
		// Token: 0x06000199 RID: 409 RVA: 0x00007E9A File Offset: 0x0000609A
		public static Complex<T2> ComplexUncNumber(Complex<Number> value)
		{
			return new Complex<T2>(GenericUnc<T1, T2>.RealUncNumber(value.real), GenericUnc<T1, T2>.RealUncNumber(value.imag));
		}

		/// <summary>
		/// Creates a new Complex Uncertainty Number
		/// </summary>
		/// <param name="value">Value</param>
		/// <returns></returns>
		// Token: 0x0600019A RID: 410 RVA: 0x00007EB7 File Offset: 0x000060B7
		public static Complex<T2> ComplexUncNumber(Number value)
		{
			return new Complex<T2>(GenericUnc<T1, T2>.RealUncNumber(value));
		}

		/// <summary>
		/// Creates a new Real Uncertainty Array from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <param name="id">Input Id</param>
		/// <param name="desc">Description</param>
		/// <param name="p">Probability</param>
		/// <returns></returns>
		// Token: 0x0600019B RID: 411 RVA: 0x00007EC4 File Offset: 0x000060C4
		public static T2[] RealUncArrayFromSamples(Number[][] samples, InputId id, string desc, double p)
		{
			return GenericUnc<T1, T2>.BuildCorrBaseInputsFromSamples(samples, id, desc, p);
		}

		/// <summary>
		/// Creates a new Real Uncertainty Array from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <param name="p">Probability</param>
		/// <returns></returns>
		// Token: 0x0600019C RID: 412 RVA: 0x00007ECF File Offset: 0x000060CF
		public static T2[] RealUncArrayFromSamples(Number[][] samples, double p)
		{
			return GenericUnc<T1, T2>.BuildCorrBaseInputsFromSamples(samples, p);
		}

		/// <summary>
		/// Creates a new Real Uncertainty Array from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <param name="id">Input Id</param>
		/// <param name="desc">Description</param>
		/// <returns></returns>
		// Token: 0x0600019D RID: 413 RVA: 0x00007ED8 File Offset: 0x000060D8
		public static T2[] RealUncArrayFromSamples(Number[][] samples, InputId id, string desc)
		{
			return GenericUnc<T1, T2>.BuildCorrBaseInputsFromSamples(samples, id, desc, 0.95);
		}

		/// <summary>
		/// Creates a new Real Uncertainty Array from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <returns></returns>
		// Token: 0x0600019E RID: 414 RVA: 0x00007EEB File Offset: 0x000060EB
		public static T2[] RealUncArrayFromSamples(Number[][] samples)
		{
			return GenericUnc<T1, T2>.BuildCorrBaseInputsFromSamples(samples, 0.95);
		}

		/// <summary>
		/// Creates a new Real Uncertainty Array
		/// </summary>
		/// <param name="values">Values</param>
		/// <param name="covariance">Covariance</param>
		/// <param name="id">Input Id</param>
		/// <param name="desc">Description</param>
		/// <returns></returns>
		// Token: 0x0600019F RID: 415 RVA: 0x00007EFC File Offset: 0x000060FC
		public static T2[] RealUncArray(Number[] values, Number[][] covariance, InputId id, string desc)
		{
			return GenericUnc<T1, T2>.BuildCorrBaseInputs(values, covariance, id, desc);
		}

		/// <summary>
		/// Creates a new Real Uncertainty Array
		/// </summary>
		/// <param name="values">Values</param>
		/// <param name="covariance">Covariance</param>
		/// <param name="idof">Inverse of the Degrees of Freedom</param>
		/// <returns></returns>
		// Token: 0x060001A0 RID: 416 RVA: 0x00007F07 File Offset: 0x00006107
		public static T2[] RealUncArray(Number[] values, Number[][] covariance, Number[] idof)
		{
			return GenericUnc<T1, T2>.BuildCorrBaseInputs(values, covariance, idof);
		}

		/// <summary>
		/// Creates a new Real Uncertainty Array
		/// </summary>
		/// <param name="values">Values</param>
		/// <param name="covariance">Covariance</param>
		/// <param name="idof">Inverse of the Degrees of Freedom</param>
		/// <returns></returns>
		// Token: 0x060001A1 RID: 417 RVA: 0x00007F14 File Offset: 0x00006114
		public static T2[] RealUncArray(Number[] values, Number[][] covariance, double idof)
		{
			int i = values.Length;
			Number[] idof2 = new Number[i];
			for (int j = 0; j < i; j++)
			{
				idof2[j] = idof;
			}
			return GenericUnc<T1, T2>.RealUncArray(values, covariance, idof2);
		}

		/// <summary>
		/// Creates a new Real Uncertainty Array
		/// </summary>
		/// <param name="values">Values</param>
		/// <returns></returns>
		// Token: 0x060001A2 RID: 418 RVA: 0x00007F50 File Offset: 0x00006150
		public static T2[] RealUncArray(Number[] values)
		{
			int i = values.Length;
			T2[] x = new T2[i];
			for (int j = 0; j < i; j++)
			{
				x[j] = GenericUnc<T1, T2>.RealUncNumber(values[j]);
			}
			return x;
		}

		/// <summary>
		/// Creates a new Complex Uncertainty Array from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <param name="id">Input Id</param>
		/// <param name="desc">Description</param>
		/// <param name="p">Probability</param>
		/// <returns></returns>
		// Token: 0x060001A3 RID: 419 RVA: 0x00007F88 File Offset: 0x00006188
		public static Complex<T2>[] ComplexUncArrayFromSamples(Complex<Number>[][] samples, InputId id, string desc, double p)
		{
			int n = samples.Length;
			int n2 = (n > 0) ? samples[0].Length : 0;
			Number[][] samples2 = new Number[n][];
			for (int i = 0; i < n; i++)
			{
				samples2[i] = new Number[2 * n2];
				for (int i2 = 0; i2 < n2; i2++)
				{
					samples2[i][2 * i2] = samples[i][i2].real;
					samples2[i][2 * i2 + 1] = samples[i][i2].imag;
				}
			}
			T2[] data = GenericUnc<T1, T2>.BuildCorrBaseInputsFromSamples(samples2, id, desc, p);
			Complex<T2>[] temp2 = new Complex<T2>[n2];
			for (int j = 0; j < n2; j++)
			{
				temp2[j] = new Complex<T2>(data[2 * j], data[2 * j + 1]);
			}
			return temp2;
		}

		/// <summary>
		/// Creates a new Complex Uncertainty Array from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <param name="p">Probability</param>
		/// <returns></returns>
		// Token: 0x060001A4 RID: 420 RVA: 0x00008060 File Offset: 0x00006260
		public static Complex<T2>[] ComplexUncArrayFromSamples(Complex<Number>[][] samples, double p)
		{
			int n = samples.Length;
			int n2 = (n > 0) ? samples[0].Length : 0;
			Number[][] samples2 = new Number[n][];
			for (int i = 0; i < n; i++)
			{
				samples2[i] = new Number[2 * n2];
				for (int i2 = 0; i2 < n2; i2++)
				{
					samples2[i][2 * i2] = samples[i][i2].real;
					samples2[i][2 * i2 + 1] = samples[i][i2].imag;
				}
			}
			T2[] data = GenericUnc<T1, T2>.BuildCorrBaseInputsFromSamples(samples2, p);
			Complex<T2>[] temp2 = new Complex<T2>[n2];
			for (int j = 0; j < n2; j++)
			{
				temp2[j] = new Complex<T2>(data[2 * j], data[2 * j + 1]);
			}
			return temp2;
		}

		/// <summary>
		/// Creates a new Complex Uncertainty Array from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <param name="id">Input Id</param>
		/// <param name="desc">Description</param>
		/// <returns></returns>
		// Token: 0x060001A5 RID: 421 RVA: 0x00008133 File Offset: 0x00006333
		public static Complex<T2>[] ComplexUncArrayFromSamples(Complex<Number>[][] samples, InputId id, string desc)
		{
			return GenericUnc<T1, T2>.ComplexUncArrayFromSamples(samples, id, desc, 0.95);
		}

		/// <summary>
		/// Creates a new Complex Uncertainty Array from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <returns></returns>
		// Token: 0x060001A6 RID: 422 RVA: 0x00008146 File Offset: 0x00006346
		public static Complex<T2>[] ComplexUncArrayFromSamples(Complex<Number>[][] samples)
		{
			return GenericUnc<T1, T2>.ComplexUncArrayFromSamples(samples, 0.95);
		}

		/// <summary>
		/// Creates a new Complex Uncertainty Array
		/// </summary>
		/// <param name="values">Values</param>
		/// <param name="covariance">Covariance</param>
		/// <param name="id">Input Id</param>
		/// <param name="desc">Description</param>
		/// <returns></returns>
		// Token: 0x060001A7 RID: 423 RVA: 0x00008158 File Offset: 0x00006358
		public static Complex<T2>[] ComplexUncArray(Complex<Number>[] values, Number[][] covariance, InputId id, string desc)
		{
			int i = values.Length;
			Number[] values2 = new Number[2 * i];
			for (int j = 0; j < i; j++)
			{
				values2[2 * j] = values[j].real;
				values2[2 * j + 1] = values[j].imag;
			}
			T2[] data = GenericUnc<T1, T2>.BuildCorrBaseInputs(values2, covariance, id, desc);
			Complex<T2>[] temp2 = new Complex<T2>[i];
			for (int k = 0; k < i; k++)
			{
				temp2[k] = new Complex<T2>(data[2 * k], data[2 * k + 1]);
			}
			return temp2;
		}

		/// <summary>
		/// Creates a new Complex Uncertainty Array
		/// </summary>
		/// <param name="values">Values</param>
		/// <param name="covariance">Covariance</param>
		/// <param name="idof">Inverse of the Degrees of Freedom</param>
		/// <returns></returns>
		// Token: 0x060001A8 RID: 424 RVA: 0x000081F8 File Offset: 0x000063F8
		public static Complex<T2>[] ComplexUncArray(Complex<Number>[] values, Number[][] covariance, Complex<Number>[] idof)
		{
			int i = values.Length;
			Number[] values2 = new Number[2 * i];
			Number[] idof2 = new Number[2 * i];
			for (int j = 0; j < i; j++)
			{
				values2[2 * j] = values[j].real;
				values2[2 * j + 1] = values[j].imag;
				idof2[2 * j] = idof[j].real;
				idof2[2 * j + 1] = idof[j].imag;
			}
			T2[] data = GenericUnc<T1, T2>.BuildCorrBaseInputs(values2, covariance, idof2);
			Complex<T2>[] temp2 = new Complex<T2>[i];
			for (int k = 0; k < i; k++)
			{
				temp2[k] = new Complex<T2>(data[2 * k], data[2 * k + 1]);
			}
			return temp2;
		}

		/// <summary>
		/// Creates a new Complex Uncertainty Array
		/// </summary>
		/// <param name="values">Values</param>
		/// <param name="covariance">Covariance</param>
		/// <param name="idof">Inverse of the Degrees of Freedom</param>
		/// <returns></returns>
		// Token: 0x060001A9 RID: 425 RVA: 0x000082D4 File Offset: 0x000064D4
		public static Complex<T2>[] ComplexUncArray(Complex<Number>[] values, Number[][] covariance, double idof)
		{
			int i = values.Length;
			Complex<Number>[] idof2 = new Complex<Number>[i];
			for (int j = 0; j < i; j++)
			{
				idof2[j] = new Complex<Number>(idof, idof);
			}
			return GenericUnc<T1, T2>.ComplexUncArray(values, covariance, idof2);
		}

		/// <summary>
		/// Creates a new Complex Uncertainty Array
		/// </summary>
		/// <param name="values">Values</param>
		/// <returns></returns>
		// Token: 0x060001AA RID: 426 RVA: 0x00008310 File Offset: 0x00006510
		public static Complex<T2>[] ComplexUncArray(Complex<Number>[] values)
		{
			int i = values.Length;
			Complex<T2>[] x = new Complex<T2>[i];
			for (int j = 0; j < i; j++)
			{
				x[j] = GenericUnc<T1, T2>.ComplexUncNumber(values[j]);
			}
			return x;
		}

		/// <summary>
		/// Creates a new Complex Uncertainty Array
		/// </summary>
		/// <param name="values">Values</param>
		/// <returns></returns>
		// Token: 0x060001AB RID: 427 RVA: 0x00008348 File Offset: 0x00006548
		public static Complex<T2>[] ComplexUncArray(Number[] values)
		{
			int i = values.Length;
			Complex<T2>[] x = new Complex<T2>[i];
			for (int j = 0; j < i; j++)
			{
				x[j] = GenericUnc<T1, T2>.ComplexUncNumber(values[j]);
			}
			return x;
		}

		/// <summary>
		/// Creates a new Real Uncertainty N-Dims Array from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <param name="id">Input Id</param>
		/// <param name="desc">Description</param>
		/// <param name="p">Probability</param>
		/// <returns></returns>
		// Token: 0x060001AC RID: 428 RVA: 0x00008380 File Offset: 0x00006580
		public static RealNArray<T2> RealUncNArrayFromSamples(Number[][] samples, InputId id, string desc, double p)
		{
			RealNArray<T2> realNArray = new RealNArray<T2>();
			realNArray.Init1dData(GenericUnc<T1, T2>.RealUncArrayFromSamples(samples, id, desc, p));
			return realNArray;
		}

		/// <summary>
		/// Creates a new Real Uncertainty N-Dims Array from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <param name="p">Probability</param>
		/// <returns></returns>
		// Token: 0x060001AD RID: 429 RVA: 0x00008396 File Offset: 0x00006596
		public static RealNArray<T2> RealUncNArrayFromSamples(Number[][] samples, double p)
		{
			RealNArray<T2> realNArray = new RealNArray<T2>();
			realNArray.Init1dData(GenericUnc<T1, T2>.RealUncArrayFromSamples(samples, p));
			return realNArray;
		}

		/// <summary>
		/// Creates a new Real Uncertainty N-Dims Array from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <param name="id">Input Id</param>
		/// <param name="desc">Description</param>
		/// <returns></returns>
		// Token: 0x060001AE RID: 430 RVA: 0x000083AA File Offset: 0x000065AA
		public static RealNArray<T2> RealUncNArrayFromSamples(Number[][] samples, InputId id, string desc)
		{
			return GenericUnc<T1, T2>.RealUncNArrayFromSamples(samples, id, desc, 0.95);
		}

		/// <summary>
		/// Creates a new Real Uncertainty N-Dims Array from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <returns></returns>
		// Token: 0x060001AF RID: 431 RVA: 0x000083BD File Offset: 0x000065BD
		public static RealNArray<T2> RealUncNArrayFromSamples(Number[][] samples)
		{
			return GenericUnc<T1, T2>.RealUncNArrayFromSamples(samples, 0.95);
		}

		/// <summary>
		/// Creates a new Real Uncertainty N-Dims Array
		/// </summary>
		/// <param name="values">Values</param>
		/// <param name="covariance">Covariance</param>
		/// <param name="id">Input Id</param>
		/// <param name="desc">Description</param>
		/// <returns></returns>
		// Token: 0x060001B0 RID: 432 RVA: 0x000083CE File Offset: 0x000065CE
		public static RealNArray<T2> RealUncNArray(RealNArray<Number> values, Number[][] covariance, InputId id, string desc)
		{
			RealNArray<T2> realNArray = new RealNArray<T2>();
			realNArray.InitNd(values.size);
			realNArray.data = GenericUnc<T1, T2>.RealUncArray(values.data, covariance, id, desc);
			return realNArray;
		}

		/// <summary>
		/// Creates a new Real Uncertainty N-Dims Array
		/// </summary>
		/// <param name="values">Values</param>
		/// <param name="covariance">Covariance</param>
		/// <param name="idof">Inverse of the Degrees of Freedom</param>
		/// <returns></returns>
		// Token: 0x060001B1 RID: 433 RVA: 0x000083F5 File Offset: 0x000065F5
		public static RealNArray<T2> RealUncNArray(RealNArray<Number> values, Number[][] covariance, RealNArray<Number> idof)
		{
			RealNArray<T2> realNArray = new RealNArray<T2>();
			realNArray.InitNd(values.size);
			realNArray.data = GenericUnc<T1, T2>.RealUncArray(values.data, covariance, idof.data);
			return realNArray;
		}

		/// <summary>
		/// Creates a new Real Uncertainty N-Dims Array
		/// </summary>
		/// <param name="values">Values</param>
		/// <param name="covariance">Covariance</param>
		/// <param name="idof">Inverse of the Degrees of Freedom</param>
		/// <returns></returns>
		// Token: 0x060001B2 RID: 434 RVA: 0x00008420 File Offset: 0x00006620
		public static RealNArray<T2> RealUncNArray(RealNArray<Number> values, Number[][] covariance, double idof)
		{
			RealNArray<T2> realNArray = new RealNArray<Number>();
			realNArray.InitNd(values.size);
			realNArray.data = GenericUnc<T1, T2>.RealUncArray(values.data, covariance, idof);
			return realNArray;
		}

		/// <summary>
		/// Creates a new Real Uncertainty N-Dims Array from samples
		/// </summary>
		/// <param name="values">Values</param>
		/// <returns></returns>
		// Token: 0x060001B3 RID: 435 RVA: 0x00008446 File Offset: 0x00006646
		public static RealNArray<T2> RealUncNArray(RealNArray<Number> values)
		{
			RealNArray<T2> realNArray = new RealNArray<T2>();
			realNArray.InitNd(values.size);
			realNArray.data = GenericUnc<Number>.RealUncArray(values.data);
			return realNArray;
		}

		/// <summary>
		/// Creates a new Complex Uncertainty N-Dims Array from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <param name="id">Input Id</param>
		/// <param name="desc">Description</param>
		/// <param name="p">Probability</param>
		/// <returns></returns>
		// Token: 0x060001B4 RID: 436 RVA: 0x0000846A File Offset: 0x0000666A
		public static ComplexNArray<T2> ComplexUncNArrayFromSamples(Complex<Number>[][] samples, InputId id, string desc, double p)
		{
			ComplexNArray<T2> complexNArray = new ComplexNArray<T2>();
			complexNArray.Init1dData(GenericUnc<T1, T2>.ComplexUncArrayFromSamples(samples, id, desc, p));
			return complexNArray;
		}

		/// <summary>
		/// Creates a new Complex Uncertainty N-Dims Array from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <param name="p">Probability</param>
		/// <returns></returns>
		// Token: 0x060001B5 RID: 437 RVA: 0x00008480 File Offset: 0x00006680
		public static ComplexNArray<T2> ComplexUncNArrayFromSamples(Complex<Number>[][] samples, double p)
		{
			ComplexNArray<T2> complexNArray = new ComplexNArray<T2>();
			complexNArray.Init1dData(GenericUnc<T1, T2>.ComplexUncArrayFromSamples(samples, p));
			return complexNArray;
		}

		/// <summary>
		/// Creates a new Complex Uncertainty N-Dims Array from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <param name="id">Input Id</param>
		/// <param name="desc">Description</param>
		/// <returns></returns>
		// Token: 0x060001B6 RID: 438 RVA: 0x00008494 File Offset: 0x00006694
		public static ComplexNArray<T2> ComplexUncNArrayFromSamples(Complex<Number>[][] samples, InputId id, string desc)
		{
			return GenericUnc<T1, T2>.ComplexUncNArrayFromSamples(samples, id, desc, 0.95);
		}

		/// <summary>
		/// Creates a new Complex Uncertainty N-Dims Array from samples
		/// </summary>
		/// <param name="samples">Samples</param>
		/// <returns></returns>
		// Token: 0x060001B7 RID: 439 RVA: 0x000084A7 File Offset: 0x000066A7
		public static ComplexNArray<T2> ComplexUncNArrayFromSamples(Complex<Number>[][] samples)
		{
			return GenericUnc<T1, T2>.ComplexUncNArrayFromSamples(samples, 0.95);
		}

		/// <summary>
		/// Creates a new Complex Uncertainty N-Dims Array
		/// </summary>
		/// <param name="values">Values</param>
		/// <param name="covariance">Covariance</param>
		/// <param name="id">Input Id</param>
		/// <param name="desc">Description</param>
		/// <returns></returns>
		// Token: 0x060001B8 RID: 440 RVA: 0x000084B8 File Offset: 0x000066B8
		public static ComplexNArray<T2> ComplexUncNArray(ComplexNArray<Number> values, Number[][] covariance, InputId id, string desc)
		{
			ComplexNArray<T2> complexNArray = new ComplexNArray<T2>();
			complexNArray.InitNd(values.size);
			complexNArray.data = GenericUnc<T1, T2>.ComplexUncArray(values.data, covariance, id, desc);
			return complexNArray;
		}

		/// <summary>
		/// Creates a new Complex Uncertainty N-Dims Array
		/// </summary>
		/// <param name="values">Values</param>
		/// <param name="covariance">Covariance</param>
		/// <param name="idof">Inverse of the Degrees of Freedom</param>
		/// <returns></returns>
		// Token: 0x060001B9 RID: 441 RVA: 0x000084DF File Offset: 0x000066DF
		public static ComplexNArray<T2> ComplexUncNArray(ComplexNArray<Number> values, Number[][] covariance, ComplexNArray<Number> idof)
		{
			ComplexNArray<T2> complexNArray = new ComplexNArray<T2>();
			complexNArray.InitNd(values.size);
			complexNArray.data = GenericUnc<T1, T2>.ComplexUncArray(values.data, covariance, idof.data);
			return complexNArray;
		}

		/// <summary>
		/// Creates a new Complex Uncertainty N-Dims Array
		/// </summary>
		/// <param name="values">Values</param>
		/// <param name="covariance">Covariance</param>
		/// <param name="idof">Inverse of the Degrees of Freedom</param>
		/// <returns></returns>
		// Token: 0x060001BA RID: 442 RVA: 0x0000850A File Offset: 0x0000670A
		public static ComplexNArray<T2> ComplexUncNArray(ComplexNArray<Number> values, Number[][] covariance, double idof)
		{
			ComplexNArray<T2> complexNArray = new ComplexNArray<T2>();
			complexNArray.InitNd(values.size);
			complexNArray.data = GenericUnc<T1, T2>.ComplexUncArray(values.data, covariance, idof);
			return complexNArray;
		}

		/// <summary>
		/// Creates a new Complex Uncertainty N-Dims Array
		/// </summary>
		/// <param name="values">Values</param>
		/// <returns></returns>
		// Token: 0x060001BB RID: 443 RVA: 0x00008530 File Offset: 0x00006730
		public static ComplexNArray<T2> ComplexUncNArray(ComplexNArray<Number> values)
		{
			ComplexNArray<T2> complexNArray = new ComplexNArray<T2>();
			complexNArray.InitNd(values.size);
			complexNArray.data = GenericUnc<T1, T2>.ComplexUncArray(values.data);
			return complexNArray;
		}

		/// <summary>
		/// Creates a new Complex Uncertainty N-Dims Array
		/// </summary>
		/// <param name="values">Values</param>
		/// <returns></returns>
		// Token: 0x060001BC RID: 444 RVA: 0x00008554 File Offset: 0x00006754
		public static ComplexNArray<T2> ComplexUncNArray(RealNArray<Number> values)
		{
			ComplexNArray<T2> complexNArray = new ComplexNArray<T2>();
			complexNArray.InitNd(values.size);
			complexNArray.data = GenericUnc<T1, T2>.ComplexUncArray(values.data);
			return complexNArray;
		}

		/// <summary>
		/// Returns the Expected Value of a Real Uncertainty Number.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001BD RID: 445 RVA: 0x00008578 File Offset: 0x00006778
		public static Number GetValue(T2 x)
		{
			return x.Value;
		}

		/// <summary>
		/// Returns the Expected Value of a Complex Uncertainty Number.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001BE RID: 446 RVA: 0x0000858C File Offset: 0x0000678C
		public static Complex<Number> GetValue(Complex<T2> x)
		{
			return new Complex<Number>(GenericUnc<T1, T2>.GetValue(x.real), GenericUnc<T1, T2>.GetValue(x.imag));
		}

		/// <summary>
		/// Returns the Expected Value of a Real Uncertainty Array.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001BF RID: 447 RVA: 0x000085AC File Offset: 0x000067AC
		public static Number[] GetValue(T2[] x)
		{
			int i = x.Length;
			Number[] y = new Number[i];
			for (int j = 0; j < i; j++)
			{
				y[j] = GenericUnc<T1, T2>.GetValue(x[j]);
			}
			return y;
		}

		/// <summary>
		/// Returns the Expected Value of a Complex Uncertainty Array.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001C0 RID: 448 RVA: 0x000085E4 File Offset: 0x000067E4
		public static Complex<Number>[] GetValue(Complex<T2>[] x)
		{
			int i = x.Length;
			Complex<Number>[] y = new Complex<Number>[i];
			for (int j = 0; j < i; j++)
			{
				y[j] = GenericUnc<T1, T2>.GetValue(x[j]);
			}
			return y;
		}

		/// <summary>
		/// Returns the Expected Value of a Real Uncertainty N-Dim Array.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001C1 RID: 449 RVA: 0x0000861C File Offset: 0x0000681C
		public static RealNArray<Number> GetValue(RealNArray<T2> x)
		{
			int i = x.numel;
			RealNArray<Number> y = new RealNArray<Number>();
			y.InitNd(x.size);
			for (int j = 0; j < i; j++)
			{
				y[j] = GenericUnc<T1, T2>.GetValue(x[j]);
			}
			return y;
		}

		/// <summary>
		/// Returns the Expected Value of a Complex Uncertainty N-Dim Array.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001C2 RID: 450 RVA: 0x00008664 File Offset: 0x00006864
		public static ComplexNArray<Number> GetValue(ComplexNArray<T2> x)
		{
			int i = x.numel;
			ComplexNArray<Number> y = new ComplexNArray<Number>();
			y.InitNd(x.size);
			for (int j = 0; j < i; j++)
			{
				y[j] = GenericUnc<T1, T2>.GetValue(x[j]);
			}
			return y;
		}

		/// <summary>
		/// Returns the Function Value of a Real Uncertainty Number.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001C3 RID: 451 RVA: 0x000086AA File Offset: 0x000068AA
		public static Number GetFcnValue(T2 x)
		{
			return x.FcnValue;
		}

		/// <summary>
		/// Returns the Function Value of a Complex Uncertainty Number.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001C4 RID: 452 RVA: 0x000086BE File Offset: 0x000068BE
		public static Complex<Number> GetFcnValue(Complex<T2> x)
		{
			return new Complex<Number>(GenericUnc<T1, T2>.GetFcnValue(x.real), GenericUnc<T1, T2>.GetFcnValue(x.imag));
		}

		/// <summary>
		/// Returns the Function Value of a Real Uncertainty Array.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001C5 RID: 453 RVA: 0x000086DC File Offset: 0x000068DC
		public static Number[] GetFcnValue(T2[] x)
		{
			int i = x.Length;
			Number[] y = new Number[i];
			for (int j = 0; j < i; j++)
			{
				y[j] = GenericUnc<T1, T2>.GetFcnValue(x[j]);
			}
			return y;
		}

		/// <summary>
		/// Returns the Function Value of a Complex Uncertainty Array.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001C6 RID: 454 RVA: 0x00008714 File Offset: 0x00006914
		public static Complex<Number>[] GetFcnValue(Complex<T2>[] x)
		{
			int i = x.Length;
			Complex<Number>[] y = new Complex<Number>[i];
			for (int j = 0; j < i; j++)
			{
				y[j] = GenericUnc<T1, T2>.GetFcnValue(x[j]);
			}
			return y;
		}

		/// <summary>
		/// Returns the Function Value of a Real Uncertainty N-Dim Array.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001C7 RID: 455 RVA: 0x0000874C File Offset: 0x0000694C
		public static RealNArray<Number> GetFcnValue(RealNArray<T2> x)
		{
			int i = x.numel;
			RealNArray<Number> y = new RealNArray<Number>();
			y.InitNd(x.size);
			for (int j = 0; j < i; j++)
			{
				y[j] = GenericUnc<T1, T2>.GetFcnValue(x[j]);
			}
			return y;
		}

		/// <summary>
		/// Returns the Function Value of a Complex Uncertainty N-Dim Array.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001C8 RID: 456 RVA: 0x00008794 File Offset: 0x00006994
		public static ComplexNArray<Number> GetFcnValue(ComplexNArray<T2> x)
		{
			int i = x.numel;
			ComplexNArray<Number> y = new ComplexNArray<Number>();
			y.InitNd(x.size);
			for (int j = 0; j < i; j++)
			{
				y[j] = GenericUnc<T1, T2>.GetFcnValue(x[j]);
			}
			return y;
		}

		/// <summary>
		/// Computes the Standard Uncertainty of a Real Uncertainty Number.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001C9 RID: 457 RVA: 0x000087DA File Offset: 0x000069DA
		public static Number GetStdUnc(T2 x)
		{
			return x.StdUnc;
		}

		/// <summary>
		/// Computes the Standard Uncertainty of a Complex Uncertainty Number.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001CA RID: 458 RVA: 0x000087EE File Offset: 0x000069EE
		public static Complex<Number> GetStdUnc(Complex<T2> x)
		{
			return new Complex<Number>(GenericUnc<T1, T2>.GetStdUnc(x.real), GenericUnc<T1, T2>.GetStdUnc(x.imag));
		}

		/// <summary>
		/// Computes the Standard Uncertainty of a Real Uncertainty Array.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001CB RID: 459 RVA: 0x0000880C File Offset: 0x00006A0C
		public static Number[] GetStdUnc(T2[] x)
		{
			int i = x.Length;
			Number[] y = new Number[i];
			for (int j = 0; j < i; j++)
			{
				y[j] = GenericUnc<T1, T2>.GetStdUnc(x[j]);
			}
			return y;
		}

		/// <summary>
		/// Computes the Standard Uncertainty of a Complex Uncertainty Array.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001CC RID: 460 RVA: 0x00008844 File Offset: 0x00006A44
		public static Complex<Number>[] GetStdUnc(Complex<T2>[] x)
		{
			int i = x.Length;
			Complex<Number>[] y = new Complex<Number>[i];
			for (int j = 0; j < i; j++)
			{
				y[j] = GenericUnc<T1, T2>.GetStdUnc(x[j]);
			}
			return y;
		}

		/// <summary>
		/// Computes the Standard Uncertainty of a Real Uncertainty N-Dim Array.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001CD RID: 461 RVA: 0x0000887C File Offset: 0x00006A7C
		public static RealNArray<Number> GetStdUnc(RealNArray<T2> x)
		{
			int i = x.numel;
			RealNArray<Number> y = new RealNArray<Number>();
			y.InitNd(x.size);
			for (int j = 0; j < i; j++)
			{
				y[j] = GenericUnc<T1, T2>.GetStdUnc(x[j]);
			}
			return y;
		}

		/// <summary>
		/// Computes the Standard Uncertainty of a Complex Uncertainty N-Dim Array.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001CE RID: 462 RVA: 0x000088C4 File Offset: 0x00006AC4
		public static ComplexNArray<Number> GetStdUnc(ComplexNArray<T2> x)
		{
			int i = x.numel;
			ComplexNArray<Number> y = new ComplexNArray<Number>();
			y.InitNd(x.size);
			for (int j = 0; j < i; j++)
			{
				y[j] = GenericUnc<T1, T2>.GetStdUnc(x[j]);
			}
			return y;
		}

		/// <summary>
		/// Computes the Inverse of the Degrees of Freedom of a Real Uncertainty Number.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001CF RID: 463 RVA: 0x0000890A File Offset: 0x00006B0A
		public static Number GetIDof(T2 x)
		{
			return x.IDof;
		}

		/// <summary>
		/// Computes the Inverse of the Degrees of Freedom of a Complex Uncertainty Number.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001D0 RID: 464 RVA: 0x0000891E File Offset: 0x00006B1E
		public static Complex<Number> GetIDof(Complex<T2> x)
		{
			return new Complex<Number>(GenericUnc<T1, T2>.GetIDof(x.real), GenericUnc<T1, T2>.GetIDof(x.imag));
		}

		/// <summary>
		/// Computes the Inverse of the Degrees of Freedom of a Real Uncertainty Array.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001D1 RID: 465 RVA: 0x0000893C File Offset: 0x00006B3C
		public static Number[] GetIDof(T2[] x)
		{
			int i = x.Length;
			Number[] y = new Number[i];
			for (int j = 0; j < i; j++)
			{
				y[j] = GenericUnc<T1, T2>.GetIDof(x[j]);
			}
			return y;
		}

		/// <summary>
		/// Computes the Inverse of the Degrees of Freedom of a Complex Uncertainty Array.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001D2 RID: 466 RVA: 0x00008974 File Offset: 0x00006B74
		public static Complex<Number>[] GetIDof(Complex<T2>[] x)
		{
			int i = x.Length;
			Complex<Number>[] y = new Complex<Number>[i];
			for (int j = 0; j < i; j++)
			{
				y[j] = GenericUnc<T1, T2>.GetIDof(x[j]);
			}
			return y;
		}

		/// <summary>
		/// Computes the Inverse of the Degrees of Freedom of a Real Uncertainty N-Dim Array.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001D3 RID: 467 RVA: 0x000089AC File Offset: 0x00006BAC
		public static RealNArray<Number> GetIDof(RealNArray<T2> x)
		{
			int i = x.numel;
			RealNArray<Number> y = new RealNArray<Number>();
			y.InitNd(x.size);
			for (int j = 0; j < i; j++)
			{
				y[j] = GenericUnc<T1, T2>.GetIDof(x[j]);
			}
			return y;
		}

		/// <summary>
		/// Computes the Inverse of the Degrees of Freedom of a Complex Uncertainty N-Dim Array.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		// Token: 0x060001D4 RID: 468 RVA: 0x000089F4 File Offset: 0x00006BF4
		public static ComplexNArray<Number> GetIDof(ComplexNArray<T2> x)
		{
			int i = x.numel;
			ComplexNArray<Number> y = new ComplexNArray<Number>();
			y.InitNd(x.size);
			for (int j = 0; j < i; j++)
			{
				y[j] = GenericUnc<T1, T2>.GetIDof(x[j]);
			}
			return y;
		}

		/// <summary>
		/// Computes the n-th Central Moment of a Real Uncertainty Number.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="n"></param>
		/// <returns></returns>
		// Token: 0x060001D5 RID: 469 RVA: 0x00008A3A File Offset: 0x00006C3A
		public static Number GetMoment(T2 x, int n)
		{
			return x.GetMoment(n);
		}

		/// <summary>
		/// Computes the n-th Central Moment of a Complex Uncertainty Number.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="n"></param>
		/// <returns></returns>
		// Token: 0x060001D6 RID: 470 RVA: 0x00008A4F File Offset: 0x00006C4F
		public static Complex<Number> GetMoment(Complex<T2> x, int n)
		{
			return new Complex<Number>(GenericUnc<T1, T2>.GetMoment(x.real, n), GenericUnc<T1, T2>.GetMoment(x.imag, n));
		}

		/// <summary>
		/// Computes the n-th Central Moment of a Real Uncertainty Array.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="n"></param>
		/// <returns></returns>
		// Token: 0x060001D7 RID: 471 RVA: 0x00008A70 File Offset: 0x00006C70
		public static Number[] GetMoment(T2[] x, int n)
		{
			int n2 = x.Length;
			Number[] y = new Number[n2];
			for (int i = 0; i < n2; i++)
			{
				y[i] = GenericUnc<T1, T2>.GetMoment(x[i], n);
			}
			return y;
		}

		/// <summary>
		/// Computes the n-th Central Moment of a Complex Uncertainty Array.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="n"></param>
		/// <returns></returns>
		// Token: 0x060001D8 RID: 472 RVA: 0x00008AAC File Offset: 0x00006CAC
		public static Complex<Number>[] GetMoment(Complex<T2>[] x, int n)
		{
			int n2 = x.Length;
			Complex<Number>[] y = new Complex<Number>[n2];
			for (int i = 0; i < n2; i++)
			{
				y[i] = GenericUnc<T1, T2>.GetMoment(x[i], n);
			}
			return y;
		}

		/// <summary>
		/// Computes the n-th Central Moment of a Real Uncertainty N-Dim Array.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="n"></param>
		/// <returns></returns>
		// Token: 0x060001D9 RID: 473 RVA: 0x00008AE8 File Offset: 0x00006CE8
		public static RealNArray<Number> GetMoment(RealNArray<T2> x, int n)
		{
			int n2 = x.numel;
			RealNArray<Number> y = new RealNArray<Number>();
			y.InitNd(x.size);
			for (int i = 0; i < n2; i++)
			{
				y[i] = GenericUnc<T1, T2>.GetMoment(x[i], n);
			}
			return y;
		}

		/// <summary>
		/// Computes the n-th Central Moment of a Complex Uncertainty N-Dim Array.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="n"></param>
		/// <returns></returns>
		// Token: 0x060001DA RID: 474 RVA: 0x00008B30 File Offset: 0x00006D30
		public static ComplexNArray<Number> GetMoment(ComplexNArray<T2> x, int n)
		{
			int n2 = x.numel;
			ComplexNArray<Number> y = new ComplexNArray<Number>();
			y.InitNd(x.size);
			for (int i = 0; i < n2; i++)
			{
				y[i] = GenericUnc<T1, T2>.GetMoment(x[i], n);
			}
			return y;
		}

		/// <summary>
		/// Computes the Coverage Interval of a Uncertainty List.
		/// </summary>
		/// <param name="z">Uncertainty List</param>
		/// <param name="p">Probability</param>
		/// <returns></returns>
		// Token: 0x060001DB RID: 475 RVA: 0x00008B78 File Offset: 0x00006D78
		public static Number[][] GetCoverageInterval(T1 z, double p)
		{
			int i = z.data.Length;
			Number[][] ci = new Number[i][];
			for (int j = 0; j < i; j++)
			{
				double[] ci2 = z.data[j].GetCoverageInterval(p);
				ci[j] = new Number[]
				{
					ci2[0],
					ci2[1]
				};
			}
			return ci;
		}

		/// <summary>
		/// Computes the Coverage Factor k.
		/// </summary>
		/// <param name="idof">Inverse of the Degrees of Freedom</param>
		/// <param name="dims">Dimensions</param>
		/// <param name="p">Probability</param>
		/// <returns></returns>
		// Token: 0x060001DC RID: 476 RVA: 0x00008BF2 File Offset: 0x00006DF2
		public static double CoverageFactor(double idof, int dims, double p)
		{
			return Statistics.CoverageFactor(idof, dims, p);
		}

		/// <summary>
		/// Computes the Covariance Matrix of a Uncertainty List.
		/// </summary>
		/// <param name="z">Uncertainty List</param>
		/// <returns></returns>
		// Token: 0x060001DD RID: 477 RVA: 0x00008BFC File Offset: 0x00006DFC
		public static Number[][] GetCovariance(T1 z)
		{
			return z.GetCovariance();
		}

		/// <summary>
		/// Computes the Correlation Matrix of a Uncertainty List.
		/// </summary>
		/// <param name="z">Uncertainty List</param>
		/// <returns></returns>
		// Token: 0x060001DE RID: 478 RVA: 0x00008C0B File Offset: 0x00006E0B
		public static Number[][] GetCorrelation(T1 z)
		{
			return GenericUnc<T1, T2>.Covariance2Correlation(GenericUnc<T1, T2>.GetCovariance(z));
		}

		// Token: 0x060001DF RID: 479 RVA: 0x00008C18 File Offset: 0x00006E18
		private static Number[][] Covariance2Correlation(Number[][] a)
		{
			int n = a.Length;
			int n2 = 0;
			if (n > 0)
			{
				n2 = a[0].Length;
			}
			if (n != n2)
			{
				throw new Exception("Matrix must be square");
			}
			Number[][] b = Array.Identity<Number>(n);
			for (int i = 0; i < n; i++)
			{
				for (int i2 = 0; i2 < i; i2++)
				{
					b[i][i2] = a[i][i2].Divide(a[i][i].Multiply(a[i2][i2]).Sqrt());
					b[i2][i] = b[i][i2];
				}
			}
			return b;
		}

		/// <summary>
		/// Computes the Jacobi Matrix of a Uncertainty List.
		/// </summary>
		/// <param name="z">Uncertainty List</param>
		/// <returns></returns>
		// Token: 0x060001E0 RID: 480 RVA: 0x00008CB7 File Offset: 0x00006EB7
		public static Number[][] GetJacobi(T1 z)
		{
			return z.GetJacobi();
		}

		/// <summary>
		/// Computes the Sensitivities to intermediate steps.
		/// </summary>
		/// <param name="z">Uncertainty List</param>
		/// <param name="y">Intermediate Result Uncertainty List</param>
		/// <returns></returns>
		// Token: 0x060001E1 RID: 481 RVA: 0x00008CC6 File Offset: 0x00006EC6
		public static Number[][] GetJacobi2(T1 z, T1 y)
		{
			return z.GetJacobi2(y);
		}

		/// <summary>
		/// Computes the Uncertainty Components.
		/// </summary>
		/// <param name="z">Uncertainty List</param>
		/// <param name="y">Intermediate Result Uncertainty List</param>
		/// <returns></returns>
		// Token: 0x060001E2 RID: 482 RVA: 0x00008CDB File Offset: 0x00006EDB
		public static Number[][] GetUncComponent(T1 z, T1 y)
		{
			return z.GetUncComponent(y);
		}

		// Token: 0x0400000E RID: 14
		private const double DEFAULT_PROPABILITY = 0.95;
	}
}
