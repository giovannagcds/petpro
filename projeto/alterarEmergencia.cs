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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projeto
{
    public partial class alterarEmergencia : Form
    {
        int id_emergencia;
        private string connectionString = "Server=localhost;Database=petpro;Uid=root;Pwd='';";
        public alterarEmergencia(int id_emergencia)
        {
            InitializeComponent();
            this.id_emergencia = id_emergencia;
            CarregarDados();
        }

        private void CarregarDados()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                        e.data_emergencia,
                        e.localizacao
                    FROM emergencia e
                    WHERE e.id_emergencia = @id_emergencia";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_emergencia", id_emergencia);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Preenche os controles do formulário com os dados
                                textBox2.Text = reader["data_emergencia"].ToString();
                                textBox3.Text = reader["localizacao"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Nenhum dado encontrado para a emergencia selecionada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Atualização no banco de dados
                string query = @"
                UPDATE emergencia e
                SET 
                    e.localizacao = @localizacao
                WHERE e.id_emergencia = @id_emergencia";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Adiciona os parâmetros
                    cmd.Parameters.AddWithValue("@id_emergencia", id_emergencia);
                    cmd.Parameters.AddWithValue("@localizacao", textBox3.Text);

                    // Executa a consulta
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Dados atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        visualizar_emergencia vse = new visualizar_emergencia();
                        vse.Show();
                    }
                    else
                    {
                        MessageBox.Show("Nenhuma alteração foi feita.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}
