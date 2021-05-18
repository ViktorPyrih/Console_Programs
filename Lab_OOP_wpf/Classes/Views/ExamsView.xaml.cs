using Lab_OOP_wpf.Classes.Extensions;
using Lab_OOP_wpf.Classes.Models;
using Lab_OOP_wpf.Classes.ViewModels;
using Lab_OOP_wpf.Classes.Views_Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab_OOP_wpf.Classes.Views
{
    /// <summary>
    /// Interaction logic for ExamsView.xaml
    /// </summary>
    partial class ExamsView : Window
    {
        ObservableCollection<Exam> exams;

        public ExamsView(ObservableCollection<Exam> exams)
        {
            InitializeComponent();
            this.exams = exams;
            TableExams.ItemsSource = exams;
        }

        private void TableExams_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = ((PropertyDescriptor)e.PropertyDescriptor)?.DisplayName ?? e.Column.Header;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var (name, mark) = (exam_name__txt_box.Text, exam_mark__txt_box.Text);

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(mark))
            {
                MessageBox.Show("Name or mark is empty.");
                return;
            }

            try
            {
                var exam_date = new DateTime(
                    int.Parse(exam_year__txt_box.Text),
                    int.Parse(exam_month__txt_box.Text),
                    int.Parse(exam_day__txt_box.Text));

                exams.Add(new Exam(name, byte.Parse(mark), exam_date));

            }
            catch (Exception)
            {
                MessageBox.Show("Wrong date or mark!");
            }
        }

        private void exam_month__txt_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!DateValidator.IsMonthValidate(exam_month__txt_box.Text))
            {
                exam_month__txt_box.Text = exam_month__txt_box.Text.Remove(exam_month__txt_box.Text.Length - 1, 1);
                exam_month__txt_box.Select(exam_month__txt_box.Text.Length, 0);
            }
        }

        private void exam_day__txt_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!DateValidator.IsDayValidate(exam_day__txt_box.Text))
            {
                exam_day__txt_box.Text = exam_day__txt_box.Text.Remove(exam_day__txt_box.Text.Length - 1, 1);
                exam_day__txt_box.Select(exam_day__txt_box.Text.Length, 0);
            }
        }
    }
}
