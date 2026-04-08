namespace CalculatorLibUnitTests;

using CalculatorLib;

public class UnitTest1
{
    [Fact]
    public void TestAddingTwoNumbers()
    {
        // Arrange: Setup the inputs and the unit under test.
        double a = 2;
        double b = 3;
        double expected = 5;
        Calculator calc = new();

        // Act: Execute the function to test.
        double actual = calc.Add(a, b);

        // Assert: Make assertions to compare expected to actual results.
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(2, 2, 4)] // Arrange: Setup the inputs
    [InlineData(2, 3, 5)]
    [InlineData(0, 1, 1)]
    public void TestAdding(double a, double b, double expected)
    {
        // Arrange: Setup the unit under test
        Calculator calc = new();

        // Act: Execute the function to test
        double actual = calc.Add(a, b);

        // Assert: Make assertions to compare expected to actual result
        Assert.Equal(expected, actual);
    }
}
