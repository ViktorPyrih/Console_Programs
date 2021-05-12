using Lab_OOP_wpf.Classes.ViewModels;
using System;
using System.Collections.Generic;
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
            OnLoad();
        }

        private void OnLoad()
        {
            TestViewModel viewModel = new TestViewModel();

            Table.ItemsSource = viewModel.students.Select(x => new { 
                Student__Long_Description = x.ToString(), 
                Student__Short_Description = x.ToShortString() });
        }
    }
}
