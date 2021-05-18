using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_wpf.Classes.Models
{
    public class Exam : ICloneable, IEquatable<Exam>
    {
        public Exam(string name, byte mark, DateTime exam_day)
        {
            this.name = name;
            this.mark = mark;
            this.exam_day = exam_day;
        }

        [DisplayName("Exam Name")]
        public string name { get; }

        [DisplayName("Mark")]
        public byte mark { get; }

        [DisplayName("Exam Date")]
        public DateTime exam_day { get; }


        public object Clone() => new Exam(name, mark, exam_day);

        public bool Equals(Exam other)
        {
            return
                other != null &&
                name.Equals(other.name) &&
                mark.Equals(other.mark) &&
                exam_day.Equals(other.exam_day);
        }

        public override string ToString()
            => $"{name} - {mark} ({exam_day.Day}.{exam_day.Month}.{exam_day.Year})";
    }
}
