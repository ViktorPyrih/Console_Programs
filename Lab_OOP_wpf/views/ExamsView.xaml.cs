using Lab_OOP_wpf.ua.cdu.edu.vu.model;
using Lab_OOP_wpf.ua.cdu.edu.vu.utils;

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Lab_OOP_wpf.views
{
    /// <summary>
    /// Interaction logic for ExamsView.xaml
    /// </summary>
    partial class ExamsView : Window
    {
        private Student student;

        public ExamsView(Student student)
        {
            InitializeComponent();
            this.student = student;
            OnLoad();
        }

        private void OnLoad()
        {
            Title = $"Exams of {student.Person.Name} {student.Person.Surname}";
            ExamsTable.ItemsSource = student.Exams;
        }

        private void ExamsTableAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = ((PropertyDescriptor)e.PropertyDescriptor)?.DisplayName ?? e.Column.Header;
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            var (name, mark) = (ExamNameTxtBox.Text, ExamMarkTxtBox.Text);

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(mark))
            {
                MessageBox.Show("Name or mark is empty.");
                return;
            }

            if (!ValidationUtils.isValidMark(ExamMarkTxtBox.Text)) 
            {
                MessageBox.Show("Mark field is not valid.");
            }

            var examTime = ExamTime.SelectedTime.GetValueOrDefault(DateTime.Now);
            var examDate = ExamCalendar.SelectedDate.GetValueOrDefault(DateTime.Now)
                .Add(examTime.TimeOfDay);
            student.AddExam(new Exam(name, byte.Parse(mark), examDate));
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e) 
        {
            Exam exam = (sender as Button).DataContext as Exam;
            student.DeleteExam(exam);
        }
    }
}
