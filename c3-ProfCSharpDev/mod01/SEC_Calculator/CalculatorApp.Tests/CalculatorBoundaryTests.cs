using Xunit;
using CalculatorApp.Core;
using System;

namespace CalculatorApp.Tests;

public class CalculatorBoundaryTests
{
    private readonly CalculatorEngine _calc = new();

    // 1. ZERO AS OPERAND
    [Theory]
    [InlineData(0, 5, 5)]   // Addition with zero
    [InlineData(5, 0, 5)]   // Subtraction with zero
    [InlineData(10, 0, 0)]  // Multiplication by zero
    [InlineData(0, 10, 0)]  // Division of zero
    public void Operations_WithZero_ReturnExpectedResults(double a, double b, double expected)
    {
        // Act is performed within specific methods based on the scenario
        double result = 0;
        if (expected == a + b) result = _calc.Add(a, b);
        else if (expected == a - b) result = _calc.Subtract(a, b);
        else if (expected == a * b) result = _calc.Multiply(a, b);
        else result = _calc.Divide(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    // 2. LARGE NUMBERS (APPROACHING SYSTEM LIMITS)
    [Fact]
    public void Multiply_LargeNumbers_HandlesPrecision()
    {
        // ARRANGE: Large numbers that don't quite hit Infinity yet
        double a = 1e150;
        double b = 2;
        double expected = 2e150;

        // ACT
        double result = _calc.Multiply(a, b);

        // ASSERT
        Assert.Equal(expected, result);
    }

    // 3. SMALL DECIMAL NUMBERS (PRECISION LIMITS)
    [Fact]
    public void Add_VerySmallNumbers_MaintainsPrecision()
    {
        // ARRANGE: Common in fractional share calculations
        double a = 0.0000000001;
        double b = 0.0000000002;
        double expected = 0.0000000003;

        // ACT
        double result = _calc.Add(a, b);

        // ASSERT: Using precision to account for floating-point noise
        Assert.Equal(expected, result, precision: 10);
    }

    // 4. POWER OPERATION BOUNDARIES
    [Theory]
    [InlineData(5, 0, 1)]    // x^0 = 1
    [InlineData(0, 5, 0)]    // 0^x = 0
    [InlineData(-2, 3, -8)]  // Negative base, odd exponent
    [InlineData(-2, 4, 16)]  // Negative base, even exponent
    public void Power_BoundaryConditions_ReturnMathematicalTruths(double baseNum, double exp, double expected)
    {
        // ACT
        double result = _calc.Power(baseNum, exp);

        // ASSERT
        Assert.Equal(expected, result);
    }

    // 5. SQUARE ROOT BOUNDARIES
    [Theory]
    [InlineData(0, 0)]               // Sqrt(0)
    [InlineData(0.00000001, 0.0001)] // Sqrt of very small positive
    public void SquareRoot_EdgeCases_ReturnCorrectResults(double input, double expected)
    {
        // ACT
        double result = _calc.SquareRoot(input);

        // ASSERT
        Assert.Equal(expected, result, precision: 8);
    }
}