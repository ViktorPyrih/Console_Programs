using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_wpf.ua.cdu.edu.vu.repository.sequence
{
    public class LongSequenceGenerator : ISequenceGenerator<long>
    {
        private long currentValue;

        public LongSequenceGenerator()
        {
        }

        public LongSequenceGenerator(long initialValue)
        {
            this.currentValue = initialValue;
        }

        public long Next() 
        {
            return ++currentValue;
        }
    }
}
