using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Calculators
{
    public class PhaseDelayCalculator
    {
        public static double CalculatePhaseDelay(double[] signal1, double[] signal2, double sampleRate)
        {
            if (signal1.Length != signal2.Length)
            {
                throw new ArgumentException("Both signals must have the same length.");
            }

            int length = signal1.Length;
            double maxCorrelation = double.MinValue;
            int maxLag = 0;

            // Compute cross-correlation
            for (int lag = 0; lag < length; lag++)
            {
                double correlation = 0.0;
                for (int i = 0; i < length - lag; i++)
                {
                    correlation += signal1[i] * signal2[i + lag];
                }
                if (correlation > maxCorrelation)
                {
                    maxCorrelation = correlation;
                    maxLag = lag;
                }
            }

            // Convert lag to phase delay in seconds
            return (double)maxLag / sampleRate;
        }
    }
}