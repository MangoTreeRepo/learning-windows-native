// Problem Set for Chapter 5: Building Your Own Types with Object-Oriented Programming
using ServerUtilities;
namespace Pset05;
class Program
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
        bool isRunning = true;

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

                    Write("Enter the server name: ");
                    string? input = ReadLine();
                    string serverName = string.IsNullOrEmpty(input) ? "Default Server Name" : input;
                    Write("Enter size of memory in gigabytes: ");
                    decimal memorySize = decimal.TryParse(ReadLine(), out decimal memSize) ? memSize : 0M;

                    Server server = new()
                    {
                        Name = serverName,
                        MemoryCapacity = memorySize,
                        CurrentStatus = ServerStatus.Offline
                    };

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
