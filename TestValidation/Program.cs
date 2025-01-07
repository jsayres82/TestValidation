
using System;
using System.Collections.Generic;
using System.Xml;
using Nuvo.TestValidation.Limits;
using System.IO;
using System.Xml.Serialization;
using Nuvo.TestValidation.Limits.Validators;
using static Nuvo.TestValidation.Limits.Units.UnitConverter;
using Nuvo.TestValidation.Limits.Units;
using Nuvo.TestValidation.Parameters;
using Nuvo.TestValidation;
using Nuvo.RF_Networks;

class Program
{
    static void Main()
    {
        SParameterCombiner combiner = new SParameterCombiner();

        //Add the paths of the S-parameter files
        combiner.AddSParameterFile("sparam_P1P2P3.s3p", new string[] { "1", "2", "3" });
        combiner.AddSParameterFile("sparam_P1P3P4.s3p", new string[] { "1", "3", "4" });
        combiner.AddSParameterFile("sparam_P1P4P5.s3p", new string[] { "1", "4", "5" });
        combiner.AddSParameterFile("sparam_P1P5P6.s3p", new string[] { "1", "5", "6" });

        //Add the paths of the S-parameter files

        Console.WriteLine($"Combining files: ");
        //combiner.AddSParameterFile("sparam_P1P2P3.s3p");
        //combiner.AddSParameterFile("sparam_P1P3P4.s3p");
        //combiner.AddSParameterFile("sparam_P1P4P5.s3p");
        //combiner.AddSParameterFile("sparam_P1P5P6.s3p");
        foreach(var f in combiner.filePortNames)
            Console.WriteLine($"       {f.Key}");
        Console.WriteLine();
        // Set the output file path
        string outputFilePath = "combined_sparams.s6p";

        // Combine the S-parameter files
        combiner.CombineSParameterFiles(outputFilePath);

        //Create a MeasurementProcessor instance
        //MeasurementProcessor processor = new MeasurementProcessor();
        Console.WriteLine($"\"{outputFilePath}\" Created from input files.");
        //TestInfo info = new TestInfo() { Program = "MUX", TestName = "Module RF Measurement", WaferName = "N/A" };
        //info.TestArticles = new List<TestArticle>();
        //info.TestArticles.Add(new TestArticle()
        //{
        //    Name = "Pentaplexer",
        //    PartNumber = "1022653",
        //    MeasurementFiles = new List<string>() { "sparam_P1P2P3.s3p", "sparam_P1P3P4.s3p" }
        //});

        //TestRequirements testRequirements = new TestRequirements();
        //// Create an instance of TestRequirement
        //var requirement = new TestRequirement
        //{
        //    Name = "MyTestRequirement",
        //    Limit = new DomainRequirementProperty() { Start = 1000, End = 2000, Limit = new BoundedLimit<double>(0.0, 1.0, Unit.None, Prefix.None) },
        //    CharacteristicParameter = new RippleParameter() { MeasurementVariables = new List<string>() { "S12", "S13" } }
        //};

        //testRequirements.Requirements.Add(requirement);
        //// Create an instance of TestRequirement
        //var requirement2 = new TestRequirement
        //{
        //    Name = "MyTestRequirement",
        //    Limit = new RangeRequirementProperty() { MinValue = 1000, MaxValue = 2000, Limit = new LessThanLimit<double>(-8.0, Unit.DecibelMilliwatt, Prefix.None) },
        //    CharacteristicParameter = new RippleParameter()
        //    {
        //        // Set the properties of the characteristic parameter
        //    }
        //};
        //testRequirements.Requirements.Add(requirement2);

        //// Create an instance of TestRequirement
        //var requirement3 = new TestRequirement
        //{
        //    Name = "MyTestRequirement",
        //    Limit = new DoubleRequirementProperty() { Value = 0, Limit = new ToleranceLimit<double>(0.0, 1.0, Unit.None, Prefix.None) },
        //    CharacteristicParameter = new RippleParameter()
        //    {
        //        // Set the properties of the characteristic parameter
        //    }
        //};

        //testRequirements.Requirements.Add(requirement3);

        //processor.TestInfo = info;
        //processor.TestRequirements = testRequirements;

        //// Serialize the TestRequirement instance to XML
        //var serializer = new XmlSerializer(typeof(MeasurementProcessor));
        //using (var writer = new StreamWriter("test_spec_file.xml"))
        //{
        //    serializer.Serialize(writer, processor);
        //}


        //processor.SetBaseDataSet(new Dictionary<string, double>());

        //// Parse the test requirements from XML
        //processor.ParseTestSpecsFromXml("test_spec_file.xml");

        //// Calculate the characteristic parameters
        //processor.CalculateCharacteristicParameters();

        //// Validate the measurement
        //processor.ValidateMeasurement();
    }

}
