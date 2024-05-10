using System.Data.SqlClient;

namespace Nuvo.TestMetrics
{
    public class ModuleMetrics
    {
        public string ModulePartNumber { get; set; }
        public string ModuleDescription { get; set; }
        public double ModuleYield { get; set; }
        public List<string> SerialNumbers { get; set; }
        public List<string> TestResultsFiles { get; set; }
        public string SpecificationFile { get; set; }
        public Dictionary<string, float> AverageValues { get; set; }
        public List<string> Tests { get; set; }

        public ModuleMetrics() { }

        public static ModuleMetrics GetFromDatabase(string connectionString, string modulePartNumber)
        {
            // Create a connection to the database
            var connection = new SqlConnection(connectionString);
            connection.Open();

            // Create a command to select the module metrics from the database
            var command = new SqlCommand("SELECT * FROM ModuleMetrics WHERE ModulePartNumber = @ModulePartNumber", connection);
            command.Parameters.AddWithValue("@ModulePartNumber", modulePartNumber);

            // Execute the command
            var reader = command.ExecuteReader();

            // Iterate through the results and create a ModuleMetrics object
            ModuleMetrics moduleMetrics = null;
            if (reader.Read())
            {
                moduleMetrics = new ModuleMetrics();
                moduleMetrics.ModulePartNumber = reader["ModulePartNumber"].ToString();
                moduleMetrics.ModuleDescription = reader["ModuleDescription"].ToString();
                moduleMetrics.ModuleYield = Convert.ToDouble(reader["ModuleYield"].ToString());
                moduleMetrics.SerialNumbers = reader["SerialNumbers"].ToString().Split(',').ToList();
                moduleMetrics.TestResultsFiles = reader["TestResultsFiles"].ToString().Split(',').ToList();
                moduleMetrics.SpecificationFile = reader["SpecificationFile"].ToString();
                moduleMetrics.AverageValues = reader["AverageValues"].ToString().Split(',').Select(x => float.Parse(x)).ToDictionary(x => x.ToString().Split('=')[0], x => float.Parse(x.ToString().Split('=')[1]));
                moduleMetrics.Tests = reader["Tests"].ToString().Split(',').ToList();
            }

            // Close the connection
            connection.Close();

            return moduleMetrics;
        }

        public void WriteToDatabase(string connectionString)
        {
            // Create a connection to the database
            var connection = new SqlConnection(connectionString);
            connection.Open();

            // Create a command to insert the module metrics into the database
            var command = new SqlCommand("INSERT INTO ModuleMetrics (ModulePartNumber, ModuleDescription, ModuleYield, SerialNumbers, TestResultsFiles, SpecificationFile, AverageValues, Tests) VALUES (@ModulePartNumber, @ModuleDescription, @ModuleYield, @SerialNumbers, @TestResultsFiles, @SpecificationFile, @AverageValues, @Tests)", connection);
            command.Parameters.AddWithValue("@ModulePartNumber", this.ModulePartNumber);
            command.Parameters.AddWithValue("@ModuleDescription", this.ModuleDescription);
            command.Parameters.AddWithValue("@ModuleYield", this.ModuleYield);
            command.Parameters.AddWithValue("@SerialNumbers", this.SerialNumbers);
            command.Parameters.AddWithValue("@TestResultsFiles", this.TestResultsFiles);
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
