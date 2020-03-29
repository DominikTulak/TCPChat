using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TCPTest
{
    /// <summary>
    /// Interakční logika pro TCPServer.xaml
    /// </summary>
    public partial class TCPServer : Window
    {
    
        SimpleTcpServer server = new SimpleTcpServer();
        public TCPServer()
        {
            InitializeComponent();

            
        }
        public void DataRecieved(object sender, SimpleTCP.Message m)
        {
            if (!CheckAccess())
            {
                Dispatcher.Invoke(new Action<Object, Message>(DataRecieved), new object[] { sender, m });
                return;
            }
            OutputBox.Text += "[Client] " + m.MessageString + "\n";
            server.Broadcast("[Client] " + m.MessageString);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (server.IsStarted)
            {
                server.Stop();
                (sender as Button).Content = "Start";
            }
            else
            {
                try
                {
                    server.Start(int.Parse(PortBox.Text));
                    server.DataReceived += DataRecieved;
                    server.Delimiter = 0x13;
                    server.StringEncoder = Encoding.UTF8;
                    (sender as Button).Content = "Stop";
                    OutputBox.Text += "Server spuštěn!\n";
                }
                catch
                {
                    OutputBox.Text += "Server nelze spustit!\n";
                }
                

            }
        }
        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) {
                server.BroadcastLine("[Server] Sdělení serveru: " +InputBox.Text);
                OutputBox.Text += "[Server] "+ InputBox.Text;
                InputBox.Text = "";
            }
        }
    }
}
