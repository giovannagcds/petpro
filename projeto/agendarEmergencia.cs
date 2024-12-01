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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projeto
{
    public partial class agendarEmergencia : Form
    {
        private string horario;
        public agendarEmergencia(string horario)
        {
            InitializeComponent();
            this.horario = horario;
            textBox1.Text = horario;
            textBox2.Text = Convert.ToString(DateTime.Now);
        }

        private void agendarEmergencia_Load(object sender, EventArgs e)
        {

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
                    string queryAnimal = "INSERT INTO emergencia(data_emergencia,localizacao,codigo) VALUES (@data, @local,@codigo);";
                    MySqlCommand cmdAnimal = new MySqlCommand(queryAnimal, conn);
                    cmdAnimal.Parameters.AddWithValue("@data", textBox2.Text);
                    cmdAnimal.Parameters.AddWithValue("@local", textBox3.Text);
                    // Gerar código aleatório de 4 dígitos
                    Random random = new Random();
                    int codigoAleatorio = random.Next(1000, 10000);
                    cmdAnimal.Parameters.AddWithValue("@codigo", codigoAleatorio);
                    cmdAnimal.ExecuteNonQuery();


                    // Mostrar mensagem de sucesso com o código
                    MessageBox.Show($"Emergência agendada com sucesso! Código: {codigoAleatorio}");
                    visualizar_emergencia vsa = new visualizar_emergencia();
                    vsa.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Text = "";
        }
    }
}
