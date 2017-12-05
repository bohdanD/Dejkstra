using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Dejkstra
{
    class Program
    {
        private static bool[] used;
        private static int[] lengths;
        private static int[] paths;
        private static int[] ways;
        private static int[,] weights;

        static void Main(string[] args)
        {
            Console.WriteLine("Input count of tops");
            int n = int.Parse(Console.ReadLine());

            used = new bool[n];
            lengths = new int[n];
            weights = new int[n, n];
            paths = new int[n];
            ways = new int[n];

            Console.WriteLine("Input weight matrix");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine($"w[{i},{j}] = ");
                    weights[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Input number of start and finish top");
            int start = int.Parse(Console.ReadLine());
            int finish = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{weights[i, j]} ");
                }
                Console.Write("\n");
            }

            for (int i = 0; i < n; i++)
            {
                used[i] = false;
                lengths[i] = int.MaxValue;
            }

            lengths[start] = 0;
            paths[start] = 6555434;
            while (true)
            {
                int from = 0;
                int fromLength = int.MaxValue;
                for (int i = 0; i < n; i++)
                {
                    if (fromLength > lengths[i] && !used[i])
                    {
                        from = i;
                        fromLength = lengths[i];
                    }
                }
                if (fromLength >= int.MaxValue)
                {
                    break;
                }
                used[from] = true;
                for (int index = 0; index < n; index++)
                {
                    if (weights[from, index] != 0)
                    {
                        if (!used[index] && (lengths[index] > lengths[from] + weights[from, index]))
                        {
                            lengths[index] = lengths[from] = weights[from, index];
                            paths[index] = from;
                        }
                    }
                }
            }
            int counter = 0;
            if (lengths[finish] < int.MaxValue)
            {
                Console.Write("Way: ");
                for (int i = finish; i != start; i = paths[i])
                {
                    ways[counter] = i;
                    counter++;
                }
                Console.Write($"x{start}-");
                for (int i = counter - 1; i >= 0; i--)
                {
                    Console.Write($"x{ways[i]}-");
                }
                Console.WriteLine($"\nWay Length: {lengths[finish]}");
            }
            else
            {
                Console.WriteLine("The way was not found");
            }

            Console.Read();
        }
    }
}
