using System;
namespace Shape;
public class Shape
{
    public string Name { get; set; }
    public string Color { get; set; }

    public Shape()
    {
        Name = "unknown";
        Color = "unknown";
    }
    public virtual double CalculateArea() { return 0; } 
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}\nColor: {Color}");
    }
}
