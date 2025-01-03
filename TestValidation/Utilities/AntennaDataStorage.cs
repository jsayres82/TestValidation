using System;
using System.Collections.Generic;

namespace Nuvo.TestValidation.Utilities
{
    public class AntennaDataStorage
    {
        private readonly Dictionary<(int Azimuth, int Elevation), double> gainData;
        private readonly Dictionary<(int Azimuth, int Elevation), double> axialRatioData;

        public AntennaDataStorage(int azimuthResolution = 1, int elevationResolution = 1)
        {
            gainData = new Dictionary<(int, int), double>();
            axialRatioData = new Dictionary<(int, int), double>();
        }

        public void AddData(int azimuth, int elevation, double gain, double axialRatio)
        {
            var key = (azimuth, elevation);
            gainData[key] = gain;
            axialRatioData[key] = axialRatio;
        }

        public (double Gain, double AxialRatio) GetData(int azimuth, int elevation)
        {
            var key = (azimuth, elevation);
            if (!gainData.ContainsKey(key) || !axialRatioData.ContainsKey(key))
            {
                throw new KeyNotFoundException($"No data available for azimuth {azimuth}, elevation {elevation}.");
            }

            return (gainData[key], axialRatioData[key]);
        }
    }
}