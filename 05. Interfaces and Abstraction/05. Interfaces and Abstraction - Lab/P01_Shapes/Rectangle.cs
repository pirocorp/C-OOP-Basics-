using System;

public class Rectangle : IDrawable
{
    private int width;
    private int height;

    public Rectangle(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    public int Width
    {
        get => this.width;
        private set
        {
            Validator.ValidateInt(value, nameof(Width));
            this.width = value;
        }
    }

    public int Height
    {
        get => this.height;
        private set
        {
            Validator.ValidateInt(value, nameof(Height));
            this.height = value;
        }
    }

    public void Draw()
    {
        DrawLine(this.Width, '*', '*');

        for (var line = 1; line < this.Height - 1; line++)
        {
            DrawLine(this.Width, ' ', '*');
        }

        DrawLine(this.Width, '*', '*');
    }

    private void DrawLine(int width, char mid, char end)
    {
        Console.Write(end);

        for (var col = 0; col < width - 1; col++)
        {
            Console.Write(mid);
        }

        Console.WriteLine(end);
    }
}