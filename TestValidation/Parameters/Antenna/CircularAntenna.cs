using Nuvo.TestValidation.Calculators.Antenna;
using Nuvo.TestValidation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Parameters.Antenna
{
    public class CircularAntenna : Antenna
    {
        public CircularAntenna(int azimuthResolution = 1, int elevationResolution = 1)
            : base(azimuthResolution, elevationResolution) { }

        public override void CalculateParameters(Dictionary<(int Azimuth, int Elevation), MeasurementData> measurementData)
        {
            foreach (var kvp in measurementData)
            {
                int azimuth = kvp.Key.Azimuth;
                int elevation = kvp.Key.Elevation;
                var data = kvp.Value;

                double gain = GainPatternCalculator.CalculateGain(data.S21, referenceGain: 0); // Replace `0` with actual reference gain
                double axialRatio = AxialRatioCalculator.CalculateAxialRatio(data.ElectricField);

                DataStorage.AddData(azimuth, elevation, gain, axialRatio);
            }
        }
    }
}
