using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LAUNCH.WPF {
    class Label: System.Windows.Controls.Label, ILabel {
        public string Text {
            get {
                if(Content==null)
                    return null;
                return Content.ToString();
            } set {
                Content = value;

            }
        }

        public Alignment Alignment {
            get {
                return Helpers.Convert(this.HorizontalAlignment);
            }
            set {
                this.HorizontalAlignment = Helpers.Convert(value);
            }
        }


    }


}
