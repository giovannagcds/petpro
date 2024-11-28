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
    public partial class visualizar_horarios : Form
    {
        public string connectionString = "Server=localhost;Database=petpro;Uid=root;Pwd='';";

        public visualizar_horarios()
        {
            InitializeComponent();
        }

        private void visualizar_horarios_Load(object sender, EventArgs e)
        {
            CarregarHorarios();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }


        private void CarregarHorarios()
        {

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Query para obter os horários
                    string query = "SELECT id_horario, data, horario, situacao FROM horario";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Define o DataSource do DataGridView
                    dataGridView1.DataSource = dt;

                    // Adiciona coluna "Agendar" e "Emergência" 
                    AddButtonColumn("Agendar", "Agendar", "Agendar");
                    AddButtonColumn("Emergencia", "Emergência", "Emergência");
                    // Oculta o botão "Agendar" para horários que não estão livres 
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string situacao = row.Cells["situacao"].Value?.ToString();
                        if (situacao != "livre")
                        {
                            row.Cells["Agendar"].Value = null; // Remove o botão 
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar horários: " + ex.Message);
                }
            }

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddButtonColumn(string name, string headerText, string buttonText)
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                Name = name,
                HeaderText = headerText,
                Text = buttonText,
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(buttonColumn);
        }

        private void AgendarHorario(int idHorario)
        {
            // Navega para a tela agendarAnimal
            agendarAnimal agendarForm = new agendarAnimal();
            agendarForm.Show();
        }

        private void MarcarComoEmergencia(int idHorario)
        {
            // Navega para a tela agendarEmergencia 
            agendarEmergencia emergenciaForm = new agendarEmergencia();
            emergenciaForm.Show();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idHorario = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_horario"].Value);
                string situacao = dataGridView1.Rows[e.RowIndex].Cells["situacao"].Value?.ToString();
                // Verifica se clicou na coluna "Agendar" 
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Agendar" && situacao == "livre")
                {
                    AgendarHorario(idHorario);
                }
                // Verifica se clicou na coluna "Emergência" 
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Emergencia")
                {
                    MarcarComoEmergencia(idHorario);
                }
            }
        }
    }
}
