// Derived class for Rectangle
public class Rectangle : Shape
{
    private double _length;
    private double _width;

    // Constructor
    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }
 
    // Override method to compute area
    public override double GetArea()
    {
        return _length * _width;
    }
}
