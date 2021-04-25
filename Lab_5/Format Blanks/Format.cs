using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab_5.Format_Blanks
{
    public class Format
    {
        public Format(Brush brushBackground, Brush brushForeground, int penWidth)
        {
            this.brushBackground = brushBackground;
            this.brushForeground = brushForeground;
            this.penWidth = penWidth;
        }

        public Brush brushBackground;
        public Brush brushForeground;
        public int penWidth;
    }
}
