using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_wpf.ua.cdu.edu.vu.model
{
    public class Person
    {
        public Person(string name, string surname, DateTime birthday)
        {
            this.Name = name;
            this.Surname = surname;
            this.Birthday = birthday;
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }
    }
}
