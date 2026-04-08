namespace MyProject.Utilities;

public static class InputHelper
{
    /// <summary>
    /// Generic prompt that repeats until a valid number of type T is provided.
    /// </summary>
    public static T PromptFor<T>(string message) where T : INumber<T>
    {
        Console.Write(message);

        if (T.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out var result))
        {
            return result;
        }

        Console.WriteLine($"[Error] Invalid {typeof(T).Name}. Try again.");
        return PromptFor<T>(message); // Recursive call
    }
}