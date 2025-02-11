﻿using Nuvo.RF_Networks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Nuvo.TestValidation.Parameters;
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.TestResults;
using MicrowaveNetworks;
using MicrowaveNetworks.Touchstone;

namespace Nuvo.TestValidation
{
    [Serializable]
    public class MeasurementProcessor
    {
        [XmlElement]
        public TestInfo TestInfo;
        public string UnitSerialNumber { get; set; }
        public string PartNumber { get; set; }

        private List<TestRequirement> testRequirements;
        private Dictionary<string, double> baseDataSet;
        private Dictionary<string, double> characteristicParameters;
        private string serialNumber; // New field for serial number
        [XmlElement]
        public TestRequirements TestRequirements;
        public MeasurementProcessor()
        {
            testRequirements = new List<TestRequirement>();
            baseDataSet = new Dictionary<string, double>();
            characteristicParameters = new Dictionary<string, double>();
        }
        public string[] GetFilesInFolder(string folderPath)
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    List<string> partNumbers = TestInfo.TestArticles.Select(article => article.PartNumber).ToList();
                    PartNumber = partNumbers.First();
                    return Directory.GetFiles(folderPath)
                        .Where(file => partNumbers.Any(partNumber => file.Contains(partNumber)))
                        .ToArray();
                }
                else
                {
                    Console.WriteLine("Folder not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while retrieving files: " + ex.Message);
            }

