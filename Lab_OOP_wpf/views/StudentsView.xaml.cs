using Lab_OOP_wpf.ua.cdu.edu.vu.model;
using Lab_OOP_wpf.ua.cdu.edu.vu.view_model;
using Lab_OOP_wpf.ua.cdu.edu.vu.view_model.helper;

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
        private StudentsViewHelper viewHelper;
        public StudentsViewHelper ViewHelper
        {
            get => viewHelper;
            private set
            {
                viewHelper = value;
            }
        }

        private StudentViewModel viewModel;
        
        private IList<Window> childrentViews;

        public StudentsView(StudentViewModel viewModel)
        {
            InitializeComponent();
            this.viewHelper = new StudentsViewHelper(StudentNameTxtBox, StudentSurnameTxtBox, EducationComboBox, BirthdayCalendar);
            this.viewModel = viewModel;
            this.childrentViews = new List<Window>();
            OnLoad();
        }

        
        public void Close() 
        {
            foreach (Window window in childrentViews) 
            {
                window.Close();
            }
        }

        private void OnLoad() {
            EducationComboBox.ItemsSource = Enum.GetValues(typeof(EducationalLevel)).Cast<EducationalLevel>();
            viewModel.Bind(StudentsTable);
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            if (!viewHelper.ValidateRecord())
            {
                return;
            }

            viewModel.AddStudent(viewHelper.ConvertRecord());

            viewHelper.CLear();
        }

        private void SeeExamsButtonClick(object sender, RoutedEventArgs e)
        {
            Student student = (sender as Button).DataContext as Student;
            ExamsView examsView = new ExamsView(student);
            childrentViews.Add(examsView);
            examsView.Show();
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e) 
        {
            Student student = (sender as Button).DataContext as Student;
            viewModel.DeleteStudent(student);
        }
    }
}
