using System;
using System.Text;

public class Book
{
    private string title;
    private string author;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public string Title
    {
        get => this.title;
        protected set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException($"{nameof(Title)} not valid!");
            }

            this.title = value;
        }
    }

    public string Author
    {
        get => this.author;
        protected set
        {
            var names = value.Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries);

            if (names.Length == 2 && char.IsDigit(names[1][0]))
            {
                throw new ArgumentException($"{nameof(Author)} not valid!");
            }

            this.author = value;
        }
    }

    public virtual decimal Price
    {
        get => this.price;
        protected set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Price)} not valid!");
            }

            this.price = value;
        }
    }

    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.Author}")
            .AppendLine($"Price: {this.Price:F2}");

        var result = resultBuilder.ToString().TrimEnd();
        return result;
    }
}