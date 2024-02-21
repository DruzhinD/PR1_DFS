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

            stack.Push(curInd);
            result += curInd;
            do
            {
                //флаг, указывающий на наличие соседей, где false - их нет, true - сосед найден
                bool neighbourFlag = false;

                //при vertInd = 4 зацикливается на 4210 - 421 - 42 - 421 - 4210
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    //если в матрице смежности указана единица, т.е. есть ребро И
                    
                    if (matrix[curInd, i] == 1 && !stack.Contains(i))
                    {
                        neighbourFlag = true;
                        stack.Push(i);
                        curInd = i; //была проблема с этим, переменная оставалась == 0

                        //если этой вершины нет в конечном списке вершин, то добавляем её туда
                        if (!result.Contains(i.ToString())) //проблема в этом условии
                            result += i;
                        break;
                    }
                }

                //если соседи не найдены, то достаем текущую вершину из стека
                if (!neighbourFlag)
                {
                    stack.Pop();
                    //теперь благодаря этому эта тварь зацикливается не на 2, а на 1
                    curInd = stack.Pop();
                    stack.Push(curInd);
                }


            }while(stack.Count > 0);

            return result;
        }
    }
}
