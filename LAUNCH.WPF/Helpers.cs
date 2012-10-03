using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LAUNCH.WPF {
    class Helpers {
        public static System.Windows.HorizontalAlignment Convert(Alignment alignment) {
            switch (alignment) {
                case Alignment.Center:
                    return System.Windows.HorizontalAlignment.Center;
                case Alignment.Left:
                    return System.Windows.HorizontalAlignment.Left;
                case Alignment.Right:
                    return System.Windows.HorizontalAlignment.Right;
                default:
                    throw new NotSupportedException(alignment.ToString());
            }
        }

        public static Alignment Convert(System.Windows.HorizontalAlignment alignment) {
            switch (alignment) {
                case System.Windows.HorizontalAlignment.Center:
                    return Alignment.Center;
                case System.Windows.HorizontalAlignment.Left:
                    return Alignment.Left;
                case System.Windows.HorizontalAlignment.Right:
                    return Alignment.Right;
                default:
                    throw new NotSupportedException(alignment.ToString());
            }
        }


    }
}
