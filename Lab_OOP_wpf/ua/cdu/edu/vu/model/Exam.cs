using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_wpf.ua.cdu.edu.vu.model
{
    public class Exam
    {
        public Exam(string name, byte mark, DateTime examDay)
        {
            Name = name;
            Mark = mark;
            ExamDate = examDay;
        }

        public string Name { get; set; }

        public byte Mark { get; set; }

        public DateTime ExamDate { get; set; }
    }
}
