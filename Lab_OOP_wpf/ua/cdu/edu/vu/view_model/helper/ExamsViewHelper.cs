using Lab_OOP_wpf.ua.cdu.edu.vu.model;
using Lab_OOP_wpf.ua.cdu.edu.vu.utils;

using MaterialDesignThemes.Wpf;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lab_OOP_wpf.ua.cdu.edu.vu.view_model.helper
{
    public class ExamsViewHelper : ViewHelper<Exam>
    {
        private TextBox examNameBox;
        private TextBox examMarkBox;
        private DatePicker examDatePicker;
        private TimePicker examTimePicker;

        public ExamsViewHelper(TextBox examNameBox, TextBox examMarkBox, DatePicker examDatePicker, TimePicker examTimePicker)
        {
            this.examNameBox = examNameBox;
            this.examMarkBox = examMarkBox;
            this.examDatePicker = examDatePicker;
            this.examTimePicker = examTimePicker;
        }

        public override bool ValidateRecord() 
        {
            var (name, mark) = (examNameBox.Text, examMarkBox.Text);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(mark))
            {
                MessageBox.Show("Name or mark is empty.");
                return false;
            }

            if (!ValidationUtils.isValidMark(mark))
            {
                MessageBox.Show("Mark field is not valid.");
                return false;
            }

            return true;
        }

        protected override bool IsRecordEmpty() 
        {
            var (name, mark) = (examNameBox.Text, examMarkBox.Text);
            return string.IsNullOrEmpty(name) && string.IsNullOrEmpty(mark);
        }

        public override Exam ConvertRecord() 
        {
            var (name, mark) = (examNameBox.Text, examMarkBox.Text);

            var examTime = examTimePicker.SelectedTime.GetValueOrDefault(DateTime.Now);
            var examDate = examDatePicker.SelectedDate.GetValueOrDefault(DateTime.Now)
                .Add(examTime.TimeOfDay);

            return new Exam(name, byte.Parse(mark), examDate);
        }

        public override void CLear()
        {
            examNameBox.Text = string.Empty;
            examMarkBox.Text = string.Empty;
            examDatePicker.Text = string.Empty;
            examTimePicker.Text = string.Empty;
        }
    }
}
