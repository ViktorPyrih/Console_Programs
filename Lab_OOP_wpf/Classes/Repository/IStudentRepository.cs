using Lab_OOP_wpf.Classes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_wpf.Classes.Repository
{
    interface IStudentRepository
    {
        ObservableCollection<Student> Load(string location);

        void Store(ObservableCollection<Student> students, string location);
    }
}
