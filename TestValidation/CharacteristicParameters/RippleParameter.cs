using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestValidation.Requirements;

namespace TestValidation.CharacteristicParameters
{
    public class RippleParameter : GenericCharacteristicParameter
    {
        public string Description { get { return "Returns the max variation of the specified measurement variable"; }  }
        public List<string> MeasurementVariables { get; set; }
        public override bool ValidateMeasurement(Dictionary<string, double> measurement)
        {
            return true;// propertyValue.ValidateMeasurement(measurement);
        }

        public override Dictionary<string, double> CalculateParameterValue(Dictionary<string, double> baseDataSet)
        {
            return baseDataSet;// baseDataSet["PassbandRipple"];
        }
    }

}
