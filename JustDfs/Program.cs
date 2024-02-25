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
            string res = DfsString(matrix, 6);
            Console.WriteLine(res);
        }

        /// <param name="matrix">матрица смежности</param>
        /// <param name="vertInd">индекс стартовой вершины</param>
        static string DfsString(int[,] matrix, int vertInd)
        {
            Stack<int> stack = new Stack<int>();
            string result = "";
            int curInd = vertInd; //текущий индекс

            stack.Push(curInd);
            result += curInd;
            do
            {
                //флаг, указывающий на наличие соседей, где false - их нет, true - сосед найден
                bool neighbourFlag = false;

                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    if (matrix[curInd, i] == 1 && !stack.Contains(i) && !result.Contains(i.ToString()))
                    {
                        neighbourFlag = true;
                        stack.Push(i);
                        curInd = i;

                        //если этой вершины нет в конечном списке вершин, то добавляем её туда
                        result += i;
                        break;
                    }
                }

                //если соседи не найдены, то достаем текущую вершину из стека
                if (!neighbourFlag)
                {
                    stack.Pop();
                    
                    if (stack.Count > 0)
                    {
                        curInd = stack.Pop();
                        stack.Push(curInd);
                    }
                }
            }while(stack.Count > 0);

            return result;
        }
    }
}
