using Xunit;
using CalculatorApp.Core; // This brings in your logic

namespace CalculatorApp.Tests;

public class CalculatorPositiveTests
{
    // We instantiate the calculator once for the class
    private readonly CalculatorEngine _calc = new();

    [Fact]
    public void Add_FinancialBalance_ReturnsCorrectSum()
    {
        // ARRANGE: Scenario - Adding two ledger entries
        double initialBalance = 150000.75;
        double deposit = -2500.50; // A withdrawal/negative entry
        double expected = 147500.25;

        // ACT
        double result = _calc.Add(initialBalance, deposit);

        // ASSERT
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Subtract_TaxDeduction_ReturnsCorrectNet()
    {
        // ARRANGE: Scenario - Calculating Net Revenue after tax
        double grossRevenue = 1000000.00;
        double taxAmount = 250500.75;
        double expected = 749499.25;

        // ACT
        double result = _calc.Subtract(grossRevenue, taxAmount);

        // ASSERT
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Multiply_QuantityAndPrice_ReturnsTotalValue()
    {
        // ARRANGE: Scenario - Buying shares of stock
        double sharePrice = 145.12;
        double quantity = 1500;
        double expected = 217680.00;

        // ACT
        double result = _calc.Multiply(sharePrice, quantity);

        // ASSERT
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Divide_PortfolioAllocation_ReturnsPreciseDecimal()
    {
        // ARRANGE: Scenario - Dividing a fund equally among 8 stakeholders
        double totalFund = 1000000.00;
        double stakeholders = 8;
        double expected = 125000.00;

        // ACT
        double result = _calc.Divide(totalFund, stakeholders);

        // ASSERT
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1.05, 10, 1.628894626777442)] // Scenario: Compound interest (5% over 10 periods)
    [InlineData(16, 0.5, 4.0)]               // Scenario: Fractional exponent (16 to the power of 1/2)
    public void Power_InterestCalculations_ReturnsCorrectValue(double baseNum, double exp, double expected)
    {
        // ARRANGE & ACT
        double result = _calc.Power(baseNum, exp);

        // ASSERT: Using precision for complex floating point math
        Assert.Equal(expected, result, precision: 10);
    }

    [Theory]
    [InlineData(144, 12)]          // Perfect Square
    [InlineData(2, 1.41421356)]   // Decimal Result (Square root of 2)
    public void SquareRoot_ValidInputs_ReturnsCorrectRoot(double input, double expected)
    {
        // ACT
        double result = _calc.SquareRoot(input);

        // ASSERT: Check result matches within 8 decimal places
        Assert.Equal(expected, result, precision: 8);
    }
}