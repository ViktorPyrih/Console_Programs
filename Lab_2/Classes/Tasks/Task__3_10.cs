using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_2.Classes.Tasks
{
    class Task__3_10 : BaseInit_TwoDim, IRunnable
    {
        public Task__3_10() :
            base ("Перетворити матрицю A, кількість елементів у кожному рядку " +
                "якої є різною, на одновимірний масив V наступним чином: " +
                "для кожного елемента матриці в одновимірний масив записуються " +
                "спочатку його індекси, а потім – значення. " +
                "Інвертувати порядок елементів масиву V та відновити на його " +
                "основі прямокутну матрицю B за зворотним принципом.") { }

        public void Run()
        {
            var arraySize = array.Select(row => row.Length).Sum() * 3;
            var V = new int[arraySize];
            
            TransferMatrixTo(V);
            ReverseElements(V);
            
            int[][] B = BuildMatrixFrom(V);
            
            Console.WriteLine("New array:");
            B.Print();
        }

        private void TransferMatrixTo(int[] singleArray)
        {
            int index = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                for (int j = 0; j < array[i].Length; ++j)
                {
                    singleArray[index] = i;
                    singleArray[index + 1] = j;
                    singleArray[index + 2] = array[i][j];
                    index += 3;
                }
            }
        }
        
        private void ReverseElements(int [] singleArray)
        {
            Stack<int> stack = new Stack<int>(); 
            
            for(int i = 2; i < singleArray.Length; i += 3)
                stack.Push(singleArray[i]);
            
            for(var i = 2; i < singleArray.Length; i += 3) 
            {
                int x = stack.Peek(); 
                stack.Pop(); 
                singleArray[i] = x; 
            } 
        }

        private int[][] BuildMatrixFrom(int[] singleArray)
        {
            if (singleArray.Length == 0) return new int[0][];

            int size = array.Length;
            int[][] B = new int[size][];

            int k = 2;
            for (int i = 0; i < size; i++)
            {
                B[i] = new int[array[i].Length];
                for(int j = 0; j < B[i].Length; ++j)
                {
                    B[i][j] = singleArray[k];
                    k += 3;
                }
            }
            return B;
        }
    }
}
