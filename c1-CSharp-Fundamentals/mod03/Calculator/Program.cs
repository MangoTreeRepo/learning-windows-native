using System;
// using Calculators;
// using Display;

namespace MainProgram
{
    class Calculator
    {
        public static int Add(int num1, int num2)
        {
            return num1 + num2;
        }
    }

    class NumberDisplay
    {
        public static void DisplayNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
        }
    }

    class UserInput
    {
        public static void GreetUser()
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine() ?? "Default Value";
            Console.WriteLine($"Hello {name}!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = 2;
            int number2 = 3;
            // Calculator calculator = new();
            Console.WriteLine($"{number1} + {number2} = {Calculator.Add(number1, number2)}");

            // NumberDisplay numberDisplay = new();
            NumberDisplay.DisplayNumbers();

            UserInput.GreetUser();
        }
    }
}