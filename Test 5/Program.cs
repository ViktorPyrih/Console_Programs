using System;
using static Test_5.Position;

namespace Test_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write height & width of array:");
            var str = Console.ReadLine().Split();
            var array = new int[int.Parse(str[0]), int.Parse(str[1])];

            array.Fill(0);

            fillFromLeftUpCorner(array);

            //fillFromRightBottomCorner(array);

            array.Print();
        }


        static void fillFromLeftUpCorner(int[,] array)
        {
            var number = 1;
            var i = 0;
            var j = -1;
            Position position = Right;

            while (!isArrayFilled(array))
            {
                var lastNumber = number;

                fillToPosition(ref number, array, ref i, ref j, position);
                fillToPosition(ref number, array, ref i, ref j, position);
                position =
                    position == Right ? Down :
                    position == Down ? Left :
                    position == Left ? Up :
                    Right;

                if (lastNumber == number) break;
            }
        }

        static void fillFromRightBottomCorner(int[,] array)
        {
            var number = 1;
            var i = array.GetLength(0) - 1;
            var j = array.GetLength(1);
            var position = Left;

            while (!isArrayFilled(array))
            {
                var lastNumber = number;

                fillToPosition(ref number, array, ref i, ref j, position);
                position = 
                    position == Left ? Up : 
                    position == Up ? Right : 
                    position == Right ? Down : 
                    Left;

                if (lastNumber == number) break;
            }
        }

        // array filling Methods

        static void fillToPosition(
            ref int numbFillWith, // number
            int[,] arr, ref int I, ref int J, // array and indexes of elements
            Position dimension) // position fill to
        {
            switch (dimension)
            {
                case Left:
                    for (int j = J - 1; j >= 0 && arr[I, j] == 0; j--)
                    {
                        J = j;
                        arr[I, J] = numbFillWith++;
                    }
                    break;

                case Right:
                    for (int j = J + 1; j < arr.GetLength(1) && arr[I, j] == 0; j++)
                    {
                        J = j;
                        arr[I, J] = numbFillWith++;
                    }
                    break;

                case Up:
                    for (int i = I - 1; i >= 0 && arr[i, J] == 0; i--)
                    {
                        I = i;
                        arr[I, J] = numbFillWith++;
                    }
                    break;

                case Down:
                    for (int i = I + 1; i < arr.GetLength(0) && arr[i, J] == 0; i++)
                    {
                        I = i;
                        arr[I, J] = numbFillWith++;
                    }
                    break;
            }
        }


        static bool isArrayFilled(int[,] arr)
        {
            foreach (var item in arr)
            {
                if (item == 0) return false;
            }
            return true;
        }

    }

    enum Position
    {
        Right, Down, Left, Up
    }
}
