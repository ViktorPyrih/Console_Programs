using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab_5.Format_Blanks
{
    static class BasicFormats
    {

        public static readonly Format RedWithYellowF = new Format(Brushes.Red, Brushes.Yellow, 5);

        public static readonly Format BasicGray = new Format(Brushes.Gray, Brushes.DimGray, 5);

        public static readonly Format BlackLineBold = new Format(null, Brushes.Black, 4);
        public static readonly Format BlackLine = new Format(null, Brushes.Black, 3);
        public static readonly Format BlackLineThin = new Format(null, Brushes.Black, 2);

        public static readonly Format BlackWithWhiteThin = new Format(Brushes.White, Brushes.Black, 2);

    }
}
