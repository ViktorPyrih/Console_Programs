using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Lab_Programs
{
    class Block_1_v15 : AutoFilledArray, IProgram
    {

        public void Run()
        {
            Console.WriteLine("Sum on the main diagonal is " + getSumOnMainDiagonal());
            Console.WriteLine("Sum on the main side is " + getSumOnSideDiagonal());
        }

        private int getSumOnMainDiagonal()
        {
            var sum = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                sum += array[i, i];
            }

            return sum;
        }

        private int getSumOnSideDiagonal()
        {
            var sum = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                sum += array[i, array.GetLength(0) - i - 1];
            }

            return sum;
        }

    }
}
