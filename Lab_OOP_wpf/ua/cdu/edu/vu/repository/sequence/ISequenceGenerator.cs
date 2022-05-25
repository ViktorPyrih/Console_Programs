using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_wpf.ua.cdu.edu.vu.repository.sequence
{
    public interface ISequenceGenerator<E>
    {
        E Next();
    }
}
