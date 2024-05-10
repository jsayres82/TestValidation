using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestMetrics
{
    public class PartMetrics
    {
        public string PartNumber { get; set; }
        public string PartDescription { get; set; }
        public string PartType { get; set; }
        public double PartYield { get; set; }
        public List<string> TestResultsFiles { get; set; }
        public List<string> Tests { get; set; }
        public List<string> SerialNumbers { get; set; }
        public List<int> WaferNumbers { get; set; }
        public string SpecificationFile { get; set; }
        public Dictionary<string, double> AverageValues { get; set; }

        public PartMetrics() { }


        public static PartMetrics GetFromDatabase(string connectionString, string partNumber)
        {
            // Create a connection to the database
            var connection = new SqlConnection(connectionString);
            connection.Open();

            // Create a command to select the part metrics from the database
            var command = new SqlCommand("SELECT * FROM PartMetrics WHERE PartNumber = @PartNumber", connection);
            command.Parameters.AddWithValue("@PartNumber", partNumber);

            // Execute the command
            var reader = command.ExecuteReader();

            // Iterate through the results and create a PartMetrics object
            PartMetrics partMetrics = null;
            if (reader.Read())
            {
                partMetrics = new PartMetrics();
                partMetrics.PartNumber = reader["PartNumber"].ToString();
                partMetrics.PartYield = Convert.ToDouble(reader["PartYield"].ToString());
                partMetrics.TestResultsFiles = reader["TestResultsFiles"].ToString().Split(',').ToList();
                partMetrics.SerialNumbers = reader["SerialNumbers"].ToString().Split(',').ToList();
                reader["WaferNumbers"].ToString().Split(',').ToList().ForEach(x => partMetrics.WaferNumbers.Add(Convert.ToInt32(x)));
                partMetrics.SpecificationFile = reader["SpecificationFile"].ToString();
                reader["AverageValues"].ToString().Split(',').ToList().ForEach(x => partMetrics.AverageValues.Add(x.Split('=')[0], double.Parse(x.Split('=')[1])));
                partMetrics.Tests = reader["Tests"].ToString().Split(',').ToList();
            }

            // Close the connection
            connection.Close();

            return partMetrics;
        }

        public void WriteToDatabase(string connectionString)
        {
            // Create a connection to the database
            var connection = new SqlConnection(connectionString);
            connection.Open();

            // Create a command to insert the part metrics into the database
            var command = new SqlCommand("INSERT INTO PartMetrics (PartNumber, PartYield, TestResultsFiles, SerialNumbers, WaferNumbers, SpecificationFile, AverageValues, Tests) VALUES (@PartNumber, @PartYield, @TestResultsFiles, @SerialNumbers, @WaferNumbers, @SpecificationFile, @AverageValues, @Tests)", connection);
            command.Parameters.AddWithValue("@PartNumber", this.PartNumber);
            command.Parameters.AddWithValue("@PartYield", this.PartYield);
            command.Parameters.AddWithValue("@TestResultsFiles", this.TestResultsFiles);
            command.Parameters.AddWithValue("@SerialNumbers", this.SerialNumbers);
            command.Parameters.AddWithValue("@WaferNumbers", this.WaferNumbers);
            command.Parameters.AddWithValue("@SpecificationFile", this.SpecificationFile);
            command.Parameters.AddWithValue("@AverageValues", this.AverageValues);
            command.Parameters.AddWithValue("@Tests", this.Tests);

            // Execute the command
            command.ExecuteNonQuery();

            // Close the connection
            connection.Close();
        }
    }
}
