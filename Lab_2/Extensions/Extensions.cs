using System;
using System.Collections.Generic;

namespace Lab_2
{
    public static class Extensions
    {
        // Get First & Last Elements from Arrays
        public static T First<T>(this T[,] originalArray) => originalArray[0, 0];
        public static T Last<T>(this T[,] originalArray) => originalArray[originalArray.GetLength(0) - 1, originalArray.GetLength(1) - 1];

        public static T First<T>(this T[] originalArray) => originalArray[0];
        public static T Last<T>(this T[] originalArray) => originalArray[originalArray.Length - 1];

        public static T First<T>(this T[][] originalArray) => originalArray[0][0];
        public static T Last<T>(this T[][] originalArray) => originalArray[originalArray.Length - 1][originalArray[originalArray.Length - 1].Length - 1];

        // Fill with number & Print to console Methods
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
        
        public static void Fill<T>(this T[][] originalArray, T with)
        {
            for (int i = 0; i < originalArray.Length; i++)
            {
                for (int j = 0; j < originalArray[i].Length ; j++)
                {
                    originalArray[i][j] = with;
                }
            }
        }

        public static void Print<T>(this IList<T> originalArray)
        {
            for (int i = 0; i < originalArray.Count; i++)
            {
                Console.Write($"{originalArray[i]}\t");
            }
            Console.WriteLine();
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
        
        public static void Print<T>(this T[][] originalArray)
        {
            for (int i = 0; i < originalArray.Length; i++)
            {
                for (int j = 0; j < originalArray[i].Length; j++)
                {
                    Console.Write($"{originalArray[i][j]}\t");
                }
                Console.WriteLine("\n");
            }
        }

        // ------------------------------------- Quick Sort
        public static void QuickSort(this int[] data) 
        {
            Sort(data, 0, data.Length - 1);
        }

        private static int[] Sort(int[] elements, int left, int right)
        {
            int i = left, j = right;
            var pivot = elements[(left + right) / 2];
            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Поменять элементы местами
                    var temp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = temp;

                    i++;
                    j--;
                }
            }

            // Рекурсивные вызовы
            if (left < j)
            {
                Sort(elements, left, j);
            }

            if (i < right)
            {
                Sort(elements, i, right);
            }

            return elements;
        }

    }
}
