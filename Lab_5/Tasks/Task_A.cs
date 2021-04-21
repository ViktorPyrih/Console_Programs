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

        public void DrawPrimitives(DrawingContext dc)
        {
            dc.DrawRectangle(Brushes.Red, null, new Rect(20, 20, 150, 100));

            GeometryDrawing arc = CreateArcDrawing(new Point(35, 35), radius: 10, 40, 100);
            dc.DrawGeometry(Brushes.Blue, new Pen(Brushes.Gray, 10), arc.Geometry);
        }

        private GeometryDrawing CreateArcDrawing(Point point, int radius, int degree_start, int degree_sweep)
        {
            var startRadians = degree_start * Math.PI / 180.0;
            var sweepRadians = degree_sweep * Math.PI / 180.0;

            var xs = radius * 2


            StreamGeometry streamGeometry = new StreamGeometry();
            using (StreamGeometryContext ctx = streamGeometry.Open())
            {
                SweepDirection sweepDirection = SweepDirection.Clockwise;

                ctx.BeginFigure(new Point())
            }

        }
    }
}
