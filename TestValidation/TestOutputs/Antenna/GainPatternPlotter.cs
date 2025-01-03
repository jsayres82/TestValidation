using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.TestOutputs.Antenna
{
    public static class GainPatternPlotter
    {
        public static void PlotGain(Dictionary<(int Azimuth, int Elevation), double> gainData)
        {
            foreach (var kvp in gainData)
            {
                Console.WriteLine($"Azimuth: {kvp.Key.Azimuth}, Elevation: {kvp.Key.Elevation}, Gain: {kvp.Value} dB");
            }
        }
    }
}
