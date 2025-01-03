using Nuvo.TestValidation.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Parameters.Antenna
{
    public class LinearGainParameter : GenericParameter
    {
        public override List<string> MeasurementVariables { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override Dictionary<string, List<double[]>> ParameterValues => throw new NotImplementedException();

        public override double MinimumMargin { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override Dictionary<string, double> CalculateParameterValue(TestRequirement req, Dictionary<string, List<double[]>> baseDataSet)
        {
            throw new NotImplementedException();
        }

        public override double[] GetParameterLimits()
        {
            throw new NotImplementedException();
        }

        public override bool ValidateMeasurement(TestRequirement req, Dictionary<string, List<double[]>> measurement)
        {
            throw new NotImplementedException();
        }
    }
}
