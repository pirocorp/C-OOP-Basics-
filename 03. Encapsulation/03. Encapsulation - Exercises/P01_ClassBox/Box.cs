using System;

public class Box
{
    private double length;
    private double width;
    private double height;

    private double Length
    {
        get => this.length;
        set
        {
            ValidateFieldNumber(value, nameof(Length));
            length = value;
        }
    }

    private double Width
    {
        get => this.width;
        set
        {
            ValidateFieldNumber(value, nameof(Width));
            width = value;
        }
    }

    private double Height
    {
        get => this.height;
        set
        {
            ValidateFieldNumber(value, nameof(Height));
            height = value;
        }
    }

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    private static void ValidateFieldNumber(double value, string name)
    {
        if (value <= 0)
        {
            throw new ArgumentException($"{name} cannot be zero or negative.");
        }
    }

    public double LateralSurfaceArea()
    {
        //Lateral Surface Area = 2lh + 2wh
        return 2 * (this.Length * this.Height) + 2 * (this.Width * this.Height);
    }

    public double SurfaceArea()
    {
        //Surface Area = 2lw + 2lh + 2wh
        return 2 * (this.Length * this.Width) + LateralSurfaceArea();
    }

    public double Volume()
    {
        //Volume = lwh
        return this.Length * this.Width * this.Height;
    }
}