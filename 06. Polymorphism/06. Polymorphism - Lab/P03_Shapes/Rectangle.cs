public class Rectangle : Shape
{
    private double height;
    private double width;

    public Rectangle(int height, int width)
    {
        this.Height = height;
        this.Width = width;
    }

    public double Height
    {
        get => this.height;
        private set => this.height = value;
    }

    public double Width
    {
        get => this.width;
        private set => this.width = value;
    }

    public override double CalculatePerimeter()
    {
        var result = 2 * this.Height + 2 * this.Width;
        return result;
    }

    public override double CalculateArea()
    {
        var result = Height * Width;
        return result;
    }

    public override string Draw()
    {
        return $"{base.Draw()} {this.GetType().Name}";
    }
}