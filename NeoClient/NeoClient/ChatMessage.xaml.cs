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

namespace NeoClient
{
    /// <summary>
    /// Логика взаимодействия для ChatMessage.xaml
    /// </summary>
    public partial class ChatMessage : UserControl
    {
        public ChatMessage(bool neo)
        {
            InitializeComponent();
            if (neo) {
                this.image1.Source = new BitmapImage(new Uri(@"pack://application:,,,/NeoClient;component/res/Neo.jpg"));
            }
        }

        public string Text {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
    }
}
