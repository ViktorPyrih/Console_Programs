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
        private double frame_C = 0;
        private double offset_Y = 0, radius = 35;
        private double coeff_offset = 1, coeff_radius = 1;


        private void update_C()
        {
            frame_C++;
            if (frame_C > 200)
            {
                frame_C = 0;
                offset_Y = 0;
                radius = 35;
                coeff_offset = 1; 
                coeff_radius = 1;
                return;
            }

            // if from center to bottom (0 < frame <= 50) => 
            // move slower + radius make small faster

            // if from bottom to center (50 < frame <= 100) => 
            // move faster + radius make small slower

            // if from center to upper (100 < frame <= 150) => 
            // move slower + radius make big faster

            // if from upper to center (150 < frame <= 200) => 
            // move faster + radius make big slower

            double adding_radius = 0.002;
            double adding_offset = 0.002;

            //coeff_radius += (frame <= 50 || (frame > 100 && frame <= 150)) ? adding_radius : -adding_radius;
            //coeff_offset += (frame <= 50 || (frame > 100 && frame <= 150)) ? -adding_offset : adding_offset;

            radius += (frame_C <= 100) ? -0.25 * coeff_radius : 0.25 * coeff_radius;
            offset_Y += ((frame_C <= 50) || (frame_C > 150)) ? 4.0 * coeff_offset : -4.0 * coeff_offset;
        }


        public void DrawAnimatedCircle(DrawingContext dc)
        {
            var line_coord = new Point(325, 325);

            dc.DrawEllipse(Brushes.Gray, new Pen(Brushes.Black, 8), 
                new Point(line_coord.X, line_coord.Y + offset_Y),
                radius, radius);

            update_C();
        }

    }
}
