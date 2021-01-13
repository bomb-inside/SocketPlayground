using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace SocketPlayground
{
    public partial class Form2 : Form // client
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "....";
            label2.Text = "송신";
            label3.Text = "수신";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clientRun();
        }

        private async void clientRun()
        {
            var clientTask = Task.Run(() => RunClient());
            await clientTask;
        }

        private void RunClient()
        {
            try
            {
                UdpClient cli = new UdpClient();

                string msg = textBox1.Text;
                byte[] datagram = Encoding.UTF8.GetBytes(msg);
                cli.Send(datagram, datagram.Length, "192.168.0.78", 7777);
                label1.Text = "[Send] 192.168.0.78:7777로 " + datagram.Length + "바이트 전송";

                IPEndPoint epRemote = new IPEndPoint(IPAddress.Any, 0);
                byte[] bytes = cli.Receive(ref epRemote);
                label2.Text = "[Receive] " + epRemote.ToString() + "로부터 " + bytes.Length + "바이트 수신";
                label3.Text = Encoding.UTF8.GetString(bytes);

                cli.Close();
            }
            catch (SocketException se)
            {
                string errorMsg = "소켓 에러 : " + se.Message;
                MessageBox.Show(errorMsg, "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
