using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Stirlitz
{
    internal class StirlitzProgram
    {
        static void Main(string[] args)
        {
            int amount = 5;
            int[,] distances = new int[5, 5]
            {
                {0, 1, 9, 9, 2 },
                {1, 0, 9, 9, 9 },
                {9, 9, 0, 9, 9 },
                {9, 9, 9, 0, 9 },
                {2, 9, 9, 9, 0 }
            };

            int minDistance = int.MaxValue;
            int start = 0, middle = 0, end = 0;

            for (int i = 0; i < amount; i++)
            {
                for (int j = 0; j < amount; j++)
                {
                    for (int k = 0; k < amount; k++)
                    {
                        if (i != j && j != k && i != k)
                        {
                            int currentDistance = distances[i, j] + distances[j, k];
                            if (currentDistance < minDistance)
                            {
                                minDistance = currentDistance;
                                start = i + 1;
                                middle = j + 1;
                                end = k + 1;
                            }
                        }
                    }
                }
            }
            List<int> mas = new List<int>() { start, middle, end };
            mas.Sort();

            Console.WriteLine(("{0} {1} {2}"),
                mas[0], mas[1], mas[2]);
             
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i <= 100; i++)
            {
                for (int j = 0; j < 100; j++)
                    for (int k = 0; k < 100; k++)
                        ;
            }
            sw.Stop();
            Console.WriteLine($"время {sw.Elapsed}");
        }
    }
}
