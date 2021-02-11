using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_5
{
    public static class Extensions
    {
        public static void Fill<T>(this T[] originalArray, T with)
        {
            for (int i = 0; i < originalArray.Length; i++)
            {
                originalArray[i] = with;
            }
        }

        public static void Fill<T>(this T[,] originalArray, T with)
        {
            for (int i = 0; i < originalArray.GetLength(0); i++)
            {
                for (int j = 0; j < originalArray.GetLength(1); j++)
                {
                    originalArray[i, j] = with;
                }
            }
        }

        public static void Print<T>(this T[,] originalArray)
        {
            for (int i = 0; i < originalArray.GetLength(0); i++)
            {
                for (int j = 0; j < originalArray.GetLength(1); j++)
                {
                    Console.Write($"{originalArray[i, j]}\t");
                }
                Console.WriteLine("\n");
            }
        }
    }
}
