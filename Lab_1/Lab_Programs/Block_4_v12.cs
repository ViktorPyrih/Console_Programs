using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Lab_Programs
{
    class Block_4_v12 : ParentProgram, IProgram
    {

        public void Run()
        {
            // create array of count of zeros
            var zero_cols = new int[array.GetLength(0)];
            zero_cols.Fill(0);

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == 0) zero_cols[i]++;
                }
            }

            // copy array
            int[] last_arr = new int[zero_cols.Length];
            Array.Copy(zero_cols, last_arr, zero_cols.Length);

            // sort array with quicksort
            zero_cols.QuickSort();

            // turn zero_cols array into array of indexes
            for (int i = 0; i < zero_cols.Length; i++)
            {
                var index = Array.IndexOf(last_arr, zero_cols[i]);
                zero_cols[i] = index;
                last_arr[index] = -1;
            }

            // change rows places in our array by zero_cols array of indexes
            var basic_cols_indexes = new int[array.GetLength(0)];
            basic_cols_indexes.FillSequenceFrom();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                var needIndex = zero_cols[i];

                if (needIndex != basic_cols_indexes[i])
                {
                    var basicIndex = Array.IndexOf(basic_cols_indexes, needIndex);

                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        var temp = array[basicIndex, j];
                        array[basicIndex, j] = array[i, j];
                        array[i, j] = temp;
                    }

                    var temp2 = basic_cols_indexes[i];
                    basic_cols_indexes[i] = needIndex;
                    basic_cols_indexes[basicIndex] = temp2;
                }
            }

            // print
            Console.WriteLine("New array with sorted cols:");
            array.Print();
        }

    }
}
