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
    /// Interakční logika pro TCPClient.xaml
    /// </summary>
    public partial class TCPClient : Window
    {
        //public TcpClient client;
        NetworkStream nwStream;
        SimpleTcpClient client = new SimpleTcpClient();
        public TCPClient()
        {
            InitializeComponent();
            client.DataReceived += DataRecieved;


        }

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
               // MessageBox.Show("Enter");
                client.Write(JmenoBox.Text + ": " +InputBox.Text);
                InputBox.Text = "";
            }
        }
        private void DataRecieved(object sender, SimpleTCP.Message m)
        {
            if (!CheckAccess())
            {
                Dispatcher.Invoke(new Action<Object, Message>(DataRecieved), new object[] { sender, m });
                return;
            }
            OutputBox.Text += m.MessageString + "\n";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if((sender as Button).Content == "Odpojit")
            {
                (sender as Button).Content = "Připojit";
                OutputBox.Text += "Odpojeno!\n";
                JmenoBox.IsReadOnly = false;
                client.Write(JmenoBox.Text + " se odpojil.");
                client.Disconnect();
            }
            else
            {
                try
                {
                    client.Connect(IPBox.Text, int.Parse(PortBox.Text));
                    client.StringEncoder = Encoding.UTF8;
                    (sender as Button).Content = "Odpojit";
                    OutputBox.Text += "Připojeno!\n";
                    JmenoBox.IsReadOnly = true;
                    client.Write(JmenoBox.Text + " se připojil.");
                }
                catch
                {
                    OutputBox.Text += "Nelze se připojit!\n";
                }
            }
            
            //if client.
            /*
            OutputBox.Text = "";
            OutputBox.IsReadOnly = true;

            string textToSend = "TestString";

            //---create a TCPClient object at the IP and port no.---
            client = new TcpClient(IPBox.Text, int.Parse(PortBox.Text));
            nwStream = client.GetStream();
            OutputBox.Text += "Připojeno\n";

            
            //---read back the text---
            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            OutputBox.Text+=("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead) +"\n");
            //Console.ReadLine();
            client.Close();
            OutputBox.Text += "Odpojeno\n";
            */

        }
        static void ReceiveData(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int byte_count;

            while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
            {
                Console.Write(Encoding.ASCII.GetString(receivedBytes, 0, byte_count));
            }
        }
    }
}
