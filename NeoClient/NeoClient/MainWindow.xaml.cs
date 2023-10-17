using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NeoClient {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        void hide(UIElement elem) {
            elem.Visibility = Visibility.Hidden;
        }
        void show(UIElement elem) {
            elem.Visibility = Visibility.Visible;
        }


        private void input_textbox_MouseEnter(object sender, MouseEventArgs e) {

        }

        private void input_textbox_MouseLeave(object sender, MouseEventArgs e) {

        }

        private void send_button_Click(object sender, RoutedEventArgs e) {
            
        }

        private void localhost_Checked(object sender, RoutedEventArgs e) {
            ip_label.IsEnabled = false;
            ip_textbox.IsEnabled = false;
        }

        private void localhost_Unchecked(object sender, RoutedEventArgs e) {
            ip_label.IsEnabled = true;
            ip_textbox.IsEnabled = true;
        }

        private void connect_button_Click(object sender, RoutedEventArgs e) {
            hide(connect_button);
            hide(ip_textbox);
            hide(ip_label);
            hide(localhost_checkbox);
            hide(port_textbox);
            hide(port_label);
            show(input_textbox);
            show(send_button);
            show(listbox_msg);
        }
    }
}
