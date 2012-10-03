﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
namespace LAUNCH.WPF {
    class Check: CheckBox, ICheck {
        public string Title {
            get {
                return this.Content.ToString();
            }
            set {
                this.Content = value;
            }
        }
        public new bool Checked {
            get {
                return this.IsChecked == true;
            }
            set {
                this.IsChecked = value;
            }
        }

        public new string ToolTip {
            get {
                return this.ToolTip;
            }
            set {
                this.ToolTip = value;
            }
        }


        public event EventHandler Changed;
        public Check() {
            this.Margin = new System.Windows.Thickness(3);
            this.Click += new System.Windows.RoutedEventHandler(Check_Click);
        }

        void Check_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (Changed != null) {
                Changed(this, e);
            }
        }
    }
}
