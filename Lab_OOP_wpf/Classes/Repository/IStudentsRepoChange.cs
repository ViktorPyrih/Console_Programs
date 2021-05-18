using Lab_OOP_wpf.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_wpf.Classes.Repository
{
    interface IStudentsRepoChange
    {

        void AddStudent(Student student);

        void RemoveStudent(Student student);

        void RemoveStudentAt(int index);
    
    }
}
