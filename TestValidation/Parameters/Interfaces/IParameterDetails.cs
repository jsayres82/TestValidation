using Nuvo.TestValidation.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Parameters.Interfaces
{
    public interface IParameterDetails
    {
        string FilePath { get; set; }
        string SerialNumber { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        List<string> MeasurementVariables { get; set; }
        Dictionary<string, List<object[]>> ParameterValues { get; }
        double MinimumMargin { get; set; }
        bool ValidateMeasurement(TestRequirement req, Dictionary<string, List<object[]>> measurement);
        Dictionary<string, object> CalculateParameterValue(TestRequirement req, Dictionary<string, List<object[]>> baseDataSet);
        object[] GetParameterLimits();
    }
}
