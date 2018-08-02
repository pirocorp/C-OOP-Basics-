using System;

namespace P03_Telephony
{
    public class Startup
    {
        public static void Main()
        {
            var inputNumbers = Console.ReadLine();
            var inputUrls = Console.ReadLine();
            var Smarthphone = new Smartphone();
            Console.WriteLine(Smarthphone.Call(inputNumbers));
            Console.WriteLine(Smarthphone.Browse(inputUrls));
        }
    }
}
