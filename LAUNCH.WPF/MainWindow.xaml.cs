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


        public void Refresh() {
            this.UpdateLayout();
        }

    }
}
