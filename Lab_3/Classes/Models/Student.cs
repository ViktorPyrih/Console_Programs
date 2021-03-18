using Newtonsoft.Json;
using System;

namespace Lab_3
{
    class Student
    {
        [JsonProperty]
        public string surName { get; private set; }

        [JsonProperty]
        public string firstName { get; private set; }

        [JsonProperty]
        public string patronymic { get; private set; }

        public string fullName => $"{surName} {firstName} {patronymic}";

        [JsonProperty]
        public char sex { get; private set; }

        [JsonProperty]
        public DateTime dateOfBirth { get; private set; }

        [JsonProperty]
        public byte mathematicsMark { get; private set; }

        [JsonProperty]
        public byte physicsMark { get; private set; }

        [JsonProperty]
        public byte informaticsMark { get; private set; }

        [JsonProperty]
        public int scholarship { get; private set; }

        public Student() { }

        public Student(string line)
        {
            var str = line.Split();

            firstName = str[0];
            surName = str[1];
            patronymic = str[2];
            sex = char.Parse(str[3]);
            dateOfBirth = new DateTime(int.Parse(str[4]), int.Parse(str[5]), int.Parse(str[6]));
            mathematicsMark = byte.Parse(str[7]);
            physicsMark = byte.Parse(str[8]);
            informaticsMark = byte.Parse(str[9]);
            scholarship = int.Parse(str[10] ?? "0");
        }

        public Student(string firstName, string surName, string patronymic, char sex, DateTime dateOfBirth, byte mathematicsMark, byte physicsMark, byte informaticsMark, int scholarship)
        {
            this.firstName = firstName;
            this.surName = surName;
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
