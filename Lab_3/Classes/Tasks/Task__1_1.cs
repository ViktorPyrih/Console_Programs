using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class Task__1_1 : IRunnable
    {
        public void Run()
        {
            var time_1 = new MyTime(14, 19, 4);
            Console.WriteLine("First date - " + time_1);

            Console.WriteLine("What lesson of first - " + time_1.WhatLesson());

            time_1.AddSeconds(125);
            Console.WriteLine("Adding 125 sec to first\n" + time_1);

            Console.WriteLine("What lesson of first - " + time_1.WhatLesson());

            var sec = MyTime.TimeSinceMidnight(time_1);
            Console.WriteLine(sec + " sec since midnight of first");

            Console.WriteLine("back from sec to first date: " + MyTime.TimeSinceMidnight(sec));

            var time_2 = new MyTime(15, 20, 7);
            Console.WriteLine("Second date - " + time_2);

            Console.WriteLine("What lesson of second - " + time_2.WhatLesson());

            var gap = MyTime.DifferenceBetween(time_1, time_2);
            Console.WriteLine("Difference between first & second: " + gap);

        }
    }
}
