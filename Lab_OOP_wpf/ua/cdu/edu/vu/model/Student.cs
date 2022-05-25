using Lab_OOP_wpf.ua.cdu.edu.vu.component;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_wpf.ua.cdu.edu.vu.model
{
    public class Student : PropertyChangedNotifier, IEqualityComparer<Student>
    {
        public Student(Person person, EducationalLevel educationalLevel)
        {
            this.person = person;
            this.educationalLevel = educationalLevel;
            this.exams = new ObservableCollection<Exam>();
        }

        public long? Id { get; set; }

        private Person person;

        public Person Person
        {
            get => person;
            set
            {
                person = value;
                OnPropertyChanged(nameof(Person));
            }
        }

        private EducationalLevel educationalLevel;

        public EducationalLevel EducationalLevel
        {
            get => educationalLevel;
            set
            {
                educationalLevel = value;
                OnPropertyChanged(nameof(EducationalLevel));
            }
        }

        private ObservableCollection<Exam> exams;

        public ObservableCollection<Exam> Exams 
        {
            get => exams;
            set
            {
                exams = value ?? new ObservableCollection<Exam>();
            }
        }

        public void AddExam(Exam exam) 
        {
            exams.Add(exam);
        }

        public void DeleteExam(Exam exam) 
        {
            exams.Remove(exam);
        }

        public bool Equals(Student x, Student y)
        {
            return x.Id.GetValueOrDefault() == y.Id.GetValueOrDefault();
        }

        public int GetHashCode(Student obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
