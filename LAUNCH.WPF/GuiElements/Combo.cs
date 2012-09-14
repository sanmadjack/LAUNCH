using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
namespace LAUNCH.WPF {
    class Combo: ComboBox, ICombo {

        public Combo() {
            this.SelectionChanged += new SelectionChangedEventHandler(Combo_SelectionChanged);
        }

        void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (this.selectionChanged != null)
                this.selectionChanged(this, e);
        }

        public event EventHandler selectionChanged;

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
                return this.SelectedItem.ToString();
            }
        }

        public void AddItem(object item) {
            this.AddChild(item);
        }

        

    }
}
