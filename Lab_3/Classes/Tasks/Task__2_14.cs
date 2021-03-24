using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class Task__2_14 : IRunnable
    {
        public void Run()
        {
            List<Student> students = StudentsRepository.ChooseTypeOfGettingStudents();

            var average_mark = students
                .Select(x => (x.informaticsMark + x.mathematicsMark + x.physicsMark) / 3)
                .Average();

            Console.WriteLine("Average mark is " + average_mark);

            var students_with_good_marks = students
                .Where(x => ((x.informaticsMark + x.mathematicsMark + x.physicsMark) / 3) > average_mark)
                .ToList();

            Console.WriteLine(string.Join("\n", students_with_good_marks
                .Select(x => x.surName)
                .ToList()));
        }
    }
}
