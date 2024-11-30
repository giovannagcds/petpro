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
    public partial class cadastroVet : Form
    {
        public cadastroVet()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            loginVet login = new loginVet();
            login.Show();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.Text = "";
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            textBox5.Text = "";
            textBox5.PasswordChar = '*';
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            textBox6.Text = "";
            textBox6.PasswordChar = '*';
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Verifique se as senhas correspondem
            if (textBox5.Text != textBox6.Text)
            {
                MessageBox.Show("As senhas não correspondem.");
                return;
            }

            // Conexão com o banco de dados
            string connectionString = "server=localhost;database=petpro;uid=root;pwd='';";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO veterinario (nome_veterinario, localizacao, email, telefone, senha, permissao, img) VALUES (@Nome, @Local, @Email, @Telefone, @Senha, @Permissao, @Img)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Nome", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Local", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Email", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Telefone", textBox4.Text);
                        cmd.Parameters.AddWithValue("@Senha", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Permissao", "vet");

                        // Converter imagem para byte
                        byte[] imageBytes;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureBox1.Image.Save(ms, pictureBox2.Image.RawFormat); imageBytes = ms.ToArray();
                        }
                        cmd.Parameters.AddWithValue("@Img", imageBytes);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Clinica cadastrada com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao cadastrar Clinica: {ex.Message}");
                }
            }

            inicioAdm iadm = new inicioAdm(); 
            iadm.Show();


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
