using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    static class InputType
    {
        // ------------------------------------- INPUT TYPE

        // Array with Arrays (Two Dim)
        public static void ArrayWithArrays(out int[][] array)
        {
            Console.WriteLine("Input '0' to randomize array.\n" +
                "Input '1' to use keyboard and enter elements in every line.\n" +
                "Input '2' to use keyboard and enter elements in one line.");

            int.TryParse(Console.ReadLine(), out int input);
            switch (input)
            {
                case 0:
                    array = RandomizeArrayWithArrays();
                    return;
                case 1:
                    array = Keyboard_1_Input_ArrayWithArrays();
                    return;
                case 2:
                    array = Keyboard_2_Input_ArrayWithArrays();
                    return;
            }

            array = new int[][] { };
            return;
        }

        private static int[][] RandomizeArrayWithArrays()
        {
            Random random = new Random();
            int[][] array = getArrayWithArrays();

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Enter the width of nested array #{i + 1}.");
                int.TryParse(Console.ReadLine(), out int width);
                var nested_array = new int[width];

                for (int j = 0; j < nested_array.Length; j++)
                {
                    nested_array[j] = random.Next(-10, 11);
                }
                array[i] = nested_array;
            }

            return array;
        }

        private static int[][] Keyboard_1_Input_ArrayWithArrays()
        {
            int[][] array = getArrayWithArrays();

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Enter the width of nested array #{i + 1}.");
                int.TryParse(Console.ReadLine(), out int width);
                var nested_array = new int[width];

                for (int j = 0; j < nested_array.Length; j++)
                {
                    int.TryParse(Console.ReadLine(), out nested_array[j]);
                }
                array[i] = nested_array;
            }

            return array;
        }

        private static int[][] Keyboard_2_Input_ArrayWithArrays()
        {
            int[][] array = getArrayWithArrays();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine($"Enter the width of nested array #{i + 1}.");
                int.TryParse(Console.ReadLine(), out int width);
                var nested_array = new int[width];
                string[] str_ = Console.ReadLine().Split();

                for (int j = 0; j < nested_array.Length; j++)
                {
                    int.TryParse(str_[j], out nested_array[j]);
                }
                array[i] = nested_array;
            }

            return array;
        }

        private static int[][] getArrayWithArrays()
        {
            Console.WriteLine("Enter the height of array.");

            var str = Console.ReadLine().Split();
            int.TryParse(str[0], out int height);
            var array = new int[height][];
            return array;
        }

        // Two Dimensions
        public static void TwoDimensions_Array(out int[,] array)
        {
            Console.WriteLine("Input '0' to randomize array.\n" +
                "Input '1' to use keyboard and enter elements in every line.\n" +
                "Input '2' to use keyboard and enter elements in one line.");

            int.TryParse(Console.ReadLine(), out int input);
            switch (input)
            {
                case 0:
                    array = RandomizeArray_TwoDimensions();
                    return;
                case 1:
                    array = Keyboard_1_Input_TwoDimensions();
                    return;
                case 2:
                    array = Keyboard_2_Input_TwoDimensions();
                    return;
            }

            array = new int[,] { };
            return;
        }

        private static int[,] RandomizeArray_TwoDimensions()
        {
            Random random = new Random();
            int[,] array = getTwoDimensionsArray();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(-10, 11);
                }
            }

            return array;
        }

        private static int[,] Keyboard_1_Input_TwoDimensions()
        {
            int[,] array = getTwoDimensionsArray();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int.TryParse(Console.ReadLine(), out array[i, j]);
                }
            }

            return array;
        }

        private static int[,] Keyboard_2_Input_TwoDimensions()
        {
            int[,] array = getTwoDimensionsArray();

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

        private static int[,] getTwoDimensionsArray()
        {
            Console.WriteLine("Enter the height & width of array.");

            var str = Console.ReadLine().Split();
            int.TryParse(str[0], out int height);
            int.TryParse(str[1], out int width);
            var array = new int[height, width];
            return array;
        }

        // One Dimension
        public static void OneDimension_Array(out int[] array)
        {
            Console.WriteLine("Input '0' to randomize array.\n" +
                "Input '1' to use keyboard and enter elements in every line.\n" +
                "Input '2' to use keyboard and enter elements in one line.");

            int.TryParse(Console.ReadLine(), out int input);
            switch (input)
            {
                case 0:
                    array = RandomizeArray_OneDimension();
                    return;
                case 1:
                    array = Keyboard_1_Input_OneDimension();
                    return;
                case 2:
                    array = Keyboard_2_Input_OneDimension();
                    return;
            }

            array = new int[] { };
            return;
        }

        private static int[] RandomizeArray_OneDimension()
        {
            Random random = new Random();
            int[] array = getOneDimensionArray();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-10, 11);
            }

            return array;
        }

        private static int[] getOneDimensionArray()
        {
            Console.WriteLine("Enter the length of array.");

            var str = Console.ReadLine().Split();
            int.TryParse(str[0], out int length);
            var array = new int[length];
            return array;
        }

        private static int[] Keyboard_1_Input_OneDimension()
        {
            var array = getOneDimensionArray();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                int.TryParse(Console.ReadLine(), out array[i]);
            }

            return array;
        }

        private static int[] Keyboard_2_Input_OneDimension()
        {
            var array = getOneDimensionArray();

            Console.WriteLine($"Enter the {array.Length} elements.");
            string[] str_ = Console.ReadLine().Split();
            for (int j = 0; j < array.Length; j++)
            {
                int.TryParse(str_[j], out array[j]);
            }

            return array;
        }
    }
}
