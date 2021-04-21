using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OnLoad();
            new Thread(Draw).Start();
            new Thread(Update).Start();
        }

        private void OnLoad()
        {
            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                DrawPrimitives(dc);
            }

            RenderTargetBitmap rtb = new RenderTargetBitmap((int)Width, (int)Height, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(dv);

            PictureBox.Source = rtb;
        }

        private void Draw()
        {
            
        }

        private void Update()
        {

        }

    }
}
