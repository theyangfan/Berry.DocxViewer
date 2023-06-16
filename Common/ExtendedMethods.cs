using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Berry.DocxViewer
{
    internal static class ExtendedMethods
    {
        public static System.Windows.Media.Color Convert(this System.Drawing.Color color)
        {
            return System.Windows.Media.Color.FromRgb(color.R, color.G, color.B);
        }
    }
}
