namespace Debugging;

class Program
{
    static double Add(double a, double b)
    {
        return a + b;    
    }

    static double PromptForDouble(string message)
    {
        Write(message);
        return double.TryParse(ReadLine(), out var result) 
            ? result 
            : Retry(message);

        static double Retry(string msg)
        {
            WriteLine("Invalid input. Please enter a valid decimal number.");
            return PromptForDouble(msg);
        }
    }

    static void Main(string[] args)
    {
        double a = PromptForDouble("Enter first number: ");
        double b = PromptForDouble("Enter second number: ");
        double answer = Add(a, b);

        WriteLine($"{a} + {b} = {answer}");
        WriteLine("Press enter to end the app.");
        ReadLine();
    }
}
