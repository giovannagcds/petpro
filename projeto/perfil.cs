using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projeto
{
    public partial class perfil : Form
    {
        private int id_usuario;
        public perfil(int id_usuario)
        {
            InitializeComponent();
            this.id_usuario = id_usuario;
            CarregarDados();
        }

        private void CarregarDados()
        {
            string connectionString = "server=localhost;database=petpro;user=root;password='';";
            string query = "SELECT * FROM usuario WHERE id_usuario = @id_usuario";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_usuario", id_usuario);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox1.Text = reader["nome_usuario"].ToString();
                            textBox2.Text = reader["email"].ToString();
                            textBox3.Text = reader["telefone"].ToString();
                            textBox4.Text = reader["senha"].ToString();

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;database=petpro;user=root;password='';";
            string query = "UPDATE usuario SET nome_usuario = @nome, email = @email, telefone = @telefone, senha = @senha, img = @img WHERE id_usuario = @id_usuario";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                    cmd.Parameters.AddWithValue("@nome", textBox1.Text);
                    cmd.Parameters.AddWithValue("@email", textBox2.Text);
                    cmd.Parameters.AddWithValue("@telefone", textBox3.Text);
                    cmd.Parameters.AddWithValue("@senha", textBox4.Text);

                    // Convertendo a imagem para byte array
                    byte[] imgBytes = null;
                    if (pictureBox1.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                            imgBytes = ms.ToArray();
                        }
                    }

                    cmd.Parameters.AddWithValue("@img", imgBytes);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Dados atualizados com sucesso!");
                    inicio i = new inicio(id_usuario);
                    i.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar dados: " + ex.Message);
                }
            }
        }
    }
}
