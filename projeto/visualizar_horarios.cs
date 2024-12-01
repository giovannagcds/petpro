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

        public visualizar_horarios()
        {
            InitializeComponent();
            CarregarHorarios();
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }

       

        private void visualizar_horarios_Load(object sender, EventArgs e)
        {
           
        }


        


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se o clique foi em uma célula da coluna de botões
            if (e.RowIndex >= 0)
            {
                // Obtém o valor do horario da linha clicada
                string horario = dataGridView1.Rows[e.RowIndex].Cells["horario"].Value.ToString();

                // Se a coluna clicada for a de "Agendar"
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Agendar")
                {
                    var situacao = dataGridView1.Rows[e.RowIndex].Cells["situacao"].Value;
                    if (situacao != null && situacao.ToString() == "livre")
                    {
                        // Código para abrir a página agendarAnimal com horario
                        AgendarAnimal(horario);
                    }
                }
                // Se a coluna clicada for a de "Emergencia"
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Emergencia")
                {
                    // Código para abrir a página agendarEmergencia com horario
                    AgendarEmergencia(horario);
                }
            }
        }

        private void AgendarAnimal(string horario)
        {
            // Aqui você pode passar o horario para a página agendarAnimal
            agendarAnimal agendarAnimalForm = new agendarAnimal(horario);
            agendarAnimalForm.Show();
        }

        private void AgendarEmergencia(string horario)
        {
            // Aqui você pode passar o horario para a página agendarEmergencia
            agendarEmergencia agendarEmergenciaForm = new agendarEmergencia(horario);
            agendarEmergenciaForm.Show();
        }

        private void AddButtonColumn(string name, string headerText, string buttonText)
        {
            
        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //var situacaoCell = dataGridView1.Rows[e.RowIndex].Cells["situacao"].Value;
            //if (situacaoCell != null && situacaoCell.ToString() == "ocupado")
            //{
            //    dataGridView1.Rows[e.RowIndex].Cells["Agendar"].Value = "";  // Remove o texto do botão
            //}
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica se a coluna atual é a de botões de agendamento
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Agendar")
            {
                var situacao = dataGridView1.Rows[e.RowIndex].Cells["situacao"].Value;

                // Se a situação for "ocupado", desabilita o botão de agendamento
                if (situacao != null && situacao.ToString() == "ocupado")
                {
                    e.Value = "Agendar";  // Mantém o texto do botão
                    e.CellStyle.ForeColor = Color.Gray;  // Muda a cor do texto para indicar desabilitado
                    dataGridView1.Rows[e.RowIndex].Cells["Agendar"].ReadOnly = true;
                    ((DataGridViewButtonCell)dataGridView1.Rows[e.RowIndex].Cells["Agendar"]).FlatStyle = FlatStyle.Flat;
                }
                else if (situacao != null && situacao.ToString() == "livre")
                {
                    e.Value = "Agendar";  // Mantém o texto do botão
                    e.CellStyle.ForeColor = Color.Black;  // Mantém a cor do texto normal
                    dataGridView1.Rows[e.RowIndex].Cells["Agendar"].ReadOnly = false;
                    ((DataGridViewButtonCell)dataGridView1.Rows[e.RowIndex].Cells["Agendar"]).FlatStyle = FlatStyle.Standard;
                }
            }
        }

        // Método para carregar e configurar o DataGridView
        public void CarregarHorarios()
        {
            // String de conexão - adapte de acordo com suas configurações
            string connectionString = "server=localhost;database=petpro;user=root;password='';";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT data, horario, situacao FROM horario";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Adiciona colunas de botão antes de definir a fonte de dados do DataGridView
                DataGridViewButtonColumn btnAgendar = new DataGridViewButtonColumn();
                btnAgendar.Name = "Agendar";
                btnAgendar.HeaderText = "Agendar";
                btnAgendar.Text = "Agendar";
                btnAgendar.UseColumnTextForButtonValue = true;

                DataGridViewButtonColumn btnEmergencia = new DataGridViewButtonColumn();
                btnEmergencia.Name = "Emergencia";
                btnEmergencia.HeaderText = "Emergencia";
                btnEmergencia.Text = "Emergencia";
                btnEmergencia.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.Add(btnAgendar);
                dataGridView1.Columns.Add(btnEmergencia);

                // Define a fonte de dados do DataGridView
                dataGridView1.DataSource = dataTable;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            visualizar_agendamento vs = new visualizar_agendamento();
            vs.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            visualizar_emergencia emergencia = new visualizar_emergencia();
            emergencia.Show();  
        }
    }
}
