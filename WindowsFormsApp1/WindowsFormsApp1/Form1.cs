using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            var tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            var port = 12345;
            string ip = textBox1.Text;
            await tcpClient.ConnectAsync(ip, port);
        }
        public async Task SendMessage(string message) 
        {
            try
            {
                    var tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    tcpClient.Send(data, new SocketFlags());
                    //await tcpClient.Send();
                    Console.Write(data);

            }
            catch (Exception)
            {
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != null)
            {
                string message = textBox3.Text;
                SendMessage(message);
                Console.Write(message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string message = textBox3.Text;
            string ip = textBox1.Text;
            string formattedMessage = $"{message}\n";

            textBox2.AppendText(formattedMessage);
            textBox2.AppendText(Environment.NewLine);
            textBox2.ScrollToCaret();
        }
    }
}
