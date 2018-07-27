namespace _06._Sneaking
{
    using System;

    public class Sneaking
    {
        static char[][] room;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            room = new char[n][];

            for (var rowIndex = 0; rowIndex < n; rowIndex++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[rowIndex] = new char[input.Length];

                for (var colIndex = 0; colIndex < input.Length; colIndex++)
                {
                    room[rowIndex][colIndex] = input[colIndex];
                }
            }

            var moves = Console.ReadLine().ToCharArray();
            var samPositionCordinates = new int[2];
            Position samPosition = null;

            for (var rowIndex = 0; rowIndex < room.Length; rowIndex++)
            {
                for (var colIndex = 0; colIndex < room[rowIndex].Length; colIndex++)
                {
                    if (room[rowIndex][colIndex] == 'S')
                    {
                        samPositionCordinates[0] = rowIndex;
                        samPositionCordinates[1] = colIndex;
                        samPosition = Position.Parse(samPositionCordinates);
                    }
                }
            }

            for (var i = 0; i < moves.Length; i++)
            {
                for (var rowIndex = 0; rowIndex < room.Length; rowIndex++)
                {
                    for (var colIndex = 0; colIndex < room[rowIndex].Length; colIndex++)
                    {
                        if (room[rowIndex][colIndex] == 'b')
                        {
                            if (rowIndex >= 0 && rowIndex < room.Length && colIndex + 1 >= 0 && colIndex + 1 < room[rowIndex].Length)
                            {
                                room[rowIndex][colIndex] = '.';
                                room[rowIndex][colIndex + 1] = 'b';
                                colIndex++;
                            }
                            else
                            {
                                room[rowIndex][colIndex] = 'd';
                            }
                        }
                        else if (room[rowIndex][colIndex] == 'd')
                        {
                            if (rowIndex >= 0 && rowIndex < room.Length && colIndex - 1 >= 0 && colIndex - 1 < room[rowIndex].Length)
                            {
                                room[rowIndex][colIndex] = '.';
                                room[rowIndex][colIndex - 1] = 'd';
                            }
                            else
                            {
                                room[rowIndex][colIndex] = 'b';
                            }
                        }
                    }
                }

                var enemyPositionCordinates = new int[2];
                Position enemyPosition = null;

                for (var colIndex = 0; colIndex < room[samPosition.X].Length; colIndex++)
                {
                    if (room[samPosition.X][colIndex] != '.' && room[samPosition.X][colIndex] != 'S')
                    {
                        enemyPositionCordinates[0] = samPosition.X;
                        enemyPositionCordinates[1] = colIndex;
                        enemyPosition = Position.Parse(enemyPositionCordinates);
                    }
                }
                if (enemyPosition != null && samPosition.Y < enemyPosition.Y && room[enemyPosition.X][enemyPosition.Y] == 'd' && enemyPosition.X == samPosition.X)
                {
                    room[samPosition.X][samPosition.Y] = 'X';
                    Console.WriteLine($"Sam died at {samPosition.X}, {samPosition.Y}");

                    PrintRoom();

                    return;
                }
                else if (enemyPosition != null && enemyPosition.Y < samPosition.Y && room[enemyPosition.X][enemyPosition.Y] == 'b' && enemyPosition.X == samPosition.X)
                {
                    room[samPosition.X][samPosition.Y] = 'X';
                    Console.WriteLine($"Sam died at {samPosition.X}, {samPosition.Y}");

                    PrintRoom();

                    return;
                }

                room[samPosition.X][samPosition.Y] = '.';

                switch (moves[i])
                {
                    case 'U':
                        samPosition.X--;
                        break;
                    case 'D':
                        samPosition.X++;
                        break;
                    case 'L':
                        samPosition.Y--;
                        break;
                    case 'R':
                        samPosition.Y++;
                        break;
                    default:
                        break;
                }

                room[samPosition.X][samPosition.Y] = 'S';

                for (var colIndex = 0; colIndex < room[samPosition.X].Length; colIndex++)
                {
                    if (room[samPosition.X][colIndex] != '.' && room[samPosition.X][colIndex] != 'S')
                    {
                        if (enemyPosition == null)
                        {
                            enemyPosition = new Position(samPosition.X, colIndex);
                        }
                        else
                        {
                            enemyPosition.X = samPosition.X;
                            enemyPosition.Y = colIndex;
                        }
                    }
                }

                if (enemyPosition != null && room[enemyPosition.X][enemyPosition.Y] == 'N' && samPosition.X == enemyPosition.X)
                {
                    room[enemyPosition.X][enemyPosition.Y] = 'X';
                    Console.WriteLine("Nikoladze killed!");

                    PrintRoom();

                    return;
                }
            }
        }

        private static void PrintRoom()
        {
            for (var rowIndex = 0; rowIndex < room.Length; rowIndex++)
            {
                for (var colIndex = 0; colIndex < room[rowIndex].Length; colIndex++)
                {
                    Console.Write(room[rowIndex][colIndex]);
                }

                Console.WriteLine();
            }
        }
    }
}