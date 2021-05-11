using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_wpf.Classes.Models
{
    class Person : ICloneable, IEquatable<Person>
    {
        public Person(string name, string surname, DateTime birthday)
        {
            this.name = name;
            this.surname = surname;
            this.birthday = birthday;
        }

        public string name { get; set; }

        public string surname { get; set; }

        public DateTime birthday { get; set; }


        public object Clone() => new Person(name, surname, birthday);

        public bool Equals(Person other)
        {
            return
                other != null &&
                name.Equals(other.name) &&
                surname.Equals(other.surname) &&
                birthday.Equals(other.birthday);
        }

        public override string ToString()
            => $"{name} {surname} birthay: {birthday.Day}.{birthday.Month}.{birthday.Year}";
    }
}
