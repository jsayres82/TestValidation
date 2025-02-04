using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Limits.Validators;
using Nuvo.TestValidation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Nuvo.TestValidation.Limits.Units.UnitConverter;
using System.Text.Json.Serialization;

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
        List<object> ValidLimits { get; }
        List<object> ValidValidators { get; }
        List<string> ValidLimitUnits { get; }
        List<string> ValidValidatorUnits { get; }
        Dictionary<string, List<object[]>> ParameterValues { get; }
        List<MeasFileTypes> FileTypesHandlers { get; }
        [JsonIgnore]
        double MinMargin { get; set; }
        [JsonIgnore]
        double ValueAtMinMargin { get; set; }
        Dictionary<string, List<object[]>> ParseFile(string fileName);
        bool ValidateMeasurement(TestRequirement req, Dictionary<string, List<object[]>> measurement);
        Dictionary<string, List<object[]>> CalculateParameterValue(TestRequirement req, Dictionary<string, List<object[]>> baseDataSet);
        object[] GetParameterLimits();
    }
}
