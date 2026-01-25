using System;

namespace CalculatorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DisplayHeader();

            // Use a helper method to handle repeated logic
            double num1 = RequestDouble("Enter your first number: ");
            double num2 = RequestDouble("Enter your second number: ");

            Console.WriteLine($"\nYou entered: {num1} and {num2}");

            DisplayMenu();
            int choice = RequestInt("Enter your choice (1-5): ", 1, 5);

            double result = PerformCalculation(num1, num2, choice);

            Console.WriteLine($"\n---------------------------");
            Console.WriteLine($"Result: {result}");
            Console.WriteLine("---------------------------");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        private static void DisplayHeader()
        {
            Console.WriteLine("Welcome to Your Personal Calculator!");
            Console.WriteLine("===================================\n");
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\nChoose an operation:");
            Console.WriteLine("1. Addition (+)\n2. Subtraction (-)\n3. Multiplication (*)\n4. Division (/)\n5. Modulus (%)");
        }

        /// <summary>
        /// Continues to prompt the user until a valid double is entered.
        /// </summary>
        private static double RequestDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double value))
                    return value;

                Console.WriteLine("Invalid input. Please enter a valid numeric value.");
            }
        }

        /// <summary>
        /// Prompts for an integer within a specific range.
        /// </summary>
        private static int RequestInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                    return value;

                Console.WriteLine($"Please enter a number between {min} and {max}.");
            }
        }

        private static double PerformCalculation(double a, double b, int operation)
        {
            return operation switch
            {
                1 => a + b,
                2 => a - b,
                3 => a * b,
                4 => b != 0 ? a / b : double.NaN, // Added safety for Division by Zero
                5 => a % b,
                _ => throw new ArgumentOutOfRangeException(nameof(operation), "Unexpected operation index.")
            };
        }
    }
}