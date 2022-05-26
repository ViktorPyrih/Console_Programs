using Lab_OOP_wpf.ua.cdu.edu.vu.model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lab_OOP_wpf.ua.cdu.edu.vu.view_model.helper
{
    public class StudentsViewHelper : ViewHelper<Student>
    {
        private TextBox studentNameBox;
        private TextBox studentSurnameBox;
        private ComboBox educationComboBox;
        private DatePicker dobCalendar;

        public StudentsViewHelper(TextBox studentNameBox, TextBox studentSurnameBox, ComboBox educationComboBox, DatePicker dobCalendar)
        {
            this.studentNameBox = studentNameBox;
            this.studentSurnameBox = studentSurnameBox;
            this.educationComboBox = educationComboBox;
            this.dobCalendar = dobCalendar;
        }

        public override bool ValidateRecord() 
        {
            var (name, surname) = (studentNameBox.Text, studentSurnameBox.Text);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname))
            {
                MessageBox.Show("Name or surname is empty.");
                return false;
            }

            if (educationComboBox.SelectedItem is null)
            {
                MessageBox.Show("Educational level is empty.");
                return false;
            }

            return true;
        }

        protected override bool IsRecordEmpty() 
        {
            var (name, surname) = (studentNameBox.Text, studentSurnameBox.Text);
            return string.IsNullOrEmpty(name) && string.IsNullOrEmpty(surname) 
                && educationComboBox.SelectedItem is null;
        }

        public override Student ConvertRecord() 
        {
            var (name, surname) = (studentNameBox.Text, studentSurnameBox.Text);
            return new Student(new Person(name, surname, dobCalendar.SelectedDate.GetValueOrDefault(DateTime.Now)),
                (EducationalLevel)educationComboBox.SelectedItem);
        }

        public override void CLear()
        {
            studentNameBox.Text = string.Empty;
            studentSurnameBox.Text = string.Empty;
            educationComboBox.Text = string.Empty;
            dobCalendar.Text = string.Empty;
        }
    }
}
