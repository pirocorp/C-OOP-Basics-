using System;

public class ButtonExample
{
    private static void Button_Click(object sender, EventArgs eventArgs)
    {
        Console.WriteLine("Button_Click() event called.");
    }

    public static void Main()
    {
        Button button = new Button();
        button.Click += Button_Click;
        button.FireClick();
    }
}
