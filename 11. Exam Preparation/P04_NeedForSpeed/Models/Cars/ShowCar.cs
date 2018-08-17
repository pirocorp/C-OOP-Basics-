using System;

public class ShowCar : Car
{
    private int stars;

    public ShowCar(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability) 
        : base(brand, model, yearOfProduction, horsePower, acceleration, suspension, durability)
    {
        this.stars = 0;
    }

    public override void Tune(int tuneIndex, string addOn)
    {
        base.Tune(tuneIndex, addOn);
        this.stars += tuneIndex;
    }

    public override string ToString()
    {
        return $"{base.ToString()}" + Environment.NewLine +
               $"{this.stars} *";
    }
}