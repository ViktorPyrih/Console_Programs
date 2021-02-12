using Lab_1.Lab_Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            IProgram program = null;

            Console.WriteLine("Choose task from 1 to 4 or additional - 'add':");
            switch (Console.ReadLine())
            {
                case "1":
                    program = new Block_1_v15();
                    break;
                case "2":
                    program = new Block_2_v15();
                    break;
                case "3":
                    program = new Block_3_v12();
                    break;
                case "4":
                    program = new Block_4_v12();
                    break;
                case "add":
                    program = new AdditionalProgram_1();
                    break;
            }

            program?.Run();
        }
    }
}
