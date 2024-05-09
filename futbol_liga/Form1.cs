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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //panel1.BackColor = Color.FromArgb(125,255, 255, 255);
            button2.BackColor = Color.FromArgb(125, 255, 255, 255);
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.textBox1.Text;
            string password = this.textBox2.Text;
            UserLogin userLogin = new UserLogin(username, password);

            if (UserLogin.isLogin)
            {
                Menu1 form2 = new Menu1();
                this.Hide();
                form2.ShowDialog();
                this.Close();

            }
            else
            {
                MessageBox.Show("Login yoki parol xato...");
                textBox1.Text = "";
                textBox2.Text = "";
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            label1.BackColor = Color.FromArgb(125, 255, 255, 255);
            label2.BackColor = Color.FromArgb(125,255,255, 255);    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main form = new main();
            this.Hide();
            form.ShowDialog();
            this.Close();   

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Red;
        }
    }
}
