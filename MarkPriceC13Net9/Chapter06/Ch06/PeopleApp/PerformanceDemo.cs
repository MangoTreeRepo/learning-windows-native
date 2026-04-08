namespace PerformanceDemo;

public class DataProcessor
{
    public void Process()
    {
        // A collection of numbers
        int[] numbers = [10, 20, 30, 40, 50, 60, 70, 80, 90, 100];

        // We want to process only the middle part (index 3 to 6)
        // This creates a VIEW, not a COPY. Zero memory allocation!
        ReadOnlySpan<int> middleSection = numbers.AsSpan()[3..7];

        PrintSpan(middleSection);
    }

    // We use ReadOnlySpan in the parameter to guarantee we won't modify the source
    private void PrintSpan(ReadOnlySpan<int> slice)
    {
        foreach (var num in slice)
        {
            Console.WriteLine($"Processing: {num}");
        }
        
        // ❌ COMPILER ERROR: Cannot assign to an item of ReadOnlySpan
        // slice[0] = 999; 
    }
}