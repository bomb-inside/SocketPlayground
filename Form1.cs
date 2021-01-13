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
            Run();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            runServer();
        }
        private async void Run()
        {
            var serverTask = Task.Run(() => runServer());
            await serverTask;
        }
        private void runServer()
        {
            try
            {
                UdpClient srv = new UdpClient(2750);

                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

                while (true)
                {
                    byte[] dgram = srv.Receive(ref remoteEP);
                    label1.Text = remoteEP.ToString() + ", " + dgram.Length;

                    srv.Send(dgram, dgram.Length, remoteEP);
                    label2.Text = remoteEP.ToString() + ", " + dgram.Length;
                }
            }
            catch (SocketException se)
            {
                string errorMsg = "소켓 에러 : " + se.Message;
                MessageBox.Show(errorMsg, "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }

            label1.Text = "서버를 종료합니다.";
        }
    }
}