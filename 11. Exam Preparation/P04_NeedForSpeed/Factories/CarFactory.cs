using System;

public class CarFactory
{
    public Car CreateCar(string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        Car newCar = null;

        switch (type)
        {
            case "Performance":
                newCar = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                break;
            case "Show":
                newCar = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                break;
            default:
                throw new NotSupportedException();
        }

        return newCar;
    }
}