using System;

public class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public double Radius
    {
        get => this.radius;
        private set => this.radius = value;
    }

    public override double CalculatePerimeter()
    {
        var result = 2 * Math.PI * this.Radius;
        return result;
    }

    public override double CalculateArea()
    {
        var result = Math.PI * this.Radius * this.Radius;
        return result;
    }

    public override string Draw()
    {
        return $"{base.Draw()} {this.GetType().Name}";
    }
}