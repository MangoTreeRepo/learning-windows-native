namespace Shape;

class Program
{
    static void Main(string[] args)
    {
        // Shape newShape = new Shape
        // {
        //     Name = "Rectangle",
        //     Color = "Blue"
        // };

        Shape newShape = new();

        Console.WriteLine("\n--- Shape: Default Behavior ---");
        newShape.DisplayInfo();
        Console.WriteLine($"CalculateArea: {newShape.CalculateArea():F2}");
        
        Circle newCircle = new();

        Console.WriteLine("\n--- Circle: Default Behavior ---");
        newCircle.DisplayInfo();
        Console.WriteLine($"CalculateArea: {newCircle.CalculateArea():F2}");

        Console.WriteLine("\n--- Circle ---");
        newCircle.Name = "New Circle";
        newCircle.Color = "Blue";
        newCircle.Radius = 5.0;
        newCircle.DisplayInfo();

        Console.WriteLine("\n--- Testing Polymorphism ---");
        List<Shape> shapes = [];
        shapes.Add(newShape);
        shapes.Add(newCircle);

        foreach (var shape in shapes)
        {
            shape.DisplayInfo();
            Console.WriteLine();
        }
    }
}
