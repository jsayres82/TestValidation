using System;
using System.Collections.Generic;
using System.Xml;
using Nuvo.TestValidation.Limits;
using System.IO;
using System.Xml.Serialization;
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Limits.Validators;
using static Nuvo.TestValidation.Limits.Units.UnitConverter;
using Nuvo.TestValidation.Limits.Units;
using Nuvo.TestValidation.Parameters;
using Nuvo.TestValidation;
using Nuvo.RF_Networks;
using Nuvo.TestValidation.TestResults;
using Nuvo.Math;
using System.Linq;

namespace Nuvo.UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string specFile = ".\\TestData\\test_spec_file.xml";
            MeasurementProcessor measurementProcessor = new MeasurementProcessor();
            measurementProcessor.ParseTestSpecsFromXml(specFile);
            List<string> results;
            string output = "";
            string MeasurementFolder = ".\\TestData\\TestFolder_1\\NewTest\\";
            List<string> files = measurementProcessor.GetFilesInFolder(MeasurementFolder).ToList();
            Dictionary<string, TestReport> TestReportsDic = new Dictionary<string, TestReport>();

            foreach (var serial in files)
            {
                var serialNumber = Path.GetFileName(serial).Split("_")[1].Replace("SN", "");
                measurementProcessor.CalculateCharacteristicParameters(serial, serialNumber);
                var result = measurementProcessor.ValidateMeasurement();
                TestReportsDic.Add(serialNumber, result);
                var r = (result.Results[0] as TestResult<Dictionary<string, List<double[]>>>).ParameterValue.First(); 
                r.v
            }
        }
    }
}
