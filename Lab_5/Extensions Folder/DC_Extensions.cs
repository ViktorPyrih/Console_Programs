using Lab_5.Format_Blanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Lab_5.Extensions_Folder
{
    public static class DC_Extensions
    {
        public static void DrawSpline(this DrawingContext dc, PointCollection pointCollection, double offsetX, double offsetY, Format format)
        {
            pointCollection = PointCollection.Parse(
                string.Join(" ", pointCollection
                .Select(x => new Point(x.X + offsetX, x.Y + offsetY))
                .Select(x => $"{x.X},{x.Y}"))
                );

            StreamGeometry streamGeometry = new StreamGeometry();

            using (StreamGeometryContext gcx = streamGeometry.Open())
            {
                gcx.BeginFigure(pointCollection.First(), true, true);
                gcx.PolyLineTo(pointCollection, true, true);
            }

            dc.DrawGeometry(format.brushBackground, new Pen(format.brushForeground, format.penWidth), streamGeometry);
        }

        private static GeometryDrawing CreateArcDrawing(Point point, int radius, int degree_start, int degree_sweep)
        {
            var startRadians = degree_start * Math.PI / 180.0;
            var sweepRadians = degree_sweep * Math.PI / 180.0;

            var xs = point.X + (Math.Cos(startRadians) * radius);
            var ys = point.Y + (Math.Sin(startRadians) * radius);

            var xe = point.X + (Math.Cos(startRadians + sweepRadians) * radius);
            var ye = point.Y + (Math.Sin(startRadians + sweepRadians) * radius);


            StreamGeometry streamGeometry = new StreamGeometry();
            using (StreamGeometryContext ctx = streamGeometry.Open())
            {
                bool isLargeArc = Math.Abs(degree_sweep) > 180;
                SweepDirection sweepDirection = SweepDirection.Clockwise;

                ctx.BeginFigure(new Point(xs, ys), false, false);
                ctx.ArcTo(new Point(xe, ye), new Size(radius, radius),
                    0, isLargeArc, sweepDirection, true, false);
            }

            GeometryDrawing drawing = new GeometryDrawing();
            drawing.Geometry = streamGeometry;
            return drawing;
        }

        public static void DrawArc(this DrawingContext dc, Point point, int radius, int degree_start, int degree_sweep, Format format)
            => dc.DrawGeometry(format.brushBackground, new Pen(format.brushForeground, format.penWidth), CreateArcDrawing(point, radius, degree_start, degree_sweep).Geometry);

    }
}
