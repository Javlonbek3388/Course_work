using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using static futbol_liga.ControlRefere;

namespace futbol_liga
{
    public partial class team : Form
    {
        public string oldPhotoName = "";
        public string oldPhotoPath = "";
        public string newPhotoName = "";
        public team()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public void uploadPhoto()
        {
            if (oldPhotoPath != "")
            {
                newPhotoName = "team_";
                string photoType = oldPhotoName.Substring(oldPhotoName.LastIndexOf('.'));
                newPhotoName += (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                newPhotoName = newPhotoName.Remove(newPhotoName.IndexOf('.'), 1);
                newPhotoName += photoType;

                File.Copy(oldPhotoPath, @"..\..\Resources\teams\" + newPhotoName);
            }
        }
        public void uploaddataToGridView()
        {
            ControlTeams control = new ControlTeams();
            dataGridView1.DataSource = control.getData();
            dataGridView1.Columns["id"].Width = 30;
            dataGridView1.Columns["name"].Width = 75;
            dataGridView1.Columns["country"].Width = 50;
            dataGridView1.Columns["coach"].Width = 70;
            dataGridView1.Columns["president"].Width = 70;
            dataGridView1.Columns["picture"].Visible = false;
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

        private void button5_Click(object sender, EventArgs e)
        {
            clearBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu form = new Menu();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void team_Load(object sender, EventArgs e)
        {
            uploaddataToGridView();
            panel1.BackColor = Color.FromArgb(125, 255, 255, 255);

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

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text.Trim();
            string name = textBox2.Text.Trim();
            string country = textBox3.Text.Trim();
            string coach = textBox4.Text.Trim();
            string president = textBox5.Text.Trim();
            //string picture = textBox6.Text.Trim();
            uploadPhoto();

            if (name != "" && country != "" && newPhotoName != "" && coach != "" && president != "")
            {
                Teams Obj = new Teams(name, country, coach, president, newPhotoName);
                ControlTeams controlTeam = new ControlTeams();
                if (controlTeam.InsertTeam(Obj))
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
                string name = textBox2.Text;
                string country = textBox3.Text;
                string coach = textBox4.Text;
                string president = textBox5.Text;

                string picture = pictureBox1.Tag.ToString();
                if (oldPhotoName != "")
                {
                    try
                    {
                        if (File.Exists(@"..\..\Resources\teams\" + picture))
                        {
                            File.Delete(@"..\..\Resources\teams\" + picture);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    uploadPhoto();
                    picture = newPhotoName;
                }


                ControlTeams controlTeams = new ControlTeams();
                if (controlTeams.updateTeams(new Teams(id, name, country, coach, president, picture)))
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["country"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["coach"].FormattedValue.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["president"].FormattedValue.ToString();

                //pictureBox1.Image = Image.FromFile(@"..\..\Resources\users\" + dataGridView1.Rows[e.RowIndex].Cells["picture"].FormattedValue.ToString());

                using (FileStream fs = new FileStream(@"..\..\Resources\teams\" + dataGridView1.Rows[e.RowIndex].Cells["picture"].FormattedValue.ToString(), FileMode.Open))
                {
                    Image image = Image.FromStream(fs);
                    pictureBox1.Image = image;
                }
                pictureBox1.Tag = dataGridView1.Rows[e.RowIndex].Cells["picture"].FormattedValue.ToString();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int id = int.Parse(textBox1.Text);

                string picture = pictureBox1.Tag.ToString();
                DialogResult dr = MessageBox.Show("Element o'chirilsinmi?", "O'chirish", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ControlTeams control = new ControlTeams();
                    if (control.deleteData(id))
                    {
                        MessageBox.Show("Element o'chirildi.");
                        try
                        {
                            if (File.Exists(@"..\..\Resources\teams\" + picture))
                            {
                                File.Delete(@"..\..\Resources\teams\" + picture);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToString("dd-MM-yyyy");
            label8.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
