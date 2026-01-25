using System;

namespace SimpleCalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("================================================================");
            Console.WriteLine("                Financial Calculator v1.0                       ");
            Console.WriteLine("================================================================");
            Console.WriteLine("This calculator performs basic arithmetic operations            ");
            Console.WriteLine("and demonstrates operator precedence for financial calculations.");

            Console.WriteLine("Enter first amount: $");
            decimal firstAmount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter second amount: $");
            decimal secondAmount = Convert.ToDecimal(Console.ReadLine());

            if (firstAmount >= 0 && secondAmount >= 0)
            {
                // Console.WriteLine($"${firstAmount:F2} + ${secondAmount:F2} = {(firstAmount + secondAmount):F2}");
                // Console.WriteLine($"${firstAmount:F2} - ${secondAmount:F2} = {(firstAmount - secondAmount):F2}");
                // Console.WriteLine($"${firstAmount:F2} / ${secondAmount:F2} = {(firstAmount / secondAmount):F2}");
                // Console.WriteLine($"${firstAmount:F2} % ${secondAmount:F2} = {(firstAmount % secondAmount):F2}");

                Console.WriteLine("{0:F2} + {1:F2} = {2:F2}", firstAmount, secondAmount, firstAmount + secondAmount);
                Console.WriteLine("{0:F2} - {1:F2} = {2:F2}", firstAmount, secondAmount, firstAmount - secondAmount);
                Console.WriteLine("{0:F2} / {1:F2} = {2:F2}", firstAmount, secondAmount, firstAmount / secondAmount);
                Console.WriteLine("{0:F2} % {1:F2} = {2:F2}", firstAmount, secondAmount, firstAmount % secondAmount);

                Console.WriteLine
                (
                    "Addition result ({0:F2})> Subtraction result ({1:F2}): {2}", 
                    firstAmount + secondAmount, firstAmount - secondAmount,
                    (firstAmount + secondAmount) > (firstAmount - secondAmount)
                );

                Console.WriteLine
                (
                    "First amount ({0:F2}) > Second amount ({1:F2}): {2}",
                    firstAmount, secondAmount, firstAmount > secondAmount
                );

                Console.WriteLine
                (
                    "Multiplication result ({0:F2} * {1:F2}) > 1000: {2}",
                    firstAmount, secondAmount, firstAmount * secondAmount > 1000
                );
            }
            else
            {
                Console.WriteLine("Invalid inputs: {0} and {1}", firstAmount, secondAmount);
            }
            
        }
    }
}