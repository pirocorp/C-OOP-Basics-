namespace _03._Jedi_Galaxy
{
    using System;
    using System.Linq;

    public class JediGalaxy
    {
        static void Main()
        {
            var dimestions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimestions[0];
            var cols = dimestions[1];

            var matrix = new int[rows, cols];

            var value = 0;

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (var colIndex = 0; colIndex < cols; colIndex++)
                {
                    matrix[rowIndex, colIndex] = value++;
                }
            }

            var command = Console.ReadLine();
            var sum = 0L;

            while (command != "Let the Force be with you")
            {
                var ivoPosition = Position.Parse(command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());

                var evilPosition = Position.Parse(Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());

                var evilPositionX = evilPosition.X;
                var evilPositionY = evilPosition.Y;

                while (evilPositionX >= 0 && evilPositionY >= 0)
                {
                    if (evilPositionX >= 0 && evilPositionX < rows && evilPositionY >= 0 && evilPositionY < cols)
                    {
                        matrix[evilPositionX, evilPositionY] = 0;
                    }
                    evilPositionX--;
                    evilPositionY--;
                }

                var ivoPositionX = ivoPosition.X;
                var ivoPositionY = ivoPosition.Y;

                while (ivoPositionX >= 0 && ivoPositionY < cols)
                {
                    if (ivoPositionX >= 0 && ivoPositionX < rows && ivoPositionY >= 0 && ivoPositionY < cols)
                    {
                        sum += matrix[ivoPositionX, ivoPositionY];
                    }

                    ivoPositionY++;
                    ivoPositionX--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }
    }
}