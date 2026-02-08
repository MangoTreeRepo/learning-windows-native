# How to create tests

To fix the naming collision and reference errors once and for all, we will rebuild the solution using a **Standard Industry Hierarchy**. This structure separates your "Domain Logic" from your "Tests," preventing the compiler from confusing namespaces with classes.

Follow these terminal commands exactly.

---

### 1. Clean the Slate

First, move out of your current folder to a fresh location to avoid mixing old files with the new ones.

```bash
mkdir SEC_Calculator
cd SEC_Calculator

```

### 2. Create the Solution and Projects

We will use a clear naming convention: `CalculatorApp` for the logic and `CalculatorApp.Tests` for the testing.

```bash
# 1. Create the Solution file
dotnet new sln

# 2. Create the Class Library (The "Engine")
dotnet new classlib -n CalculatorApp.Core

# 3. Create the xUnit Project (The "Validator")
dotnet new xunit -n CalculatorApp.Tests

# 4. Add projects to the Solution
dotnet sln add CalculatorApp.Core/CalculatorApp.Core.csproj
dotnet sln add CalculatorApp.Tests/CalculatorApp.Tests.csproj

```

### 3. Link the Projects

This command tells the Test project: "You are allowed to look inside the Core project."

```bash
dotnet add CalculatorApp.Tests/CalculatorApp.Tests.csproj reference CalculatorApp.Core/CalculatorApp.Core.csproj

```

---

### 4. Implementation: The Logic

Open the folder in VS Code: `code .`.
In `CalculatorApp.Core`, rename `Class1.cs` to `CalculatorEngine.cs`.

**Crucial:** Note that the **Namespace** is `CalculatorApp.Core` and the **Class** is `CalculatorEngine`. They are no longer the same name, which fixes your `CS0118` error.

```csharp
namespace CalculatorApp.Core;

public class CalculatorEngine 
{
    public double Add(double a, double b)
    {
        if (double.IsInfinity(a) || double.IsInfinity(b))
            throw new ArgumentException("Cannot perform operations with infinity values");
        // ... (rest of your logic from before)
        return a + b;
    }
    // ... Add your other methods (Subtract, Multiply, etc.) here
}

```

---

### 5. Implementation: The Test

In `CalculatorApp.Tests`, rename `UnitTest1.cs` to `CalculatorTests.cs`.

```csharp
using Xunit;
using CalculatorApp.Core; // This brings in your logic

namespace CalculatorApp.Tests;

public class CalculatorTests
{
    // We reference the class "CalculatorEngine" inside the namespace "CalculatorApp.Core"
    private readonly CalculatorEngine _calc = new();

    [Fact]
    public void Add_SimpleValues_ReturnsCorrectSum()
    {
        // Arrange
        double a = 10;
        double b = 20;

        // Act
        var result = _calc.Add(a, b);

        // Assert
        Assert.Equal(30, result);
    }
}

```

---

### 6. Verify the Build

Go back to your terminal and run:

```bash
dotnet test

```


## Unit Test 1: Test Valid Mathematical Operations

Create comprehensive positive test cases for all mathematical operations using the AAA pattern (Arrange, Act, Assert). Test basic arithmetic operations with realistic values, ensuring correct calculation results. Include test cases for:

- Addition with positive and negative numbers
- Subtraction resulting in positive and negative results
- Multiplication with various number combinations
- Division with clean results and decimal precision
- Power operations with integer and fractional exponents
- Square root operations with perfect squares and decimal results

Use realistic mathematical scenarios rather than trivial examples. Test with values you might encounter in financial applications.

**💡 Tip:** Use the `[Theory]`and `[InlineData]` attributes for testing multiple input combinations efficiently instead of writing separate test methods for each scenario.

**❗ Common Mistakes**

- Testing only trivial cases (1+1, 2*2) instead of realistic scenarios
- Not considering floating-point precision requirements for decimal results
- Forgetting to test negative numbers and mixed positive/negative operations

**File**: `CalculatorTests.cs`

## Unit Test 2: Boundary Tests

Design boundary value tests for mathematical limits and edge cases that commonly cause calculation errors.

Focus on critical boundaries:

- Zero as operand in all operations (especially division and power operations)
- Operations with very large numbers approaching system limits
- Operations with very small decimal numbers
- Boundary conditions for power operations (x^0, 0^x, negative bases)
- Square root of zero and very small positive numbers

Mathematical boundary testing often reveals precision issues and overflow conditions that don't appear with typical values.

**💡 Tip**: Test both sides of boundary conditions - values just above and just below critical limits to catch off-by-one errors.

**❗ Common Mistakes**

- Testing only obvious boundaries like zero without considering mathematical edge cases
- Not testing both sides of boundary conditions
- Ignoring floating-point precision issues that emerge at mathematical boundaries

**File**: `CalculatorBoundaryTests.cs`

## Unit Test 3: Division by Zero and Mathematical Impossibilities

Create comprehensive tests for mathematical operations that are impossible or undefined.

Test scenarios that should trigger appropriate error handling:

- Division by zero with various dividend values
- Square root of negative numbers
- Invalid power operations (negative base with fractional exponent, 0 raised to negative power)
- Operations involving infinity or NaN values

Design tests to verify that your calculator handles these conditions by throwing specific exception types with helpful messages.

**💡 Tip:** Use `Assert.Throws<SpecificExceptionType>()` to verify that the correct exception is thrown for each mathematical impossibility.

**❗ Common Mistakes**

- Only testing division by zero without considering other mathematical impossibilities
- Using generic Assert.Throws without specifying the expected exception type
- Not verifying that error messages are helpful and descriptive

**File**: `CalculatorInvalidTests.cs`


## Unit Test 4: Overflow and Boundary Limit Testing

Create tests for calculations that exceed system numerical limits or approach mathematical boundaries.

Test scenarios involving:

- Operations with very large numbers that might cause overflow
- Power operations with large exponents
- Calculations that result in numbers too small to represent accurately
- Multiple operations that compound to exceed limits

Test that your calculator handles these conditions gracefully by either throwing appropriate exceptions or returning mathematically correct results within system precision limits.

💡 Tip: Use double.MaxValue and double.MinValue constants to test system limits systematically.

❗ Common Mistakes

- Not testing overflow conditions systematically across all operations
- Assuming the system will handle large numbers automatically
- Not considering how multiple operations might compound to exceed limits

**File**: `CalculatorLimitTests.cs`