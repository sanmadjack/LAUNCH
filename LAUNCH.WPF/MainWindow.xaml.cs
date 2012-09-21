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
using System.Windows.Forms;
namespace LAUNCH.WPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWindow {
        private GuiBuilder gui;

        public ITextBox ArgDisplay {
            get {
                return ArgOutput;
            }
        }


        public ITabs Tabs {
            get {
                return mainTabs;
            }
        }
        public ICombo ProfileCombo {
            get {
                return profileCombo;
            }
        }

        public MainWindow() {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }


        void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            gui = new GuiBuilder(this);
        }

        public void ClearTabs() {

        }

        public void Refresh() {
            this.UpdateLayout();
        }

        public string SelectFile() {
            OpenFileDialog file = new OpenFileDialog();

            if (file.ShowDialog(this.GetIWin32Window()) == System.Windows.Forms.DialogResult.OK) {
                return file.FileName;
            }
            return null;
        }

        #region stuff for interacting with windows.forms controls
        // Ruthlessly stolen from http://stackoverflow.com/questions/315164/how-to-use-a-folderbrowserdialog-from-a-wpf-application
        public System.Windows.Forms.IWin32Window GetIWin32Window() {
            var source = System.Windows.PresentationSource.FromVisual(this) as System.Windows.Interop.HwndSource;
            System.Windows.Forms.IWin32Window win = new OldWindow(source.Handle);
            return win;
        }

        private class OldWindow : System.Windows.Forms.IWin32Window {
            private readonly System.IntPtr _handle;
            public OldWindow(System.IntPtr handle) {
                _handle = handle;
            }

            #region IWin32Window Members
            System.IntPtr System.Windows.Forms.IWin32Window.Handle {
                get { return _handle; }
            }
            #endregion
        }
        #endregion
    }
}
