// Problem Set for Chapter 5: Building Your Own Types with Object-Oriented Programming
using System.Text.Json;
using System.Text.RegularExpressions;
using ServerUtilities;
namespace Pset07;

partial class Program
{
    public static string GetMenuChoice()
    {
        const int Col1 = 10;
        const int Col2 = 4;
        const int Col3 = 10;
        string line = new('-', Col1 + Col2 + Col3 + 3);

        Console.Clear();
        WriteLine(line);
        WriteLine($"{" ", Col1} {"Menu", Col2} {" ", Col3}");
        WriteLine(line);
        WriteLine("Port Configurations (port)");
        WriteLine("Diagnostics (diagnostics)");
        WriteLine("Ping (ping)");
        WriteLine("Server status (server)");
        WriteLine("List all servers (list)");
        WriteLine("Save servers (save)");
        WriteLine("Load servers (load)");
        WriteLine("Exit (exit)");
        WriteLine(line);
        Write("Enter choice: ");
        string choice = ReadLine()?.ToLower() ?? string.Empty;

        return choice;
    }

    /// <summary>
    /// Pings the target address and throws exception if target is not provided.
    /// </summary>
    /// <param name="targetAddress">The address to be pinged.</param>
    /// <param name="packetSize">Optional packet size; defaults to 32</param>
    /// <returns>Tuple of ping sucess and the round trip time.</returns>
    /// <exception cref="T:System.ArgumentException">
    /// Thrown when the <paramref name="targetAddress"/> is null, empty, or whitespace.
    /// </exception>
    public static (bool IsSuccess, int RoundTripTime) SimulatePing(string targetAddress, int packetSize = 32)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(targetAddress, paramName: nameof(targetAddress));

        if (targetAddress == "localhost")
        {
            return (true, 1);
        }

