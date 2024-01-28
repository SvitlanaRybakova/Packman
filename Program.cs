using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Net.NetworkInformation;

namespace Packman
{
    internal class Program
    {
        static void Main(string[] args)


        {
            Console.CursorVisible = false;

            char[,] gameMap = ReadMap("map.txt");

            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false);


            int pacmanX = 1;
            int pacmanY = 1;

            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Blue;
                DrawMap(gameMap);


                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(pacmanX, pacmanY);
                Console.Write("@");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(22, 0);
                Console.Write("The pressed key is: " + pressedKey.KeyChar);
                pressedKey = Console.ReadKey();

                HandleInput(pressedKey, ref pacmanX, ref pacmanY);
            }

        }

        private static char[,] ReadMap(string path)
        {
            string[] file = File.ReadAllLines(path);
            char[,] map = new char[GetMaxLenghtOfLine(file), file.Length];

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    map[x, y] = file[y][x];
                }
            }
            return map;
        }

        private static void DrawMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    Console.Write(map[y, x]);
                }
                Console.WriteLine();
            }
        }

        private static int GetMaxLenghtOfLine(string[] lines)
        {
            int maxLength = lines[0].Length;

            foreach (var line in lines)
            {
                if (line.Length > maxLength)
                {
                    maxLength = line.Length;
                }
            }
            return maxLength;
        }

        private static void HandleInput(ConsoleKeyInfo pressedKey, ref int pacmanX, ref int pacmanY)
        {
            if(pressedKey.Key == ConsoleKey.UpArrow)
            {
                pacmanY -= 1;
            }
            if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                pacmanY += 1;
            }
            if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                pacmanX += 1;
            }
            if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                pacmanX -= 1;
            }
        }
    }
}
