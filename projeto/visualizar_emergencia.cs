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
    public partial class visualizar_emergencia : Form
    {
        private string connectionString = "Server=localhost;Database=petpro;Uid=root;Pwd='';";
        public visualizar_emergencia()
        {
            InitializeComponent();
            CarregarHorarios();
        }

        public void CarregarHorarios()
        {
            // String de conexão - adapte de acordo com suas configurações
            string connectionString = "server=localhost;database=petpro;user=root;password='';";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id_emergencia, data_emergencia,localizacao FROM emergencia";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Ocultar a coluna id_animal
                if (dataGridView1.Columns.Contains("id_emergencia"))
                {
                    dataGridView1.Columns["id_emergencia"].Visible = false;
                }

                // Define a fonte de dados do DataGridView
                dataGridView1.DataSource = dataTable;

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


        private void button2_Click(object sender, EventArgs e)
        {
            visualizar_agendamento vsa = new visualizar_agendamento();  
            vsa.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica se não é o header
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Alterar")
                {
                    int idEmergencia = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_emergencia"].Value);

                    // Exibe uma MessageBox para pedir o código
                    string codigoInput = Microsoft.VisualBasic.Interaction.InputBox(
                        "Digite o código da emergencia:",
                        "Validação de Código",
                        "");

                    if (!string.IsNullOrEmpty(codigoInput))
                    {
                        if (ValidarCodigo(idEmergencia, codigoInput))
                        {
                            // Código válido, abre a tela de alteração
                            alterarEmergencia alterarHorario = new alterarEmergencia(idEmergencia);
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
                    int id_emergencia = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_emergencia"].Value);

                    // Exibe uma MessageBox para pedir o código
                    string codigoInput = Microsoft.VisualBasic.Interaction.InputBox(
                        "Digite o código do agendamento para confirmar a exclusão:",
                        "Validação de Código",
                        "");

                    if (!string.IsNullOrEmpty(codigoInput))
                    {
                        if (ValidarCodigo(id_emergencia, codigoInput))
                        {
                            // Código válido, exclui o agendamento
                            ExcluirAgendamento(id_emergencia);
                            CarregarHorarios(); // Atualiza os dados no DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Código inválido! Não foi possível excluir a emergencia.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }


        private bool ValidarCodigo(int id_emergencia, string codigoInput)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT COUNT(*) 
                FROM emergencia e
                WHERE e.id_emergencia = @id_emergencia AND e.codigo = @codigo";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_emergencia", id_emergencia);
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

        private void ExcluirAgendamento(int id_emergencia)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                DELETE e
                FROM emergencia e
                WHERE e.id_emergencia = @id_emergencia";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_emergencia", id_emergencia);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Emergencia excluído com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir o agendamento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void visualizar_emergencia_Click(object sender, EventArgs e)
        {
            CarregarHorarios();
        }
    }
}
