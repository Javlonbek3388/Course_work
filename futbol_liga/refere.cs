using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static futbol_liga.ControlRefere;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace futbol_liga
{
    public partial class refere : Form
    {
        public string oldPhotoName = "";
        public string oldPhotoPath = "";
        public string newPhotoName = "";
        public refere()
        {   
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text.Trim();
            string name = textBox2.Text.Trim();
            string last_name = textBox3.Text.Trim();
            string username = textBox4.Text.Trim();
            string password = textBox5.Text.Trim();
            //string picture = textBox6.Text.Trim();
            uploadPhoto();


            if (name != "" && last_name != "" && newPhotoName != "" && username != "" && password != "")
            {
                referees refObj = new referees(name, last_name, username, password, newPhotoName);
                ControlRefere controlRef = new ControlRefere();
                if (controlRef.insertRefere(refObj))
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
        public void uploadPhoto()
        {
            if (oldPhotoPath != "")
            {
                newPhotoName = "user_";
                string photoType = oldPhotoName.Substring(oldPhotoName.LastIndexOf('.'));
                newPhotoName += (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                newPhotoName = newPhotoName.Remove(newPhotoName.IndexOf('.'), 1);
                newPhotoName += photoType;

                File.Copy(oldPhotoPath, @"..\..\Resources\users\" + newPhotoName);
            }
        }
        public void clearBox()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            //textBox6.Text = "";
            newPhotoName = "";
            oldPhotoName = "";
            oldPhotoPath = "";
            pictureBox1.Image = null;
            uploaddataToGridView();
        }
        public void uploaddataToGridView()
        {
            ControlRefere control = new ControlRefere();
            dataGridView1.DataSource = control.getDataRefere();
            dataGridView1.Columns["id"].Width = 40;
            dataGridView1.Columns["name"].Width = 80;
            dataGridView1.Columns["last_name"].Width = 80;
            dataGridView1.Columns["password"].Visible = false;
            dataGridView1.Columns["picture"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu form = new Menu();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void refere_Load(object sender, EventArgs e)
        {
            uploaddataToGridView();
            panel1.BackColor = Color.FromArgb(125, 255, 255, 255);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            clearBox();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToString("dd-MM-yyyy");
            label8.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (pictureBox1 != null)
            {
                openFileDialog.Filter = "(*.jpg;*.jpeg;*.png;*.bmp;)|*.jpg;*.jpeg;*.png;*.bmp;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    oldPhotoName = openFileDialog.SafeFileName;
                    oldPhotoPath = openFileDialog.FileName;
                    pictureBox1.Image = Image.FromFile(oldPhotoPath);
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //delete
            
            if (textBox1.Text != "")
            {
                int id = int.Parse(textBox1.Text);
                
                string picture = pictureBox1.Tag.ToString();
                DialogResult dr = MessageBox.Show("Element o'chirilsinmi?", "O'chirish", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ControlRefere controlRef = new ControlRefere();
                    if (controlRef.deleteData(id))
                    {
                        MessageBox.Show("Element o'chirildi.");
                        try
                        {
                            if (File.Exists(@"..\..\Resources\users\" + picture))
                            {
                                File.Delete(@"..\..\Resources\users\" + picture);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        clearBox();
                    }
                    else
                    {
                        MessageBox.Show("Element o'chirildi.");
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["last_name"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["username"].FormattedValue.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["password"].FormattedValue.ToString();

                //pictureBox1.Image = Image.FromFile(@"..\..\Resources\users\" + dataGridView1.Rows[e.RowIndex].Cells["picture"].FormattedValue.ToString());

                using (FileStream fs = new FileStream(@"..\..\Resources\users\" + dataGridView1.Rows[e.RowIndex].Cells["picture"].FormattedValue.ToString(), FileMode.Open))
                        {
                            Image image = Image.FromStream(fs);
                            pictureBox1.Image = image;
                        }
                    pictureBox1.Tag = dataGridView1.Rows[e.RowIndex].Cells["picture"].FormattedValue.ToString();

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int id = int.Parse(textBox1.Text);
                string name = textBox2.Text;
                string last_name = textBox3.Text;
                string username = textBox4.Text;
                string password = textBox5.Text;

                string picture = pictureBox1.Tag.ToString();
                if (oldPhotoName != "")
                {
                    try
                    {
                        if (File.Exists(@"..\..\Resources\users\" + picture))
                        {
                            File.Delete(@"..\..\Resources\users\" + picture);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    uploadPhoto();
                    picture = newPhotoName;
                }



                ControlRefere controlref = new ControlRefere();
                if (controlref.updateRefere(new referees(id, name, last_name, username, password, picture)))
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
