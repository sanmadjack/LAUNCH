using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
namespace LAUNCH.WPF {
    class BoxThing: GroupBox, IBoxThing {

        public new string Header {
            get {
                return base.Header.ToString();
            }
            set {
                base.Header = value;
            }
        }
        public void addItem(IElement ele) {
            this.Content = ele;
        }

        public void addItems(List<IElement> eles) {
            throw new NotSupportedException();
        }
    }
}
