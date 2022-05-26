using Lab_OOP_wpf.ua.cdu.edu.vu.model;
using Lab_OOP_wpf.ua.cdu.edu.vu.utils;
using Lab_OOP_wpf.ua.cdu.edu.vu.view_model.helper;

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
        private ViewHelper<Exam> viewHelper;
        private Student student;

        public ExamsView(Student student)
        {
            InitializeComponent();
            this.viewHelper = new ExamsViewHelper(ExamNameTxtBox, ExamMarkTxtBox, ExamCalendar, ExamTime);
            this.student = student;
            OnLoad();
        }

        private void OnLoad()
        {
            Title = $"Exams of {student.Person.Name} {student.Person.Surname}";
            ExamsTable.ItemsSource = student.Exams;
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            if (!viewHelper.ValidateRecord()) 
            {
                return;
            }

            student.AddExam(viewHelper.ConvertRecord());

            viewHelper.CLear();
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e) 
        {
            Exam exam = (sender as Button).DataContext as Exam;
            student.DeleteExam(exam);
        }

        private void ViewClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = viewHelper.OnClose(exam => student.AddExam(exam));
        }
    }
}
