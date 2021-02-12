using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Lab_Programs
{
    class AdditionalProgram_1 : ParentProgram, IProgram
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

                // change place: (min to First place, max to Last place)
                // 1)
                var temp1 = array[i, 0];
                array[i, 0] = array[i, minIndex];
                array[i, minIndex] = temp1;
                if (maxIndex == 0) maxIndex = minIndex;
                // 2)
                var temp2 = array[i, array.GetLength(1) - 1];
                array[i, array.GetLength(1) - 1] = array[i, maxIndex];
                array[i, maxIndex] = temp2;
            }

            Console.WriteLine("New array:");
            array.Print();
        }

    }
}
