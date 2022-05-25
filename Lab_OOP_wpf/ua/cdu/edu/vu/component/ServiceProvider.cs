using Lab_OOP_wpf.ua.cdu.edu.vu.service;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_wpf.ua.cdu.edu.vu.component
{
    public static class ServiceProvider
    {
        private static StudentService studentService;

        public static StudentService GetStudentService()
        {
            if (studentService is null)
            {
                studentService = new StudentService();
            }

            return studentService;
        }
    }
}
