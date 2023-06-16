using System;
using System.Collections.Generic;
using System.Xml;
using TestValidation.Limits;
using System.IO;
using System.Xml.Serialization;
using TestValidation.Limits;
using TestValidation.Limits.Validators;
using static TestValidation.Limits.Units.UnitConverter;
using TestValidation.Limits.Units;
using TestValidation.Parameters;
using TestValidation;
using RF_Networks;
using TestValidation.TestResults;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestReport report = new TestReport();
            report.SerialNumber = "123456";
            report.PartNumber = "ABC123";

            TestResult<string> result1 = new TestResult<string>("StringParam", true, "hello");
            TestResult<double> result2 = new TestResult<double>("DoubleParam",  false,  3.14 );

            report.Results.Add(result1);
            report.Results.Add(result2);

            Console.WriteLine("Serial Number: " + report.SerialNumber);
            Console.WriteLine("Part Number: " + report.PartNumber);
            Console.WriteLine("Test Results:");
            foreach (var result in report.Results)
            {
                if (result is TestResult<string> stringResult)
                {
                    Console.WriteLine($"Parameter: {stringResult.ParameterName}, Passed: {stringResult.Passed}, Value: {stringResult.ParameterValue}");
                }
                else if (result is TestResult<double> doubleResult)
                {
                    Console.WriteLine($"Parameter: {doubleResult.ParameterName}, Passed: {doubleResult.Passed}, Value: {doubleResult.ParameterValue}");
                }
            }
        }
    }
}
