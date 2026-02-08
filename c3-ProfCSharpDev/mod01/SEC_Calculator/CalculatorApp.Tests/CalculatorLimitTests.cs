using Xunit;
using CalculatorApp.Core;
using System;

namespace CalculatorApp.Tests;

public class CalculatorLimitTests
{
    private readonly CalculatorEngine _calc = new();

    // 1. ADDITION OVERFLOW
    [Fact]
    public void Add_NumbersNearMaxValue_ThrowsOverflowException()
    {
        // ARRANGE: MaxValue is approx 1.79e308
        double a = double.MaxValue;
        double b = double.MaxValue;

        // ACT & ASSERT
        var exception = Assert.Throws<OverflowException>(() => _calc.Add(a, b));
        Assert.Contains("exceeds maximum value", exception.Message);
    }

    // 2. MULTIPLY OVERFLOW (The most common risk)
    [Fact]
    public void Multiply_LargeNumbers_ThrowsOverflowException()
    {
        // ARRANGE
        double a = 1e200;
        double b = 1e150; // Result would be 1e350, which is > 1.79e308

        // ACT & ASSERT
        Assert.Throws<OverflowException>(() => _calc.Multiply(a, b));
    }

    // 3. POWER OPERATION LIMITS
    [Theory]
    [InlineData(10, 310)]  // 10^310 is way beyond double.MaxValue
    [InlineData(2, 1024)]  // 2^1024 is the limit for double
    public void Power_LargeExponents_ThrowsOverflowException(double baseNum, double exp)
    {
        // ACT & ASSERT
        Assert.Throws<OverflowException>(() => _calc.Power(baseNum, exp));
    }

    // 4. PRECISION UNDERFLOW (Numbers too small to represent)
    [Fact]
    public void Multiply_VerySmallNumbers_UnderflowsToZero()
    {
        // ARRANGE: double.Epsilon is the smallest positive value (~5e-324)
        double a = 1e-200;
        double b = 1e-200; 
        
        // ACT
        // In IEEE 754, if a result is too small, it becomes 0 (underflow)
        // Your code doesn't throw for underflow, it returns the math result.
        var result = _calc.Multiply(a, b);

        // ASSERT
        Assert.Equal(0, result);
    }

    // 5. COMPOUND OPERATIONS (Chained Overflows)
    [Fact]
    public void ChainedOperations_ThatEventuallyOverflow_ThrowsException()
    {
        // ARRANGE: A sequence of operations that individually pass but collectively fail
        double initial = 1e200;
        
        // ACT & ASSERT
        var step1 = _calc.Multiply(initial, 1e50); // Result: 1e250 (Safe)
        
        // This next step should trigger the guard
        Assert.Throws<OverflowException>(() => _calc.Multiply(step1, 1e100));
    }
}