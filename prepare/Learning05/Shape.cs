using System;
using System.Collections.Generic;

// Base class for all shapes
public class Shape
{
    private string _color;

    // Constructor
    public Shape(string color)
    {
        _color = color;
    }

    // Getter for color
    public string GetColor()
    {
        return _color;
    }

    // Setter for color
    public void SetColor(string color)
    {
        _color = color;
    }

    // Virtual method to compute area
    public virtual double GetArea()
    {
        // Base implementation returns 0
        return 0;
    }
}