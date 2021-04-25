using Lab_5.Format_Blanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Lab_5
{
    public partial class MainWindow
    {
        private readonly string basicImagePATH = Environment.CurrentDirectory + @"\Images\"; 

        public void Draw_UFO_Animation(DrawingContext dc)
        {
            // static background
            dc.DrawImage(new BitmapImage(new Uri(basicImagePATH + "background.jpg")), 
                new Rect(0, 0, 1600 / 2, 1257 / 2));


            // chassis_1
            {
                var transform = new RotateTransform(angle: frameData.rotateAngle_chassis_1, frameData.UFO_coord.X + 85, frameData.UFO_coord.Y + 230);
                dc.PushTransform(transform);
                dc.DrawImage(new BitmapImage(new Uri(basicImagePATH + "chassis.png")),
                    new Rect(frameData.UFO_coord.X, frameData.UFO_coord.Y + 226, 200 / 1.5, 150 / 1.5));
                dc.Pop();
            }

            // chassis_2
            {
                var transform = new RotateTransform(angle: frameData.rotateAngle_chassis_2, frameData.UFO_coord.X + 317, frameData.UFO_coord.Y + 224);
                dc.PushTransform(transform);
                dc.DrawImage(new BitmapImage(new Uri(basicImagePATH + "chassis2.png")),
                    new Rect(frameData.UFO_coord.X + 270, frameData.UFO_coord.Y + 220, 200 / 1.5, 150 / 1.5));
                dc.Pop();
            }

            // UFO
            dc.DrawImage(new BitmapImage(new Uri(basicImagePATH + "UFO.png")),
                    new Rect(frameData.UFO_coord.X, frameData.UFO_coord.Y, 412, 417));

            if (frameData.isFire)
            {
                // Fire
                dc.DrawImage(new BitmapImage(new Uri(basicImagePATH + "UFO's fire.png")),
                        new Rect(frameData.UFO_coord.X, frameData.UFO_coord.Y, 412, 417));
            }

            UFO_Update();
        }

        private FrameData frameData = new FrameData();
        private int frame = 0;
        
        private void UFO_Update()
        {
            frame++;

            if (frame < 165) 
                frameData.UFO_coord.Y += frame < 125 ? 1.5 : 1.1;

            if (frame > 135) frameData.isFire = false;

            if (frame > 40)
            {
                if (frameData.rotateAngle_chassis_1 < 0) frameData.rotateAngle_chassis_1 += 2;
                if (frameData.rotateAngle_chassis_2 > 0) frameData.rotateAngle_chassis_2 -= 2;
            }

            if (frame == 225)
            {
                frame = 0;
                frameData = new FrameData();
            }
        }

    }
}
