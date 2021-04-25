using Lab_5.Extensions_Folder;
using Lab_5.Format_Blanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab_5
{
    public partial class MainWindow
    {

        public void DrawPrimitives(DrawingContext dc)
        {
            // rectangle
            dc.DrawRectangle(Brushes.Black, null, new Rect(20, 20, 150, 100));

            // circle segment
            dc.DrawArc(new Point(150, 150), radius: 100, 40, 140, new Format(Brushes.Gray, Brushes.Gray, 25));

            // parallelogram
            dc.DrawSpline(new PointCollection { 
                new Point(180, 240), new Point(290, 240), 
                new Point(310, 310), new Point(200, 310) 
            }, 140, 0, BasicFormats.BasicGray);

            // romb
            dc.DrawSpline(new PointCollection {
                new Point(100, 200), new Point(150, 100),
                new Point(100, 000), new Point(050, 100) 
            }, 500, 70, BasicFormats.BasicGray);

            // 8-angle figure
            dc.DrawSpline(new PointCollection
            {
                new Point(100, 100), new Point(130, 110),
                new Point(140, 140), new Point(130, 170),
                new Point(100, 180), new Point(70, 170),
                new Point(60, 140), new Point(70, 110),
            }, 250, 0, BasicFormats.BasicGray);
        }

    }

}
