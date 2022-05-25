using Lab_OOP_wpf.ua.cdu.edu.vu.view_model;
using Lab_OOP_wpf.views;
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

namespace Lab_OOP_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private event Action OnClose;
        private StudentViewModel studentViewModel;

        public MainWindow()
        {
            InitializeComponent();
            this.studentViewModel = new StudentViewModel();
            OnLoad();
        }

        private void OnLoad() 
        {
            ViewFrame.Content = new StudentsView(studentViewModel);
            OnClose = studentViewModel.OnClose;
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OnClose();
        }
    }
}
