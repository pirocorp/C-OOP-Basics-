namespace _04._Hotel_Reservation
{
    using System;

    public class HotelReservation
    {
        public static void Main()
        {
            var priceCalc = PriceCalculator.Parse(Console.ReadLine());
            Console.WriteLine(priceCalc.Calculate());
        }
    }
}