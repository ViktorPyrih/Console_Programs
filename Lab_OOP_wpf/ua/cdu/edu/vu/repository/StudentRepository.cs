using Lab_OOP_wpf.ua.cdu.edu.vu.model;
using Lab_OOP_wpf.ua.cdu.edu.vu.repository.sequence;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_wpf.ua.cdu.edu.vu.repository
{
    public class StudentRepository : IRepository<Student>
    {
        private static readonly string STORAGE_FILE = "storage/students.json";

        private LongSequenceGenerator primaryKeyGenerator;
        private ObservableCollection<Student> students;

        public StudentRepository()
        {
            this.students = JsonConvert.DeserializeObject<ObservableCollection<Student>>(File.ReadAllText(STORAGE_FILE));
            this.primaryKeyGenerator = InitPrimaryKeyGenerator();
        }

        private LongSequenceGenerator InitPrimaryKeyGenerator() 
        {
            return new LongSequenceGenerator(students.Max(student => student.Id).GetValueOrDefault(0));
        }

        public void Flush()
            => File.WriteAllText(STORAGE_FILE, JsonConvert.SerializeObject(students));

        public ObservableCollection<Student> FindAll()
        {
            return students;
        }

        public void Save(Student student) 
        {
            student.Id = primaryKeyGenerator.Next();
            students.Add(student);
        }

        public void Delete(Student student)
        {
            students.Remove(student);
        }
    }
}
