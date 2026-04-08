using System.Text.Json.Serialization;

namespace ServerUtilities;

[JsonDerivedType(typeof(Server), typeDiscriminator: "general")]
[JsonDerivedType(typeof(DatabaseServer), typeDiscriminator: "database")]
public class Server : IRestartable
{
    public required string Name { get; init; }
    public decimal MemoryCapacity { get; init; }
    public ServerStatus CurrentStatus { get; set; }

    public required DateTimeOffset ProvisionedOn { get; init; }
    
    public TimeSpan UpTime
    {
        get
        {
            return DateTimeOffset.UtcNow - ProvisionedOn;
        }
    }
    public void ToggleStatus()
    {
        CurrentStatus = CurrentStatus switch
        {
            ServerStatus.Offline     => ServerStatus.Online,
            ServerStatus.Online      => ServerStatus.Offline,
            ServerStatus.Maintenance => throw new InvalidOperationException("Cannot toggle status while in maintenance mode."),
            _                        => throw new InvalidOperationException("Invalid Server Status")
        };
    }

    public override string ToString()
    {
        string currentStatus = CurrentStatus switch
        {
            ServerStatus.Offline     => "Offline",
            ServerStatus.Online      => "Online",
            ServerStatus.Maintenance => "Under Maintenance",
            _                        => "Unknown Status"
        };

        return $"Server Name: {Name}, Capacity: {MemoryCapacity:N0}GB, Status: {currentStatus}, Created: {ProvisionedOn}, Uptime: {UpTime}";
    }

    public void Restart()
    {
        CurrentStatus = CurrentStatus switch
        {
            ServerStatus.Maintenance => throw new InvalidOperationException("Cannot restart a server in maintenance mode."),
            _                        => ServerStatus.Offline
        };

        // WriteLine($"Restarting server {Name}.");
        CurrentStatus = ServerStatus.Online;
    }
}
