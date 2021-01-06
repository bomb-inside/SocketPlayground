using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketPlayground
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 serverForm = new Form1();
            serverForm.Show();
            Program.ac.MainForm = serverForm;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 clientForm = new Form2();
            clientForm.Show();
            Program.ac.MainForm = clientForm;
            this.Close();
        }
    }
}
