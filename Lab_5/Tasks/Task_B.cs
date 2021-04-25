using Lab_5.Extensions_Folder;
using Lab_5.Format_Blanks;
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
        private double gradus = 0;
        private void update_B()
        {
            if (gradus > 0) gradus -= 0.125;
            else gradus = 360;
        }


        public void DrawFerrisWheel(DrawingContext dc)
        {
            var center = new Point(382, 295);
            DrawBottom(dc, new Point(center.X - 132, center.Y + 95));
            DrawWheel(dc, center, count_of_cabins: 8, gradus);
            
            update_B();
        }

        private void DrawBottom(DrawingContext dc, Point gl_coord)
        {
            dc.DrawSpline(new PointCollection
            {
                new Point(55, 150), new Point(110, -70),
                new Point(128, -58), new Point(80, 150)
            }, 
            gl_coord.X - 10, gl_coord.Y, BasicFormats.BlackLine);
            dc.DrawSpline(new PointCollection
            {
                new Point(210, 150), new Point(155, -70),
                new Point(138, -58), new Point(185, 150)
            },
            gl_coord.X + 10, gl_coord.Y, BasicFormats.BlackLine);

            for (int i = 0; i <= 12; i++)
            {
                if (i % 2 != 0)
                {
                    dc.DrawRectangle((i == 1 || i == 7 ? Brushes.Red : i == 3 || i == 9 ? Brushes.Yellow : Brushes.Green), 
                        null, new Rect(
                        x: gl_coord.X + (i * 20.25), y: gl_coord.Y + 150,
                        width: 20.25, height: 40));
                }

                if (i != 0)
                {
                    dc.DrawRectangle(Brushes.DarkGray, null, new Rect(
                        x: gl_coord.X + (i * 20.25), y: gl_coord.Y + 150,
                        width: 2, height: 20));

                    dc.DrawRectangle(Brushes.Black, null, new Rect(
                        x: gl_coord.X + (i * 20.25), y: gl_coord.Y + 150 + 20,
                        width: 2, height: 20));
                }

                dc.DrawArc(new Point(gl_coord.X + 10 + (i * 20.25), gl_coord.Y + 150), radius: 10, 0, 180,
                    BasicFormats.BlackWithWhiteThin);
            }

            dc.DrawRectangle(null, new Pen(Brushes.Black, 3), new Rect(gl_coord.X, gl_coord.Y + 150, width: 265, height: 40));

        }

        private void DrawWheel(DrawingContext dc, Point gl_coord, int count_of_cabins, double gradus = 0)
        {
            double first_ellipse_rad = 40, last_ellipse_rad = 175;

            for (int i = 0; i < count_of_cabins; i++)
            {
                var distance = (Math.PI * 2 / count_of_cabins * i) + (gradus / (Math.PI * 2));
                Point 
                    start_point = new Point(gl_coord.X + Math.Cos(distance) * first_ellipse_rad, gl_coord.Y + Math.Sin(distance) * first_ellipse_rad),
                    final_point = new Point(gl_coord.X + Math.Cos(distance) * last_ellipse_rad, gl_coord.Y + Math.Sin(distance) * last_ellipse_rad);

                DrawCabin(dc, final_point);
                dc.DrawLine(new Pen(Brushes.Black, 6), start_point, final_point);
            }


            dc.DrawEllipse(null, new Pen(Brushes.Black, 5), gl_coord, first_ellipse_rad, first_ellipse_rad);
            dc.DrawEllipse(null, new Pen(Brushes.Black, 5), gl_coord, last_ellipse_rad - 40, last_ellipse_rad - 40);
            dc.DrawEllipse(null, new Pen(Brushes.Black, 8), gl_coord, last_ellipse_rad, last_ellipse_rad);
        }

        private void DrawCabin(DrawingContext dc, Point gl_coord)
        {
            int cabin_in_rad = 25;
            dc.DrawArc(new Point(gl_coord.X, gl_coord.Y + 35), cabin_in_rad, 0, 180, BasicFormats.BlackLineBold);

            for (int i = -1; i <= 1; i++)
            {
                dc.DrawLine(new Pen(Brushes.Black, 4), 
                    new Point(gl_coord.X + i * cabin_in_rad, gl_coord.Y + 35 + (i == 0 ? cabin_in_rad : 0)),
                    new Point(gl_coord.X + i * cabin_in_rad, gl_coord.Y + 43 - cabin_in_rad));
            }

            dc.DrawLine(new Pen(Brushes.Black, 4), 
                new Point(gl_coord.X - cabin_in_rad, gl_coord.Y + 20), 
                new Point(gl_coord.X + cabin_in_rad, gl_coord.Y + 20));


            dc.DrawRoundedRectangle(null, new Pen(Brushes.Black, 5),
                new Rect(gl_coord.X - 40 / 2, gl_coord.Y - 40 / 2, width: 40, height: 40),
                5, 3);
        }

    }
}
