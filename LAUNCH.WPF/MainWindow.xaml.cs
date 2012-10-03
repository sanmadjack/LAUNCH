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


        public void Refresh() {
            this.UpdateLayout();
        }

        public string SelectFile() {
            return SelectFile(null);
        }

        public string SelectFile(string open_dir) {
            OpenFileDialog file = new OpenFileDialog();

            if (open_dir != null)
                file.InitialDirectory = open_dir;

            if (file.ShowDialog(this.GetIWin32Window()) == System.Windows.Forms.DialogResult.OK) {
                return file.FileName;
            }
            return null;
        }


        #region Stuff for tabs
        public void ClearTabs() {
            mainTabs.Visibility = System.Windows.Visibility.Collapsed;
            ButtonGrid.Visibility = System.Windows.Visibility.Collapsed;
            mainTabs.Items.Clear();
        }


        public void AddTab(String name, IElement element) {
            if (element == null)
                throw new ArgumentNullException("Element is null, fucker! What the fuck!");
            mainTabs.Visibility = System.Windows.Visibility.Visible;
            ButtonGrid.Visibility = System.Windows.Visibility.Visible;

            TabItem item = new TabItem();
            item.Content = element;
            item.Header = name;

            mainTabs.Items.Add(item);

            mainTabs.TabIndex = 0;

        }
        #endregion


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

        private void ApplyButton_Click(object sender, RoutedEventArgs e) {
            gui.Apply();
        }

        private void RunButton_Click(object sender, RoutedEventArgs e) {
            gui.Run();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private bool CheckForunsavedChanges() {
            if (gui!=null&&gui.UnsavedChanges) {
                switch (
                System.Windows.MessageBox.Show(this, "There are unsaved changes, would you like to apply them before closing?", "Hold on a sec", MessageBoxButton.YesNoCancel, MessageBoxImage.Question)
                ) {
                    case MessageBoxResult.Yes:
                        gui.Apply();
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        return false;
                }
            }
            return true;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            e.Cancel = !CheckForunsavedChanges();
        }


        private void profileCombo_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (!CheckForunsavedChanges()) {

            }

        }


    }
}
