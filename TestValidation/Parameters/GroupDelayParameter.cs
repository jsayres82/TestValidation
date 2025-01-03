using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MicrowaveNetworks;
using MicrowaveNetworks.Touchstone;
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Parameters.Interfaces;

namespace Nuvo.TestValidation.Parameters
{
    public class GroupDelayParameter : GenericParameter, IParameterDetails
    {

        public string Description { get { return "Evaluates a scattering parameter for S-Parameter Matrix"; } }
        public override List<string> MeasurementVariables { get; set; }
        [XmlIgnore]
        public override Dictionary<string, List<double[]>> ParameterValues { get => parameterValues; }
        public override double MinimumMargin
        {
            get => MinMargin;
            set => MinMargin = value;
        }
        private double[] reqLimit;
        private Dictionary<string, List<double[]>> parameterValues = new Dictionary<string, List<double[]>>();
        public static StreamWriter sw;
        private List<string> parameterDomain = new List<string>();
        private Dictionary<string, List<Complex>> complexParameterValue = new Dictionary<string, List<Complex>>();
        public override bool ValidateMeasurement(TestRequirement req, Dictionary<string, List<double[]>> measurement)
        {
            int index = 0;
            bool passed = true;
            bool ispassed = true;
            MinMargin = double.MaxValue;
            reqLimit = new double[parameterValues[MeasurementVariables.First()].Count];

            if (File.Exists($"SerialNumber{serialNumber}_requirement_{req.Name}.csv"))
                File.Delete($"SerialNumber{serialNumber}_requirement_{req.Name}.csv");

            // Open the StreamWriter here; replace 'filePath' with your actual file path
            sw = new StreamWriter($"SerialNumber{serialNumber}_requirement_{req.Name}.csv", true);
            sw.WriteLine($"Frequency,TestValue,Margin,{req.Limit.Validator.GetType().Name},Result");

            foreach (var sParam in MeasurementVariables)
            {
                foreach (var val in parameterValues[sParam])
                {
                    double testValue = val[0];
                    double limit = req.Limit.Validator.Value;
                    reqLimit[index] = limit;
                    passed = true;
                    if (!req.Limit.ValidateMeasurement(System.Convert.ToDouble(parameterDomain.ElementAt(index)), testValue))
                    {
                        passed = false;
                        ispassed = false;
                    }
                    string result = passed == true ? "Passed" : "Failed";

                    double margin = req.Limit.CalculateMargin(System.Convert.ToDouble(parameterDomain.ElementAt(index)), testValue);
                    if (!double.NaN.Equals(margin))
                    {
                        if (margin < MinMargin)
                            MinMargin = margin;
                        // Write the test value, margin, and limit to the CSV file
                        sw.WriteLine($"{System.Convert.ToDouble(parameterDomain.ElementAt(index))},{testValue},{margin},{limit},{result}");

                    }
                    else
                    {
                        var test = 1;
                    }

                    index++;
                }
            }

            // Close the StreamWriter after all measurements have been validated
            sw.Close();

            return ispassed;
        }
        public static void WriteToCsv<T>(string filePath, T testValue, T margin, T limit)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            // Check if the file exists
            if (!File.Exists(filePath))
            {
                // Create a new file and write the header
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine("TestValue,Margin,Limit");
                }
            }

            // Append the test value, margin, and limit to the existing CSV file
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine($"{testValue},{margin},{limit}");
            }
        }
        public override Dictionary<string, double> CalculateParameterValue(TestRequirement req, Dictionary<string, List<double[]>> baseDataSet)
        {
            Dictionary<string, double> vals = new Dictionary<string, double>();
            baseDataSet = getMeasurementVariables(baseDataSet);
            int index = 0;
            foreach (var s in baseDataSet[MeasurementVariables[0]])
            {
                vals.Add(parameterDomain[index], baseDataSet[MeasurementVariables[0]][index++][0]);
            }
            return vals;
        }


        private Dictionary<string, List<double[]>> parseMeasurementsFromFile(string filePath)
        {
            Dictionary<string, List<double[]>> data = new Dictionary<string, List<double[]>>();
            //Dictionary<string, List<string>> dataStr = combiner.ExtractSParameterData(filePath);
            Dictionary<string, List<string>> dataStr = new Dictionary<string, List<string>>();
            INetworkParametersCollection coll = Touchstone.ReadAllData(filePath);
            int index = 0;
            int portOne = Convert.ToInt32(MeasurementVariables[0].Substring(1)[0].ToString());
            int portTwo = Convert.ToInt32(MeasurementVariables[0].Substring(1)[1].ToString());

            parameterValues = new Dictionary<string, List<double[]>>();
            parameterValues.Add(MeasurementVariables[0], new List<double[]>());
            var vals = new List<double[]>();
            foreach (FrequencyParametersPair pair in coll)
            {
                vals.Add(new double[2] { pair.Parameters[portOne, portTwo].Magnitude_dB, pair.Parameters[portOne, portTwo].Phase_deg });
            }
            parameterValues[MeasurementVariables[0]] = vals;
            return parameterValues;
        }

        private Dictionary<string, List<double[]>> getMeasurementVariables(Dictionary<string, List<double[]>> measurement)
        {
            sprams.AddRange(s.ToList());
            parameterValues = new Dictionary<string, List<double[]>>();
            parameterDomain = measurement.Keys.ToList();
            int index = 0;
            int idx = 0;
            Dictionary<string, List<Complex>> parsedData = new Dictionary<string, List<Complex>>();
            foreach (var val in s)
            {
                parsedData.Add(val, new List<Complex>());
                if (val.Equals(MeasurementVariables[0]))
                    idx = index;
                index++;
            }

            parameterValues.Add(MeasurementVariables[0], new List<double[]>());
            foreach (var d in measurement.Keys)
            {
                index = 0;
                foreach (var val in measurement[d])
                {
                    if (index == idx)
                    {
                        var valF = new double[2]
                        {
                            20*Math.Log10(val[0]),
                            val[1]*(180/Math.PI)
                        };
                        parameterValues[MeasurementVariables[0]].Add(valF);
                        //Console.WriteLine($"{s[measurement[d].IndexOf(val)]}: {parsedData[s[measurement[d].IndexOf(val)]].Last().Magnitude} dB  {(180/Math.PI) * parsedData[s[measurement[d].IndexOf(val)]].Last().Phase} degrees");
                    }
                    index++;
                }
            }
            double fc = 0.0;
            bool auto_fc = true;
            double phaseDC;
            double fc2;
            double[] frequency = new double[parameterDomain.Count];
            double[] data1 = new double[parameterDomain.Count];
            index = 0;
            foreach (var freq in parameterDomain)
            {
                data1[index] = parameterValues[MeasurementVariables[0]].ElementAt(index)[1] * (Math.PI / 180);
                frequency[index++] = Convert.ToDouble(freq);
            }

            double[] phase = Unwrap(frequency, data1, fc, auto_fc, out phaseDC, out fc2);
            data1 = GroupDelay(CutoffCorrectedFrequency(frequency, fc2), phase, false);
            index = 0;
            foreach (var freq in parameterDomain)
            {
                parameterValues[MeasurementVariables[0]][index][0] = data1[index++];
            }
            return parameterValues;
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

        public override double[] GetParameterLimits()
        {

            return reqLimit;
        }

        string[] s = new string[9] { "S11", "S12", "S13", "S21", "S22", "S23", "S31", "S32", "S33" };
        List<string> sprams = new List<string>();

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
    }
}
