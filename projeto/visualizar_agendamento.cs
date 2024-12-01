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
    public partial class visualizar_agendamento : Form
    {
        private string connectionString = "Server=localhost;Database=petpro;Uid=root;Pwd='';";

        public visualizar_agendamento()
        {
            InitializeComponent();
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
                    a.horario,
                    a.codigo, 
                    nome_animal, 
                    raca_animal, 
                    tipo_animal, 
                    situacao_medica 
                FROM agendamento_animais a";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;

                    // Ocultar a coluna id_animal
                    if (dataGridView1.Columns.Contains("codigo"))
                    {
                        dataGridView1.Columns["codigo"].Visible = false;
                    }

                    // Adiciona os botões de ação
                    if (!dataGridView1.Columns.Contains("Alterar"))
                    {
                        DataGridViewButtonColumn btnAlterar = new DataGridViewButtonColumn
                        {
                            Name = "Alterar",
                            HeaderText = "Alterar",
                            Text = "Alterar",
                            UseColumnTextForButtonValue = true
                        };
                        dataGridView1.Columns.Add(btnAlterar);
                    }

                    if (!dataGridView1.Columns.Contains("Excluir"))
                    {
                        DataGridViewButtonColumn btnExcluir = new DataGridViewButtonColumn
                        {
                            Name = "Excluir",
                            HeaderText = "Excluir",
                            Text = "Excluir",
                            UseColumnTextForButtonValue = true
                        };
                        dataGridView1.Columns.Add(btnExcluir);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os dados: {ex.Message}");
            }
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica se não é o header
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Alterar")
                {
                    // Obtém o id_animal da linha selecionada
                    int idAnimal = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["codigo"].Value);

                    // Exibe uma MessageBox para pedir o código
                    string codigoInput = Microsoft.VisualBasic.Interaction.InputBox(
                        "Digite o código do agendamento:",
                        "Validação de Código",
                        "");

                    if (!string.IsNullOrEmpty(codigoInput))
                    {
                        if (ValidarCodigo(idAnimal, codigoInput))
                        {
                            // Código válido, abre a tela de alteração
                            alterarAnimal alterarHorario = new alterarAnimal(idAnimal);
                            alterarHorario.Show();
                        }
                        else
                        {
                            MessageBox.Show("Código inválido! Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Excluir")
                {
                    // Obtém o id_animal da linha selecionada
                    int idAnimal = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["codigo"].Value);

                    // Exibe uma MessageBox para pedir o código
                    string codigoInput = Microsoft.VisualBasic.Interaction.InputBox(
                        "Digite o código do agendamento para confirmar a exclusão:",
                        "Validação de Código",
                        "");

                    if (!string.IsNullOrEmpty(codigoInput))
                    {
                        if (ValidarCodigo(idAnimal, codigoInput))
                        {
                            // Código válido, exclui o agendamento
                            ExcluirAgendamento(idAnimal);
                            CarregarDados(); // Atualiza os dados no DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Código inválido! Não foi possível excluir o agendamento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private bool ValidarCodigo(int idAnimal, string codigoInput)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT COUNT(*) 
                FROM animal_horario ah
                WHERE ah.FK_animal_id_animal = @idAnimal AND ah.codigo = @codigo";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idAnimal", idAnimal);
                        cmd.Parameters.AddWithValue("@codigo", codigoInput);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao validar o código: {ex.Message}");
                return false;
            }
        }

        private void ExcluirAgendamento(int idAnimal)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                DELETE ah
                FROM animal_horario ah
                INNER JOIN animal a ON ah.FK_animal_id_animal = a.id_animal
                WHERE a.id_animal = @idAnimal";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idAnimal", idAnimal);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Agendamento excluído com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir o agendamento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void button2_Click(object sender, EventArgs e)
        {
            visualizar_horarios horarios = new visualizar_horarios();
            horarios.Show();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
        }

        private void visualizar_agendamento_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }
    }

}
