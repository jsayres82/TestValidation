using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestValidation.CharacteristicParameters;

namespace TestValidation.Requirements
{
    public abstract class GenericRequirementProperty
    {
        public virtual bool ValidateMeasurement(double measurement)
        {
            return true;
        }
    }

}