        return (true, 45);
    }

    static void Main(string[] args)
    {
        string fileName = "servers.json";
        string pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string serverJsonPath = System.IO.Path.Combine(pathToDesktop, fileName);

        bool isRunning = true;

        Dictionary<string, Server> dictServer = [];
        Regex regexIPv4AddressChecker = new(@"^\d{1,3}(\.\d{1,3}){3}$");

        while(isRunning)
        {
            string choice = GetMenuChoice();

            switch (choice)
            {
                case "port":

                    Write("Enter port number [0 - 65,535]: ");

                    if (ushort.TryParse(ReadLine(), out ushort portNumber))
                    {
                        WriteLine($"Port Number: {portNumber}");
                    }
                    else
                    {
                        WriteLine("Invalid Port Number.");
                    }

                    ReadKey();
                    break;

                case "diagnostics":

                    Write("Enter a small number: ");
                    byte smallNumber = byte.TryParse(ReadLine(), out byte result) ? result : byte.MinValue;
                    WriteLine($"Small Number: {smallNumber}");

                    try
                    {
                        byte byteNumber = byte.MaxValue;
                        checked
                        {
                            byteNumber += smallNumber;
                            WriteLine($"Maximum byte plus small number {byteNumber}");
                        }
                    }
                    catch (OverflowException)
                    {
                        ConsoleColor previousColor = ForegroundColor;
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("We have an overflow exception.");
                        ForegroundColor = previousColor;
                    }
                    catch (Exception ex)
                    {
                        WriteLine($"Exception: {ex.Message}.");
                    }

                    ReadKey();
                    break;
                
                case "ping":

                    try
                    {
                        Write("Enter target address: ");
                        string targetAddress = ReadLine()!;
                        var (success, ping) = SimulatePing(targetAddress);
                        WriteLine($"Is Successful? {success}, Round trip time: {ping}");
                    }
                    catch (ArgumentException ex)
                    {
                        ConsoleColor previousColor = ForegroundColor;
                        ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{ex.Message}");
                        ForegroundColor = previousColor;
                    }

                    ReadKey();
                    break;

                case "exit":

                    isRunning = false;
                    WriteLine("Exiting ...");
                    break;

                case "server":

                    Write("Enter the IPv4 address: ");
                    string? input = ReadLine() ?? string.Empty;
                    
                    if (!regexIPv4AddressChecker.IsMatch(input))
                    {
                        WriteLine("Error: Not a valid IPv4 address.");
                        ReadKey();
                        break;
                    }

                    string ipv4Address = input;
                    if (dictServer.ContainsKey(ipv4Address))
                    {
                        WriteLine("Error: IPv4 address already exists.");
                        ReadKey();
                        break;
                    }

                    Write("Enter the server name: ");
                    input = ReadLine();
                    string serverName = string.IsNullOrEmpty(input) ? "Default Server Name" : input;
                    Write("Enter size of memory in gigabytes: ");
                    decimal memorySize = decimal.TryParse(ReadLine(), out decimal memSize) ? memSize : 0M;
                    Write("Do you want to create a (G)eneral server or a (D)atabase server? ");
                    input = ReadLine();

                    ServerType serverType = input switch
                    {
                        "D" or "d" => ServerType.DatabaseServer,
                        _          => ServerType.GeneralServer
                    };

                    string dbEngine = string.Empty;

                    if (serverType is ServerType.DatabaseServer)
                    {
                        Write("Enter DB engine name {example: PostgreSQL, MySQL}: ");
                        input = ReadLine();
                        dbEngine = string.IsNullOrEmpty(input) ? "Default DB Engine" : input;
                    }

                    Server server = ServerFactory.Create(serverType, serverName, memorySize, dbEngine);
                    dictServer.Add(key: ipv4Address, value: server);

                    WriteLine(server.ToString());

                    try
                    {
                        server.ToggleStatus();
                        WriteLine(server.ToString());
                    }
                    catch (InvalidOperationException invalidEx)
                    {
                        WriteLine($"Error: {invalidEx.Message}");
                    }

                    server.Restart();
                    
                    ReadKey();
                    break;

                case "list":

                    if (dictServer == null || dictServer.Count == 0)
                    {
                        WriteLine("No servers found.");
                        ReadKey();
                        break;
                    }

                    foreach ( var (ipAdd, serv) in dictServer)
                    {
                        string formattedUptime = serv.UpTime.ToString(@"dd\.hh\:mm\:ss");
                        WriteLine($"IP Address: {ipAdd}, Name: {serv.Name}, Uptime: {formattedUptime}");
                    }

                    ReadKey();
                    break;

                case "save":

                    var optionsSerializer = new JsonSerializerOptions { WriteIndented = true };
                    string jsonString = JsonSerializer.Serialize(dictServer, optionsSerializer);

                    try
                    {
                        using StreamWriter outputFile = File.CreateText(serverJsonPath);
                        outputFile.Write(jsonString);
                        WriteLine($"Successfully serialized data to {serverJsonPath}");
                    }
                    catch (Exception ex)
                    {
                        WriteLine($"An error occurred writing to a JSON file: {ex.Message}");
                    }

                    ReadKey();
                    break;

                case "load":

                    if (!File.Exists(serverJsonPath))
                    {
                        WriteLine($"File containing the servers list does not exist: {serverJsonPath}");
                        ReadKey();
                        break;
                    }

                    try
                    {
                        string loadServers = File.ReadAllText(serverJsonPath);
                        var optionsDeserializer = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        dictServer = JsonSerializer.Deserialize<Dictionary<string, Server>>(loadServers, optionsDeserializer) ?? [];
                        WriteLine($"Successfully loaded servers in {serverJsonPath}");
                    }
                    catch (JsonException ex)
                    {
                        WriteLine($"Error: JSON deserialization failed: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        WriteLine($"An unexpected error occurred: {ex.Message}");
                    }

                    ReadKey();
                    break;

                default:
                
                    WriteLine($"Invalid choice. Please try again.");
                    ReadKey();
                    break;
            }
        }
    }
}
