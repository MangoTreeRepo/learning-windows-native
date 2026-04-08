namespace ServerUtilities;

public class DatabaseServer : Server
{
    public required string DatabaseEngine { get; set; }

    public override string ToString()
    {
        string baseToString = base.ToString();
        return $"{baseToString}, Engine: {DatabaseEngine}";
    }
}