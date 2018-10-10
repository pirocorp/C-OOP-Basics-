namespace EnvironmentSystem.Core
{
    using System;
    using System.Text;

    using Interfaces;
    using Models;

    public class ConsoleRenderer : IRenderer
    {
        private readonly int consoleWidth;
        private readonly int consoleHeight;

        private char[,] consoleMatrix;

        public ConsoleRenderer(int consoleWidth, int consoleHeight)
        {
            this.consoleWidth = consoleWidth;
            this.consoleHeight = consoleHeight;
            this.InitializeConsole();
        }

        public void EnqueueForRendering(IRenderable obj)
        {
            var objImage = obj.ImageProfile;

            var imageRows = objImage.GetLength(0);
            var imageCols = objImage.GetLength(1);

            var objTopLeft = obj.Bounds.TopLeft;

            var lastRow = Math.Min(objTopLeft.Y + imageRows, this.consoleHeight);
            var lastCol = Math.Min(objTopLeft.X + imageCols, this.consoleWidth);

            for (var row = objTopLeft.Y; row < lastRow; row++)
            {
                for (var col = objTopLeft.X; col < lastCol; col++)
                {
                    if (row >= 0 && row < this.consoleHeight &&
                        col >= 0 && col < this.consoleWidth)
                    {
                        this.consoleMatrix[row, col] = 
                            objImage[row - objTopLeft.Y, col - objTopLeft.X];
                    }
                }
            }
        }

        public void RenderAll()
        {
            Console.SetCursorPosition(0, 0);
            var scene = new StringBuilder();
            for (var row = 0; row < this.consoleHeight; row++)
            {
                for (var col = 0; col < this.consoleWidth; col++)
                {
                    scene.Append(this.consoleMatrix[row, col]);
                }
            }

            Console.WriteLine(scene.ToString());
        }

        public void ClearQueue()
        {
            for (var row = 0; row < this.consoleHeight; row++)
            {
                for (var col = 0; col < this.consoleWidth; col++)
                {
                    this.consoleMatrix[row, col] = ' ';
                }
            }
        }

        private void CleanConsole()
        {
            for (var row = 0; row < this.consoleHeight; row++)
            {
                for (var col = 0; col < this.consoleWidth; col++)
                {
                    this.consoleMatrix[row, col] = ' ';
                }
            }
        }

        private void InitializeConsole()
        {
            this.consoleMatrix = new char[this.consoleHeight, this.consoleWidth];

            Console.SetWindowSize(this.consoleWidth, this.consoleHeight);
            Console.SetBufferSize(this.consoleWidth, this.consoleHeight);
        }
    }
}
