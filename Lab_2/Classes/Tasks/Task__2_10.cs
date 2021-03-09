using System;
namespace Lab_2.Classes.Tasks
{
    class Task__2_10 : BaseInit_TwoDim, IRunnable
    {
        public Task__2_10() :
            base ("Додати по одному рядку після кожного парного рядка матриці"
                    + "(тобто, кожного рядка, що у початковій"
                    + "матриці мав парний номер)") { }

        public void Run()
        {
            int originalSize = array.Length;

            Array.Resize(ref array, array.Length + originalSize / 2);

            InsertRows(array.Length - 1, originalSize - 1);

            Console.WriteLine("New array:");
            array.Print();
        }

        private void InsertRows(int newPosition, int oldPosition)
        {
            int[] rowToInsert = { 0, 0, 0 };

            while (oldPosition >= 0)
            {
                if (oldPosition % 2 != 0)
                {
                    array[newPosition] = rowToInsert;
                    --newPosition;
                }
                array[newPosition] = array[oldPosition];
                --oldPosition; --newPosition;
            }
        }
    }
}
