using System;

public class GoldenEditionBook : Book
{
    private const decimal PRICE_INCREASE_MULTYPLAYER = 1.3M;

    public GoldenEditionBook(string author, string title, decimal price)
        : base(author, title, price)
    {
    }

    public override decimal Price => base.Price * PRICE_INCREASE_MULTYPLAYER;
};