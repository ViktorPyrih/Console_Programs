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
            this.exams = exams == null ? new ObservableCollection<Exam>() { } : exams;
        }


        private Person Person;

        public Person person
        {
            get => Person;
            set
            {
                Person = value;
                OnPropertyChanged(nameof(Person));
            }
        }


        private EducationalLevel ObtainedEducationalLevel;

        public EducationalLevel obtainedEducationalLevel
        {
            get => ObtainedEducationalLevel;
            set
            {
                ObtainedEducationalLevel = value;
                OnPropertyChanged(nameof(ObtainedEducationalLevel));
            }
        }


        private ObservableCollection<Exam> Exams;

        public ObservableCollection<Exam> exams
        {
            get => Exams;
            set
            {
                Exams = value;
                OnPropertyChanged(nameof(Exams));
            }
        }


        public void AddExam(Exam exam) 
        {
            Exams.Add(exam ?? throw new NullReferenceException("You're trying to put 'null' into exams."));
            OnPropertyChanged(nameof(Exams));
        }

        public object Clone() => new Student(Person.Clone() as Person, obtainedEducationalLevel, exams.Clone() as ObservableCollection<Exam>);

        public bool Equals(Student other)
        {
            return
                other != null &&
                person.Equals(other.person) &&
                obtainedEducationalLevel.Equals(other.obtainedEducationalLevel) &&
                EqualityComparer<ObservableCollection<Exam>>.Default.Equals(exams, other.exams);
        }


        public override string ToString()
            => $"Student {person}, {obtainedEducationalLevel}{(exams.Count > 0 ? $";\nExams: {string.Join("\n\t", exams)}" : "")}.";

        public string ToShortString()
            => $"Student {person.surname} : {(exams.Count > 0 ? exams.Average(x => (int)x.mark).ToString() : "No marks")}";
    }
}
