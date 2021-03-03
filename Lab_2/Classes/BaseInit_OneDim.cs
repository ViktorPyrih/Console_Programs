using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.Classes
{
    abstract class BaseInit_OneDim : TaskPrint
    {
        protected int[] array;

        public BaseInit_OneDim(string Text) : base(Text)
        {
            InputType.OneDimension_Array(out array);
            Console.WriteLine("Base array:");
            array.Print();
        }
    }
}
