using MySql.Data.MySqlClient;
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
    public partial class loginAdm : Form
    {
        public loginAdm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;database=petpro;uid=root;pwd='';";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM administrador WHERE email = @Email AND senha = @Senha AND permissao = @Usuario";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Senha", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Usuario", "adm");
                        int userCount = Convert.ToInt32(cmd.ExecuteScalar());
                        if (userCount > 0)
                        {
                            MessageBox.Show("Login realizado com sucesso!");
                            inicio inicio = new inicio();
                            inicio.Show();
                        }
                        else
                        {
                            MessageBox.Show("Email, senha ou permissão incorretos(as).");
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show($"Erro ao tentar fazer login: {ex.Message}"); }
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
            textBox2.PasswordChar= '*'; 
        }
    }
}
