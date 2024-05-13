using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static futbol_liga.ControlRefere;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using System.IO;

namespace futbol_liga
{
    public partial class games : Form
    {
        public games()
        {
            InitializeComponent();
        }
        public void uploaddataToGridView()
        {
            ControlGames control = new ControlGames();
            dataGridView1.DataSource = control.getDataGames();
            dataGridView1.Columns["id"].Width = 35;
            dataGridView1.Columns["game_time"].Width = 60;
            dataGridView1.Columns["stadium"].Width = 70;
            dataGridView1.Columns["refere_id"].Visible = false;
            dataGridView1.Columns["team1"].Width = 68;
            dataGridView1.Columns["team2"].Width = 67;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu1 form = new Menu1();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string game_time = textBox2.Text.Trim();
            string stadium = textBox3.Text.Trim();
            int refere_id = int.Parse(textBox4.Text.Trim());
            //ControlGames controlTeams = new ControlGames();
            //int refere_id = controlTeams.getIdByName(comboBox1.SelectedItem.ToString());
            string team1 = textBox5.Text.Trim();
            string team2 = textBox6.Text.Trim();
            if (game_time != "" && stadium != "" && refere_id != 0 && team1 != "" && team2 !="")
            {
                Games Obj = new Games(game_time, stadium, refere_id, team1, team2);
                ControlGames control = new ControlGames();
                if (control.insertGame(Obj))
                {
                    MessageBox.Show("Ma'lumotlar muvofaqqiyatli kiritildi!");
                    clearBox();
                    uploaddataToGridView();
                }
                else
                {
                    MessageBox.Show("ma'lumotlar kiritilmadi");

                }
            }
            else
            {
                MessageBox.Show("Barcha maydonlar to'ldirilishi shart! ");
            }
        }
        public void clearBox()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            uploaddataToGridView();


        }

        private void games_Load(object sender, EventArgs e)
        {
        //    ControlRefere controlGames = new ControlRefere();
        //    DataTable dataTable = controlGames.getDataGame();
        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        comboBox1.Items.Add(row["name"].ToString());
        //    }
            panel1.BackColor = Color.FromArgb(125, 255, 255, 255);
            uploaddataToGridView();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int id = int.Parse(textBox1.Text);
                DialogResult dr = MessageBox.Show("Element o'chirilsinmi?", "O'chirish", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ControlGames game = new ControlGames();
                    if (game.deleteData(id))
                    {
                        MessageBox.Show("Element o'chirildi!");
                        clearBox();
                    }
                    else
                    {
                        MessageBox.Show("Element o'chirilmadi!!!");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int id = int.Parse(textBox1.Text);
                string game_time = textBox2.Text;
                string stadium = textBox3.Text;
                int refere_id = int.Parse(textBox4.Text);
                string team1 = textBox5.Text;
                string team2 = textBox6.Text;

                ControlGames obj = new ControlGames();
                if (obj.update(new Games(id, game_time, stadium, refere_id, team1, team2)))
                {
                    MessageBox.Show("Ma'lumot o'zgardi.");
                    clearBox();
                }
                else
                {
                    MessageBox.Show("Ma'lumot o'zgarmadi.");
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clearBox();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToString("dd-MM-yyyy");
            label8.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["game_time"].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["stadium"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["refere_id"].FormattedValue.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["team1"].FormattedValue.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["team2"].FormattedValue.ToString();

                
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
