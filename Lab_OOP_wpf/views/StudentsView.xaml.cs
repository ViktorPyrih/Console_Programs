using Lab_OOP_wpf.ua.cdu.edu.vu.model;
using Lab_OOP_wpf.ua.cdu.edu.vu.view_model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_OOP_wpf.views
{
    /// <summary>
    /// Логика взаимодействия для StudentsView.xaml
    /// </summary>
    public partial class StudentsView : Page
    {
        private StudentViewModel viewModel;

        public StudentsView(StudentViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            OnLoad();
        }

        private void OnLoad() {
            EducationComboBox.ItemsSource = Enum.GetValues(typeof(EducationalLevel)).Cast<EducationalLevel>();
            viewModel.Bind(StudentsTable);
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            var (name, surname) = (StudentNameTxtBox.Text, StudentSurnameTxtBox.Text);

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
            {
                MessageBox.Show("Name or surname is empty.");
                return;
            }

            if (EducationComboBox.SelectedItem is null)
            {
                MessageBox.Show("Educational level is empty.");
                return;
            }

            viewModel.AddStudent(
                new Student(new Person(name, surname, BirthdayCalendar.SelectedDate.GetValueOrDefault(DateTime.Now)),
                (EducationalLevel)EducationComboBox.SelectedItem)
            );
        }

        private void SeeExamsButtonClick(object sender, RoutedEventArgs e)
        {
            Student student = (sender as Button).DataContext as Student;
            ExamsView examsView = new ExamsView(student);
            examsView.Show();
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e) 
        {
            Student student = (sender as Button).DataContext as Student;
            viewModel.DeleteStudent(student);
        }
    }
}
