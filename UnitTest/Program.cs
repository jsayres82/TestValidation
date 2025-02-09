using System;
using System.Collections.Generic;
using System.Xml;
using Nuvo.TestValidation.Limits;
using System.IO;
using System.Xml.Serialization;
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.Limits.Validators;
using static Nuvo.TestValidation.Limits.Units.GenericUnits;
using Nuvo.TestValidation.Limits.Units;
using Nuvo.TestValidation.Parameters;
using Nuvo.TestValidation;
using Nuvo.RF_Networks;
using Nuvo.TestValidation.TestResults;
using System.Linq;
using Org.BouncyCastle.Tls;
using Nuvo.TestServer;

namespace Nuvo.UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //string specFile = ".\\TestData\\test_spec_file.xml";
            //MeasurementProcessor measurementProcessor = new MeasurementProcessor();
            //measurementProcessor.ParseTestSpecsFromXml(specFile);
            //List<string> results;
            //string output = "";
            //string MeasurementFolder = ".\\TestData\\TestFolder_1\\NewTest\\";
            //List<string> files = measurementProcessor.GetFilesInFolder(MeasurementFolder).ToList();
            //Dictionary<string, TestReport> TestReportsDic = new Dictionary<string, TestReport>();

            //foreach (var serial in files)
            //{
            //    var serialNumber = Path.GetFileName(serial).Split("_")[1].Replace("SN", "");
            //    measurementProcessor.CalculateCharacteristicParameters(serial, serialNumber);
            //    var result = measurementProcessor.ValidateMeasurement();
            //    TestReportsDic.Add(serialNumber, result);
            //    var r = (result.Results[0] as TestResult<Dictionary<string, List<double[]>>>).ParameterValue.First(); 
            //    //r.v
            //}
            var testServer = new Nuvo.TestServer.TestServer();
            testServer.AddTest("Test1", new List<string> { "file1.txt", "file2.txt" }, "192.168.1.1");
            testServer.AddTest("Test2", new List<string> { "file3.txt", "file4.txt" }, "192.168.1.2");
            var tests = testServer.GetTests();
            foreach (string test in tests)
            {
                Console.WriteLine(test);

                var ipAddress = testServer.GetIpAddresses(test);
                Console.WriteLine(ipAddress);
                foreach(var file in testServer.GetFileNames(test))
                {
                    Console.WriteLine(file);
                }
            }
            testServer.WatchForFiles();
            while(true) { }
        }
    }
}
