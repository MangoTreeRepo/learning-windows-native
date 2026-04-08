namespace ServerUtilities;

public static class ServerFactory
{
    public static Server Create(string ipv4Address, ServerType serverType, string serverName, decimal memorySize, string dbEngine = "PostgreSQL")
    {
        return serverType switch
        {
            ServerType.GeneralServer => new Server()
                {
                    Name = serverName,
                    MemoryCapacity = memorySize,
                    CurrentStatus = ServerStatus.Offline,
                    ProvisionedOn = DateTimeOffset.UtcNow,
                    IpAddress = ipv4Address
                },
            
            ServerType.DatabaseServer => new DatabaseServer()
                {
                    Name = serverName,
                    MemoryCapacity = memorySize,
                    CurrentStatus = ServerStatus.Offline,
                    DatabaseEngine = dbEngine,
                    ProvisionedOn = DateTimeOffset.UtcNow,
                    IpAddress = ipv4Address,
                }
        };
    }
}
