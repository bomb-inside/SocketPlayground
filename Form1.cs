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
    public partial class Form1 : Form
    {
        static string ipString = "192.168.100.100";
        static int portNum = 2750;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            try
            {
                Socket mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ipString), portNum);
            }
            catch (Exception ex)
            {
                // 연결 실패 : ex.Message 형태로 표시해보기 - delegate 사용?
                string errorMsg = "연결 실패 : " + ex.Message;
                MessageBox.Show(errorMsg, "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                int[] arr = new int[2];
                arr[100] = 1;
            }
            catch (Exception ex)
            {
                // 연결 실패 : ex.Message 형태로 표시해보기 - delegate 사용?
                string errorMsg = "연결 실패 : " + ex.Message;
                MessageBox.Show(errorMsg, "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
