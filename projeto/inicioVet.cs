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
    public partial class inicioVet : Form
    {
        public inicioVet()
        {
            InitializeComponent();
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            visualizar_emergencia vse = new visualizar_emergencia();
            vse.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            visualizar_agendamento vsa = new visualizar_agendamento();
            vsa.Show();
        }
    }
}
