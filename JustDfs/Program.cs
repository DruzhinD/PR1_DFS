using System;
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
                { 0, 0, 0, 0, 1, 1, 0 }, //6
            };
            string res = DfsString(matrix, 2);
            Console.WriteLine(res);
        }

        /// <param name="matrix">матрица смежности</param>
        /// <param name="vertInd">индекс стартовой вершины</param>
        static string DfsString(int[,] matrix, int vertInd)
        {
            //условие: неважно какое именно измерение, вершина будет та же т.е. [1,0] == [0,1]
            Stack<int> stack = new Stack<int>();
            string result = "";
            int curInd = vertInd; //текущий индекс

            int counter = 0;
            do
            {
                counter++;
                //флаг, указывающий на наличие соседей, где false - их нет, true - сосед найден
                bool neighbourFlag = false;

                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    //если в матрице смежности указана единица, т.е. есть ребро
                    if (matrix[curInd, i] == 1 && !stack.Contains(i) && !result.Contains(i.ToString()))
                    {
                        if (!result.Contains(curInd.ToString()))
                            result += curInd;
                        stack.Push(curInd);
                        curInd = i;
                        neighbourFlag = true;

                        Console.WriteLine($"{result} | {curInd} | итерация: {counter}");
                        break;
                    }
                }

                //если соседи не найдены, то достаем текущую вершину из стека
                if (!neighbourFlag)
                {
                    if (!result.Contains(curInd.ToString()))
                        result += curInd;
                    curInd = stack.Pop();
                }
            }while(stack.Count > 0 | result.Length != matrix.GetLength(1));

            return result;
        }
    }
}
