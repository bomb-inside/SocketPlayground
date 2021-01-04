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
            try
            {
                Socket mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ipString), portNum);
            }
            catch (Exception ex)
            {
                // delegate 써서 오류 내용 표시해보기
                MessageBox.Show("연결에 실패했습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
