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
    public partial class inicioAdm : Form
    {
        private MySqlConnection connection;
        public inicioAdm()
        {
            InitializeComponent();
            string connectionString = "server=localhost;database=petpro;uid=root;pwd='';"; 
            connection = new MySqlConnection(connectionString); 
            LoadVeterinarios();
        }

        private void LoadVeterinarios()
        {
            try
            {
                connection.Open();
                string query = "SELECT id_veterinario, nome_veterinario, localizacao, telefone, email, senha, permissao FROM veterinario";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;

                // Adding the Alterar button
                DataGridViewButtonColumn alterarButtonColumn = new DataGridViewButtonColumn();
                alterarButtonColumn.Name = "Alterar";
                alterarButtonColumn.HeaderText = "Alterar";
                alterarButtonColumn.Text = "Alterar";
                alterarButtonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(alterarButtonColumn);

                // Adding the Excluir button
                DataGridViewButtonColumn excluirButtonColumn = new DataGridViewButtonColumn();
                excluirButtonColumn.Name = "Excluir";
                excluirButtonColumn.HeaderText = "Excluir";
                excluirButtonColumn.Text = "Excluir";
                excluirButtonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(excluirButtonColumn);

                dataGridView1.CellClick += dataGridView1_CellClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        
        private void button1_Click_1(object sender, EventArgs e)
        {
            cadastroVet iadm = new cadastroVet();
            iadm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Alterar"].Index)
            {
                int idVeterinario = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_veterinario"].Value);
                AlterarVeterinario(idVeterinario);
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Excluir"].Index)
            {
                int idVeterinario = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_veterinario"].Value);
                ExcluirVeterinario(idVeterinario);
            }
        }

        private void AlterarVeterinario(int idVeterinario)
        {
            // Lógica para alterar o veterinário
            // Navegar para a página de alteração, passando o id do veterinário
            alterarVet alterarVetForm = new alterarVet(idVeterinario);
            alterarVetForm.Show();
        }

        private void ExcluirVeterinario(int idVeterinario)
        {
            try
            {
                connection.Open();
                string query = "DELETE FROM veterinario WHERE id_veterinario = @id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", idVeterinario);
                cmd.ExecuteNonQuery();

                // Excluindo registros da tabela de relacionamento
                string relQuery = "DELETE FROM veterinario_horario WHERE FK_veterinario_id_veterinario = @id";
                MySqlCommand relCmd = new MySqlCommand(relQuery, connection);
                relCmd.Parameters.AddWithValue("@id", idVeterinario);
                relCmd.ExecuteNonQuery();

                MessageBox.Show("Veterinário excluído com sucesso!");
                LoadVeterinarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void inicioAdm_Load(object sender, EventArgs e)
        {

        }

        private void inicioAdm_Click(object sender, EventArgs e)
        {
            LoadVeterinarios();
        }
    }
}
