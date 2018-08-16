using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

public class RaceTower
{
    private IList<Driver> racingDrivers;
    private Stack<Driver> faileDrivers;
    private Track track;
    private DriverFactory driverFactory;
    private TyreFactory tyreFactory;

    public RaceTower()
    {
        this.driverFactory = new DriverFactory();
        this.tyreFactory = new TyreFactory();
        this.racingDrivers = new List<Driver>();
        this.faileDrivers = new Stack<Driver>();
    }

    public Track Track => this.track;

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.track = new Track(lapsNumber, trackLength);
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            var driverType = commandArgs[0];
            var driverName = commandArgs[1];

            var horsePower = int.Parse(commandArgs[2]);
            var fuelAmount = double.Parse(commandArgs[3]);

            var tyreArgs = commandArgs.Skip(4).ToArray();
            var tyre = this.tyreFactory.CreateTyre(tyreArgs);

            var car = new Car(horsePower, fuelAmount, tyre);

            var driver = driverFactory.CreateDriver(driverType, driverName, car);
            this.racingDrivers.Add(driver);
        }
        catch
        {
        }
    }
        
    public void DriverBoxes(List<string> commandArgs)
    {
        var reasonToBox = commandArgs[0];
        var driverName = commandArgs[1];

        var currentDriver = this.racingDrivers.FirstOrDefault(x => x.Name == driverName);
        var methodArgs = commandArgs.Skip(2).ToArray();

        if (reasonToBox == "Refuel")
        {
            currentDriver.Refuel(methodArgs);
        }
        else if (reasonToBox == "ChangeTyres")
        {
            var currentTyre = this.tyreFactory.CreateTyre(methodArgs);
            currentDriver.ChangeTyres(currentTyre);
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        var numberOfLaps = int.Parse(commandArgs[0]);

        if (numberOfLaps > this.track.LapsNumber - this.track.CurrentLap)
        {
            return $"There is no time! On lap {this.track.CurrentLap}.";
        }

        var sb = new StringBuilder();

        for (var lap = 0; lap < numberOfLaps; lap++)
        {
            for (var index = 0; index < this.racingDrivers.Count; index++)
            {
                var racingDriver = this.racingDrivers[index];

                try
                {
                    racingDriver.CompleteLap(this.track.TrackLength);
                }
                catch (ArgumentException e)
                {
                    racingDriver.Fail(e.Message);
                    this.faileDrivers.Push(racingDriver);
                    this.racingDrivers.RemoveAt(index);
                    index--;
                }
            }

            this.track.CurrentLap++;

            //Overtaking
            var orderedDrivers = this.racingDrivers
                .OrderByDescending(x => x.TotalTime)
                .ToList();

            for (var index = 0; index < orderedDrivers.Count - 1; index++)
            {
                var currentDriver = orderedDrivers[index];
                var targetDriver = orderedDrivers[index + 1];

                var isOvertaken = this.TryOvertake(currentDriver, targetDriver);

                if (isOvertaken)
                {
                    index++;
                    sb.AppendLine(
                        $"{currentDriver.Name} has overtaken {targetDriver.Name} on lap {this.track.CurrentLap}.");
                }
                else
                {
                    if (!currentDriver.IsRacing)
                    {
                        this.faileDrivers.Push(currentDriver);
                        orderedDrivers.RemoveAt(index); //If no remove
                        this.racingDrivers.Remove(currentDriver);
                        index--; //If no remove
                    }
                }
            }
        }

        if (this.track.CurrentLap == this.track.LapsNumber)
        {
            var winner = this.racingDrivers.OrderBy(x => x.TotalTime).First();

            sb.AppendLine($"{winner.Name} wins the race for {winner.TotalTime:F3} seconds.");
        }

        return sb.ToString().TrimEnd();
    }

    private bool TryOvertake(Driver currentDriver, Driver targetDriver)
    {
        var timeDiferential = currentDriver.TotalTime - targetDriver.TotalTime;

        var success = false;

        var aggressiveDriver = currentDriver is AggressiveDriver &&
                               currentDriver.Car.Tyre is UltrasoftTyre;

        var foggyWeather = this.track.Weather == Weather.Foggy;

        var aggressiveDriverCrash = aggressiveDriver && foggyWeather;

        var enduranceDriver = currentDriver is EnduranceDriver &&
                              currentDriver.Car.Tyre is HardTyre;

        var rainyWeather = this.track.Weather == Weather.Rainy;

        var enduranceDriverCrash = enduranceDriver && rainyWeather;

        var crash = aggressiveDriverCrash || enduranceDriverCrash;

        if ((aggressiveDriver || enduranceDriver) && timeDiferential <= 3)
        {
            if (crash)
            {
                currentDriver.Fail("Crashed");
            }
            else
            {
                success = true;
                currentDriver.TotalTime -= 3;
                targetDriver.TotalTime += 3;
            }
        }
        else if (timeDiferential <= 2)
        {
            success = true;
            currentDriver.TotalTime -= 2;
            targetDriver.TotalTime += 2;
        }

        return success;
    }

    public string GetLeaderboard()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Lap {this.track.CurrentLap}/{this.track.LapsNumber}");

        var leaderboardDrivers = this.racingDrivers
            .OrderBy(d => d.TotalTime)
            .Concat(this.faileDrivers);

        var counter = 1;

        foreach (var driver in leaderboardDrivers)
        {
            sb.AppendLine($"{counter++} {driver}");
        }

        var result = sb.ToString().TrimEnd();
        return result;
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        var wetherType = commandArgs[0];

        if (Enum.TryParse<Weather>(wetherType, out var weather))
        {
            this.track.Weather = weather;
        }
        else
        {
            throw new ArgumentException("Invalid Weather Type");
        }
    }
}