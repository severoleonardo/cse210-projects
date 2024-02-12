using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating a list of shapes
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 4, 6));
        shapes.Add(new Circle("Green", 3));

        // Iterating through the list and displaying areas
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape: {shape.GetType().Name}, Color: {shape.GetColor()}, Area: {shape.GetArea()}");
        }
    }
}