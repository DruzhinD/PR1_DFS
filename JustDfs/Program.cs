using System;
using System.Collections.Generic;
using System.Data;

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
            string res = DfsString(matrix, 4);
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

            //stack.Push(curInd);
            //result += curInd;
            do
            {
                //флаг, указывающий на наличие соседей, где false - их нет, true - сосед найден
                bool neighbourFlag = false;

                //при vertInd = 4 зацикливается на 4210 - 421 - 42 - 421 - 4210
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    //если в матрице смежности указана единица, т.е. есть ребро И
                    //ЗАЦИКЛИВАЕТСЯ на 4211111111111111111111
                    if (matrix[curInd, i] == 1 && !stack.Contains(i) && !result.Contains(i.ToString()))
                    {
                        result += curInd;
                        stack.Push(curInd);
                        curInd = i;
                        neighbourFlag = true;

                        //если этой вершины нет в конечном списке вершин, то добавляем её туда
                        //result += i;
                        break;
                    }
                }

                //если соседи не найдены, то достаем текущую вершину из стека
                if (!neighbourFlag)
                {
                    curInd = stack.Pop();
                    
                    if (stack.Count > 100)
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
