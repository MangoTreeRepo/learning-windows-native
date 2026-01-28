namespace LabDataProc;

public class DataBucket
{
    private readonly List<int> _dataBucket = [];
    public void Add(int number) => _dataBucket.Add(number);
    public void Empty() => _dataBucket.Clear();
    public IEnumerable<int> GetAll() => _dataBucket.AsReadOnly();
}
class Program
{
    private static void CollectNumbers(DataBucket dataBucket)
    {
        const int SentinelStop = -999;
        Console.Write("Enter numbers for analysis (-999 to stop): ");
        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine(">>> [Invalid Input] Please enter a positive whole number.");
                Console.Write("Enter number: ");
                continue;
            }

            if (number == SentinelStop)
            {
                Console.WriteLine("Processing stopped. Analyzing collected data...");
                break;
            }

            if (number < 0)
            {
                Console.WriteLine($"Invalid entry: {number} (negative numbers not allowed). Skipping...");
                Console.Write("Enter number: ");
                continue;
            }

            dataBucket.Add(number);
            Console.Write("Enter number: ");
        }        
    }

    private static void PrintSummary(DataBucket dataBucket)
    {
        var numbers = dataBucket.GetAll();

        if(!numbers.Any())
        {
            Console.WriteLine("No data collected.");
            return;
        }

        foreach (var number in numbers)
        {
            Console.Write($"{number} ");
        }

        Console.WriteLine("\n--- Statistics ---");
        Console.WriteLine($"Count:   {numbers.Count()}");
        Console.WriteLine($"Sum:     {numbers.Sum()}");
        Console.WriteLine($"Average: {numbers.Average():F2}"); // F2 formats to 2 decimal places
        Console.WriteLine($"Max:     {numbers.Max()}");
        Console.WriteLine($"Min:     {numbers.Min()}");
    }

    private static void StatisticsEngine()
    private static void DisplayMenu()
    {
        // Console.Clear();
        Console.WriteLine("==============================");
        Console.WriteLine("        DISPLAY MENU          ");
        Console.WriteLine("==============================");
        Console.WriteLine("1. Enter new dataset");
        Console.WriteLine("2. Display current statistic");
        Console.WriteLine("3. Clear data");
        Console.WriteLine("0. Exit");
        Console.WriteLine("------------------------------");
        Console.Write("Selection > ");
    }

    private static int GetSelection()
    {
        HashSet<int> validChoices = [0, 1, 2, 3];

        while (true)
        {
            DisplayMenu();

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                // Console.WriteLine(">>> [Invalid Input] Please choose between 1, 2, 3, and 0.");
                // Console.ReadKey();
                continue;
            }

            if (validChoices.Contains(choice))
            {
                return choice;
            } 
        }
    }
    static void Main(string[] args)
    {
        DataBucket myDataBucket = new();

        bool isRunning = true;
        
        while (isRunning)
        {
            int choice = GetSelection();
            switch (choice)
            {
                case 1:
                    myDataBucket.Empty();
                    CollectNumbers(myDataBucket);
                    break;
                case 2:
                    PrintSummary(myDataBucket);
                    break;
                case 3:
                    myDataBucket.Empty();
                    break;
                case 0:
                    isRunning = false;
                    break;
            }
        }
    }
}
