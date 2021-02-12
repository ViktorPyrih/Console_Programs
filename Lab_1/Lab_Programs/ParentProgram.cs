using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Lab_Programs
{
    abstract class ParentProgram
    {
        protected int[,] array;

        public ParentProgram()
        {
            Extensions.InputType(out array);
            array.Print();
        }
    }
}
