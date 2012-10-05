using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LAUNCH.WPF {
    class TextBox:System.Windows.Controls.TextBox,  ITextBox {
        public event EventHandler Changed;

        public new string ToolTip {
            get {
                return this.ToolTip;
            }
            set {
                this.ToolTip = value;
            }
        }

        public TextBox() {
            this.TextChanged += new System.Windows.Controls.TextChangedEventHandler(TextBox_TextChanged);
        }

        void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {
            if (Changed != null) {
                Changed(this, e);
            }
        }

        public bool MultiLine {
            get {
                return base.AcceptsReturn;
            }
            set {
                base.AcceptsReturn = value;
            }
        }

        public bool Scrolling {
            get {
                return base.HorizontalScrollBarVisibility== System.Windows.Controls.ScrollBarVisibility.Auto;
            }
            set {
                if (value) {
                    base.HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto;
                    base.VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto;
                } else {
                    base.HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Disabled;
                    base.VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Disabled;
                }
            }
        }

        public bool ReadOnly {
            get {
                return base.IsReadOnly;
            }
            set {
                base.IsReadOnly = value;
                base.IsReadOnlyCaretVisible = value;
            }
        }

    }
}
