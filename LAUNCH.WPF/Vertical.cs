using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
namespace LAUNCH.WPF {
    class Vertical: StackPanel, IVertical {
        public Vertical() {
            this.Orientation = System.Windows.Controls.Orientation.Vertical;

        }

        public void addItem(IElement ele) {
            this.Children.Add(ele as UIElement);
        }

        public void addItems(List<IElement> eles) {
            foreach (IElement ele in eles) {
                addItem(ele);
            }
        }

    }
}
