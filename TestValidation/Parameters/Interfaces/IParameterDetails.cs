using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Utilities;
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
        int ParameterVariableCount { get; set; }
        List<string> VariableNames { get; }
        Dictionary<string, List<object[]>> ParameterValues { get; }
        List<MeasFileTypes> FileTypesHandlers { get; }
        double MinimumMargin { get; set; }
        Dictionary<string, List<object[]>> ParseFile(string fileName);
        bool ValidateMeasurement(TestRequirement req, Dictionary<string, List<object[]>> measurement);
        Dictionary<string, List<object[]>> CalculateParameterValue(TestRequirement req, Dictionary<string, List<object[]>> baseDataSet);
        object[] GetParameterLimits();
    }
}
