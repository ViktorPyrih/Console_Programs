using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.Classes
{
    abstract class BaseInit_TwoDim : TaskPrint
    {
        protected int[][] array;

        public BaseInit_TwoDim(string Text) : base(Text)
        {
            Console.WriteLine("Input type:");
            InputType.ArrayWithArrays(out array);
            Console.WriteLine("Base array:");
            array.Print();
        }
    }
}
