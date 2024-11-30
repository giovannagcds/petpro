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

namespace projeto
{
    public partial class alterarVet : Form
    {
        public string idVeterinario;
        public alterarVet(string idVeterinario)
        {
            InitializeComponent();
            this.idVeterinario = idVeterinario;
        }

        private void CarregarDadosVeterinario()
        {
            string connectionString = "server=localhost;database=petpro;user=root;password='';";
            string query = "SELECT * FROM veterinario WHERE id_veterinario = @id";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idVeterinario);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox1.Text = reader["nome_veterinario"].ToString();
                            textBox2.Text = reader["localizacao"].ToString();
                            textBox4.Text = reader["telefone"].ToString();
                            textBox3.Text = reader["email"].ToString();
                            textBox5.Text = reader["senha"].ToString();


                            // Verificar se a coluna img não é nula
                            if (reader["img"] != DBNull.Value)
                            {
                                byte[] imgBytes = (byte[])reader["img"];
                                if (imgBytes != null && imgBytes.Length > 0)
                                {
                                    using (MemoryStream ms = new MemoryStream(imgBytes))
                                    {
                                        pictureBox2.Image = Image.FromStream(ms);
                                        MessageBox.Show("Imagem carregada com sucesso!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Imagem não encontrada.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Nenhuma imagem armazenada no banco de dados.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;database=petpro;user=root;password='';";
            string query = "UPDATE veterinario SET nome_veterinario = @nome, localizacao = @localizacao, telefone = @telefone, email = @correo, senha = @senha, permissao = @permissao, img = @img WHERE id_veterinario = @id";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idVeterinario);
                    cmd.Parameters.AddWithValue("@nome", textBox1.Text);
                    cmd.Parameters.AddWithValue("@localizacao", textBox2.Text);
                    cmd.Parameters.AddWithValue("@telefone", textBox4.Text);
                    cmd.Parameters.AddWithValue("@correo", textBox3.Text);
                    cmd.Parameters.AddWithValue("@senha", textBox5.Text);
                    cmd.Parameters.AddWithValue("@permissao", "vet");

                    // Convertendo a imagem para byte array
                    byte[] imgBytes = null;
                    if (pictureBox2.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
                            imgBytes = ms.ToArray();
                        }
                    }
                    cmd.Parameters.AddWithValue("@img", imgBytes);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Dados atualizados com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar dados: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
    }
}
