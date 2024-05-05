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
            //panel1.BackColor = Color.FromArgb(125, 255, 255, 255);
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
    }
}
