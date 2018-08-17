using System;
using System.Collections.Generic;

public class CarManager
{
    private Dictionary<int, Car> registeredCars;
    private Dictionary<int, Car> parkedCars;
    private Dictionary<int, Race> openRaces;
    private CarFactory carFactory;
    private RaceFactory raceFactory;

    public CarManager()
    {
        this.registeredCars = new Dictionary<int, Car>();
        this.parkedCars = new Dictionary<int, Car>();
        this.openRaces = new Dictionary<int, Race>();
        this.carFactory = new CarFactory();
        this.raceFactory = new RaceFactory();
    }

    public void Register(int id, string type, string brand, string model, 
        int yearOfProduction, int horsepower,int acceleration, 
        int suspension, int durability)
    {
        var newCar = this.carFactory.CreateCar(type, brand, model, yearOfProduction, 
            horsepower, acceleration, suspension, durability);

        this.registeredCars[id] = newCar;
    }

    public string Check(int id)
    {
        var result = string.Empty;

        if (this.registeredCars.ContainsKey(id))
        {
            result = this.registeredCars[id].ToString();
        }

        if (this.parkedCars.ContainsKey(id))
        {
            result = this.parkedCars[id].ToString();
        }

        return result;
    }

    public void Open(int id, string type, int length, string route, int prizePool, params int[] aditionalParameter)
    {
        var newRace = this.raceFactory.CreaterRace(type, length, route, prizePool, aditionalParameter);

        this.openRaces[id] = newRace;
    }

    public void Participate(int carId, int raceId)
    {
        if (this.registeredCars.ContainsKey(carId))
        {
            var currentCar = this.registeredCars[carId];

            if (this.openRaces.ContainsKey(raceId))
            {
                var currentRace = this.openRaces[raceId];

                try
                {
                    currentRace.AddParticipant(currentCar);
                }
                catch (ArgumentException)
                {

                }
            }
        }
    }

    public string Start(int id)
    {
        var currentRace = this.openRaces[id];

        if (currentRace.Participants.Count > 0)
        {
            var result = currentRace.RaceResult();
            this.openRaces.Remove(id);
            return result;
        }

        return "Cannot start the race with zero participants.";
    }

    public void Park(int id)
    {
        if (this.registeredCars.ContainsKey(id))
        {
            var currentCar = this.registeredCars[id];

            if (!currentCar.InRace)
            {
                this.registeredCars.Remove(id);
                this.parkedCars.Add(id, currentCar);
            }
        }
    }

    public void Unpark(int id)
    {
        if (this.parkedCars.ContainsKey(id))
        {
            var currentCar = this.parkedCars[id];
            this.parkedCars.Remove(id);
            this.registeredCars.Add(id, currentCar);
        }
    }

    public void Tune(int tuneIndex, string addOn)
    {
        if (this.parkedCars.Count > 0)
        {
            foreach (var car in this.parkedCars.Values)
            {
                car.Tune(tuneIndex, addOn);
            }
        }
    }
}