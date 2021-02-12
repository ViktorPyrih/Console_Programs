using System;

namespace Lab_1
{
    public static class Extensions
    {
        // Get First & Last Elements from Arrays
        public static T First<T>(this T[,] originalArray) => originalArray[0, 0];
        public static T Last<T>(this T[,] originalArray) => originalArray[originalArray.GetLength(0) - 1, originalArray.GetLength(1) - 1];

        public static T First<T>(this T[] originalArray) => originalArray[0];
        public static T Last<T>(this T[] originalArray) => originalArray[originalArray.Length - 1];

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

        public static void FillSequenceFrom(this int[] originalArray, int from = 0)
        {
            for (int i = 0; i < originalArray.Length; i++)
            {
                originalArray[i] = from++;
            }
        }

        public static void Print<T>(this T[] originalArray)
        {
            for (int i = 0; i < originalArray.GetLength(0); i++)
            {
                Console.Write($"{originalArray[i]}\t");
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

        // Quick Sort
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

        // INPUT
        public static void InputType(out int[,] array)
        {
            Console.WriteLine("Input '0' to randomize array.\n" +
                "Input '1' to use keyboard and enter elements in every line.\n" +
                "Input '2' to use keyboard and enter elements in one line.");

            int.TryParse(Console.ReadLine(), out int input);
            switch (input)
            {
                case 0:
                    array = RandomizeArray();
                    return;
                case 1:
                    array = Keyboard_1_Input();
                    return;
                case 2:
                    array = Keyboard_2_Input();
                    return;
            }

            array = new int[,] { };
            return;
        }

        private static int[,] RandomizeArray()
        {
            Random random = new Random();
            Console.WriteLine("Enter the height & width of array.");

            var str = Console.ReadLine().Split();
            int.TryParse(str[0], out int height);
            int.TryParse(str[1], out int width);
            var array = new int[height, width];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(-10, 11);
                }
            }

            return array;
        }

        private static int[,] Keyboard_1_Input()
        {
            Console.WriteLine("Enter the height & width of array.");

            var str = Console.ReadLine().Split();
            int.TryParse(str[0], out int height);
            int.TryParse(str[1], out int width);
            var array = new int[height, width];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int.TryParse(Console.ReadLine(), out array[i, j]);
                }
            }

            return array;
        }

        private static int[,] Keyboard_2_Input()
        {
            Console.WriteLine("Enter the height & width of array.");

            var str = Console.ReadLine().Split();
            int.TryParse(str[0], out int height);
            int.TryParse(str[1], out int width);
            var array = new int[height, width];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine($"Enter the elements in row {i + 1}/{array.GetLength(0)} (should be {array.GetLength(1)}).");
                string[] str_ = Console.ReadLine().Split();
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int.TryParse(str_[j], out array[i, j]);
                }
            }

            return array;
        }

    }
}
