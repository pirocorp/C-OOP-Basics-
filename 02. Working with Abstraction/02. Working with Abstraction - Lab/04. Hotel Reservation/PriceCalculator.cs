namespace _04._Hotel_Reservation
{
    using System;

    public class PriceCalculator
    {
        private decimal pricePerDay;
        private int numberOfNights;
        private SeasonMultiplayer seasonMultiplayer;
        private Discount discount;

        public PriceCalculator(decimal pricePerDay, int numberOfNights, SeasonMultiplayer seasonMultiplayer, Discount discount)
        {
            this.pricePerDay = pricePerDay;
            this.numberOfNights = numberOfNights;
            this.seasonMultiplayer = seasonMultiplayer;
            this.discount = discount;
        }

        public static PriceCalculator Parse(string inputLine)
        {
            var tokens = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            var pricePerDay = decimal.Parse(tokens[0]);
            var nights = int.Parse(tokens[1]);
            var seasonMultiplayer = Enum.Parse<SeasonMultiplayer>(tokens[2]);
            var discount = Discount.None;

            if (tokens.Length > 3)
            {
                discount = Enum.Parse<Discount>(tokens[3]);
            }

            return new PriceCalculator(pricePerDay, nights, seasonMultiplayer, discount);
        }

        public string Calculate()
        {
            var priceBeforeDiscount = pricePerDay * numberOfNights * (int) seasonMultiplayer;
            var discountRatio = (100m - (decimal) discount) / 100;
            var totalPrice = priceBeforeDiscount * discountRatio;

            return $"{totalPrice:F2}";
        }
    }
}