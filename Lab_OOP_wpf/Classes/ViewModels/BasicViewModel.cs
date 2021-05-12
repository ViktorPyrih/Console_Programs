using Lab_OOP_wpf.Classes.Extensions;
using Lab_OOP_wpf.Classes.Models;
using Lab_OOP_wpf.Classes.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_wpf.Classes.ViewModels
{
    abstract class BasicViewModel : PropertyChangedNotifier
    {
        private ObservableCollection<Student> Students;
        public ObservableCollection<Student> students
        {
            get => Students;
            protected set
            {
                Students = value;
                OnPropertyChanged(nameof(Students));
            }
        }

        private StudentRepository studentRepository = new StudentRepository();

        public void Load(string url) => students = studentRepository.Load(url);

        public void Store(string url) => studentRepository.Store(students, url);

    }
}
