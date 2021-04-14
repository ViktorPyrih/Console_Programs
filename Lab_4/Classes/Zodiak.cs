using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class Zodiak : IComparable
    {
        [JsonProperty]
        public string name { get; private set; }

        [JsonProperty]
        public string surname { get; private set; }

        [JsonProperty]
        public ZodiakTypes zodiakType { get; private set; }

        [JsonProperty]
        public DateTime birthday { get; private set; }


        public Zodiak() { }

        public Zodiak(string name, string surname, ZodiakTypes zodiakType, DateTime birthday)
        {
            this.name = name;
            this.surname = surname;
            this.zodiakType = zodiakType;
            this.birthday = birthday;
        }

        public override string ToString()
            => $"{name} {surname} {zodiakType} {birthday.Day}.{birthday.Month}.{birthday.Year}";

        public int CompareTo(object obj)
        {
            if (obj is Zodiak)
            {
                var other_zodiak = obj as Zodiak;

                var comp_1 = birthday.CompareTo(other_zodiak.birthday);
                if (comp_1 != 0) return comp_1;

                var comp_2 = name.CompareTo(other_zodiak.name);
                if (comp_2 != 0) return comp_2;

                var comp_3 = surname.CompareTo(other_zodiak.surname);
                if (comp_3 != 0) return comp_3;

                return zodiakType.CompareTo(other_zodiak.zodiakType);
            }
            else return -1;
        }
    }
}
