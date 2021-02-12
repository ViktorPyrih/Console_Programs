using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Lab_Programs
{
    class Block_3_v12 : AutoFilledArray, IProgram
    {

        public void Run()
        {
            var side_diagonal = new int[array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                side_diagonal[i] = array[i, array.GetLength(0) - i - 1];
            }

            side_diagonal.QuickSort();
            side_diagonal.Reverse();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i, array.GetLength(0) - i - 1] = side_diagonal[i];
            }

            Console.WriteLine("New array with sorted side diagonal:");
            array.Print();
        }

    }
}
