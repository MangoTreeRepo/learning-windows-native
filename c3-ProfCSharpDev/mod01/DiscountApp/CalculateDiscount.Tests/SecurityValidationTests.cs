using Xunit;
using CalculateDiscount;

namespace CalculateDiscount.Tests;

public class SecurityValidationTests
{
    private readonly DiscountCalculator _calculator = new();

    // ARRANGE
    [Theory]
    [InlineData("GOLD' OR '1'='1")]             // Classic SQL Injection
    [InlineData("GOLD'; DROP TABLE Users;--")]  // Destructive SQL Injection
    [InlineData("SELECT * FROM Rewards")]       // Statement Injection
    public void CalculateDiscount_SqlInjectionAttempts_ReturnsZeroDiscount(string injectionInput)
    {
        // ACT
        var result = _calculator.CalculateDiscount(injectionInput, 100m);

        // ASSERT
        // The security goal is that the system treats the attack as a "wrong string"
        Assert.Equal(0m, result);
    }

    [Fact]
    public void CalculateDiscount_ExtremelyLongString_HandlesWithoutCrashing()
    {
        // ARRANGE: Create a 1-million character string
        string longInput = new string('A', 1000000);
        decimal amount = 100m;

        // ACT
        var result = _calculator.CalculateDiscount(longInput, amount);

        // ASSERT
        // C# handles this safely, result should be 0 because 'AAAA...' != 'GOLD'
        Assert.Equal(0m, result);
    }

    // ARRANGE
    [Theory]
    [InlineData("<script>alert('XSS')</script>")] // Cross-Site Scripting
    [InlineData("\u0000\u0001\u0002")]            // Null bytes/Control characters
    [InlineData("../../../etc/passwd")]           // Directory Traversal
    public void CalculateDiscount_MaliciousInput_ReturnsZeroDiscount(string maliciousInput)
    {
        // ACT
        var result = _calculator.CalculateDiscount(maliciousInput, 100m);

        // ASSERT: Neutralization
        Assert.Equal(0m, result);
    }
}