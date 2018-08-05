public abstract class Shape
{
    public abstract double CalculatePerimeter();

    public abstract double CalculateArea();

    public virtual string Draw()
    {
        //IF I use here return $"Drawing {this.GetType().Name}" -> the result will be the same -> then i dont need to override this method
        return $"Drawing";
    }
}