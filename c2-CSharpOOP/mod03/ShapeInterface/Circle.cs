namespace ShapeInterface;

public class Circle : Shape
{
    public double Radius { get; set; }
    public Circle(double radius) : base("Circle")
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.Round(Math.PI * Radius * Radius, 2);
    }

    public override void Draw()
    {
        base.Draw();
        Console.WriteLine($"Radius: {Radius} Area: {CalculateArea()}");
    }
}