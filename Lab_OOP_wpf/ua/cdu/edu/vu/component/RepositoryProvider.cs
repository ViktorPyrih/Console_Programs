using Lab_OOP_wpf.ua.cdu.edu.vu.repository;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_wpf.ua.cdu.edu.vu.component
{
    public static class RepositoryProvider
    {
        private static StudentRepository studentRepository;

        static RepositoryProvider() 
        {
            Directory.SetCurrentDirectory("..");
            Directory.SetCurrentDirectory("..");
        }

        public static StudentRepository GetStudentRepository() 
        {
            if (studentRepository is null) 
            {
                studentRepository = new StudentRepository();
            }

            return studentRepository;
        }
    }
}
