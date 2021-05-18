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
    class TestViewModel : BasicViewModel, IStudentsRepoChange
    {
        
        public TestViewModel()
        {
            var student1 = new Student(new Person("Ivan", "Ivanovich", new DateTime(2001, 12, 20)), EducationalLevel.Bachelor);
            var student2 = new Student(new Person("Petya", "Zabolotniy", new DateTime(1999, 10, 15)), EducationalLevel.Bachelor);
            var student3 = new Student(new Person("Grisha", "Rzhanoi", new DateTime(1997, 05, 12)), EducationalLevel.Master);
            var student4 = new Student(new Person("Denis", "Golden", new DateTime(1995, 09, 02)), EducationalLevel.Specialist);

            students = new ObservableCollection<Student> { student1, student2, student3, student4 };

            var math_exam = new Exam("Math", 5, new DateTime(2021, 05, 25));

            students[0].AddExam(math_exam);
        }

        public void AddStudent(Student student) => students.Add(student);

        public void RemoveStudent(Student student) => students.Remove(student);

        public void RemoveStudentAt(int index) => students.RemoveAt(index);

    }
}
