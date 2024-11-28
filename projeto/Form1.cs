using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            login loginCliente = new login();
            loginCliente.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loginVet login = new loginVet();
            login.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loginAdm login = new loginAdm();
            login.Show();
        }
    }
}
