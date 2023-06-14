using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestValidation.CharacteristicParameters;

namespace TestValidation.Limits
{
    public abstract class GenericLimit
    {
        public virtual bool ValidateMeasurement(double freq, double measurement)
        {
            return ValidateMeasurement(measurement);
        }

        public virtual bool ValidateMeasurement(double measurement)
        {
            return true;
        }
    }

}
