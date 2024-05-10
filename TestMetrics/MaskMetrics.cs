using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestMetrics
{
    public class MaskMetrics
    {
        public string MaskName { get; set; }
        public List<int> WaferNumbers { get; set; }
        public List<WaferMetrics> WaferMetrics { get; set; }
        public double MaskYield { get; set; }

        public MaskMetrics() { }

        public static MaskMetrics GetFromDatabase(string connectionString, string maskName) 
        {
            // Create a connection to the database
            var connection = new SqlConnection(connectionString);
            connection.Open();

            // Create a command to select the mask metrics from the database
            var command = new SqlCommand("SELECT * FROM MaskMetrics WHERE MaskName = @MaskName", connection);
            command.Parameters.AddWithValue("@MaskName", maskName);

            // Execute the command
            var reader = command.ExecuteReader();

            // Iterate through the results and create a MaskMetrics object
            MaskMetrics maskMetrics = null;
            if (reader.Read()) {
                maskMetrics = new MaskMetrics();
                maskMetrics.MaskName = reader["MaskName"].ToString();
                reader["WaferNumbers"].ToString().Split(',').ToList().ForEach(x => maskMetrics.WaferNumbers.Add(Convert.ToInt32(x)));
                maskMetrics.MaskYield= Convert.ToDouble(reader["MaskYield"].ToString());
                maskMetrics.WaferMetrics = new List<WaferMetrics>();
                foreach (var waferNumber in maskMetrics.WaferNumbers)
                {
                    var waferMetrics = Nuvo.TestMetrics.WaferMetrics.GetFromDatabase(connectionString, waferNumber);
                    maskMetrics.WaferMetrics.Add(waferMetrics);
                }
                }

            // Close the connection
            connection.Close();

            return maskMetrics;
        }

        public void WriteToDatabase(string connectionString)
        {
            // Create a connection to the database
            var connection = new SqlConnection(connectionString);
            connection.Open();

            // Create a command to insert the mask metrics into the database
            var command = new SqlCommand("INSERT INTO MaskMetrics (MaskName, WaferNumbers, MaskYields, WaferMetrics) VALUES (@MaskName, @WaferNumbers, @MaskYields, @WaferMetrics)", connection);
            command.Parameters.AddWithValue("@MaskName", this.MaskName);
            command.Parameters.AddWithValue("@WaferNumbers", this.WaferNumbers);
            command.Parameters.AddWithValue("@MaskYields", this.MaskYield);
            command.Parameters.AddWithValue("@WaferMetrics", this.WaferMetrics);

            // Execute the command
            command.ExecuteNonQuery();

            // Close the connection
            connection.Close();
        }
    }
}
