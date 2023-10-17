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

using System.Threading;

namespace NeoClient {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private static Client client;
        private string IP, port_str;
        private int port;

        public MainWindow() {
            InitializeComponent();
            //add_message("test morph", false);
            //add_message("test neo", true);
        }

        void hide(UIElement elem) {
            elem.Visibility = Visibility.Hidden;
        }
        void show(UIElement elem) {
            elem.Visibility = Visibility.Visible;
        }

        void add_message(string msg, bool is_neo) {
            ListBoxItem item = new ListBoxItem();
            ChatMessage message_container = new ChatMessage(is_neo);
            message_container.Text = msg;
            item.Content = message_container;
            listbox_msg.Items.Add(item);
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
            // Let's try to connect!

            if (localhost_checkbox.IsChecked == true) {
                IP = "127.0.0.1";
            }
            else {
                if (!ip_textbox.Text.Equals("")) {
                    IP = ip_textbox.Text;
                }
                else {
                    MessageBox.Show("Enter the IP!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (!port_textbox.Text.Equals("")) {
                port_str = port_textbox.Text;
            }
            else {
                MessageBox.Show("Enter the port!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            port = Convert.ToInt32(port_str);

            client = new Client(IP, port);
            ThreadPool.QueueUserWorkItem(client.HandleSession);

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
