using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LAUNCH.WPF {
    class Slider: System.Windows.Controls.Slider, ISlider {
        public event EventHandler Changed;

        public double Increment {
            get {
                return base.TickFrequency;
            }
            set {
                base.TickFrequency = value;
            }
        }

        public double Max {
            get {
                return base.Maximum;
            }
            set {
                base.Maximum = value;
            }
        }
        public double Min {
            get {
                return base.Minimum;
            }
            set {
                base.Minimum = value;
            }
        }
        public Slider() {
            this.ValueChanged +=new System.Windows.RoutedPropertyChangedEventHandler<double>(Slider_ValueChanged);
        }

        void Slider_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e) {
            if (Changed != null) {
                Changed(this, e);
            }
        }
    }
}
