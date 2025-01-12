using iText.Barcodes.Dmcode;
using MicrowaveNetworks;
using MicrowaveNetworks.Matrices;
using MicrowaveNetworks.Touchstone;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Utilities
{
    public class GenericDataConverter
    {
        public static INetworkParametersCollection ToNetworkParameters(Dictionary<string, List<object[]>> baseDataSet)
        {
            //// Get the frequency points
            var parameterDomain = baseDataSet.Keys.ToList();
            //var sumTraceList = new List<double>(parameterDomain.Count);
            var frequencyList = new List<string>(parameterDomain.Count);
            
            bool isFirstPass = true;
            List<INetworkParametersCollection> c = new List<INetworkParametersCollection>();

            // Loop through each frequency and populate the network parameter values for each sParameter
            foreach (var d in baseDataSet)
            {
                frequencyList.Add(d.Key);
                var m = d.Value.First();
                var matrix = new ScatteringParametersMatrix((IList<NetworkParameter>)m[0]);
                var pair = new FrequencyParametersPair(Convert.ToDouble(d.Key), matrix);
                
                if(isFirstPass)
                {
                    c.Add(new NetworkParametersCollection<ScatteringParametersMatrix>(matrix.NumPorts));
                    isFirstPass = false;
                }
                c.First().Add(pair.Frequency_Hz, pair.Parameters as ScatteringParametersMatrix);
            }

            return c.First();
        }


        public static Dictionary<string, List<object[]>> FromNetworkParameters(string filePath)
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
