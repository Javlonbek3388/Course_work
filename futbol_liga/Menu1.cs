using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace futbol_liga
{
    public partial class Menu1 : Form
    {
        public Menu1()
        {
            InitializeComponent();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            //button1.ForeColor = Color.Red;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Menu form = new Menu();
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

        private void button4_Click(object sender, EventArgs e)
        {
            result form = new result();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            refere form = new refere();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            scorer form = new scorer();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            asist form = new asist();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToString("dd-MM-yyyy");
            label8.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
