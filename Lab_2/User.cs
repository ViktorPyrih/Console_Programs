using System;
using System.Collections.Generic;

namespace Lab_2
{
    public readonly struct User
    {
        public string Name { get; }
        public IList<Type> Tasks { get; }

        public User(string name, IList<Type> tasks) => (Name, Tasks) = (name, tasks);
    }
}