using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
namespace LAUNCH.WPF {
    class Tabs: TabControl, ITabs {
        public Tabs() {
        }


        public void clearTabs() {

        }

        public void addNewTab(String name, IElement element) {
            if (element == null)
                throw new ArgumentNullException("Element is null, fucker! What the fuck!");

            TabItem item = new TabItem();
            item.Content = element;
            item.Header = name;

            this.AddChild(item);

            this.TabIndex = 0;

        }



    }
}
