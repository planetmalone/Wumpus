using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wumpus
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();

            for (int i = 0; i < map.Count(); i++)
            {
                Console.WriteLine(map[i]);
            }

            wait();
        }

        static void wait()
        {
            Console.ReadKey();
        }
    }
}
