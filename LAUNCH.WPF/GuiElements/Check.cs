using System;
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

    }
}
