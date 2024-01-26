using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Packman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] gameMap = ReadMap("map.txt");
            DrawMap(gameMap);
        }

        private static char[,] ReadMap(string path)
        {
            string[] file = File.ReadAllLines(path);
            char[,] map = new char[GetMaxLenghtOfLine(file), file.Length];

            for(int x = 0; x < map.GetLength(0);  x++)
            {
                for(int y = 0; y < map.GetLength(1); y++)
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
    }
}
