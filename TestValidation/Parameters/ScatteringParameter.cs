using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TestValidation.Limits;
using TestValidation.Limits.Validators;

namespace TestValidation.Parameters
{
    public class ScatteringParameter : GenericParameter
    {
        public string Description { get { return "Returns the scattering parameter specified in measurement variable"; } }
        public List<string> MeasurementVariables { get; set; }
        private List<string> parameterDomain = new List<string>();
        private Dictionary<string, List<double[]>> parameterValue = new Dictionary<string, List<double[]>>();
        private Dictionary<string, List<Complex>> complexParameterValue = new Dictionary<string, List<Complex>>();

        public override bool ValidateMeasurement(TestRequirement req, Dictionary<string, List<double[]>> measurement)
        {
            int index = 0;
            bool passed = true;
            foreach (var sParam in MeasurementVariables)
                foreach (var val in complexParameterValue[sParam])
                {
                    //if (!req.Limit.ValidateMeasurement(Convert.ToDouble(parameterDomain.ElementAt(index)), 1 * (new Complex(val[0], val[1])).Magnitude))
                    if (!req.Limit.ValidateMeasurement(Convert.ToDouble(parameterDomain.ElementAt(index)), 1 * val.Magnitude))
                    {
                        passed = false;
                        //Console.WriteLine($"Freq: {parameterDomain.ElementAt(index)} - {sParam} = {val.Magnitude}");
                    }
                    //Console.WriteLine($"Freq: {parameterDomain.ElementAt(index)} - {sParam} = {val.Magnitude} dB {val.Phase * (180/Math.PI)} Deg");
                    //Console.WriteLine($"Freq: {parameterDomain.ElementAt(index)} - {sParam} = {val.Magnitude}");
                    index++;
                }
            return passed;
        }

        public override Dictionary<string, double> CalculateParameterValue(TestRequirement req, Dictionary<string, List<double[]>> baseDataSet)
        {
            Dictionary<string, double> vals = new Dictionary<string, double>();
            baseDataSet = getMeasurementVariables(baseDataSet);
            foreach (var s in baseDataSet.Keys)
            {
                vals.Add(s, baseDataSet[s].First().First());
            }
            parameterValue = baseDataSet;
            return vals;
        }

        private Dictionary<string, List<double[]>> getMeasurementVariables(Dictionary<string, List<double[]>> measurement)
        {
            sprams.AddRange(s.ToList()); 
            parameterDomain = measurement.Keys.ToList();
            Dictionary<string, List<Complex>> parsedData = new Dictionary<string, List<Complex>>();
            foreach (var val in s)
                parsedData.Add(val, new List<Complex>());
            foreach (var d in measurement.Keys)
            {
                foreach (var val in measurement[d])
                {
                    var x = val.First();
                    var  y= val.Last();
                    parsedData[s[measurement[d].IndexOf(val)]].Add(new Complex(val[0], val[1]));
                    //Console.WriteLine($"{s[measurement[d].IndexOf(val)]}: {parsedData[s[measurement[d].IndexOf(val)]].Last().Magnitude} dB  {(180/Math.PI) * parsedData[s[measurement[d].IndexOf(val)]].Last().Phase} degrees");
                }
            }
            complexParameterValue = parsedData;
            return new Dictionary<string, List<double[]>>();

        }
        string[] s =new string[9] { "S11", "S12", "S13", "S21", "S22", "S23", "S31", "S32", "S33" };
        List<string> sprams = new List<string>();
    }
}
