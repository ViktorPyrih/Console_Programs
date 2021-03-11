using System;
using System.Collections.Generic;
using Lab_2.Classes;
using Lab_2.Classes.Tasks;

namespace Lab_2
{
    internal static class Program
    {
        public record User(string Name, IList<Type> Tasks);

        private static readonly User[] Users =
        {
            new("Denis", new[] { typeof(Task__1_10), typeof(Task__2_10), typeof(Task__3_10) }),
            new("Igor", new[] { typeof(Task__1_8), typeof(Task__2_8), typeof(Task__3_8)})
        };
        
        public static void Main()
        {
            while (true)
            {
                try
                {
                    Run(); // Entry point
                }
                catch (Exception)
                {
                    Console.WriteLine("Unfortunately something went wrong!");
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private static void Run()
        {
            Console.WriteLine("Choose block to run (print 0 to exit):");

            int block;
            while (!int.TryParse(Console.ReadLine(), out block).Equals(true)){}
            
            if (block == 0) Environment.Exit(0);

            Console.WriteLine("Choose task to run:");
            PrintUsers(block);
            
            int task;
            while (!int.TryParse(Console.ReadLine(), out task).Equals(true)){}

            ((IRunnable) Activator.CreateInstance(Users[task-1].Tasks[block-1]))?.Run();
        }

        private static void PrintUsers(int block)
        {
            for (int i = 0; i < Users.Length; ++i)
                Console.WriteLine($"{i+1} {Users[i].Name} + {Users[i].Tasks[block-1].Name}");
        }
    }
}
