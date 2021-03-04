using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.Classes.Tasks
{
    class Task__3_8 : BaseInit_TwoDim, IRunnable
    {
        public Task__3_8() : base("У прямокутнiй матрицi B, що мiстить лише нулi та одиницi, обчислити кiлькiсть нулiв у кожному рядку " +
                                  "i записати отриманi кiлькостi в одновимiрний масив P.Створити матрицю Z, кiлькiсть стовпчикiв у " +
                                  "кожному рядку якоi визначається вiдповiдним значенням з масиву P.В кожен рядок матрицi Z записати " +
                                  "пiдряд iндекси нулiв з вiдповiдних рядкiв матрицi B.Iнвертувати порядок елементiв у кожному рядку " +
                                  "матрицi Z.")
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] >= 1) array[i][j] = 1;
                    else if (array[i][j] <= 0) array[i][j] = 0;
                }
            }

            Console.WriteLine("Rebuild array:");
            array.Print();
        }


        public void Run()
        {
            var array_P = new int[array.Length];
            array_P.Fill(0);

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] == 0) array_P[i]++;
                }
            }

            var array_Z = new int[array.Length][];

            for (int i = 0; i < array.Length; i++)
            {
                var nested_in_Z_arr = new int[array_P[i] * 2];
                
                for (int j = 0, k = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] == 0)
                    {
                        nested_in_Z_arr[k++] = i;
                        nested_in_Z_arr[k++] = j;
                    }
                }

                array_Z[i] = nested_in_Z_arr;
            }

            array_Z.Print();



        }
    }
}
