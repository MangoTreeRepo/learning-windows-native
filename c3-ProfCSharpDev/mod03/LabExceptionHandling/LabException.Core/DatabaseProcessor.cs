using System;
using Microsoft.Data.SqlClient; // Ensure 'SqlClient' is included
using System.Data;             // Needed for CommandType or ConnectionState

namespace LabException.Core;

public class DatabaseProcessor
{
    public void ProcessData(string connectionString, string data)
    {
        if (string.IsNullOrWhiteSpace(data))
            throw new ArgumentException("Data to insert cannot be null or empty.", nameof(data));

        try
        {
            // 'using' ensures Dispose() is called even if an exception occurs
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            using var command = new SqlCommand("INSERT INTO Data (Value) VALUES (@data)", connection);
            command.Parameters.AddWithValue("@data", data);
            
            command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            // Handle specific SQL errors (e.g., Primary Key violations, Server down)
            Console.WriteLine($"Database error: {ex.Number} - {ex.Message}");
            throw; // Re-throw so the caller knows the save failed
        }
        catch (InvalidOperationException ex)
        {
            // Occurs if the connection string is invalid or the connection is already open
            Console.WriteLine($"Configuration error: {ex.Message}");
            throw;
        }
    }
}