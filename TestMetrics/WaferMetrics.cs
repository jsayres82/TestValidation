using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestMetrics
{
    public class WaferMetrics
    {
        public int WaferNumber { get; set; }
        public string MaskName { get; set; }
        public List<string> PartNumbers { get; set; }
        public List<PartMetrics> PartMetrics { get; set; }
        public double WaferYield { get; set; }

        public List<string> Tests { get; set; }

        public WaferMetrics() { }


        public static WaferMetrics GetFromDatabase(string connectionString, int waferNumber)
        {
            // Create a connection to the database
            var connection = new SqlConnection(connectionString);
            connection.Open();

            // Create a command to select the wafer metrics from the database
            var command = new SqlCommand("SELECT * FROM WaferMetrics WHERE WaferNumber = @WaferNumber", connection);
            command.Parameters.AddWithValue("@WaferNumber", waferNumber);

            // Execute the command
            var reader = command.ExecuteReader();

            // Iterate through the results and create a WaferMetrics object
            WaferMetrics waferMetrics = null;
            if (reader.Read())
            {
                waferMetrics = new WaferMetrics();
                waferMetrics.WaferNumber = Convert.ToInt32(reader["WaferNumber"].ToString());
                waferMetrics.MaskName = reader["MaskName"].ToString();
                waferMetrics.PartMetrics = reader["PartMetrics"].ToString().Split(',').Select(x => TestMetrics.PartMetrics.GetFromDatabase(connectionString, x)).ToList();
                waferMetrics.WaferYield = Convert.ToDouble(reader["WaferYield"].ToString());
                waferMetrics.Tests = reader["Tests"].ToString().Split(',').ToList();
            }

            // Close the connection
            connection.Close();

            return waferMetrics;
        }

        public void WriteToDatabase(string connectionString)
        {
            // Create a connection to the database
            var connection = new SqlConnection(connectionString);
            connection.Open();

            // Create a command to insert the wafer metrics into the database
            var command = new SqlCommand("INSERT INTO WaferMetrics (WaferNumber, MaskName, WaferYield, PartMetrics, Tests) VALUES (@WaferNumber, @MaskName, @WaferYield, @PartMetrics, @Tests)", connection);
            command.Parameters.AddWithValue("@WaferNumber", this.WaferNumber);
            command.Parameters.AddWithValue("@MaskName", this.MaskName);
            command.Parameters.AddWithValue("@WaferYield", this.WaferYield);
            command.Parameters.AddWithValue("@PartMetrics", this.PartMetrics);
            command.Parameters.AddWithValue("@Tests", this.Tests);

            // Execute the command
            command.ExecuteNonQuery();

            // Close the connection
            connection.Close();
        }
    }
}
