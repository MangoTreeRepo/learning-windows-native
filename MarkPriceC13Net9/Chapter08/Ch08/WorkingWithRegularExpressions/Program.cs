using System.Text.RegularExpressions; // To use RegEx

Write("Enter your age: ");
string input = ReadLine()!;
Regex ageChecker = MyRegex();
WriteLine(ageChecker.IsMatch(input) ? "Thank you!" : $"This is not a valid age: {input}");

partial class Program
{
    [GeneratedRegex(@"^\d+$")]
    private static partial Regex MyRegex();
}