namespace ShapeInterface;

using System;
public abstract class Shape : IDrawable
{
    public string Color { get; set; }
    public string Name { get; protected set; }

    protected Shape(string name)
    {
        Name = name;
        Color = "Black" ;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}\nColor: {Color}");
    }

    public abstract double CalculateArea();

    public virtual void Draw()
    {
        DisplayInfo();
        Console.WriteLine($"Drawing {Name}");
    }
}