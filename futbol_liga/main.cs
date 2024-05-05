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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void main_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(125, 255, 255, 255);
            button1.BackColor = Color.FromArgb(125, 255, 255, 255);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 Form = new Form1();
            this.Hide();
            Form.ShowDialog();
            this.Close();
        }
    }
}
