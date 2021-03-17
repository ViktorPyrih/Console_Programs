using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class Student
    {
        public string surName { get; }
        public string firstName { get; }
        public string patronymic { get; }

        public string fullName => $"{surName} {firstName} {patronymic}";

        public char sex { get; }

        public DateTime dateOfBirth { get; }

        public char mathematicsMark { get; }
        public char physicsMark { get; }
        public char informaticsMark { get; }

        public int scholarship { get; }
        
        public Student(string line)
        {

        }

        public Student(string surName, string firstName, string patronymic, char sex, DateTime dateOfBirth, char mathematicsMark, char physicsMark, char informaticsMark, int scholarship)
        {
            this.surName = surName;
            this.firstName = firstName;
            this.patronymic = patronymic;
            this.sex = sex;
            this.dateOfBirth = dateOfBirth;
            this.mathematicsMark = mathematicsMark;
            this.physicsMark = physicsMark;
            this.informaticsMark = informaticsMark;
            this.scholarship = scholarship;
        }
    }
}
