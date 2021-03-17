using Lab_3.Classes.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class Program
    {
        private static readonly List<User> users = new List<User>
        {
            //new User("Denis", new[] { }),
            new User("Igor", new[] { typeof(Task__1_1) })
        };

        static void Main(string[] args)
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
        }
    }
}
