using RF_Networks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TestValidation.Parameters;
using TestValidation.Limits;

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
                GenericParameter characteristicParameter = requirement.CharacteristicParameter;

                // Calculate the parameter value based on the base data set
                characteristicParameter.CalculateParameterValue(requirement,
                                        parseMeasurementsFromFile(TestInfo.TestArticles[0].MeasurementFiles[0]));

                // Store the parameter value in the dictionary
                //characteristicParameters[requirement.Name] = parameterValue.First().Value;
            }
        }

        public void ValidateMeasurement()
        {
            foreach (var requirement in TestRequirements.Requirements)
            {
                // Retrieve the characteristic parameter for the requirement
                GenericParameter characteristicParameter = requirement.CharacteristicParameter;

                // Get the parameter value from the dictionary
                //double parameterValue = characteristicParameters[requirement.Name];
                
                // Validate the measurement against the requirement
                bool isPassed = characteristicParameter.ValidateMeasurement(requirement, new Dictionary<string, List<double[]>>());

                // Print the result
                Console.WriteLine($"{requirement.Name}: {(isPassed ? "Passed" : "Failed")}");
            }
        }

        private Dictionary<string, List<double[]>> parseMeasurementsFromFile(string filePath)
        {
            Dictionary<string, List<double[]>> data = new Dictionary<string, List<double[]>>();
            SParameterCombiner combiner = new SParameterCombiner();
            Dictionary<string, List<string>> dataStr = combiner.ExtractSParameterData(filePath);
            foreach(var dList in dataStr.Keys)
            {
                //Console.Write($"{dList}: ");
                if (dList == "")
                    continue;
                data.Add(dList, new List<double[]>());
                foreach (var d in dataStr[dList])
                {

                    //Console.Write($"{d} "); 
                    var val = d.Split(" ");
                    Complex v = Complex.FromPolarCoordinates(Convert.ToDouble(val.First()), Convert.ToDouble(val.Last()));
                    //Complex v = new Complex(Convert.ToDouble(val.First()), Convert.ToDouble(val.Last()));
                    
                    data[dList].Add(new double[2] { v.Real, v.Imaginary });
                }
                //Console.WriteLine();
            }
            return data;
        }



    }
}
