using Lab_OOP_wpf.ua.cdu.edu.vu.component;
using Lab_OOP_wpf.ua.cdu.edu.vu.model;
using Lab_OOP_wpf.ua.cdu.edu.vu.service;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lab_OOP_wpf.ua.cdu.edu.vu.view_model
{
    public class StudentViewModel : PropertyChangedNotifier
    {
        private readonly StudentService studentService = ServiceProvider.GetStudentService();

        public void Bind(DataGrid studentsTable) 
        {
            studentsTable.ItemsSource = studentService.GetAllStudents();
        }

        public void AddStudent(Student student) 
        {
            studentService.AddStudent(student);
        }

        public void DeleteStudent(Student student) 
        {
            studentService.DeleteStudent(student);
        }

        public void SaveStudentsToStorage() 
        {
            studentService.SaveStudents();
        }
    }
}
