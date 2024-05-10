using System;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data.SqlClient;
//using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestMetrics
{
    public class MetricsDatabase
    {
        public static void CreateDatabase(string connectionString)
        {
            // Check if the database exists
            var databaseExists = false;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT COUNT(*) AS Count FROM sys.databases WHERE name = 'MetricsDatabase'", connection);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    databaseExists = reader["Count"].ToString() == "1";
                }
            }

            // If the database doesn't exist, create it
            if (!databaseExists)
            {
                var createDatabaseCommand = new SqlCommand("CREATE DATABASE MetricsDatabase");
                createDatabaseCommand.ExecuteNonQuery();
            }

            // Check if the tables exist
            var tables = GetTables(connectionString);

            // If the tables don't exist, create them
            if (tables.Count != 4)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var createTablesCommand = new SqlCommand(
                    "CREATE TABLE MaskMetrics (MaskName VARCHAR(255) NOT NULL, WaferNumbers VARCHAR(255) NOT NULL, MaskYields VARCHAR(255) NOT NULL, WaferMetrics VARCHAR(255) NOT NULL, PRIMARY KEY (MaskName))",
                    connection);
                    createTablesCommand.ExecuteNonQuery();

                    createTablesCommand = new SqlCommand(
                        "CREATE TABLE WaferMetrics (WaferNumber INT NOT NULL, MaskName VARCHAR(255) NOT NULL, PartMetrics VARCHAR(255) NOT NULL, WaferYield FLOAT NOT NULL, Tests VARCHAR(255) NOT NULL, PRIMARY KEY (WaferNumber))",
                        connection);
                    createTablesCommand.ExecuteNonQuery();

                    createTablesCommand = new SqlCommand(
                        "CREATE TABLE PartMetrics (PartNumber VARCHAR(255) NOT NULL, PartYield INT NOT NULL, TestResultsFiles VARCHAR(255) NOT NULL, SerialNumbers VARCHAR(255) NOT NULL, WaferNumbers VARCHAR(255) NOT NULL, SpecificationFile VARCHAR(255) NOT NULL, AverageValues VARCHAR(255) NOT NULL, Tests VARCHAR(255) NOT NULL, PRIMARY KEY (PartNumber))",
                        connection);
                    createTablesCommand.ExecuteNonQuery();

                    createTablesCommand = new SqlCommand(
                        "CREATE TABLE ModuleMetrics (ModulePartNumber VARCHAR(255) NOT NULL, ModuleDescription VARCHAR(255) NOT NULL, ModuleYield INT NOT NULL, SerialNumbers VARCHAR(255) NOT NULL, TestResultsFiles VARCHAR(255) NOT NULL, SpecificationFile VARCHAR(255) NOT NULL, AverageValues VARCHAR(255) NOT NULL, Tests VARCHAR(255) NOT NULL, PRIMARY KEY (ModulePartNumber))",
                        connection);
                    createTablesCommand.ExecuteNonQuery();
                }
            }

        }
        public static List<string> GetTables(string connectionString)
        {
            var tables = new List<string>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT name FROM sys.tables", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tables.Add(reader["name"].ToString());
                }
            }
            return tables;
        }
    }
}
