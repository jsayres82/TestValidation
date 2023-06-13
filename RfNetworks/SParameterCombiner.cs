using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RF_Networks
{
    public class SParameterCombiner
    {
        private Dictionary<string, string> filePortNames;
        private Dictionary<string, List<string>> fileNamesPortsDic;

        public SParameterCombiner()
        {
            filePortNames = new Dictionary<string, string>();
            fileNamesPortsDic = new Dictionary<string, List<string>>();
        }

        public void AddSParameterFile(string filePath, string[] portNumbers)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                Console.WriteLine($"Invalid file path: {filePath}");
                return;
            }

            if (portNumbers == null || portNumbers.Length == 0)
            {
                Console.WriteLine($"Invalid port numbers for file: {filePath}");
                return;
            }

            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string filePortName = $"{fileName}";

            if (!filePortNames.ContainsKey(filePath))
            {
                filePortNames[filePath] = filePortName;
            }
            fileNamesPortsDic.Add(filePortName, portNumbers.ToList());
        }

        public void AddSParameterFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                Console.WriteLine($"Invalid file path: {filePath}");
                return;
            }

            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string filePortName = $"{fileName}";

            if (!filePortNames.ContainsKey(filePath))
            {
                filePortNames[filePath] = filePortName;
            }

            fileNamesPortsDic.Add(filePortName, GetPortNumbers(filePortName).ToList());
        }

        public void CombineSParameterFiles(string outputFilePath)
        {
            Dictionary<string, List<List<string>>> fileData = new Dictionary<string, List<List<string>>>();
            List<string> freqs = new List<string>();
            int numPorts = GetNumPorts();
            List<string>[,] arr = new List<string>[numPorts, numPorts];

            foreach (KeyValuePair<string, string> kvp in filePortNames)
            {
                string filePath = kvp.Key;
                string filePortName = kvp.Value;
                Dictionary<string, List<string>> data = ExtractSParameterData(filePath);
                List<List<string>> values = GetSParameterValues(data, out freqs);

                fileData[filePortName] = values;

                int index = 1;
                foreach (var iStr in GetPortNumbers(filePortName))
                {
                    int i = Convert.ToInt32(iStr) - 1;
                    foreach (var jStr in GetPortNumbers(filePortName))
                    {
                        int j = Convert.ToInt32(jStr) - 1;
                        if (arr[i, j] == null)
                        {
                            arr[i, j] = new List<string>();
                            foreach (var freq in data.Keys)
                            {
                                if (!freq.Equals(""))
                                {
                                    arr[i, j].Add($"{data[freq][index - 1]}");
                                }
                            }
                        }
                        index++;
                    }
                }
            }

            int valIndex = 0;
            if (freqs.First().Equals(""))
            {
                freqs.Remove(freqs.First());
            }

            StringBuilder outputContent = new StringBuilder();
            outputContent.AppendLine("# Hz S  dB   R 50");

            foreach (var freq in freqs)
            {
                StringBuilder line = new StringBuilder();

                for (int j = 0; j < numPorts; j++)
                {
                    for (int i = 0; i < numPorts; i++)
                    {
                        if (arr[i, j] == null)
                        {
                            line.Append($"{double.NaN} {double.NaN} ");
                        }
                        else
                        {
                            line.Append($"{arr[i, j].ElementAt(valIndex)} ");
                        }
                    }
                }

                valIndex++;
                string combinedPortData = $"{freq} {line}";
                outputContent.AppendLine(combinedPortData);
            }

            File.WriteAllText(outputFilePath, outputContent.ToString());
        }

        public Dictionary<string, List<string>> ExtractSParameterData(string filePath)
        {
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
            List<string> values = new List<string>();
            bool foundStartMarker = false;
            string freq = "";
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (line.StartsWith("!") || line.StartsWith("#"))
                {
                    foundStartMarker = true;
                    continue;
                }

                if (foundStartMarker && !string.IsNullOrWhiteSpace(line))
                {
                    List<string> tempValues = TrimAndSplitLine(line);
                    if (tempValues.Count > 0)
                    {
                        if (tempValues.Count % 2 == 0)
                        {
                            for (int i = 0; i < tempValues.Count; i += 2)
                            {
                                data[freq].Add($"{tempValues[i]} {tempValues[i + 1]}");
                            }
                        }
                        else
                        {
                            if (data.Count > 0)
                            {
                                List<string> temp = new List<string>();
                                for (int i = 1; i < tempValues.Count; i += 2)
                                {
                                    temp.Add($"{tempValues[i]} {tempValues[i + 1]}");
                                }
                                freq = tempValues[0];
                                data.Add(freq, temp);
                                values = new List<string>();
                            }
                            else
                            {
                                data.Add("", values);
                                values = new List<string>();
                                values.AddRange(tempValues);
                            }
                        }
                    }

                }
            }

            return data;
        }

        private static List<string> TrimAndSplitLine(string line)
        {
            line = StripTrailingComment(line).Trim();

            string[] data = Regex.Split(line, @"\s+");
            return new List<string>(data);
        }

        private static string StripTrailingComment(string line)
        {
            int index = line.IndexOf(Constants.CommentChar);
            if (index >= 0)
            {
                return line.Substring(0, index);
            }
            else return line;
        }

        private int GetNumPorts()
        {
            int numPorts = 0;

            foreach (KeyValuePair<string, string> kvp in filePortNames)
            {
                string filePortName = kvp.Value;
                List<string> numPortstr = filePortName.Split('P').ToList();
                numPortstr.Remove(numPortstr.First());

                foreach (string p in numPortstr)
                {
                    if (int.TryParse(p, out var portNumber))
                    {
                        numPorts = Math.Max(numPorts, portNumber);
                    }
                }
            }

            return numPorts;
        }

        private List<List<string>> GetSParameterValues(Dictionary<string, List<string>> data, out List<string> freqs)
        {
            List<List<string>> values = new List<List<string>>();
            freqs = new List<string>();

            foreach (var kvp in data)
            {
                var freq = kvp.Key;
                var sparams = kvp.Value;

                if (!string.IsNullOrEmpty(freq))
                {
                    freqs.Add(freq);
                    values.Add(sparams);
                }
            }

            return values;
        }

        private IEnumerable<string> GetPortNumbers(string filePortName)
        {
            List<string> numPortstr = filePortName.Split('P').ToList();
            numPortstr.Remove(numPortstr.First());

            return numPortstr;
        }
    }

    internal static class Constants
    {
        public const char CommentChar = '!';
    }
}
