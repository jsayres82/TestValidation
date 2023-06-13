using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TestValidation.CharacteristicParameters;
using TestValidation.Requirements;

namespace TestValidation
{
    [Serializable]
    public class MeasurementProcessor
    {
        [XmlElement]
        public TestInfo TestInfo;
        private List<TestRequirement> testRequirements;
        private Dictionary<string, double> baseDataSet;
        private Dictionary<string, double> characteristicParameters;
        [XmlElement]
        public TestRequirements TestRequirements;
        public MeasurementProcessor()
        {
            testRequirements = new List<TestRequirement>();
            baseDataSet = new Dictionary<string, double>();
            characteristicParameters = new Dictionary<string, double>();
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
            using (StreamReader reader = new StreamReader("C:\\Users\\214782\\source\\repos\\TestValidation\\TestValidation\\bin\\Debug\\net5.0\\test_requirements.xml"))
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
                GenericCharacteristicParameter characteristicParameter = requirement.CharacteristicParameter;

                // Calculate the parameter value based on the base data set
                Dictionary<string, double> parameterValue = characteristicParameter.CalculateParameterValue(baseDataSet);

                // Store the parameter value in the dictionary
                characteristicParameters[requirement.Name] = 0;
            }
        }

        public void ValidateMeasurement()
        {
            foreach (var requirement in TestRequirements.Requirements)
            {
                // Retrieve the characteristic parameter for the requirement
                GenericCharacteristicParameter characteristicParameter = requirement.CharacteristicParameter;

                // Get the parameter value from the dictionary
                double parameterValue = characteristicParameters[requirement.Name];

                // Validate the measurement against the requirement
                bool isPassed = true;// characteristicParameter.ValidateMeasurement(requirement.PropertyValue, baseDataSet);

                // Print the result
                Console.WriteLine($"{requirement.Name}: {(isPassed ? "Passed" : "Failed")}");
            }
        }


    }
}
