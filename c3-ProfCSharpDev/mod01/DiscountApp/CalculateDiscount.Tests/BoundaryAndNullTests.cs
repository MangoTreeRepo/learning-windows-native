using Xunit;
using CalculateDiscount;

namespace CalculateDiscount.Tests;

public class BoundaryAndNullTests
{
    // We use a private field to hold the calculator for this file
    private readonly DiscountCalculator _calculator = new();

    [Theory]
    [InlineData("GOLD", 0)]           // Edge: Zero
    [InlineData("GOLD", 1000000000)] // Edge: Large Amount
    public void CalculateDiscount_BoundaryAmounts_ReturnsExpectedValues(string level, decimal amount)
    {
        // ACT
        decimal expected = amount * 0.15m;
        var result = _calculator.CalculateDiscount(level, amount);

        // ASSERT
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CalculateDiscount_NullLoyaltyLevel_ReturnsZeroNoCrash()
    {
        // ACT
        var result = _calculator.CalculateDiscount(null!, 100m);

        // ASSERT
        Assert.Equal(0m, result);
    }

    [Theory]
    [InlineData("gold")]
    [InlineData("Gold")]
    [InlineData("GoLd")]
    public void CalculateDiscount_CaseInsensitivity_ReturnsCorrectDiscount(string level)
    {
        // ACT
        var result = _calculator.CalculateDiscount(level, 100m);

        // ASSERT
        Assert.Equal(15m, result);
    }
}