using System;
using Lab_3.Classes.Models;

namespace Lab_3.Classes.Tasks
{
    public class Task__1_2 : IRunnable
    {
        public void Run()
        {
            MyFrac fraction1 = new MyFrac(5, 4);
            MyFrac fraction2 = new MyFrac(-1, 2);
            MyFrac fraction3 = new MyFrac(-5);

            Console.WriteLine((double) fraction1);
            Console.WriteLine(fraction1.ToString());
            Console.WriteLine(fraction1.ToStringWithIntegerPart());
            
            Console.WriteLine(-fraction1);
            Console.WriteLine(fraction1 + fraction2);
            Console.WriteLine(fraction1 - fraction2);
            Console.WriteLine(fraction1 * fraction2);
            Console.WriteLine(fraction1 / fraction2);
            
            Console.WriteLine(fraction3.ToString());
        }
    }
}