namespace EnvironmentSystem.Core
{
    using System;
    using Interfaces;

    public class KeyboardController : IController
    {
        public event EventHandler Pause;

        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                var keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.Spacebar)
                {
                    this.Pause?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}