using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.C
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var array = new int[n][];
            for (int i = 0; i < n; i++)
            {
                array[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            var sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += array[i][i];
                sum += array[i][n - i - 1];
            }

            if (n % 2 != 0) sum -= array[n / 2][n / 2];

            Console.WriteLine(sum);

        }
    }
}
