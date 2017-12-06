using System;
using System.ComponentModel.Design;

namespace Prym
{
    class Program
    {
        private static int[,] adjMatrix;
        private static bool[] internalTop;

        static void Main(string[] args)
        {
            int size = 0;
            int startTopNumber = -1;
            int mincost = 0;

            Console.WriteLine("Input count of tops and start top");

            size = int.Parse(Console.ReadLine());
            startTopNumber = int.Parse(Console.ReadLine());

            adjMatrix = new int[size, size];
            internalTop = new bool[size];

            Console.WriteLine("Input adjacency matrix. type 'i' for infinity");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i != j)
                    {
                        Console.WriteLine($"adjacency matrix[{i},{j}]=");
                        var inpString = Console.ReadLine();
                        adjMatrix[i, j] = int.Parse(inpString == "i" ? int.MaxValue.ToString() : inpString);
                    }
                    else
                    {
                        adjMatrix[i, j] = int.MaxValue;
                    }
                }
            }

            internalTop[startTopNumber] = true;
            int countOfSelectedTops = 1;
            int from, to;
            Console.WriteLine("Path:");

            while (countOfSelectedTops < size)
            {
                from = to = -1;
                int minEdgeWeight = int.MaxValue;

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (adjMatrix[i,j] != int.MaxValue && internalTop[i] && adjMatrix[i,j] <= minEdgeWeight)
                        {
                            minEdgeWeight = adjMatrix[i, j];
                            from = i;
                            to = j;
                        }
                    }
                }
                if (!internalTop[from] || !internalTop[to])
                {
                    Console.WriteLine($"{from}------{to}");
                    countOfSelectedTops++;
                    mincost += minEdgeWeight;
                    internalTop[to] = true;
                }
                adjMatrix[from, to] = int.MaxValue;
                adjMatrix[to, from] = int.MaxValue;


            }
            Console.WriteLine($"Min cosst: {mincost}");
            Console.ReadLine();
        }
    }
}
