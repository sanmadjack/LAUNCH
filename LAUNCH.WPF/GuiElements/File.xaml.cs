using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LAUNCH.WPF {
    /// <summary>
    /// Interaction logic for File.xaml
    /// </summary>
    public partial class File : UserControl, IFile {
        IWindow parentWindow;

        public event EventHandler Changed;


        public new string ToolTip {
            get {
                return this.ToolTip;
            }
            set {
                this.ToolTip = value;
            }
        }


        public File(IWindow window) {
            InitializeComponent();
            parentWindow = window;
            txt.TextChanged += new TextChangedEventHandler(txt_TextChanged);
        }

        void txt_TextChanged(object sender, TextChangedEventArgs e) {
            if (Changed != null) {
                Changed(this, e);
            }
        }

        public string SelectedFile {
            get {
                return txt.Text;
            }
            set {
                txt.Text = value;
            }
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e) {

        }

        private void btn_Click(object sender, RoutedEventArgs e) {
            string file;
            if(txt.Text!=null&&txt.Text!="") {
                file = parentWindow.SelectFile(System.IO.Path.GetDirectoryName(txt.Text));
            } else {
                file = parentWindow.SelectFile();
            }


            if (file != null) {
                txt.Text = file;
            }
        }
    }
}
