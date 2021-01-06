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
            string bindIP = textBox1.Text;
            int bindPort = Int32.Parse(textBox2.Text);
            string serverIP = textBox3.Text;
            int serverPort = Int32.Parse(textBox4.Text);
            string message = textBox5.Text;

            try
            {
                IPEndPoint clientAddress = new IPEndPoint(IPAddress.Parse(bindIP), bindPort);
                IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);

                label1.Text = String.Format("클라이언트 : {0}, {1}", clientAddress, serverAddress);

                TcpClient client = new TcpClient(clientAddress);

                client.Connect(serverAddress);

                byte[] data = Encoding.Default.GetBytes(message);

                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);
                label2.Text = String.Format("송신 : {0}", message);

                data = new byte[256];
                string responseData = "";

                int bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.Default.GetString(data, 0, bytes);
                label3.Text = String.Format("수신 : {0}", responseData);

                stream.Close();
                client.Close();
            }
            catch (SocketException se)
            {
                string errorMsg = "소켓 에러 : " + se.Message;
                MessageBox.Show(errorMsg, "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            label1.Text = "클라이언트를 종료합니다.";
        }
    }
}
