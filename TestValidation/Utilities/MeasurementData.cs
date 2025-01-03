using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Utilities
{
    public class MeasurementData
    {
        public double S21 { get; set; } // Scattering parameter
        public (double Ex, double Ey) ElectricField { get; set; } // Electric field components
    }
}
