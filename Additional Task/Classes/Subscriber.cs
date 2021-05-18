using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Additional_Task.Classes
{
    class Subscriber : ICloneable
    {
        public Subscriber(string surname, string phoneNumber)
        {
            this.surname = surname;
            this.phoneNumber = phoneNumber;
        }

        public string surname { get; }

        public string phoneNumber { get; }


        public object Clone() => new Subscriber(surname, phoneNumber);

        public override string ToString() => $"{surname} - {phoneNumber}";
    }
}
