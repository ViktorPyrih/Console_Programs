using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    static class StudentsRepository
    {
        public static readonly string PATH = Environment.CurrentDirectory + @"\Saves.json";

        public static List<Student> GetStudentsFromFile() 
            => JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(PATH));

        private static readonly List<Student> dictionary = new List<Student>
        {
            new Student("Victor", "Pavlov", "Egorovich", 'M', new DateTime(2000, 06, 01), 2, 3, 3, 0),
            new Student("Katerina", "Zabolotna", "Andriivna", 'F', new DateTime(1998, 08, 06), 5, 5, 5, 2000),
            new Student("Andrew", "Steel", "Igorovich", 'M', new DateTime(1997, 12, 31), 2, 3, 2, 0),
            new Student("Keanu", "Reeves", "Yeah", 'M', new DateTime(2001, 11, 29), 5, 4, 5, 1500),
            new Student("John", "Wick", "Cool", 'M', new DateTime(1999, 10, 05), 2, 3, 2, 0),
            new Student("Madam", "Dzerdginski", "Viktorovna", 'F', new DateTime(2000, 05, 05), 3, 3, 3, 0),
            new Student("Johnny", "Silverhand", "Cyber", 'M', new DateTime(2001, 07, 12), 4, 5, 4, 1000),
            new Student("Christopher", "Lloyd", "Allen", 'M', new DateTime(2002, 08, 15), 4, 4, 2, 0),
            new Student("Illya", "Prusikin", "Vladimirovich", 'M', new DateTime(1998, 09, 25), 4, 5, 4, 500),
            new Student("Alina", "Pavlovna", "Nikitivna", 'F', new DateTime(1999, 04, 10), 2, 2, 4, 0)
        };

        public static void FillDocument() 
            => File.WriteAllText(PATH, JsonConvert.SerializeObject(dictionary));
    }
}
