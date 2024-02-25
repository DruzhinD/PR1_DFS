using System;
using System.Collections.Generic;
using System.Linq;

namespace AllRoutes
{
    internal class ProgramRoutes
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
            
            int vertex = 4;
            SortedDictionary<int, string> routes = DfsRoutes(matrix, vertex);
            //делаем красивый вывод
            Console.WriteLine($"Для вершины {vertex} составлены следующие маршруты:");
            foreach (KeyValuePair<int, string> r in routes)
            {
                Console.WriteLine("До {0}: {1}",
                    arg0: r.Key,
                    arg1: string.Join("-", r.Value.ToCharArray()));
            }
        }

        /// <param name="matrix">матрица смежности</param>
        /// <param name="vertInd">индекс стартовой вершины</param>
        /// <param name="routes">список маршрутов</param>
        static SortedDictionary<int, string> DfsRoutes(int[,] matrix, int vertInd)
        {
            //здесь будут храниться маршруты в виде <точка: маршрут>
            SortedDictionary<int, string> routes = new SortedDictionary<int, string>();
            Stack<int> stack = new Stack<int>();
            string finalResult = "";
            string currentRoute = "";
            int curInd = vertInd; //текущий индекс

            stack.Push(curInd);
            finalResult += curInd;
            do
            {
                //флаг, указывающий на наличие соседей, где false - их нет, true - сосед найден
                bool neighbourFlag = false;

                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    if (matrix[curInd, i] == 1 && !stack.Contains(i) && !finalResult.Contains(i.ToString()))
                    {
                        neighbourFlag = true;
                        stack.Push(i);
                        curInd = i;

                        //если этой вершины нет в конечном списке вершин, то добавляем её туда
                        finalResult += i;
                        break;
                    }
                }

                //если соседи не найдены, то достаем текущую вершину из стека
                //но перед этим записываем полученный маршрут
                if (!neighbourFlag)
                {
                    //получение маршрута
                    int[] nums = new int[stack.Count];
                    stack.CopyTo(nums, 0);
                    currentRoute = "";
                    for (int i = nums.Length - 1; i >= 0; i--)
                        currentRoute += nums[i];
                    routes[nums[0]] = currentRoute;

                    //часть логики DFS
                    stack.Pop();
                    if (stack.Count > 0)
                    {
                        curInd = stack.Pop();
                        stack.Push(curInd);
                    }
                }
            } while (stack.Count > 0);
            Console.WriteLine($"Результат DFS: {finalResult}");
            return routes;
        }
    }
}
