using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.Classes
{
    abstract class TaskPrint
    {
        public TaskPrint(string Text)
        {
            Console.WriteLine("Task: " + Text);
        }
    }
}
