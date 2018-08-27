using System;

namespace P01_GalacticGPS
{
    public class StartUp
    {
        public static void Main()
        {
            var home = new Location(18.037986, 28.870097, Planet.Earth);
            Console.WriteLine(home);
        }
    }
}
