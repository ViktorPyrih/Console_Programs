using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.B
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            var list = new List<long> { 1 };

            var bound = Math.Round(Math.Sqrt(n));
            for (int i = 2; i <= bound; i++)
            {
                if (n % i == 0) list.Add(i);
            }

            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (n / list[i] != list[i]) list.Add(n / list[i]);
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
