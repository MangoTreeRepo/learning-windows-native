using Xunit;
using CalculateDiscount;

namespace CalculateDiscount.Tests;

public class DiscountCalculatorTests
{
    [Theory] // 1. Tells xUnit this is a parameterized test (runs multiple times with different data).
    [InlineData("GOLD", 100.0, 15.0)]   // 2. First test run: level="GOLD", amount=100.0, expected=15.0
    [InlineData("SILVER", 100.0, 10.0)] // 3. Second test run: level="SILVER", amount=100.0, expected=10.0
    [InlineData("BRONZE", 100.0, 5.0)]  // 4. Third test run: level="BRONZE", amount=100.0, expected=5.0
    public void CalculateDiscount_ValidLevels_ReturnsCorrectDiscount(string level, decimal amount, decimal expected)
    {
        // ARRANGE: Initialize the object we want to test.
        var calculator = new DiscountCalculator();

        // ACT: Call the specific method with the data from InlineData.
        var result = calculator.CalculateDiscount(level, amount);

        // ASSERT: Verify that the actual 'result' matches the 'expected' value we defined.
        Assert.Equal(expected, result);
    }

    [Theory]                            // 1. Again, a Theory allows us to test multiple "bad" inputs in one go.
    [InlineData("PLATINUM", 100.0)]     // 2. "PLATINUM" isn't in our switch case.
    [InlineData("random_text", 100.0)]  // 3. Completely invalid text.
    [InlineData(null, 100.0)]           // 4. Null input (testing your loyaltyLevel?.ToUpper() safety).
    [InlineData("  ", 100.0)]           // 5. Whitespace
    public void CalculateDiscount_InvalidLevels_ReturnsZeroDiscount(string level, decimal amount)
    {
        // ARRANGE: Setup.
        var calculator = new DiscountCalculator();

        // ACT: Run the code with the invalid level.
        var result = calculator.CalculateDiscount(level, amount);

        // ASSERT: In your code, the default case returns 0m. We verify that here.
        Assert.Equal(0m, result);
    }

    [Fact] // 1. A Fact is a test that takes no parameters and always runs the same way.
    public void CalculateDiscount_NegativeAmount_ThrowsArgumentException()
    {
        // ARRANGE: Setup the calculator and the "bad" data.
        var calculator = new DiscountCalculator();
        string level = "GOLD";
        decimal negativeAmount = -50m;

        // ACT & ASSERT: 
        // Assert.Throws takes a "Lambda Expression" (() => ...).
        // It runs the code inside the brackets and passes the test ONLY if an ArgumentException occurs.
        var exception = Assert.Throws<ArgumentException>(() => 
            calculator.CalculateDiscount(level, negativeAmount));

        // Optional Extra Step: Verify the specific error message you wrote in the code.
        Assert.Equal("Purchase amount cannot be negative", exception.Message);
    }
}