using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
namespace LAUNCH.WPF {
    class Slider: System.Windows.Controls.Grid, ISlider {
        public event EventHandler Changed;
        System.Windows.Controls.Slider slider = new System.Windows.Controls.Slider();
        Label label = new Label();


        public double Increment {
            get {
                return slider.TickFrequency;
            }
            set {
                slider.TickFrequency = value;
            }
        }

        public double Max {
            get {
                return slider.Maximum;
            }
            set {
                slider.Maximum = value;
            }
        }
        public double Min {
            get {
                return slider.Minimum;
            }
            set {
                slider.Minimum = value;
            }
        }
        public double Value {
            get {
                return slider.Value;
            }
            set {
                slider.Value = value;
            }
        }
        public bool NumberVisible {
            get {
                return label.Visibility == System.Windows.Visibility.Visible;
            }
            set {
                if (value)
                    label.Visibility = System.Windows.Visibility.Visible;
                else
                    label.Visibility = System.Windows.Visibility.Visible;
            }
        }



        public Slider() {
            ColumnDefinition col = new ColumnDefinition();
            col.Width = new System.Windows.GridLength(1, System.Windows.GridUnitType.Star);
            this.ColumnDefinitions.Add(col);

            col = new ColumnDefinition();
            col.Width = new System.Windows.GridLength(1, System.Windows.GridUnitType.Auto);
            this.ColumnDefinitions.Add(col);

            Grid.SetColumn(slider, 0);
            Grid.SetColumn(label, 0);

            this.Children.Add(slider);
            this.Children.Add(label);

            label.Visibility = System.Windows.Visibility.Collapsed;

            slider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(Slider_ValueChanged);
            slider.IsSnapToTickEnabled = true;
        }

        void Slider_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e) {
            label.Content = slider.Value;
            if (Changed != null) {
                Changed(this, e);
            }
        }
    }
}
