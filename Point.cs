using System;
using System.Collections.Generic;

public interface IShape
{
    void Draw(double x, double y);
    double GetArea();
}

public class Rectangle : IShape
{
    public virtual double Width { get; set; }
    public virtual double Height { get; set; }

    public void Draw(double x, double y)
    {
        // ... drawing stuff omitted ...
    }

    public double GetArea()
    {
        return Width * Height;
    }
}

public class Square : Rectangle
{
    private double _width;
    private double _height;

    public override double Width
    {
        get => _width;
        set
        {
            _width = value;
            _height = value;
        }
    }

    public override double Height
    {
        get => _height;
        set
        {
            _width = value;
            _height = value;
        }
    }
}

public class Point: IShape
{
    public void Draw(double x, double y)
    {
        // ... drawing stuff omitted ..
    }

    public double GetArea()
    {
        throw new NotSupportedException();
    }
}

public class DrawableCollection
{
    List<IShape> _shapes = new List<IShape>();

    public DrawableCollection(params IShape[] shapes)
    {
        _shapes.AddRange(shapes);
    }

    public void DrawAllColumn()
    {
        double x = 0;
        double y = 0;

        foreach (var shape in _shapes)
        {
            shape.Draw(x, y);
            y += 10;
        }
    }
}
