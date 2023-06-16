using System;
using System.Collections.Generic;

namespace Nuvo.Math.Core.Special
{
	/// <summary>
	/// Double Helper
	/// </summary>
	// Token: 0x02000028 RID: 40
	public static class DoubleHelper
	{
		/// <summary>
		/// Is Approximately Equal
		/// </summary>
		/// <param name="value1">Value 1</param>
		/// <param name="value2">Value 2</param>
		/// <param name="epsilon">Epsilon (Default: 1e-15)</param>
		/// <returns></returns>
		// Token: 0x06000212 RID: 530 RVA: 0x000098E8 File Offset: 0x00007AE8
		public static bool IsApproximatelyEqual(double value1, double value2, double epsilon = 1E-15)
		{
			if (value1.Equals(value2))
			{
				return true;
			}
			if (double.IsInfinity(value1) | double.IsNaN(value1))
			{
				return value1.Equals(value2);
			}
			if (double.IsInfinity(value2) | double.IsNaN(value2))
			{
				return value1.Equals(value2);
			}
			double divisor = Math.Max(value1, value2);
			if (divisor.Equals(0.0))
			{
				divisor = Math.Min(value1, value2);
			}
			return Math.Abs((value1 - value2) / divisor) <= epsilon;
		}

		/// <summary>
		/// Is Less or Approximately Equal
		/// </summary>
		/// <param name="value1">Value 1</param>
		/// <param name="value2">Value 2</param>
		/// <param name="epsilon">Epsilon (Default: 1e-15)</param>
		/// <returns></returns>
		// Token: 0x06000213 RID: 531 RVA: 0x00009963 File Offset: 0x00007B63
		public static bool IsLessOrApproximatelyEqual(double value1, double value2, double epsilon = 1E-15)
		{
			return value1 <= value2 || DoubleHelper.IsApproximatelyEqual(value1, value2, epsilon);
		}

		/// <summary>
		/// Is Greater or Approximately Equal
		/// </summary>
		/// <param name="value1">Value 1</param>
		/// <param name="value2">Value 2</param>
		/// <param name="epsilon">Epsilon (Default: 1e-15)</param>
		/// <returns></returns>
		// Token: 0x06000214 RID: 532 RVA: 0x00009973 File Offset: 0x00007B73
		public static bool IsGreaterOrApproximatelyEqual(double value1, double value2, double epsilon = 1E-15)
		{
			return value1 >= value2 || DoubleHelper.IsApproximatelyEqual(value1, value2, epsilon);
		}

		/// <summary>
		/// Is Approximately Equal
		/// </summary>
		/// <param name="values1">Values 1</param>
		/// <param name="values2">Values 2</param>
		/// <param name="epsilon">Epsilon (Default: 1e-15)</param>
		/// <returns></returns>
		// Token: 0x06000215 RID: 533 RVA: 0x00009984 File Offset: 0x00007B84
		public static bool IsApproximatelyEqual(double[] values1, double[] values2, double epsilon = 1E-15)
		{
			int n = (values1 != null) ? values1.Length : 0;
			int n2 = (values2 != null) ? values2.Length : 0;
			bool same = n == n2;
			if (same)
			{
				for (int i = 0; i < n; i++)
				{
					same = (same && DoubleHelper.IsApproximatelyEqual(values1[i], values2[i], epsilon));
					if (!same)
					{
						break;
					}
				}
			}
			return same;
		}

		/// <summary>
		/// Union of two sorted arrays
		/// </summary>
		/// <param name="a">Array a</param>
		/// <param name="b">Array b</param>
		/// <returns></returns>
		// Token: 0x06000216 RID: 534 RVA: 0x000099D0 File Offset: 0x00007BD0
		public static double[] Union(double[] a, double[] b)
		{
			int i = 0;
			int i2 = 0;
			int n = a.Length;
			int n2 = b.Length;
			List<double> c = new List<double>(n + n2);
			while (i < n || i2 < n2)
			{
				if (i < n)
				{
					if (i2 < n2)
					{
						if (DoubleHelper.IsApproximatelyEqual(a[i], b[i2], 1E-15))
						{
							c.Add(a[i++]);
							i2++;
						}
						else if (a[i] < b[i2])
						{
							c.Add(a[i++]);
						}
						else
						{
							c.Add(b[i2++]);
						}
					}
					else
					{
						c.Add(a[i++]);
					}
				}
				else
				{
					c.Add(b[i2++]);
				}
			}
			return c.ToArray();
		}

		/// <summary>
		/// Intersection of two sorted arrays
		/// </summary>
		/// <param name="a">Array a</param>
		/// <param name="b">Array b</param>
		/// <returns></returns>
		// Token: 0x06000217 RID: 535 RVA: 0x00009A7C File Offset: 0x00007C7C
		public static double[] Intersection(double[] a, double[] b)
		{
			int i = 0;
			int i2 = 0;
			int n = a.Length;
			int n2 = b.Length;
			List<double> c = new List<double>(Math.Min(n, n2));
			while (i < n && i2 < n2)
			{
				if (DoubleHelper.IsApproximatelyEqual(a[i], b[i2], 1E-15))
				{
					c.Add(a[i++]);
					i2++;
				}
				else if (a[i] < b[i2])
				{
					i++;
				}
				else
				{
					i2++;
				}
			}
			return c.ToArray();
		}
	}
}
