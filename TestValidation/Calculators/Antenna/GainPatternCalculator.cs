using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Calculators.Antenna
{
    public static class GainPatternCalculator
    {
        public static double CalculateGain(double s21, double referenceGain)
        {
            // Normalize S21 with reference gain and calculate gain in dB
            return 20 * Math.Log10(Math.Abs(s21)) + referenceGain;
        }
    }
}
