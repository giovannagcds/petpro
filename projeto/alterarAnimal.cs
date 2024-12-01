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
    public partial class alterarAnimal : Form
    {
        private int idAnimal;
        private string connectionString = "Server=localhost;Database=petpro;Uid=root;Pwd='';";

        public alterarAnimal(int idAnimal)
        {
            InitializeComponent();
            this.idAnimal = idAnimal;
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
                        a.nome_animal, 
                        a.tipo_animal, 
                        a.raca_animal, 
                        a.situacao_medica, 
                        h.data, 
                        h.horario 
                    FROM animal a
                    INNER JOIN animal_horario ah ON a.id_animal = ah.FK_animal_id_animal
                    INNER JOIN horario h ON ah.FK_horario_id_horario = h.id_horario
                    WHERE a.id_animal = @idAnimal";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idAnimal", idAnimal);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Preenche os controles do formulário com os dados
                                textBox1.Text = reader["horario"].ToString();
                                textBox2.Text = reader["nome_animal"].ToString();
                                textBox3.Text = reader["tipo_animal"].ToString();
                                textBox4.Text = reader["raca_animal"].ToString();
                                comboBox1.Text = reader["situacao_medica"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Nenhum dado encontrado para o animal selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close(); // Fecha o formulário caso não encontre dados
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
                UPDATE animal a
                INNER JOIN animal_horario ah ON a.id_animal = ah.FK_animal_id_animal
                INNER JOIN horario h ON ah.FK_horario_id_horario = h.id_horario
                SET 
                    a.nome_animal = @nomeAnimal,
                    a.tipo_animal = @tipoAnimal,
                    a.raca_animal = @racaAnimal,
                    a.situacao_medica = @situacaoMedica
                WHERE a.id_animal = @idAnimal";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Adiciona os parâmetros
                    cmd.Parameters.AddWithValue("@nomeAnimal", textBox2.Text);
                    cmd.Parameters.AddWithValue("@tipoAnimal", textBox3.Text);
                    cmd.Parameters.AddWithValue("@racaAnimal", textBox4.Text);
                    cmd.Parameters.AddWithValue("@situacaoMedica", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@idAnimal", idAnimal);

                    // Executa a consulta
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Dados atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        visualizar_agendamento vsa = new visualizar_agendamento();
                        vsa.Show();
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
