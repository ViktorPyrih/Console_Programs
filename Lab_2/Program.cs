using Lab_2.Classes;
using Lab_2.Classes.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Entry point

            Console.WriteLine("Print number of task you want run.");
            var n = Console.ReadLine();

            IRunnable _Task = null;

            switch (n)
            {
                case "1":
                    _Task = new Task__1_8();
                    break;

                case "2":
                    _Task = new Task__2_8();
                    break;

                case "3":
                    _Task = new Task__3_8();
                    break;
            }

            _Task?.Run();
        }
    }
}
