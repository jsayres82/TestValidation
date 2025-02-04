using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Limits.Validators;
using Nuvo.TestValidation.Parameters.Interfaces;
using System.Collections;
using Nuvo.TestValidation.Calculators.Interfaces;
using Nuvo.TestValidation.Calculators;
using Nuvo.TestValidation.Utilities;
using static Nuvo.TestValidation.Limits.Units.UnitConverter;
using Newtonsoft.Json;
using System.Reflection;

namespace Nuvo.TestValidation.Parameters
{
    [XmlInclude(typeof(InsertionLossParameter))]
    [XmlInclude(typeof(PhaseBalanceParameter))]
    [XmlInclude(typeof(GroupDelayParameter))]
    [XmlInclude(typeof(AmplitudeBalanceParameter))]
    [XmlInclude( typeof(ScatteringParameter))]
    [XmlInclude(typeof(ReturnLossParameter))]
    [XmlInclude(typeof(FlatnessParameter))]
    [Serializable]
    public abstract class GenericParameter
    {
        protected static string LimitStr = "Limit";
        protected static string ValidatorStr = "Validator";
        public virtual double MinMargin { get; set; } = double.MaxValue;

        [XmlIgnore]
        public string FilePath { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public virtual string Description { get; set; } = "";
        public virtual int ParameterVariableCount { get; set; } = 1;
        public List<string> VariableNames { get; set; }
        public List<string> MeasurementVariables { get; set; }
        //[JsonIgnore]
        [XmlIgnore]
        public abstract Dictionary<string, List<object[]>> ParameterValues { get; }

        [XmlIgnore]
        public abstract double ValueAtMinMargin { get; set; }

        public List<MeasFileTypes> FileTypesHandlers { get; } = new List<MeasFileTypes>() { MeasFileTypes.None };

        public abstract bool ValidateMeasurement(TestRequirement req, Dictionary<string, List<object[]>> measurement);

        private IParameterValueCalculator _parameterValueCalculator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="calculator"></param>
        public GenericParameter(IParameterValueCalculator calculator)
        {
            _parameterValueCalculator = new DoubleParameterValueCalculator();
            VariableNames = new List<string>();
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public GenericParameter()
        {
            _parameterValueCalculator = new DoubleParameterValueCalculator();
            VariableNames = new List<string>();
        }

        public abstract object[] GetParameterLimits();

        /// <summary>
        /// Calculates the parameter values(currently calculates value for entire array. Could speed things up and just do start to stop.
        /// </summary>
        /// <param name="req"></param>
        /// <param name="baseDataSet"></param>
        /// <returns></returns>
        public virtual Dictionary<string, List<object[]>>  CalculateParameterValue(TestRequirement req, Dictionary<string, List<object[]>> baseDataSet)
        {
            return _parameterValueCalculator.Calculate(req, baseDataSet);
        }

        // Needs to be implemented currently handling in MeasurementProcessor.
        /// <summary>
        /// Will be used to determine how to parse the input data.
        /// May be a high level ParseFile method that calls multiple files like for antenna meas pkg
        ///     - It would first call the parser for ref horn gain data file which is a CSV input file saving the array values as a measurement variable
        ///     - It would then call the parser for the meaured Horn sXp or CSV file only saving the S12 data as a measurement variable
        ///     - It would then call the parser for multiple s2p or s3p files and save the horizontal and vertical S11/S12 array at each azimuth/elevation
        ///     All the parsed values would be the long list of measurement variables required to calculate the ParameterValue
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public virtual Dictionary<string, List<object[]>> ParseFile(string fileName)
        {
            return new Dictionary<string, List<object[]>>();
        }

        public static Dictionary<string, Type> GetGenericParameterTypes()
        {
            return Assembly.GetExecutingAssembly()
                        .GetTypes()
                        .Where(t => t.IsClass && !t.IsAbstract && typeof(GenericParameter).IsAssignableFrom(t)) // concrete class, inheriting from GenericLimit
                        .ToDictionary(t => t.Name, t => t);
        }
    }
}
