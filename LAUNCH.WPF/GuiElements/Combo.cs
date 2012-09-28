using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
namespace LAUNCH.WPF {
    class Combo: ComboBox, ICombo {
        public event EventHandler Changed;

        public Combo() {
            this.SelectionChanged += new SelectionChangedEventHandler(Combo_SelectionChanged);
        }

        void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (this.Changed != null)
                this.Changed(this, e);
        }

        public new string ToolTip {
            get {
                return this.ToolTip;
            }
            set {
                this.ToolTip = value;
            }
        }


        public int ActiveIndex {
            get {
                return this.SelectedIndex;
            }
            set {
                this.SelectedIndex = value;
            }
        }

        public string ActiveText {
            get {
                if (this.SelectedItem == null)
                    return null;
                return this.SelectedItem.ToString();
            }
        }

        public void AddItem(object item) {
            this.AddChild(item);
        }

        

    }
}
