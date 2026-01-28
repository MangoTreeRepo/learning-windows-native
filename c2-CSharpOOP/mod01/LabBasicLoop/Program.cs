namespace LabBasicLoop;

class Program
{
    static void Main(string[] args)
    {
        // for-loop example
        Console.WriteLine("Numbers 1 through 10:");
        for (int i = 1; i <= 10; i++)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();

        // while-loop example
        Console.WriteLine("Enter commands (type 'quit' to exit):");
        string userInput = string.Empty;
        while (userInput != "quit")
        {
            userInput = Console.ReadLine() ?? string.Empty;
            Console.WriteLine($"You entered: {(userInput != string.Empty ? userInput : "None")}");
        }

        Console.WriteLine("First While Loop ended.");

        // alternative: better to declare userr input string inside 
        // since it has smallest scope according to Gemini
        Console.WriteLine("Enter commands (type 'quit' to exit):");
        while (true)
        {
            // Declaring inside is clean and optimized
            string userInput2 = Console.ReadLine() ?? string.Empty;

            if (userInput2.Equals("quit", StringComparison.OrdinalIgnoreCase)) 
                break;

            Console.WriteLine($"You entered: {(string.IsNullOrEmpty(userInput2) ? "None" : userInput2)}");
        }

        Console.WriteLine("Second While Loop ended.");

        // do-while loop example
        int choice = int.MinValue;
        Console.WriteLine("------------------------------");
        Console.WriteLine("            Menu              ");
        Console.WriteLine("------------------------------");
        Console.WriteLine();
        Console.WriteLine("1. Say Hello                  ");
        Console.WriteLine("2. Show Time                  ");
        Console.WriteLine("0. Exit.                      ");
        do
        {
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                choice = -1;
                continue;
            }
            switch (choice)
            {
                case 1: Console.WriteLine("Hello"); break;
                case 2: Console.WriteLine(DateTime.Now.ToString("HH:mm:ss")); break;
                case 0: break;
                default: break;
            }
        } while (choice != 0);

        // Gemini version
        bool isRunning = true;

        while (isRunning)
        {
            // 1. Clear and Redraw for a "Dashboard" feel
            Console.Clear();
            Console.WriteLine("==============================");
            Console.WriteLine("       APPLICATION MENU       ");
            Console.WriteLine("==============================");
            Console.WriteLine("1. Say Hello");
            Console.WriteLine("2. Show Current Time");
            Console.WriteLine("0. Exit");
            Console.WriteLine("------------------------------");
            Console.Write("Selection > ");

            // 2. Robust Input Handling
            string input = Console.ReadLine() ?? string.Empty;

            if (!int.TryParse(input, out int choice2))
            {
                Console.WriteLine("\n[Error] Invalid input. Please enter a number.");
                PauseForUser();
                continue;
            }

            // 3. Clean Switch Logic
            switch (choice2)
            {
                case 1:
                    Console.WriteLine("\nHello there!");
                    break;
                case 2:
                    Console.WriteLine($"\nCurrent Time: {DateTime.Now:HH:mm:ss}");
                    break;
                case 0:
                    Console.WriteLine("\nExiting application...");
                    isRunning = false;
                    continue; // Skip the pause on exit
                default:
                    Console.WriteLine($"\n[Error] '{choice}' is not a valid option.");
                    break;
            }

            PauseForUser();
        }
    }

    private static void PauseForUser()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
