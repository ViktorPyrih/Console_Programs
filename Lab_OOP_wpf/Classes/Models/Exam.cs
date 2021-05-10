using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_wpf.Classes.Models
{
    class Exam : ICloneable, IEquatable<Exam>
    {
        public Exam(string name, byte mark, DateTime exam_day)
        {
            this.name = name;
            this.mark = mark;
            this.exam_day = exam_day;
        }

        public string name { get; set; }

        public byte mark { get; set; }

        public DateTime exam_day { get; set; }


        public object Clone() => new Exam(name, mark, exam_day);

        public bool Equals(Exam other)
        {
            return
                other != null &&
                name.Equals(other.name) &&
                mark.Equals(other.mark) &&
                exam_day.Equals(other.exam_day);
        }
    }
}
