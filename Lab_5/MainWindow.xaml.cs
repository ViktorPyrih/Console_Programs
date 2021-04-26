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

            new Thread(() =>
            {
                while (true)
                {
                    // 25 times per second
                    Draw();
                    Thread.Sleep(20);
                }
            }).Start();
        }

        private void Draw()
        {
            Dispatcher.Invoke(() => 
            {
                DrawingVisual dv = new DrawingVisual();
                using (DrawingContext dc = dv.RenderOpen())
                {
                    switch (taskState)
                    {
                        case 1:
                            DrawPrimitives(dc);
                            break;
                        case 2:
                            DrawFerrisWheel(dc);
                            break;
                        case 3:
                            DrawAnimatedCircle(dc);
                            break;
                        case 4:
                            Draw_UFO_Animation(dc);
                            break;
                    }
                }

                RenderTargetBitmap rtb = new RenderTargetBitmap((int)Width, (int)Height, 96, 96, PixelFormats.Pbgra32);
                rtb.Render(dv);

                PictureBox.Source = rtb;
            });
        }


        private int taskState = 1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender == ButtonRight) taskState++;
            if (sender == ButtonLeft) taskState--;

            ButtonLeft.IsEnabled = true;
            ButtonRight.IsEnabled = true;

            if (taskState == 1) ButtonLeft.IsEnabled = false;
            if (taskState == 4) ButtonRight.IsEnabled = false;
        }
    }
}
