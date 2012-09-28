using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LAUNCH.WPF {
    class Resolution: Slider, IResolution {
        //public event EventHandler Changed;

        public new string ToolTip {
            get {
                return this.ToolTip;
            }
            set {
                this.ToolTip = value;
            }
        }

    }
}
