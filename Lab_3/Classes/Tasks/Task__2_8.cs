using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lab_3.Classes.Tasks
{
    public class Task__2_8 : IRunnable
    {
        private static DateTime GetCurrentGetDateTime() => DateTime.Now;
        
        public void Run()
        {
            List<Student> students = StudentsRepository.GetStudentsFromFile();

            List<Student> selectedStudents = students
                .Where(student => GetAge(student) < 16).ToList();

            Console.WriteLine($"Number of students younger than 16: {selectedStudents.Count}\n");

            foreach (var student in selectedStudents)
                PrintData(student);
        }

        private int GetAge(Student student)
        {
            DateTime birthdate = student.dateOfBirth;
            DateTime now = GetCurrentGetDateTime();
            
            int age = now.Year - birthdate.Year;
            
            if (birthdate.Date > now.AddYears(-age)) --age;
            
            return age;
        }

        private void PrintData(Student student)
        {
            PropertyInfo[] properties = student.GetType().GetProperties();
            
            foreach (var property in properties)
                Console.WriteLine($"{property.Name} - {property.GetValue(student)}");
            Console.WriteLine();
        }
    }
}