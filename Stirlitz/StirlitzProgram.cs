using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stirlitz
{
    internal class StirlitzProgram
    {
        static void Main(string[] args)
        {
            //кол-во площадей
            int amount = 5;
            //матрица расстояний (смежности)
            int[] distances = new int[]
            {
                0, 1, 9, 9, 2,
                1, 0, 9, 9, 9,
                9, 9, 0, 9, 9,
                9, 9, 9, 0, 9,
                2, 9, 9, 9, 0,
            };

        }
    }
}
