using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Principal;
using static System.Net.Mime.MediaTypeNames;

namespace Nuvo.TestServer
{
    public class TestServer
    {

        private Dictionary<string,List<string>> tests = new Dictionary<string, List<string>>();
        private Dictionary<string, string> ipAddresses = new Dictionary<string, string>();

        public TestServer() { }


        public void AddTest(string testName, List<string> fileNames, string ipAddress)
        {
            tests.Add(testName, fileNames);
            ipAddresses.Add(testName,ipAddress);
        }

        public List<string> GetFileNames(string test)
        {
            return tests[test];
        }

        public List<string> GetTests()
        {
            return tests.Keys.ToList();
        }

        public string GetIpAddresses(string test)
        {
            return ipAddresses[test];
        }

        public bool Watch(string sourceFile, string destFile)
        {
            string username = "username";
            string password = "password";
            bool fileFound = false;
            try
            {
                NetworkCredential networkCredential = new NetworkCredential(username, password);
                var fileExists = File.Exists(sourceFile);
                if (fileExists)
                {
                    File.Copy(sourceFile, destFile, true);
                    fileFound = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: {0}", ex.Message);
            }
            return fileFound;
        }

        public void WatchForFiles()
        {
            while (true)
            {
                // Check for new files
                for (int i = 0; i < tests.Count; i++)
                {
                    string testName = tests.Keys.ToList().ElementAt(i);
                    List<string> fileNames = tests[testName];
                    string ipAddress = ipAddresses[testName];

                    //string fileName = @"QBpluginlink.txt";
                    string targetPath = $"\\\\{ipAddress}\\C$";
                    string sourcePath = $"C:\\TestData\\{testName}";

                    Console.WriteLine(targetPath);
                    Console.WriteLine(sourcePath);

                    foreach (string fileName in fileNames)
                    {
                        // Use Path class to manipulate file and directory paths.
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        string sourceFile = System.IO.Path.Combine(sourcePath, fileName);

                        if(Watch(sourceFile,destFile))
                        {
                            // File was created, remove it from the list
                            tests[testName].Remove(fileName);
                        }

                        //// To copy a folder's contents to a new location:
                        //// Create a new target folder, if necessary.
                        //if (System.IO.Directory.Exists(targetPath))
                        //{
                        //    // To copy a file to another location and 
                        //    // overwrite the destination file if it already exists.
                        //    System.IO.File.Copy(sourceFile, destFile, true);

                        //    if (File.Exists(fileName))
                        //    {
                        //        // File was created, remove it from the list
                        //        tests[testName].Remove(fileName);
                        //    }
                        //}
                    }

                    if (fileNames.Count == 0)
                    {
                        // All files for this test were created, remove the test from the list
                        tests.Remove(testName);
                        ipAddresses.Remove(testName);
                    }
                }

                // Sleep for a second
                System.Threading.Thread.Sleep(1000);
            }
        }


    }
}