using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Lab_Programs
{
    class Block_2_v15 : AutoFilledArray, IProgram
    {

        public void Run()
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                // find max & min
                var maxIndex = 0;
                var minIndex = 0;

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > array[i, maxIndex]) maxIndex = j;
                    if (array[i, j] < array[i, minIndex]) minIndex = j;
                }

                // change place
                var temp = array[i, maxIndex];
                array[i, maxIndex] = array[i, minIndex];
                array[i, minIndex] = temp;
            }

            Console.WriteLine("New array:");
            array.Print();

        }

    }
}
