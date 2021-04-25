using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Lab_5
{
    public partial class MainWindow
    {
        private double degree = 0;

        private void update_C()
        {
            degree += 0.08;
            if (degree >= 360) degree %= 360;
        }


        public void DrawAnimatedCircle(DrawingContext dc)
        {
            var line_coord = new Point(325, 325);
            var distance = 150;

            dc.DrawEllipse(Brushes.Gray, new Pen(Brushes.Black, 8), 
                new Point(line_coord.X + distance * Math.Cos(degree), line_coord.Y + distance * Math.Sin(degree)), 
                35, 35);

            update_C();
        }

    }
}
