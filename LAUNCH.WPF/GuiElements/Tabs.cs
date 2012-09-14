using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
namespace LAUNCH.WPF {
    class Tabs: TabControl, ITabs {

        public void clearTabs() {

        }

        public void addNewTab(String name, IElement element) {
            UIElement uie = element as UIElement;

            this.AddChild(element);
        }



    }
}
