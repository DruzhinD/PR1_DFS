using System.Collections.Generic;

namespace JustDfs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix =
            {
            //    0  1  2  3  4  5  6
                { 0, 1, 0, 0, 0, 0, 0 }, //0
                { 1, 0, 1, 1, 0, 0, 0 }, //1
                { 0, 1, 0, 1, 1, 0, 0 }, //2
                { 0, 1, 1, 0, 0, 0, 0 }, //3
                { 0, 0, 1, 0, 0, 1, 1 }, //4
                { 0, 0, 0, 0, 1, 0, 1 }, //5
                { 0, 0, 0, 0, 1, 0, 1 }, //6
                { 0, 0, 0, 0, 1, 1, 0 }, //7
            };
        }

        /// <param name="matrix">матрица смежности</param>
        /// <param name="vertInd">индекс стартовой вершины</param>
        static string DfsString(int[,] matrix, int vertInd)
        {
            //условие: неважно какое именно измерение, вершина будет та же т.е. [1,0] == [0,1]
            Stack<int> stack = new Stack<int>();
            string result = "";

            stack.Push(vertInd);

            //тупик
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                }
            }

            while (result.Length !=  matrix.GetLength(0) || stack.Count != 0)
            {
                
            }

            return "";
        }
    }
}
