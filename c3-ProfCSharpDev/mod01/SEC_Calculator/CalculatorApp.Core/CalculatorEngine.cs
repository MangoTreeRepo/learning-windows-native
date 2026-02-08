namespace CalculatorApp.Core;

public class CalculatorEngine
{
    public double Add(double a, double b)
    {
        if (double.IsInfinity(a) || double.IsInfinity(b))
            throw new ArgumentException("Cannot perform operations with infinity values");
    
        if (double.IsNaN(a) || double.IsNaN(b))
            throw new ArgumentException("Cannot perform operations with NaN values");

        var result = a + b;

        if (double.IsInfinity(result))
            throw new OverflowException("Addition result exceeds maximum value");

        return result;
    }
    public double Subtract(double a, double b)
    {
        if (double.IsInfinity(a) || double.IsInfinity(b))
            throw new ArgumentException("Cannot perform operations with infinity values");

        if (double.IsNaN(a) || double.IsNaN(b))
            throw new ArgumentException("Cannot perform operations with NaN values");

        var result = a - b;

        if (double.IsInfinity(result))
            throw new OverflowException("Subtraction result exceeds maximum value");

        return result;
    }
    public double Multiply(double a, double b)
    {
        if (double.IsInfinity(a) || double.IsInfinity(b))
            throw new ArgumentException("Cannot perform operations with infinity values");

        if (double.IsNaN(a) || double.IsNaN(b))
            throw new ArgumentException("Cannot perform operations with NaN values");
        var result = a * b;

        if (double.IsInfinity(result))
            throw new OverflowException("Multiplication result exceeds maximum value");

        return result;
    }
    public double Divide(double dividend, double divisor)
    {
        if (double.IsInfinity(dividend) || double.IsInfinity(divisor))
            throw new ArgumentException("Cannot perform operations with infinity values");

        if (double.IsNaN(dividend) || double.IsNaN(divisor))
            throw new ArgumentException("Cannot perform operations with NaN values");

        if (divisor == 0)
            throw new DivideByZeroException("Cannot divide by zero");

        var result = dividend / divisor;

        if (double.IsInfinity(result))
            throw new OverflowException("Division result exceeds maximum value");

        return result;
    }
    public double Power(double baseNumber, double exponent)
    {
        if (double.IsInfinity(baseNumber) || double.IsInfinity(exponent))
            throw new ArgumentException("Cannot perform operations with infinity values");

        if (double.IsNaN(baseNumber) || double.IsNaN(exponent))
            throw new ArgumentException("Cannot perform operations with NaN values");

        if (baseNumber == 0 && exponent < 0)
            throw new ArgumentException("Cannot raise zero to a negative power");

        if (baseNumber < 0 && (exponent != Math.Floor(exponent)))
            throw new ArgumentException("Cannot raise negative number to fractional power");

        var result = Math.Pow(baseNumber, exponent);

        if (double.IsInfinity(result))
            throw new OverflowException("Power operation result exceeds maximum value");

        if (double.IsNaN(result))
            throw new ArgumentException("Power operation resulted in undefined value");

        return result;
    }
    public double SquareRoot(double number)
    {
        if (double.IsInfinity(number))
            throw new ArgumentException("Cannot perform operations with infinity values");

        if (double.IsNaN(number))
            throw new ArgumentException("Cannot perform operations with NaN values");

        if (number < 0)
            throw new ArgumentException("Cannot calculate square root of negative number");

        return Math.Sqrt(number);
    }
}
