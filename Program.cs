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
            char[,] map = null;
            string[] file = File.ReadAllLines("map.txt");
            Console.WriteLine(file[0]);
        }
    }
}
