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

namespace projeto
{
    public partial class inicio : Form
    {
        private int id_usuario;
        public inicio(int id_usuario)
        {
            InitializeComponent();
            this.id_usuario = id_usuario;
            AtualizarLabels();
        }

        private void inicio_Load(object sender, EventArgs e)
        {

        }
    // Método para atualizar as labels
    public void AtualizarLabels()
    {
        // String de conexão - adapte de acordo com suas configurações
        string connectionString = "server=localhost;database=petpro;user=root;password='';";

        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT nome_veterinario, localizacao FROM veterinario ORDER BY id_veterinario DESC LIMIT 1";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    label1.Text = reader["nome_veterinario"].ToString();
                    label2.Text = reader["localizacao"].ToString();
                }
            }
        }
    }


    private void button1_Click(object sender, EventArgs e)
        {
            visualizar_horarios v = new visualizar_horarios();
            v.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            perfil p = new perfil(id_usuario);
            p.Show();
        }
    }
}
