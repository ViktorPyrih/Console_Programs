using System;

namespace Lab_2
{
    public record User
    {
        public string Name { get; }
        public Type[] Tasks { get; }
        public User(string name, Type[] tasks) => (Name, Tasks) = (name, tasks);
    }
}