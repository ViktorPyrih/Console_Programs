using System;
using System.Collections.Generic;
using Lab_2.Classes;
using Lab_2.Classes.Tasks;

namespace Lab_2
{
    internal static class Program
    {
        private static readonly List<User> users = new List<User>
        {
            new User("Denis", new[] { typeof(Task__1_10), typeof(Task__2_10), typeof(Task__3_10)}),
            new User("Igor", new[] { typeof(Task__1_8), typeof(Task__2_8), typeof(Task__3_8)})
        };
        
        public static void Main()
        {
            User.PrintUsers(users);

            Console.WriteLine("Choose user to run (print 0 to exit):");
            int.TryParse(Console.ReadLine(), out int user_code);

            if (user_code == 0) Environment.Exit(0);

            Console.WriteLine(users[user_code - 1]);

            Console.WriteLine("Choose task to run:");
            int.TryParse(Console.ReadLine(), out int task);

            Console.WriteLine($"Trying start task {users[user_code - 1].Tasks[task - 1].Name}...");
            users[user_code - 1].RunTask(task - 1);

            Console.ReadKey();
        }
    }
}
