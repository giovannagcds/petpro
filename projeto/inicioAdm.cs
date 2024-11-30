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
    public partial class inicioAdm : Form
    {
        public inicioAdm()
        {
            InitializeComponent();
            carregarDados();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cadastroVet iadm = new cadastroVet();
            iadm.Show();
        }

        private void carregarDados()
        {
            string connectionString = "server=localhost;database=petpro;user=root;password='';";
            string query = "SELECT * FROM veterinario";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open(); MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); dataGridView1.DataSource = dataTable;
                    // Adicionar botões de "Alterar" e "Excluir"
                    DataGridViewButtonColumn btnAlterar = new DataGridViewButtonColumn();
                    btnAlterar.HeaderText = "Alterar"; btnAlterar.Text = "Alterar";
                    btnAlterar.UseColumnTextForButtonValue = true;
                    btnAlterar.Name = "btnAlterar";
                    dataGridView1.Columns.Add(btnAlterar);

                    DataGridViewButtonColumn btnExcluir = new DataGridViewButtonColumn();
                    btnExcluir.HeaderText = "Excluir"; btnExcluir.Text = "Excluir";
                    btnExcluir.UseColumnTextForButtonValue = true;
                    btnExcluir.Name = "btnExcluir";
                    dataGridView1.Columns.Add(btnExcluir);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["btnAlterar"].Index && e.RowIndex >= 0)
            {
                // Navegar para a página de alteração
                string idVeterinario = dataGridView1.Rows[e.RowIndex].Cells["id_veterinario"].Value.ToString();
                alterarVet page = new alterarVet(idVeterinario);
                page.Show();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["btnExcluir"].Index && e.RowIndex >= 0)
            {
                // Excluir o veterinário
                string idVeterinario = dataGridView1.Rows[e.RowIndex].Cells["id_veterinario"].Value.ToString();
                ExcluirVeterinario(idVeterinario);
            }
        }

        private void ExcluirVeterinario(string idVeterinario)
        {
            string connectionString = "server=localhost;database=petpro;user=root;password='';";
            string query = "DELETE FROM veterinario WHERE id_veterinario = @id";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open(); MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idVeterinario);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Veterinário excluído com sucesso!");
                    carregarDados();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir o veterinário: " + ex.Message);
                }
            }
        }
    }
}
