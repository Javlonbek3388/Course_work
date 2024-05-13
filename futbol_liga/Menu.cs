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
            //ControlTeams controlteam = new ControlTeams();
            //DataTable dataTable = controlteam.getData();
            //foreach(DataRow row in dataTable.Rows)
            //{
            //    comboBox1.Items.Add(row["country"].ToString());
            //}
            //ControlTeams controlTeams = new ControlTeams();
            //DataTable dataTable1 = controlTeams.getData();
            //foreach (DataRow row in dataTable1.Rows)
            //{
            //    comboBox2.Items.Add(row["name"].ToString());
            //}
         

            uploaddataToGridView();
        }

        public void clearBox()
        {
            textBox1.Text = "";
            //comboBox1.Text = string.Empty;
            //comboBox2.Text = string.Empty;
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
            
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            
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
            string text = textBox2.Text.Trim();
            string text2 = textBox3.Text.Trim();
            string text3 = textBox4.Text.Trim();
            string text4 = textBox5.Text.Trim();
            if (text != "" || text2 !="" || text3 != "" || text4 != "")
            {
                ControlGames games = new ControlGames();
                //dataGridView1.DataSource = games.filtrData(text, text2);
                //dataGridView1.Columns["refere_name"].Width = 70;
                //dataGridView1.Columns["refere_last_name"].Width = 70;

                dataGridView1.DataSource = games.filtr(text, text2, text3, text4);


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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Menu1 form = new Menu1();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void button2_Click_3(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {

            string belgi1 = comboBox1.Text;
            string min = textBox6.Text;
            string belgi2 = comboBox2.Text;
            string max = textBox7.Text;

            if (belgi1 != "" && min != "" && belgi2=="" && max =="")
            {
                ControlGames control = new ControlGames();
                dataGridView1.DataSource = control.filtrData1(belgi1, min);
                dataGridView1.Columns["country"].Width = 50;
                dataGridView1.Columns["points"].Width = 50;
                dataGridView1.Columns["coach"].Width = 70;
                dataGridView1.Columns["name"].Width = 50;

            }
            if (belgi1 == "" && min == "" && belgi2 != "" && max != "")
            {
                ControlGames control = new ControlGames();
                dataGridView1.DataSource = control.filtrData2(belgi2, max);
                dataGridView1.Columns["country"].Width = 50;
                dataGridView1.Columns["points"].Width = 50;

            }
            if (belgi2 != "" && min != "" && max != "" && belgi1 != "")
            {
                ControlGames control = new ControlGames();
                dataGridView1.DataSource = control.filtrData(belgi1, min, belgi2, max);
                dataGridView1.Columns["country"].Width = 50;
                dataGridView1.Columns["points"].Width = 50;

            }

            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
