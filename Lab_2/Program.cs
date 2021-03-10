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
                case "18":
                    _Task = new Task__1_8();
                    break;

                case "28":
                    _Task = new Task__2_8();
                    break;

                case "38":
                    _Task = new Task__3_8();
                    break;

                case "110":
                    _Task = new Task__1_10();
                    break;

                case "210":
                    _Task = new Task__2_10();
                    break;

                case "310":
                    _Task = new Task__3_10();
                    break;

                default:
                    Main(new string[0]);
                    break;
            }

            _Task?.Run();
        }
    }
}
