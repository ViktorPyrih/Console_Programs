using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_1
{

    struct Student : IComparable<Student>
    {
        public string name;
        public string surName;
        public DateTime birthday;
        public double scholarship;
        public Type type;

        public Student(string name, string surName, DateTime birthday, double scholarship, Type type)
        {
            this.name = name;
            this.surName = surName;
            this.birthday = birthday;
            this.scholarship = scholarship;
            this.type = type;
        }

        public int CompareTo(Student other)
        {
            return birthday.CompareTo(other.birthday);
        }

        public override string ToString()
        {
            return name + " " + surName + " " + type;
        }
    }

    enum Type
    {
        BoyNextDoor, DungeonMaster
    }

    class Program
    {
        static void Main(string[] args)
        {
            var student_1 = new Student("Ivan", "Ivanovich", new DateTime(2001, 03, 15), 1400, Type.BoyNextDoor);
            var student_2 = new Student("Ivan 2", "Ivanovich", new DateTime(2000, 04, 15), 1400, Type.BoyNextDoor);
            var student_3 = new Student("Ivan", "Ivanovich", new DateTime(1998, 03, 15), 1200, Type.DungeonMaster);

            Console.WriteLine(student_1.CompareTo(student_2));

            var students = new Student[3] { student_1, student_2, student_3 };

            Array.Sort(students);

            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(students[i]);
            }
        }
    }
}
