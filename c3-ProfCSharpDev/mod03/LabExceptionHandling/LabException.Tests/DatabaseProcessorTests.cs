using Xunit;
using System;
using Microsoft.Data.SqlClient;
using LabException.Core;

namespace DatabaseTests;

public class DatabaseProcessorTests
{
    private readonly DatabaseProcessor _processor = new();

    [Fact]
    public void ProcessData_InvalidConnectionString_ThrowsInvalidOperationException()
    {
        // ARRANGE
        string badConnString = "Not a real connection string";
        string data = "Test Data";

        // ACT & ASSERT
        // Validates that our exception handling doesn't swallow configuration errors
        Assert.Throws<InvalidOperationException>(() => 
            _processor.ProcessData(badConnString, data));
    }

    [Fact]
    public void ProcessData_EmptyData_ThrowsArgumentException()
    {
        // ARRANGE
        string connString = "Server=myServer;Database=myDB;User Id=myUser;Password=myPassword;";
        
        // ACT & ASSERT
        var ex = Assert.Throws<ArgumentException>(() => 
            _processor.ProcessData(connString, ""));
        
        Assert.Contains("Data to insert cannot be null", ex.Message);
    }
}