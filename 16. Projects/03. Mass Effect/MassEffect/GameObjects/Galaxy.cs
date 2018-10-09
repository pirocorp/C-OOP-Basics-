namespace MassEffect.GameObjects
{
    using System.Collections.Generic;
    using System.Linq;
    
    using Exceptions;
    using Locations;
    using Interfaces;

    public class Galaxy
    {
        public HashSet<StarSystem> StarSystems { get; set; }

        public Galaxy()
        {
            this.StarSystems = new HashSet<StarSystem>();
        }

        public StarSystem GetStarSystemByName(string name)
        {
            return this.StarSystems
                .First(s => s.Name == name);
        }

        public void TravelTo(IStarship ship, StarSystem destination)
        {
            var startLocation = ship.Location;
            if (!startLocation.NeighbourStarSystems.ContainsKey(destination))
            {
                throw new LocationOutOfRangeException(
                    $"Cannot travel directly from {startLocation.Name} to {destination.Name}");
            }

            var requiredFuel = startLocation.NeighbourStarSystems[destination];
            if (ship.Fuel < requiredFuel)
            {
                throw new InsufficientFuelException(
                    $"Not enough fuel to travel to {destination.Name} - {ship.Fuel}/{requiredFuel}");
            }

            ship.Fuel -= requiredFuel;
            ship.Location = destination;
        }
    }
}
