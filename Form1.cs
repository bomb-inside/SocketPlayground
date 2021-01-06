using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SocketPlayground
{
    public partial class Form1 : Form // server
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "....";
            label2.Text = "수신";
            label3.Text = "송신";
        }
        private async void serverRun()
        {
            await Task.Run(async () =>
            {
                string bindIP = textBox1.Text;
                int bindPort = Int32.Parse(textBox2.Text);
                TcpListener server = null;

                try
                {
                    IPEndPoint localAddress = new IPEndPoint(IPAddress.Parse(bindIP), bindPort);
                    server = new TcpListener(localAddress);

                    // start server and wait until client requests connection with TcpClient.Connect()
                    server.Start();
                    label1.Text = "메아리 서버 시작...";

                    while (true)
                    {
                        // AcceptTcpClient() returns TcpClient
                        TcpClient client = server.AcceptTcpClient();
                        label1.Text = "클라이언트 접속 : " + ((IPEndPoint)client.Client.RemoteEndPoint).ToString();

                        // get NetworkStream object
                        NetworkStream stream = client.GetStream();

                        int length;
                        string data = null;
                        byte[] bytes = new byte[256];

                        while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            data = Encoding.Default.GetString(bytes, 0, length);
                            label2.Text = String.Format("수신 : {0}", data);

                            byte[] msg = Encoding.Default.GetBytes(data);
                            stream.Write(msg, 0, msg.Length);
                            label3.Text = String.Format("송신 : {0}", data);
                        }

                        stream.Close();
                        client.Close();
                    }
                }
                catch (SocketException se)
                {
                    string errorMsg = "소켓 에러 : " + se.Message;
                    MessageBox.Show(errorMsg, "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    server.Stop();
                }

                label1.Text = "서버를 종료합니다.";
            });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            serverRun();
        }
    }
}
/*
        static string ipString = "192.168.100.100";
        static int portNum = 2750;
            try
            {
                int[] arr = new int[2];
                arr[100] = 1;
                Socket mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ipString), portNum);
            }
            catch (Exception ex)
            {
                // 연결 실패 : ex.Message 형태로 표시해보기 - delegate 사용?
                string errorMsg = "연결 실패 : " + ex.Message;
                MessageBox.Show(errorMsg, "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */