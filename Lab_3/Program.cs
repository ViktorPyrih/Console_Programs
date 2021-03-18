using System;
using System.Collections.Generic;
using Lab_3.Classes.Tasks;

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

            try
            {
                Console.WriteLine(users[user_code - 1]);

                Console.WriteLine("Choose task to run:");
                int.TryParse(Console.ReadLine(), out int task);

                StudentsRepository.FillDocument();

                Console.WriteLine($"Trying start {users[user_code - 1].Tasks[task - 1].Name}...\n");
                users[user_code - 1].RunTask(task - 1);

            }
            catch (Exception e) 
            {
                Console.WriteLine("Something went wrong...\n" + e);
            }
            
        }
    }
}
