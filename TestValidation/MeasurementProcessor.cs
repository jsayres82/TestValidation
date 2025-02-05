using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Nuvo.TestValidation.Parameters;
using Nuvo.TestValidation.Limits;
using Nuvo.TestValidation.TestResults;
using MicrowaveNetworks;
using MicrowaveNetworks.Touchstone;
using System.Data;
using Nuvo.TestValidation.Utilities;
using Newtonsoft.Json;

namespace Nuvo.TestValidation
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class MeasurementProcessor
    {
        //[JsonProperty]
        [XmlElement]
        public TestInfo TestInfo;
        public string UnitSerialNumber { get; set; }
        public string PartNumber { get; set; }
        private Dictionary<string, List<object[]>> measFileObjectDic = new Dictionary<string, List<object[]>>();
        private List<TestRequirement> testRequirements;
        private Dictionary<string, double> baseDataSet;
        private Dictionary<string, double> characteristicParameters;
        private string serialNumber; // New field for serial number
        private string file;
        //[JsonProperty]
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
                    List<string> partNumbers = new List<string>();
                    var extension = TestInfo.MeasFileType;
                    if (extension.Equals("sXp"))
                        extension = $"s{TestInfo.ParamCount}p";
                    PartNumber = TestInfo.PartNum;
                    return Directory.GetFiles(folderPath)
                        .Where(f => (f.EndsWith(extension) & f.Contains(PartNumber)))
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

        public TestRequirements ParseTestRequirementsFromJson(string jsonFilePath)
        {
            var requirements = JsonHelper.LoadFromJson<TestRequirements>(jsonFilePath);
            TestRequirements = requirements;

            return TestRequirements;
        }

        public TestRequirements ParseTestSpecsFromJson(string jsonFilePath)
        {
            var proc = JsonHelper.LoadFromJson<MeasurementProcessor>(jsonFilePath);
            TestRequirements = proc.TestRequirements;
            TestInfo = proc.TestInfo;

            return TestRequirements;
        }

        public TestRequirements ParseTestRequirementsFromXml(string xmlFilePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TestRequirements));
            using (StreamReader reader = new StreamReader(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "test_requirements.xml")))
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
                characteristicParameter.FilePath = TestInfo.TestArticles.MeasurementFiles[0];

                // Calculate the parameter value based on the base data set
                characteristicParameter.CalculateParameterValue(requirement,
                                        parseMeasurementsFromFile(TestInfo.TestArticles.MeasurementFiles[0]));
            }
        }

        public void CalculateCharacteristicParameters(string measurementFile, string serialNumber)
        {
            UnitSerialNumber = serialNumber;
            measFileObjectDic = GenericDataConverter.FromNetworkParameters(measurementFile);
            foreach (var requirement in TestRequirements.Requirements)
            {
                // Retrieve the characteristic parameter for the requirement
                GenericParameter characteristicParameter = requirement.CharacteristicParameter;

                UnitSerialNumber = serialNumber;


                characteristicParameter.FilePath = measurementFile;
                file = measurementFile;

                // Calculate the parameter value based on the base data set and serial number
                characteristicParameter.CalculateParameterValue(requirement, measFileObjectDic);
            }
        }

        public void CalculateCharacteristicParameters(string measurementFolder)
        {
            foreach (var requirement in TestRequirements.Requirements)
            {
                // Retrieve the characteristic parameter for the requirement
                GenericParameter characteristicParameter = requirement.CharacteristicParameter;

                string filePath = Path.Combine(measurementFolder, TestInfo.TestArticles.MeasurementFiles[0]);

                characteristicParameter.FilePath = TestInfo.TestArticles.MeasurementFiles[0];
                // Calculate the parameter value based on the base data set
                characteristicParameter.CalculateParameterValue(requirement,
                                        parseMeasurementsFromFile(filePath));
            }
        }

        public bool ValidateMeasurement(string serialNumber)
        {
            this.serialNumber = serialNumber; // Store the serial number
            //TestReport results = new TestReport(UnitSerialNumber, TestInfo.PartNum);
            foreach (var requirement in TestRequirements.Requirements)
            {
                // Retrieve the characteristic parameter for the requirement
                GenericParameter characteristicParameter = requirement.CharacteristicParameter;

                // Validate the measurement against the requirement
                object isPassed = characteristicParameter.ValidateMeasurement(requirement, new Dictionary<string, List<object[]>>());


            }
            return true;
        }

        public TestReport ValidateMeasurement()
        {
            FileAccessChecker fileCheck = new FileAccessChecker();
            TestReport testReport = new TestReport(UnitSerialNumber, TestInfo.TestName, TestInfo.WaferName, TestInfo.Program, TestInfo.PartNum);
            foreach (var requirement in TestRequirements.Requirements)
            {
                // Retrieve the characteristic parameter for the requirement
                GenericParameter characteristicParameter = requirement.CharacteristicParameter;
                characteristicParameter.SerialNumber = UnitSerialNumber;
                // Validate the measurement against the requirement
                var isPassed = characteristicParameter.ValidateMeasurement(requirement, new Dictionary<string, List<object[]>>());

                // Create a TestResult instance with parameter values of type Dictionary<string, List<double[]>>
                var result = new TestResult<Dictionary<string, List<double[]>>> (requirement.Name, isPassed, characteristicParameter.ValueAtMinMargin, characteristicParameter.MinMargin);
                result.Limit = requirement.Limit;
                testReport.Results.Add(result);

            }
            testReport.TestFile = file;
            //testReport.WriteToJson(new FileInfo(file).DirectoryName);
            testReport.WriteToXml(new FileInfo(file).DirectoryName);

            // if(fileCheck.TryToAccessFile($"{file}\\SN{UnitSerialNumber}_Result.xml"))
            //testReport.CreatePdfFromJson(new FileInfo(file).DirectoryName);
            testReport.CreatePdfFromXml(new FileInfo(file).DirectoryName);

            return testReport;// testReport;
        }

        private Dictionary<string, List<object[]>> parseMeasurementsFromFile(string filePath)
        {
            Dictionary<string, List<object[]>> data = new Dictionary<string, List<object[]>>();
            INetworkParametersCollection coll = Touchstone.ReadAllData(filePath);
            Dictionary<string, IList<NetworkParameter>> networkParamCollDataDic = new Dictionary<string, IList<NetworkParameter>>();
            foreach (FrequencyParametersPair pair in coll)
            {
                var matrixEnum = pair.Parameters.GetEnumerator(ListFormat.SourcePortMajor);
                IList<NetworkParameter> flattenedList = new List<NetworkParameter>();
                while (matrixEnum.MoveNext())
                {
                    flattenedList.Add(matrixEnum.Current.NetworkParameter);
                }
                networkParamCollDataDic.Add(pair.Frequency_Hz.ToString(), flattenedList.ToArray());
            }
            foreach (var dList in networkParamCollDataDic)
            {
                data.Add(dList.Key.ToString(), new List<object[]>());
                data[dList.Key.ToString()].Add(new object[] { networkParamCollDataDic[dList.Key] });
            }
            return data;
        }
    }
}
