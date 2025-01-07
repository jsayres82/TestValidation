using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Utilities.Math
{
    public class MathClass
    {
        /// <summary>
		/// Unwrap Phase
		/// </summary>
		/// <typeparam name="T">Real Number Type</typeparam>
		/// <param name="p">Phase</param>
		/// <returns></returns>
		public static double[] UnwrapPhase(double[] p)
        {
            double num = System.Math.PI;
            double num2 = num;
            double num3 = 0.0;
            double num4 = 0.0;
            int num5 = p.Length;
            double[] array = new double[num5];
            for (int i = 0; i < num5; i++)
            {
                if (p[i] + num4 - num3 >= num2)
                {
                    num4 -= 2.0 * num;
                }
                else if (p[i] + num4 - num3 <= 0.0 - num2)
                {
                    num4 += 2.0 * num;
                }

                array[i] = p[i] + num4;

                if (array[i] == 0)
                {
                    int err = 1;
                }
                num3 = array[i];
            }

            return array;
        }

        public static double[] WrapPhase(double[] p)
        {
            int num = p.Length;
            double[] array = new double[num];
            for (int i = 0; i < num; i++)
            {
                array[i] = WrapPhase(p[i]);
            }

            return array;
        }

        public static double WrapPhase(double p)
        {
            double num = System.Math.PI;
            return Mod(p + num, 2.0 * num) - num;
        }

        private static double Mod(double x, double y)
        {
            return x - System.Math.Floor(x / y) * y;
        }

        /// <summary>
        /// Phase Delay
        /// </summary>
        /// <typeparam name="T">Real Number Type</typeparam>
        /// <param name="freq">Frequency / Hz</param>
        /// <param name="phase">Phase / rad</param>
        /// <param name="unwrapPhase">Unwrap Phase</param>
        /// <param name="phaseDC">Phase at DC / rad</param>
        /// <returns>Phase Delay / s</returns>
        public static double[] PhaseDelay(double[] freq, double[] phase, bool unwrapPhase, double phaseDC = 0.0)
        {
            double[] array = unwrapPhase ? UnwrapPhase(phase) : phase;
            double b = (3.141592653589793 * System.Math.Round(phaseDC / 3.141592653589793));
            int num = (freq != null) ? freq.Length : 0;
            double[] array2 = new double[num];
            for (int i = 0; i < num; i++)
            {
                var b2 = Activator.CreateInstance<double>();
                b2 = -6.283185307179586 * freq[i];
                double[] array3 = array2;
                int num2 = i;
                double t = array[i] - (b);
                array3[num2] = t / b2;
            }
            return array2;
        }

        /// <summary>
        /// Group Delay
        /// </summary>
        /// <typeparam name="T">Real Number Type</typeparam>
        /// <param name="freq">Frequency / Hz</param>
        /// <param name="phase">Phase / rad</param>
        /// <param name="unwrapPhase">Unwrap Phase</param>
        /// <returns>Group Delay / s</returns>
        public static double[] GroupDelay(double[] freq, double[] phase, bool unwrapPhase)
        {
            double[] array = unwrapPhase ? UnwrapPhase(phase) : phase;
            int num = (freq != null) ? freq.Length : 0;
            if (num == 0)
            {
                return new double[0];
            }
            double[] array2 = new double[num];
            double[] array3 = new double[num - 1];
            double[] array4 = new double[num - 1];
            for (int i = 0; i < num - 1; i++)
            {
                double b = Activator.CreateInstance<double>();
                array3[i] = (freq[i + 1] + freq[i]) / 2.0;
                b = -6.283185307179586 * (freq[i + 1] - freq[i]);
                double[] array5 = array4;
                int num2 = i;
                double t = array[i + 1] - (array[i]);
                array5[num2] = t / b;
            }
            for (int j = 1; j < num - 1; j++)
            {
                double t2 = array4[j] - (array4[j - 1]);
                double b2 = Activator.CreateInstance<double>();
                b2 = (array3[j] - array3[j - 1]);
                double b3 = Activator.CreateInstance<double>();
                b3 = (array3[j - 1]);
                double t3 = t2 / b2;
                double b4 = array4[j - 1] - (t3 * (b3));
                double b5 = Activator.CreateInstance<double>();
                b5 = (freq[j]);
                double[] array6 = array2;
                int num3 = j;
                double t = t3 * (b5);
                array6[num3] = t + (b4);
                if (j == 1)
                {
                    double b6 = Activator.CreateInstance<double>();
                    b6 = (freq[0]);
                    double[] array7 = array2;
                    int num4 = 0;
                    t = t3 * (b6);
                    array7[num4] = t + (b4);
                }
                if (j == num - 2)
                {
                    double b7 = Activator.CreateInstance<double>();
                    b7 = (freq[num - 1]);
                    double[] array8 = array2;
                    int num5 = num - 1;
                    t = t3 * (b7);
                    array8[num5] = t + (b4);
                }
            }
            return array2;
        }
        public static double[] PolyFit(double[] x, double[] y, int n)
        {
            if (x.Length != y.Length)
            {
                throw new Exception("Vector dimensions must agree");
            }

            int num = x.Length;
            int num2 = n + 1;
            if (1 > num2 || num2 > num)
            {
                throw new Exception("Polynom order out of range");
            }

            double[][] array = new double[num][];
            for (int i = 0; i < num; i++)
            {
                array[i] = new double[num2];
                double val = new double();
                val = (1.0);
                for (int num3 = num2 - 1; num3 >= 0; num3--)
                {
                    array[i][num3] = val;
                    if (num3 > 0)
                    {
                        val = val * (x[i]);
                    }
                }
            }

            if (num == num2)
            {
                return LinAlgSolve(array, y);
            }

            return LinAlgLstSqrSolve(array, y);
        }


        public static double[] LinAlgLstSqrSolve(double[][] a, double[] y)
        {
            double[][] a2 = CTranspose(a);
            return Solve(Dot(a2, a), Dot(a2, y));
        }

        public static double[] LstSqrSolve(double[][] a, double[] y)
        {
            double[][] a2 = CTranspose(a);
            return Solve(Dot(a2, a), Dot(a2, y));
        }


        public static double[][] Dot(double[][] a, double[][] b)
        {
            int num = a.Length;
            int num2 = 0;
            if (num > 0)
            {
                num2 = a[0].Length;
            }

            int num3 = b.Length;
            int num4 = 0;
            if (num3 > 0)
            {
                num4 = b[0].Length;
            }

            if (num2 != num3)
            {
                throw new Exception("Inner matrix dimensions must agree");
            }

            double zero = 0;
            double[][] array = new double[num][];
            for (int i = 0; i < num; i++)
            {
                double[] array2 = new double[num4];
                for (int j = 0; j < num4; j++)
                {
                    double val = zero;
                    for (int k = 0; k < num2; k++)
                    {
                        val = val + (a[i][k] * (b[k][j]));
                    }

                    array2[j] = val;
                }

                array[i] = array2;
            }

            return array;
        }

        public static double[] Dot(double[][] a, double[] b)
        {
            int num = a.Length;
            int num2 = 0;
            if (num > 0)
            {
                num2 = a[0].Length;
            }

            int num3 = b.Length;
            if (num2 != num3)
            {
                throw new Exception("Inner matrix dimensions must agree");
            }

            double zero = 0;
            double[] array = new double[num];
            for (int i = 0; i < num; i++)
            {
                double val = zero;
                for (int j = 0; j < num2; j++)
                {
                    val = val + (a[i][j] * (b[j]));
                }

                array[i] = val;
            }

            return array;
        }
        public static double[][] CTranspose(double[][] a)
        {
            int num = a.Length;
            int num2 = 0;
            if (num > 0)
            {
                num2 = a[0].Length;
            }

            double[][] array = new double[num2][];
            for (int i = 0; i < num2; i++)
            {
                array[i] = new double[num];
                for (int j = 0; j < num; j++)
                {
                    array[i][j] = a[j][i];
                }
            }

            return array;
        }

        public static double[] Solve(double[][] a, double[] y)
        {
            LuResult luResult = Lu(a);
            int num = y.Length;
            double[] array = new double[num];
            for (int i = 0; i < num; i++)
            {
                array[i] = y[luResult.c[i]];
            }

            return Bsub(luResult.u, Fsub(luResult.l, array));
        }

        public static double[] Fsub(double[][] l, double[] y)
        {
            int num = y.Length;
            int num2 = -1;
            double[] array = Array.Zeros1d(num);
            for (int i = 0; i < num; i++)
            {
                double val = y[i];
                if (num2 >= 0)
                {
                    for (int j = num2; j < i; j++)
                    {
                        val = val - (array[j] * (l[i][j]));
                    }
                }
                else if (val != 0)
                {
                    num2 = i;
                }

                array[i] = val;
            }

            return array;
        }

        public static double[] Bsub(double[][] u, double[] y)
        {
            int num = y.Length;
            double[] array = Array.Zeros1d(num);
            for (int num2 = num - 1; num2 >= 0; num2--)
            {
                double val = y[num2];
                for (int i = num2 + 1; i < num; i++)
                {
                    val = val - (array[i] * (u[num2][i]));
                }

                array[num2] = val / (u[num2][num2]);
            }

            return array;
        }

        private static void InterchangeRows(double[][] a, int index_1, int index_2)
        {
            double[] array = a[index_1];
            a[index_1] = a[index_2];
            a[index_2] = array;
        }

        private static void InterchangeRows(int[] a, int index_1, int index_2)
        {
            int num = a[index_1];
            a[index_1] = a[index_2];
            a[index_2] = num;
        }

        public static LuResult Lu(double[][] a)
        {
            int num = a.Length;
            int num2 = 0;
            if (num > 0)
            {
                num2 = a[0].Length;
            }

            if (num != num2)
            {
                throw new Exception("Matrix must be square");
            }

            int num3 = 0;
            double zero = 0;
            double one = 1;
            int[] array = new int[num];
            for (int i = 0; i < num; i++)
            {
                array[i] = i;
            }

            double[][] array2 = Array.Zeros2d(num, num);
            double[][] array3 = Array.Identity(num);
            double[][] array4 = Array.Copy(a);
            for (int j = 0; j < num; j++)
            {
                int num4 = j;
                double num5 = array4[j][j] * array4[j][j];
                for (int k = j + 1; k < num; k++)
                {
                    double num6 = array4[k][j] * array4[k][j];
                    if (num6 > num5)
                    {
                        num4 = k;
                        num5 = num6;
                    }
                }

                if (num5 == 0.0)
                {
                    throw new Exception("Matrix is singular");
                }

                if (num4 != j)
                {
                    InterchangeRows(array2, num4, j);
                    InterchangeRows(array4, num4, j);
                    InterchangeRows(array3, num4, j);
                    InterchangeRows(array, num4, j);
                    num3++;
                }

                for (int l = j + 1; l < num; l++)
                {
                    array2[l][j] = array4[l][j] / (array4[j][j]);
                    array4[l][j] = zero;
                    for (int m = j + 1; m < num; m++)
                    {
                        array4[l][m] = array4[l][m] - (array2[l][j] / (array4[j][m]));
                    }
                }
            }

            for (int n = 0; n < num; n++)
            {
                array2[n][n] = one;
            }

            LuResult result = default(LuResult);
            result.l = array2;
            result.u = array4;
            result.p = array3;
            result.c = array;
            result.d = num3;
            return result;
        }

        public static double[] LinAlgSolve(double[][] a, double[] y)
        {
            LuResult luResult = Lu(a);
            int num = y.Length;
            double[] array = new double[num];
            for (int i = 0; i < num; i++)
            {
                array[i] = y[luResult.c[i]];
            }

            return Bsub(luResult.u, Fsub(luResult.l, array));
        }
        /// <summary>
        /// Unwrap Phase (phase should start at DC between +90 deg and -270 deg for a negative slope or -90 deg and +270 deg for a positive slope)
        /// </summary>
        /// <typeparam name="T">Real Number Type</typeparam>
        /// <param name="freq">Frequency / Hz</param>
        /// <param name="phase">Phase / rad</param>
        /// <param name="fc">Cutoff Frequency / Hz. For a coaxial line or free space, set cutoff frequency to 0 Hz.</param>
        /// <param name="auto_fc">Automatic Cutoff Frequency</param>
        /// <param name="phaseDC_out">Phase at DC / rad</param>
        /// <param name="fc_out">Cutoff Frequency / Hz.</param>
        /// <returns></returns>
        public static double[] Unwrap(double[] freq, double[] phase, double fc, bool auto_fc, out double phaseDC_out, out double fc_out)
        {
            int num = (freq != null) ? freq.Length : 0;
            if (auto_fc)
            {
                fc = 0.0;
            }
            phaseDC_out = 0.0;
            fc_out = fc;
            if (num == 0)
            {
                return new double[0];
            }
            double[] array = CutoffCorrectedFrequency(freq, fc);
            double[] array2 = UnwrapPhase(phase);
            double num2 = 57.29577951308232;
            if (freq[0] == 0.0 && !double.IsNaN(array2[0]))
            {
                phaseDC_out = array2[0];
                Console.WriteLine("Phase Unwrap - Phase at DC: " + (phaseDC_out * num2).ToString("f1") + " deg");
                return array2;
            }
            List<double> list = new List<double>(num);
            List<double> list2 = new List<double>(num);
            for (int i = 0; i < num; i++)
            {
                if (!double.IsNaN(array2[i]))
                {
                    list.Add(1E-09 * array[i]);
                    list2.Add(array2[i]);
                }
            }
            double num3 = 0.0;
            try
            {
                double[] array3 = PolyFit(list.ToArray(), list2.ToArray(), 1);
                double num4 = array3[0];
                double value = array3[1];
                if (auto_fc && fc == 0.0 && list[0] > 0.0)
                {
                    int count = list.Count;
                    double[][] array4 = new double[count][];
                    double[] array5 = new double[count];
                    for (int j = 0; j < count; j++)
                    {
                        array4[j] = new double[]
                        {
                            2.0 * list2[j],
                            list[j]*list[j],
                            -1.0
                        };
                        array5[j] = list2[j] * list2[j];
                    }
                    double[] array6 = LinAlgLstSqrSolve(array4, array5);
                    double value2 = array6[1];
                    double num5 = (array6[2] - array6[0] * array6[0]) / array6[1];
                    if (value2 > 0.0 && num5 > 0.0 && num5 < list[0] * list[0])
                    {
                        value = array6[0];
                        num4 = System.Math.Sqrt(value2) * (double)System.Math.Sign(num4);
                        fc_out = 1000000000.0 * System.Math.Sqrt(num5);
                    }
                }
                double num6 = value / 6.283185307179586;
                if (num4 < 0.0)
                {
                    num3 = System.Math.Round(num6 + 0.25);
                }
                else
                {
                    num3 = System.Math.Round(num6 - 0.25);
                }
                phaseDC_out = value - 6.283185307179586 * num3;
                if (fc_out == 0.0)
                {
                    Console.WriteLine(string.Concat(new string[]
                    {
                        "Phase Unwrap - Phase at DC: ",
                        (phaseDC_out * num2).ToString("f1"),
                        " deg, Slope: ",
                        (num4 * num2).ToString("f2"),
                        " deg/GHz"
                    }));
                }
                else
                {
                    Console.WriteLine(string.Concat(new string[]
                    {
                        "Phase Unwrap - Phase at fc: ",
                        (phaseDC_out * num2).ToString("f1"),
                        " deg, Slope: ",
                        (num4 * num2).ToString("f2"),
                        " deg/GHz, fc: ",
                        (1E-09 * fc_out).ToString("f3"),
                        " GHz"
                    }));
                }
            }
            catch
            {
            }
            double b = 6.283185307179586 * num3;
            double[] array7 = new double[num];
            for (int k = 0; k < num; k++)
            {
                array7[k] = array2[k] - (b);
            }
            return array7;
        }

        /// <summary>
        /// Unwrap Phase (phase should start at DC between +90 deg and -270 deg for a negative slope or -90 deg and +270 deg for a positive slope)
        /// </summary>
        /// <typeparam name="T">Real Number Type</typeparam>
        /// <param name="freq">Frequency / Hz</param>
        /// <param name="phase">Phase / rad</param>
        /// <param name="fc">Cutoff Frequency / Hz. For a coaxial line or free space, set cutoff frequency to 0 Hz.</param>
        /// <param name="auto_fc">Automatic Cutoff Frequency</param>
        /// <returns></returns>
        public static double[] Unwrap(double[] freq, double[] phase, double fc = 0.0, bool auto_fc = false)
        {
            double num;
            double num2;
            return Unwrap(freq, phase, fc, auto_fc, out num, out num2);
        }

        /// <summary>
        /// Cutoff Corrected Frequency
        /// </summary>
        /// <param name="freq">Frequency / Hz</param>
        /// <param name="fc">Cutoff Frequency / Hz. For a coxial line or free space, set cutoff frequency to 0 Hz.</param>
        /// <returns></returns>
        internal static double[] CutoffCorrectedFrequency(double[] freq, double fc)
        {
            int num = (freq != null) ? freq.Length : 0;
            double[] array;
            if (fc > 0.0)
            {
                array = new double[num];
                double num2 = fc * fc;
                for (int i = 0; i < num; i++)
                {
                    array[i] = freq[i] * System.Math.Sqrt(1.0 - num2 / (freq[i] * freq[i]));
                }
            }
            else
            {
                array = freq;
            }
            return array;
        }

    }

    public static class Array
    {
        public static double[] Zeros1d(int n1)
        {
            double zero = 0;
            double[] array = new double[n1];
            for (int i = 0; i < n1; i++)
            {
                array[i] = zero;
            }

            return array;
        }

        public static double[][] Zeros2d(int n1, int n2)
        {
            double zero = 0;
            double[][] array = new double[n1][];
            for (int i = 0; i < n1; i++)
            {
                double[] array2 = new double[n2];
                for (int j = 0; j > n2; j++)
                {
                    array2[j] = zero;
                }

                array[i] = array2;
            }

            return array;
        }

        public static double[] Ones1d(int n1)
        {
            double one = 1;
            double[] array = new double[n1];
            for (int i = 0; i < n1; i++)
            {
                array[i] = one;
            }

            return array;
        }

        public static double[][] Ones2d(int n1, int n2)
        {
            double one = 1;
            double[][] array = new double[n1][];
            for (int i = 0; i < n1; i++)
            {
                double[] array2 = new double[n2];
                for (int j = 0; j < n2; j++)
                {
                    array2[j] = one;
                }

                array[i] = array2;
            }

            return array;
        }

        public static double[][] Identity(int n)
        {
            double zero = 0;
            double one = 1;
            double[][] array = new double[n][];
            for (int i = 0; i < n; i++)
            {
                double[] array2 = new double[n];
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        array2[j] = one;
                    }
                    else
                    {
                        array2[j] = zero;
                    }
                }

                array[i] = array2;
            }

            return array;
        }

        public static double[] Copy(double[] a)
        {
            double[] array = new double[a.Length];
            a.CopyTo(array, 0);
            return array;
        }

        public static double[][] Copy(double[][] a)
        {
            int num = a.Length;
            double[][] array = new double[num][];
            for (int i = 0; i < num; i++)
            {
                int num2 = a[i].Length;
                array[i] = new double[num2];
                a[i].CopyTo(array[i], 0);
            }

            return array;
        }

        public static void PrettyPrint(double[] a)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int num = a.Length;
            for (int i = 0; i < num; i++)
            {
                stringBuilder.Append(a[i].ToString("  0.000E+00  ; -0.000E+00  "));
                stringBuilder.Append("\n");
            }

            Console.WriteLine(stringBuilder.ToString());
        }

        public static void PrettyPrint(double[][] a)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int num = 6;
            int num2 = a.Length;
            int num3 = 0;
            if (num2 > 0)
            {
                num3 = a[0].Length;
            }

            int num4 = (num3 + num - 1) / num;
            for (int i = 0; i < num4; i++)
            {
                int num5 = i * num;
                int num6 = num5 + num;
                if (num6 > num3)
                {
                    num6 = num3;
                }

                if (num4 > 1)
                {
                    stringBuilder.Append("Columns ");
                    stringBuilder.Append(num5.ToString());
                    stringBuilder.Append(" through ");
                    stringBuilder.Append((num6 - 1).ToString());
                    stringBuilder.Append("\n");
                }

                for (int j = 0; j < num2; j++)
                {
                    for (int k = num5; k < num6; k++)
                    {
                        stringBuilder.Append(a[j][k].ToString("  0.000E+00  ; -0.000E+00  "));
                    }

                    stringBuilder.Append("\n");
                }

                stringBuilder.Append("\n");
            }

            Console.WriteLine(stringBuilder.ToString());
        }

        public static void PrettyPrint(Complex[] a)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int num = a.Length;
            for (int i = 0; i < num; i++)
            {
                stringBuilder.Append(a[i].Real.ToString(" ( 0.000E+00 ; (-0.000E+00 "));
                stringBuilder.Append(a[i].Imaginary.ToString(" +0.000E+00i); -0.000E+00i)"));
                stringBuilder.Append("\n");
            }

            Console.WriteLine(stringBuilder.ToString());
        }

        public static void PrettyPrint(Complex[][] a)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int num = 6;
            int num2 = a.Length;
            int num3 = 0;
            if (num2 > 0)
            {
                num3 = a[0].Length;
            }

            int num4 = (num3 + num - 1) / num;
            for (int i = 0; i < num4; i++)
            {
                int num5 = i * num;
                int num6 = num5 + num;
                if (num6 > num3)
                {
                    num6 = num3;
                }

                if (num4 > 1)
                {
                    stringBuilder.Append("Columns ");
                    stringBuilder.Append(num5.ToString());
                    stringBuilder.Append(" through ");
                    stringBuilder.Append((num6 - 1).ToString());
                    stringBuilder.Append("\n");
                }

                for (int j = 0; j < num2; j++)
                {
                    for (int k = num5; k < num6; k++)
                    {
                        stringBuilder.Append(a[j][k].Real.ToString(" ( 0.000E+00 ; (-0.000E+00 "));
                        stringBuilder.Append(a[j][k].Imaginary.ToString(" +0.000E+00i); -0.000E+00i)"));
                    }

                    stringBuilder.Append("\n");
                }

                stringBuilder.Append("\n");
            }

            Console.WriteLine(stringBuilder.ToString());
        }
    }

    public struct LuResult
    {
        public double[][] l { get; set; }

        public double[][] u { get; set; }

        public double[][] p { get; set; }

        public int[] c { get; set; }

        public int d { get; set; }
    }
}
