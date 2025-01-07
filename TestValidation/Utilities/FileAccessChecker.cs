using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Nuvo.TestValidation.Utilities
{
    public class FileAccessChecker
    {
        public bool IsFileAvailable(string filePath)
        {
            try
            {
                // Try to open the file with exclusive access
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    // If we reach here, the file is not locked by another process
                    return true;
                }
            }
            catch (IOException)
            {
                // File is locked by another process
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                // You do not have permission to access this file
                Console.WriteLine("You do not have the necessary permissions to access this file.");
                return false;
            }
        }

        public bool TryToAccessFile(string filePath, int maxAttempts = 10, int delayMilliseconds = 100)
        {
            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        return true; // File was successfully accessed
                    }
                }
                catch (IOException)
                {
                    // File is locked, wait and try again
                    Thread.Sleep(delayMilliseconds);
                }
            }
            return false; // Could not access the file after max attempts
        }


        public static void Main(string[] args)
        {
            FileAccessChecker checker = new FileAccessChecker();
            string filePath = @"C:\path\to\your\file.txt";

            if (checker.IsFileAvailable(filePath))
            {
                Console.WriteLine("The file is available.");
            }
            else
            {
                Console.WriteLine("The file is being used by another process.");
            }
        }
    }
}
