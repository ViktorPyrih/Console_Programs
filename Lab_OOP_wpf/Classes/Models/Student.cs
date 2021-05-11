using Lab_OOP_wpf.Classes.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_wpf.Classes.Models
{
    //https://github.com/eXCoreX/Uni_OOP_2nd/blob/master/Lab%203/Lab_3/Models/Magazine.cs

    class Student : PropertyChangedNotifier, ICloneable, IEquatable<Student>
    {
        public Student(Person person, EducationalLevel obtainedEducationalLevel, ObservableCollection<Exam> exams = null)
        {
            this.person = person;
            this.obtainedEducationalLevel = obtainedEducationalLevel;
            this.exams = exams ?? new ObservableCollection<Exam>();
        }

        public Person person { get; private set; }

        public EducationalLevel obtainedEducationalLevel { get; private set; }

        public ObservableCollection<Exam> exams
        {
            get => exams;
            set
            {
                exams = value;
                OnPropertyChanged(nameof(exams));
            }
        }


        public void AddExam(Exam exam) => exams.Add(exam ?? throw new NullReferenceException("You are trying to put 'null' into exams."));

        public object Clone() => new Student(person.Clone() as Person, obtainedEducationalLevel, exams.Clone() as ObservableCollection<Exam>);

        public bool Equals(Student other)
        {
            return
                other != null &&
                person.Equals(other.person) &&
                obtainedEducationalLevel.Equals(other.obtainedEducationalLevel) &&
                EqualityComparer<ObservableCollection<Exam>>.Default.Equals(exams, other.exams);
        }


        public override string ToString()
            => $"Student {person}, {obtainedEducationalLevel};\nExams: {string.Join("\n\t", exams)}.";

        public string ToShortString()
            => $"Student {person.surname} : {exams.Average(x => (int)x.mark)}";
    }
}
