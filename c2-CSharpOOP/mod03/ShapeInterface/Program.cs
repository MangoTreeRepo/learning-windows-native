namespace ShapeInterface;

class Program
{
    static void Main(string[] args)
    {
        // Test polymorphism through interface and abstract class
        Console.WriteLine("\n--- IDrawable ---");
        IDrawable drawable = new Circle(5.0) { Color = "Red" };
        drawable.Draw();

        Console.WriteLine("\n--- Shape ---");
        Shape shape = new Circle(3.0) { Color = "Blue" };
        Console.WriteLine($"Area: {shape.CalculateArea()}");
        shape.Draw();
    }
}
