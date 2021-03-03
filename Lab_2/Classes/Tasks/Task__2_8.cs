using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.Classes.Tasks
{
    class Task__2_8 : BaseInit_TwoDim, IRunnable
    {
        public Task__2_8() : base("Знищити рядок, в якому знаходиться найбiльший елемент матрицi (якщо у рiзних мiсцях є кiлька " +
                                  "елементiв з однаковим максимальним значенням, то лише перший з них)"){}

        public void Run()
        {
            var index = getIndexOfRow_WhereMaxElem();

            for (int i = index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }

            Array.Resize(ref array, array.Length - 1);

            Console.WriteLine("New array:");
            array.Print();
        }

        private int getIndexOfRow_WhereMaxElem()
        {
            var max_index_i = 0;
            var max_index_j = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > array[max_index_i][max_index_j]) 
                    { 
                        max_index_i = i; 
                        max_index_j = j; 
                    }
                }
            }

            return max_index_i;
        }
    }
}
