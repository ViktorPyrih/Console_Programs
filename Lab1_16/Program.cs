using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_16
{
    class Program
    {
        static void Main(string[] args)
        {
            Extensions.InputType(out int[,] array);
            array.Print();


            for (int j = 0; j < array.GetLength(1); j++)
            {
                var col = new int[array.GetLength(0)];
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    col[i] = array[i, j];
                }
                Console.WriteLine($"Sum and Count of negative El in {j + 1} col:");
                getNegativeElementsInCol(col).Print();
                Console.WriteLine();
            }

        }

        static int[] getNegativeElementsInCol(int[] col)
        {
            var sum_el = 0;
            var count = 0;

            for (int i = 0; i < col.Length; i++)
            {
                if (col[i] < 0)
                {
                    sum_el += col[i];
                    count++;
                }
            }

            return new int[] {sum_el, count};

            //return col.Where(x => x == -1).ToArray();
        }
    }
}
