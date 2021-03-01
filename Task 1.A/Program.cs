using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.A
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var list = new List<int>();

            int k = int.Parse(Console.ReadLine());
            for (int i = 0; i < k; i++)
            {
                var str = Console.ReadLine().Split();
                int a = int.Parse(str[0]);
                int b = int.Parse(str[1]);

                int sum = 0;
                for (int j = a - 1; j < b; j++)
                {
                    sum += array[j];
                }
                list.Add(sum);
            }

            Console.WriteLine(string.Join("\n", list));
        }
    }
}
