using System;

namespace Lab1_16
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




        public static void InputType(out int[,] array)
        {
            Console.WriteLine("Input '0' to randomize array.\n" +
                "Input '1' to use keyboard and enter elements in every line.\n" +
                "Input '2' to use keyboard and enter elements in one line.");

            int.TryParse(Console.ReadLine(), out int input);
            switch (input)
            {
                case 0:
                    array = randomizeArray();
                    return;
                case 1:
                    array = keyboard_1_Input();
                    return;
                case 2:
                    array = keyboard_2_Input();
                    return;
            }

            array = new int[,] { };
            return;
        }

        private static int[,] randomizeArray()
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

        private static int[,] keyboard_1_Input()
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

        private static int[,] keyboard_2_Input()
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