            return new string[0]; // Return an empty array if an error occurs or the folder doesn't exist
        }

        public void ReadMeasurementData(string[] filePaths)
        {
            // Implementation for reading and parsing measurement data
        }

        public void SetBaseDataSet(Dictionary<string, double> dataSet)
        {
            baseDataSet = dataSet;
        }


        public TestRequirements ParseTestRequirementsFromXml(string xmlFilePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TestRequirements));
            using (StreamReader reader = new StreamReader("C:\\Users\\214782\\source\\repos\\Nuvo.TestValidation\\Nuvo.TestValidation\\bin\\Debug\\net5.0\\test_requirements.xml"))
            {
                TestRequirements requirements = (TestRequirements)serializer.Deserialize(reader);

                TestRequirements = requirements;
            }
            return TestRequirements;
        }

        public TestRequirements ParseTestSpecsFromXml(string xmlFilePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MeasurementProcessor));
            using (StreamReader reader = new StreamReader(xmlFilePath))
            {
                MeasurementProcessor proc = (MeasurementProcessor)serializer.Deserialize(reader);

                TestRequirements = proc.TestRequirements;
                TestInfo = proc.TestInfo;
            }
            return TestRequirements;
        }

        public void CalculateCharacteristicParameters()
        {
            foreach (var requirement in TestRequirements.Requirements)
            {
                // Retrieve the characteristic parameter for the requirement
                GenericParameter characteristicParameter = requirement.CharacteristicParameter;

                // Calculate the parameter value based on the base data set
                characteristicParameter.CalculateParameterValue(requirement,
                                        parseMeasurementsFromFile(TestInfo.TestArticles[0].MeasurementFiles[0]));

                // Store the parameter value in the dictionary
                //characteristicParameters[requirement.Name] = parameterValue.First().Value;
            }
        }
        public void CalculateCharacteristicParameters(string measurementFile, string serialNumber)
        {
            UnitSerialNumber = serialNumber;
            foreach (var requirement in TestRequirements.Requirements)
            {
                // Retrieve the characteristic parameter for the requirement
                GenericParameter characteristicParameter = requirement.CharacteristicParameter;

                UnitSerialNumber = serialNumber;


                // Calculate the parameter value based on the base data set and serial number
                characteristicParameter.CalculateParameterValue(requirement, parseMeasurementsFromFile(measurementFile));

                // Store the parameter value in the dictionary
                //characteristicParameters[requirement.Name] = parameterValue.First().Value;
            }
        }

        public void CalculateCharacteristicParameters(string measurementFolder)
        {
            foreach (var requirement in TestRequirements.Requirements)
            {
                // Retrieve the characteristic parameter for the requirement
                GenericParameter characteristicParameter = requirement.CharacteristicParameter;

                string filePath = Path.Combine(measurementFolder, TestInfo.TestArticles[0].MeasurementFiles[0]);

                // Calculate the parameter value based on the base data set
                characteristicParameter.CalculateParameterValue(requirement,
                                        parseMeasurementsFromFile(filePath));

                // Store the parameter value in the dictionary
                //characteristicParameters[requirement.Name] = parameterValue.First().Value;
            }
        }

        public List<string> ValidateMeasurementOld()
        {
            List<string> results = new List<string>();
            foreach (var requirement in TestRequirements.Requirements)
            {
                // Retrieve the characteristic parameter for the requirement
                GenericParameter characteristicParameter = requirement.CharacteristicParameter;

                // Get the parameter value from the dictionary
                //double parameterValue = characteristicParameters[requirement.Name];

                // Validate the measurement against the requirement
                var isPassed = characteristicParameter.ValidateMeasurement(requirement, new Dictionary<string, List<double[]>>());

                // Print the result
                Console.WriteLine($"{requirement.Name}: {(isPassed ? "Passed" : "Failed")}");
                results.Add($"{results.Count + 1} - {requirement.Name}: {(isPassed ? "Passed" : "Failed")}");
            }
            return results;
        }

        public bool ValidateMeasurement(string serialNumber)
        {
            this.serialNumber = serialNumber; // Store the serial number
            //TestReport results = new TestReport(UnitSerialNumber, TestInfo.TestArticles[0].PartNumber);
            foreach (var requirement in TestRequirements.Requirements)
            {
                // Retrieve the characteristic parameter for the requirement
                GenericParameter characteristicParameter = requirement.CharacteristicParameter;

                // Validate the measurement against the requirement
                object isPassed = characteristicParameter.ValidateMeasurement(requirement, new Dictionary<string, List<double[]>>());


            }
            return true;
        }

        public TestReport ValidateMeasurement()
        {
            // Create a new instance of the TestReport class

            //TestReport report = new TestReport();
            TestReport testReport = new TestReport(UnitSerialNumber, TestInfo.TestArticles[0].PartNumber);
            foreach (var requirement in TestRequirements.Requirements)
            {
                // Retrieve the characteristic parameter for the requirement
                GenericParameter characteristicParameter = requirement.CharacteristicParameter;
                characteristicParameter.serialNumber = UnitSerialNumber;
                // Validate the measurement against the requirement
                var isPassed = characteristicParameter.ValidateMeasurement(requirement, new Dictionary<string, List<double[]>>());

                // Create a TestResult instance with parameter values of type Dictionary<string, List<double[]>>
                var result = new TestResult<Dictionary<string, List<double[]>>> (requirement.Name, isPassed, characteristicParameter.ParameterValues, requirement.CharacteristicParameter.MinimumMargin);
                testReport.Results.Add(result);
            }
            return testReport;// testReport;
        }

        private Dictionary<string, List<double[]>> parseMeasurementsFromFile(string filePath)
        {
            Dictionary<string, List<double[]>> data = new Dictionary<string, List<double[]>>();
            SParameterCombiner combiner = new SParameterCombiner();
            //Dictionary<string, List<string>> dataStr = combiner.ExtractSParameterData(filePath);
            Dictionary<string, List<string>> dataStr = new Dictionary<string, List<string>>();
            INetworkParametersCollection coll = Touchstone.ReadAllData(filePath);
            foreach (FrequencyParametersPair pair in coll)
            {
                List<string> s = new List<string>();
                for(int i =1; i<=pair.Parameters.NumPorts;i++)
                    for(int j = 1; j <= pair.Parameters.NumPorts; j++)
                    {
                        s.Add($"{pair.Parameters[i, j].Real} {pair.Parameters[i, j].Imaginary}");
                    }
                        dataStr.Add(pair.Frequency_Hz.ToString(),s);
                //double insertionLoss = matrix[2, 1].Magnitude_dB;
                //Console.WriteLine($"Insertion loss at {frequency} is {insertionLoss} dB");
            }
            foreach (var dList in dataStr.Keys)
            {
                //Console.Write($"{dList}: ");
                if (dList == "")
                    continue;
                data.Add(dList, new List<double[]>());
                foreach (var d in dataStr[dList])
                {

                    //Console.Write($"{d} "); 
                    var val = d.Split(" ");
                    Complex v = Complex.FromPolarCoordinates(System.Convert.ToDouble(val.First()), System.Convert.ToDouble(val.Last()));
                    //Complex v = new Complex(Convert.ToDouble(val.First()), Convert.ToDouble(val.Last()));
                    
                    data[dList].Add(new double[2] { v.Real, v.Imaginary });
                }
                //Console.WriteLine();
            }
            return data;
        }



    }
}
