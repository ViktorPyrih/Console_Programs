using Lab_OOP_wpf.ua.cdu.edu.vu.repository.sequence;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_wpf.ua.cdu.edu.vu.repository
{
    public interface IRepository<T>
    {
        void Flush();

        ObservableCollection<T> FindAll();

        void Save(T entity);

        void Delete(T entity);
    }
}
