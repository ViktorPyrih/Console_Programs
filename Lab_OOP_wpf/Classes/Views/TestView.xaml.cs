using Lab_OOP_wpf.Classes.Models;
using Lab_OOP_wpf.Classes.ViewModels;
using Lab_OOP_wpf.Classes.Views_Commands;
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

namespace Lab_OOP_wpf.Classes.Views
{
    /// <summary>
    /// Логика взаимодействия для TestView.xaml
    /// </summary>
    public partial class TestView : Page
    {
        public TestView()
        {
            InitializeComponent();
            education__combo_box.ItemsSource = Enum.GetValues(typeof(EducationalLevel)).Cast<EducationalLevel>();
            OnLoad();
        }

        TestViewModel viewModel = new TestViewModel();

        private void OnLoad() => Table.ItemsSource = viewModel.students;


        private void birthday_month__txt_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!DateValidator.IsMonthValidate(birthday_month__txt_box.Text))
            {
                birthday_month__txt_box.Text = birthday_month__txt_box.Text.Remove(birthday_month__txt_box.Text.Length - 1, 1);
                birthday_month__txt_box.Select(birthday_month__txt_box.Text.Length, 0);
            }
        }

        private void birthday_day__txt_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!DateValidator.IsDayValidate(birthday_day__txt_box.Text))
            {
                birthday_day__txt_box.Text = birthday_day__txt_box.Text.Remove(birthday_day__txt_box.Text.Length - 1, 1);
                birthday_day__txt_box.Select(birthday_day__txt_box.Text.Length, 0);
            }
        }

        private void Table_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = ((PropertyDescriptor)e.PropertyDescriptor)?.DisplayName ?? e.Column.Header;

            if (e.Column.Header as string == "Exams") e.Column.Visibility = Visibility.Hidden;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var (name, surname) = (student_name__txt_box.Text, student_surname__txt_box.Text);

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
            {
                MessageBox.Show("Name or surname is empty.");
                return;
            }

            if (education__combo_box.SelectedItem == null)
            {
                MessageBox.Show("Educational level is empty.");
                return;
            }

            try
            {
                var birthday = new DateTime(
                    int.Parse(birthday_year__txt_box.Text),
                    int.Parse(birthday_month__txt_box.Text),
                    int.Parse(birthday_day__txt_box.Text));

                viewModel.AddStudent(new Student(new Person(name, surname, birthday),
                (EducationalLevel) education__combo_box.SelectedItem));

            }
            catch (Exception)
            {
                MessageBox.Show("Wrong birthday date.");
            }
        }

        private void See_Exams_Button_Click(object sender, RoutedEventArgs e)
        {
            Student student = (sender as Button).DataContext as Student;

            ExamsView examsView = new ExamsView(student.exams);

            examsView.Show();
        }
    }
}