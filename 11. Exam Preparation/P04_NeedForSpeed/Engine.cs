using System;

public class Engine
{
    public void Run()
    {
        var carManager = new CarManager();
        var inputLine = string.Empty;

        while ((inputLine = Console.ReadLine()) != "Cops Are Here")
        {
            var tokens = inputLine.Split();

            var command = tokens[0];

            switch (command)
            {
                case "register":
                    var id = int.Parse(tokens[1]);
                    var type = tokens[2];
                    var brand = tokens[3];
                    var model = tokens[4];
                    var year = int.Parse(tokens[5]);
                    var horsePower = int.Parse(tokens[6]);
                    var acceleration = int.Parse(tokens[7]);
                    var suspension = int.Parse(tokens[8]);
                    var durability = int.Parse(tokens[9]);
                    carManager.Register(id, type, brand, model, year, horsePower, acceleration, suspension, durability);
                    break;
                case "check":
                    id = int.Parse(tokens[1]);
                    var result = carManager.Check(id);
                    Console.WriteLine(result);
                    break;
                case "open":
                    id = int.Parse(tokens[1]);
                    type = tokens[2];
                    var length = int.Parse(tokens[3]);
                    var route = tokens[4];
                    var prizePool = int.Parse(tokens[5]);

                    if (type == "Circuit" || type == "TimeLimit")
                    {
                        var aditionalParameter = int.Parse(tokens[6]);
                        carManager.Open(id, type, length, route, prizePool, aditionalParameter);
                    }
                    else
                    {
                        carManager.Open(id, type, length, route, prizePool);
                    }

                    break;
                case "participate":
                    var carId = int.Parse(tokens[1]);
                    var raceId = int.Parse(tokens[2]);
                    carManager.Participate(carId, raceId);
                    break;
                case "start":
                    raceId = int.Parse(tokens[1]);

                    result = carManager.Start(raceId);

                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        Console.WriteLine(result);
                    }

                    break;
                case "park":
                    carId = int.Parse(tokens[1]);
                    carManager.Park(carId);
                    break;
                case "unpark":
                    carId = int.Parse(tokens[1]);
                    carManager.Unpark(carId);
                    break;
                case "tune":
                    var tuneIndex = int.Parse(tokens[1]);
                    var addOn = tokens[2];
                    carManager.Tune(tuneIndex, addOn);
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}