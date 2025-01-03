using Nuvo.TestValidation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Parameters.Antenna
{
    public abstract class Antenna
    {
        protected AntennaDataStorage DataStorage;

        protected Antenna(int azimuthResolution = 1, int elevationResolution = 1)
        {
            DataStorage = new AntennaDataStorage(azimuthResolution, elevationResolution);
        }

        public abstract void CalculateParameters(Dictionary<(int Azimuth, int Elevation), MeasurementData> measurementData);

        public double GetGain(int azimuth, int elevation)
        {
            return DataStorage.GetData(azimuth, elevation).Gain;
        }

        public double GetAxialRatio(int azimuth, int elevation)
        {
            return DataStorage.GetData(azimuth, elevation).AxialRatio;
        }
    }


}
