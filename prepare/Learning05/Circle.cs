// Derived class for Circle
public class Circle : Shape
{
    private double _radius;

    // Constructor
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Override method to compute area
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}
