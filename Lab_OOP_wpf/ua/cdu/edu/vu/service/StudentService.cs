using Lab_OOP_wpf.ua.cdu.edu.vu.model;
using Lab_OOP_wpf.ua.cdu.edu.vu.repository;
using Lab_OOP_wpf.ua.cdu.edu.vu.component;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_wpf.ua.cdu.edu.vu.service
{
    public class StudentService
    {

        private readonly IRepository<Student> repository = RepositoryProvider.GetStudentRepository();

        public ObservableCollection<Student> GetAllStudents() 
        {
            return repository.FindAll();
        }

        public void AddStudent(Student student) 
        {
            repository.Save(student);
        }

        public void DeleteStudent(Student student) 
        {
            repository.Delete(student);
        }

        public void SaveStudents() 
        {
            repository.Flush();
        }
    }
}
