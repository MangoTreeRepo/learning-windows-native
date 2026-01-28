namespace LabNumberGuess;

using System;

public class Program
{
    // 1. Define Constants to avoid "Magic Numbers"
    private const int SecretNumber = 6;
    private const int MaxAttempts = 3;
    private const int MinRange = 1;
    private const int MaxRange = 10;

    public static void Main(string[] args)
    {
        DisplayHeader();
        RunGameLoop();
    }

    private static void DisplayHeader()
    {
        Console.WriteLine("========================================");
        Console.WriteLine($" Guess the Secret Number ({MinRange}-{MaxRange})!");
        Console.WriteLine($" You have {MaxAttempts} attempts.");
        Console.WriteLine("========================================\n");
    }

    private static void RunGameLoop()
    {
        for (int attempt = 1; attempt <= MaxAttempts; attempt++)
        {
            Console.Write($"Attempt {attempt}/{MaxAttempts}: ");
            
            if (!int.TryParse(Console.ReadLine(), out int guess))
            {
                Console.WriteLine(">>> [Invalid Input] Please enter a numeric value.");
                attempt--; // Optional: Don't penalize the user for a typo
                continue;
            }

            if (guess == SecretNumber)
            {
                Console.WriteLine($"\nSUCCESS: You found {SecretNumber} in {attempt} attempts!");
                return; // Exit the method immediately
            }

            // 2. Use ternary operators and clean feedback
            string hint = guess < SecretNumber ? "Too LOW" : "Too HIGH";
            bool isLastAttempt = (attempt == MaxAttempts);

            Console.WriteLine(isLastAttempt 
                ? $"\nGAME OVER: The secret number was {SecretNumber}." 
                : $"> {hint}. Try again.");
        }
    }
}
