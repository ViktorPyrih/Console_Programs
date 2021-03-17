using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab_3
{
    public class User
    {
        public string Name { get; }
        public IList<Type> Tasks { get; }

        public User(string name, IList<Type> tasks) => (Name, Tasks) = (name, tasks);

        public override string ToString() 
            => $"{Name} - {string.Join(", ", Tasks.Select(x => x.Name.Remove(4, 1).Replace('_', ' ')))}";

        public static void PrintUsers(List<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }

        public void RunTask(int task) 
            => ((IRunnable)Activator.CreateInstance(Tasks[task]))?.Run();
    }
}