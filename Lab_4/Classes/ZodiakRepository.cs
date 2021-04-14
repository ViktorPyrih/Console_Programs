using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class ZodiakRepository
    {
        public List<Zodiak> zodiaks { get; private set; }

        public ZodiakRepository(List<Zodiak> zodiaks)
        {
            this.zodiaks = zodiaks;
        }


        public List<Zodiak> GetZodiakBySurname(string surname)
            => zodiaks
                .Where(x => x.surname == surname)
                .ToList();

        public void Sort() => zodiaks = zodiaks.OrderBy(x => x).ToList();

    }
}
