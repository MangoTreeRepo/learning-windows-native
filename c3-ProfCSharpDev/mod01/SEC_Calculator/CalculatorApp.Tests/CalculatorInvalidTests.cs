using Xunit;
using CalculatorApp.Core;
using System;

namespace CalculatorApp.Tests;

public class CalculatorInvalidTests
{
    private readonly CalculatorEngine _calc = new();

    // 1. DIVISION BY ZERO
    [Theory]
    [InlineData(100.0)]
    [InlineData(-50.5)]
    [InlineData(0.0)]
    public void Divide_ByZero_ThrowsDivideByZeroException(double dividend)
    {
        // ACT & ASSERT
        var exception = Assert.Throws<DivideByZeroException>(() => 
            _calc.Divide(dividend, 0));

        Assert.Equal("Cannot divide by zero", exception.Message);
    }

    // 2. SQUARE ROOT OF NEGATIVES
    [Fact]
    public void SquareRoot_NegativeNumber_ThrowsArgumentException()
    {
        // ACT & ASSERT
        var exception = Assert.Throws<ArgumentException>(() => 
            _calc.SquareRoot(-1.0));

        Assert.Contains("negative number", exception.Message);
    }

    // 3. INVALID POWER OPERATIONS
    [Theory]
    [InlineData(0, -1, "negative power")]             // 0 raised to negative power
    [InlineData(-4, 0.5, "fractional power")]         // Negative base, fractional exponent
    public void Power_InvalidInputs_ThrowsArgumentException(double baseNum, double exp, string expectedPart)
    {
        // ACT & ASSERT
        var exception = Assert.Throws<ArgumentException>(() => 
            _calc.Power(baseNum, exp));

        Assert.Contains(expectedPart, exception.Message);
    }

    // 4. INFINITY AND NaN GUARDS
    [Theory]
    [InlineData(double.PositiveInfinity, 1.0)]
    [InlineData(1.0, double.NaN)]
    public void Operations_WithInfinityOrNaN_ThrowsArgumentException(double a, double b)
    {
        // Testing one representative operation (Add) as the guards are shared
        Assert.Throws<ArgumentException>(() => _calc.Add(a, b));
        Assert.Throws<ArgumentException>(() => _calc.Multiply(a, b));
    }
}