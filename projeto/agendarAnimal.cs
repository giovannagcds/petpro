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
    public partial class agendarAnimal : Form
    {
        private string horario;
        public agendarAnimal(string horario)
        {
            InitializeComponent();
            this.horario = horario;
            textBox1.Text = horario;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;database=petpro;uid=root;pwd='';";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Inserir animal na tabela `animal`
                    string queryAnimal = "INSERT INTO animal(nome_animal, tipo_animal, raca_animal, situacao_medica) VALUES (@nome_animal, @tipo_animal, @raca_animal, @situacao_medica);";
                    MySqlCommand cmdAnimal = new MySqlCommand(queryAnimal, conn);
                    cmdAnimal.Parameters.AddWithValue("@nome_animal", textBox2.Text);
                    cmdAnimal.Parameters.AddWithValue("@tipo_animal", textBox3.Text);
                    cmdAnimal.Parameters.AddWithValue("@raca_animal", textBox4.Text);
                    cmdAnimal.Parameters.AddWithValue("@situacao_medica", comboBox1.SelectedItem.ToString());
                    cmdAnimal.ExecuteNonQuery();

                    // Obter o ID do animal inserido
                    long animalId = cmdAnimal.LastInsertedId;

                    // Obter o ID do horário
                    string queryHorario = "SELECT id_horario FROM horario WHERE horario = @horario;";
                    MySqlCommand cmdHorario = new MySqlCommand(queryHorario, conn);
                    cmdHorario.Parameters.AddWithValue("@horario", textBox1.Text);
                    object result = cmdHorario.ExecuteScalar();
                    if (result != null)
                    {
                        long horarioId = Convert.ToInt64(result);

                        // Gerar código aleatório de 4 dígitos
                        Random random = new Random();
                        int codigoAleatorio = random.Next(1000, 10000);

                        // Inserir relacionamento na tabela `animal_horario`
                        string queryAnimalHorario = "INSERT INTO animal_horario(FK_horario_id_horario, FK_animal_id_animal, codigo) VALUES (@FK_horario_id_horario, @FK_animal_id_animal, @codigo);";
                        MySqlCommand cmdAnimalHorario = new MySqlCommand(queryAnimalHorario, conn);
                        cmdAnimalHorario.Parameters.AddWithValue("@FK_horario_id_horario", horarioId);
                        cmdAnimalHorario.Parameters.AddWithValue("@FK_animal_id_animal", animalId);
                        cmdAnimalHorario.Parameters.AddWithValue("@codigo", codigoAleatorio);
                        cmdAnimalHorario.ExecuteNonQuery();

                        // Mostrar mensagem de sucesso com o código
                        MessageBox.Show($"Animal agendado com sucesso! Código: {codigoAleatorio}");
                        visualizar_agendamento vsa = new visualizar_agendamento();
                        vsa.Show();
                    }
                    else
                    {
                        MessageBox.Show("Horário não encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";  
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.Text = "";
        }
    }
}
