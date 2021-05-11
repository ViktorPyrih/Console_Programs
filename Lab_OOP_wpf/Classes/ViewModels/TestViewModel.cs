using Lab_OOP_wpf.Classes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_wpf.Classes.ViewModels
{
    class TestViewModel : BasicViewModel
    {
        public ObservableCollection<Student> students_repos { get; private set; }




    }
}
