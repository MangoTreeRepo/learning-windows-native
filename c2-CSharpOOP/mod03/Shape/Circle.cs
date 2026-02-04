namespace Shape;

public class Circle : Shape 
{
    public double Radius { get; set; }

    public Circle() : base()
    {
        Radius = 1.0;
    }

    public override double CalculateArea()
    {
        return Math.Round(Math.PI * Radius * Radius, 2);
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Radius: {Radius}");
        Console.WriteLine($"Area: {CalculateArea()}");
    }
}
