using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Calculators.Antenna
{
    public static class AxialRatioCalculator
    {
        public static double CalculateAxialRatio((double Ex, double Ey) electricField)
        {
            // Compute axial ratio from electric field components
            double magnitudeEx = Math.Abs(electricField.Ex);
            double magnitudeEy = Math.Abs(electricField.Ey);

            return magnitudeEx > magnitudeEy
                ? magnitudeEx / magnitudeEy
                : magnitudeEy / magnitudeEx;
        }
    }

}
