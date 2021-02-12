using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Lab_Programs
{
    abstract class AutoFilledArray
    {
        protected int[,] array;

        public AutoFilledArray()
        {
            Extensions.InputType(out array);
            array.Print();
        }
    }
}
