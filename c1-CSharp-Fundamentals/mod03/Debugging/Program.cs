// Method to divide two numbers
using System;

namespace Debugging
{
    public class Program
    {
        public static double DivideNumbers(double numerator, double denominator)
        {
            return denominator != 0 ? numerator / denominator : double.NaN;
        }

        public static double CalculateAverage(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                Console.WriteLine("Cannot calculate the average of an empty array.");
                return double.NaN;
            }

            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum / numbers.Length;
        }

        public static double ApplyDiscount(double price, double discountPercentage)
        {
            return price * (1 - discountPercentage / 100.0);
        }

        public static int FindMax(int[] numbers)
        {
            int max = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }
            return max;
        }
        public static void Main()
        {
            // Attempt to divide 10 by 0
            double result = DivideNumbers(10, 0);
            Console.WriteLine("The result is: " + result);

            int[] numbers = {}; // Empty array
            double average = CalculateAverage(numbers);
            Console.WriteLine("The average is: " + average);

            double finalPrice = ApplyDiscount(1000, 15);
            Console.WriteLine("The final price is: " + finalPrice);

            int[] myNumbers = [-5, -10, -3, -8, -2];
            int maxNumber = FindMax(myNumbers);
            Console.WriteLine("The maximum number is: " + maxNumber);
        }
    }

}