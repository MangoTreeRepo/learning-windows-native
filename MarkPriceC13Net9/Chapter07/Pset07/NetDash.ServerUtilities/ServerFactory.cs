namespace ServerUtilities;

public static class ServerFactory
{
    public static Server Create(ServerType serverType, string serverName, decimal memorySize, string dbEngine = "PostgreSQL")
    {
        return serverType switch
        {
            ServerType.GeneralServer => new Server()
                {
                    Name = serverName,
                    MemoryCapacity = memorySize,
                    CurrentStatus = ServerStatus.Offline
                },
            
            ServerType.DatabaseServer => new DatabaseServer()
                {
                    Name = serverName,
                    MemoryCapacity = memorySize,
                    CurrentStatus = ServerStatus.Offline,
                    DatabaseEngine = dbEngine
                }
        };
    }
}