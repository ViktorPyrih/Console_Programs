using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class Zodiak
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
    }
}
