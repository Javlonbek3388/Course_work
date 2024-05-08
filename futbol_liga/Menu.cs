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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace futbol_liga
{
    public partial class Menu : Form
    {
        

        public Menu()
        {
            InitializeComponent();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            ControlGames controlGames = new ControlGames();
            DataTable dataTable = controlGames.getDataGames();
            foreach(DataRow row in dataTable.Rows)
            {
                comboBox1.Items.Add(row["stadium"].ToString());
            }
            comboBox1.Text = string.Empty;
            uploaddataToGridView();
        }

        public void clearBox()
        {
            textBox1.Text = "";
            comboBox1.Text = string.Empty;
            uploaddataToGridView();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            refere form = new refere();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            result form = new result(); 
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            team form = new team();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            games form = new games();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            games form = new games();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromArgb(00008);
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            games form = new games();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            refere form = new refere();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.FromArgb(00008);
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Red;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.FromArgb(00008);
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.ForeColor = Color.Red;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.ForeColor = Color.Red;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ForeColor = Color.FromArgb(00008);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            scorer form = new scorer();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            asist form = new asist();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }
        public void uploaddataToGridView()
        {
            ControlGames control = new ControlGames();
            dataGridView1.DataSource = control.getDataGames();
            dataGridView1.Columns["id"].Width = 40;
            dataGridView1.Columns["refere_id"].Visible = false;


        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // string keyText = textBox1.Text.Trim();
            string text = comboBox1.SelectedItem.ToString();
            if (text != "" )
            {
                ControlGames games = new ControlGames();
                dataGridView1.DataSource = games.filtrData(text);
                dataGridView1.Columns["refere_name"].Width = 70;
                dataGridView1.Columns["refere_last_name"].Width = 70;
                

            }
            else
            {
                MessageBox.Show("Filter maydoni bo'sh bo'lmasligi kerak.");
                uploaddataToGridView();
                clearBox();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {

            string text = textBox1.Text.Trim();
            
            if (text != "")
            {
                ControlGames games = new ControlGames();
                dataGridView1.DataSource = games.searchData(text);
                dataGridView1.Columns["refere_name"].Width = 70;
                dataGridView1.Columns["refere_last_name"].Width = 70;
                

            }
            else
            {
                MessageBox.Show("Qidiruv maydoni bo'sh bo'lmasligi kerak.");
                uploaddataToGridView();
                clearBox();
            }

        }
    }
}
