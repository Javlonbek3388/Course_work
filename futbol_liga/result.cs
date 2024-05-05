using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static futbol_liga.ControlRefere;

namespace futbol_liga
{
    public partial class result : Form
    {
        public result()
        {
            InitializeComponent();
        }
        public void uploaddataToGridView()
        {
            ControlResult controlresult = new ControlResult();
            dataGridView1.DataSource = controlresult.getDataResult();
            dataGridView1.Columns["id"].Width = 40;
            dataGridView1.Columns["team_id"].Width = 45;
            dataGridView1.Columns["points"].Width = 45;
            dataGridView1.Columns["game_count"].Width = 45;
            dataGridView1.Columns["win"].Width = 45;
            dataGridView1.Columns["lose"].Width = 45;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void result_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(125,255,255,255);
            uploaddataToGridView();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            clearBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            int team_id = int.Parse(textBox2.Text.Trim());
            int points = int.Parse(textBox3.Text.Trim());
            int game_count = int.Parse(textBox4.Text.Trim());
            int win = int.Parse(textBox5.Text.Trim());
            int lose = int.Parse(textBox6.Text.Trim());


            if (team_id >0 && points > 0 &&  game_count >= 0 && win >= 0 && lose>=0)
            {
                Result Obj = new Result(team_id, points, game_count, win, lose);
                ControlResult controlRes = new ControlResult();
                if (controlRes.insert(Obj))
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int id = int.Parse(textBox1.Text);
                int team_id = int.Parse(textBox2.Text);
                int points = int.Parse(textBox3.Text);
                int game_count = int.Parse(textBox4.Text);
                int win = int.Parse(textBox5.Text);
                int lose =int.Parse(textBox6.Text);
                
                ControlResult obj = new ControlResult();
                if (obj.update(new Result(id, team_id, points, game_count, win, lose)))
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

        private void button7_Click(object sender, EventArgs e)
        {
            Menu form = new Menu();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int id = int.Parse(textBox1.Text);

                
                DialogResult dr = MessageBox.Show("Element o'chirilsinmi?", "O'chirish", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ControlResult obj = new ControlResult();
                    if (obj.delete(id))
                    {
                        MessageBox.Show("Element o'chirildi.");
                        clearBox();
                    }
                    else
                    {
                        MessageBox.Show("Element o'chirilmadi.");
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["team_id"].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["points"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["game_count"].FormattedValue.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["win"].FormattedValue.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["lose"].FormattedValue.ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
