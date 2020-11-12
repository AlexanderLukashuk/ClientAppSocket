using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace ClientAppSocket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Send(object sender, RoutedEventArgs e)
        {
            // адрес интранет сети, адрес локальный и адрес localhost (127.0.0.1)
            // 2 тип адреса узнаем через командную строку и команду ipconfig
            //var ipAddress = IPAddress.Parse("172.27.61.79");
            var ipAddress = IPAddress.Parse("127.0.0.1"); //создали ip адрес

            // создаем сокет для ip сети с транспортным протоколов TCP, работающий через потоки(постоянные соединения)
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // сокет создан, но еще не работает

            try
            {
                await socket.ConnectAsync(new IPEndPoint(ipAddress, 62227));

                var text = textBox.Text;

                var data = Encoding.UTF8.GetBytes(text);

                await socket.SendAsync(data, SocketFlags.None);

                socket.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
