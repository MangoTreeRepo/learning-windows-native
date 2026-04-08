// Problem Set for Chapter 3: Controlling Flow, Converting Types, and Handling Exceptions
const int Col1 = 10;
const int Col2 = 4;
const int Col3 = 10;
string line = new('-', Col1 + Col2 + Col3 + 3);

bool isRunning = true;

while (isRunning)
{
    // Menu
    Console.Clear();
    WriteLine(line);
    WriteLine($"{" ", Col1} {"Menu", Col2} {" ", Col3}");
    WriteLine(line);
    WriteLine("Port Configurations (port)");
    WriteLine("Diagnostics (diagnostics)");
    WriteLine("Exit (exit)");
    WriteLine(line);
    Write("Enter choice: ");
    string choice = ReadLine()?.ToLower() ?? string.Empty;

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

        case "exit":

            isRunning = false;
            WriteLine("Exiting ...");
            break;

        default:

            WriteLine($"Invalid choice. Choose between the three options.");
            ReadKey();
            break;
    }

}