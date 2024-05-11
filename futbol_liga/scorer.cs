using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static futbol_liga.ControlRefere;



namespace futbol_liga
{
    public partial class scorer : Form
    {
        public string oldPhotoName = "";
        public string oldPhotoPath = "";
        public string newPhotoName = "";
        public scorer()
        {
            InitializeComponent();
        }
        public void uploaddataToGridView()
        {
            ControlResult controlresult = new ControlResult();
            dataGridView1.DataSource = controlresult.getDataScorer();
            dataGridView1.Columns["id"].Width = 40;
            dataGridView1.Columns["goal_count"].Width = 45;
            dataGridView1.Columns["team_id"].Visible = false;
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
        private void scorer_Load(object sender, EventArgs e)
        {
            uploaddataToGridView();
            panel1.BackColor = Color.FromArgb(125, 255, 255, 255);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Menu1 form = new Menu1();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }
        public void uploadPhoto()
        {
            if (oldPhotoPath != "")
            {
                newPhotoName = "scorer_";
                string photoType = oldPhotoName.Substring(oldPhotoName.LastIndexOf('.'));
                newPhotoName += (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                newPhotoName = newPhotoName.Remove(newPhotoName.IndexOf('.'), 1);
                newPhotoName += photoType;

                File.Copy(oldPhotoPath, @"..\..\Resources\leaders\" + newPhotoName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string name = textBox2.Text.Trim();
            int team_id = int.Parse(textBox3.Text.Trim());
            int goal_count = int.Parse(textBox4.Text.Trim());
            string position = textBox5.Text.Trim();
            //string picture = textBox6.Text.Trim();
            uploadPhoto();


            if (name != "" && position != "" && newPhotoName != "" && team_id > 0 && goal_count>0)
            {
                top_scorer Obj = new top_scorer(name, team_id, goal_count, position, newPhotoName);
                ControlResult control = new ControlResult();
                if (control.InsertSc(Obj))
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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

        private void button5_Click(object sender, EventArgs e)
        {
            clearBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int id = int.Parse(textBox1.Text);
                string name = textBox2.Text;
                int team_id = int.Parse(textBox3.Text);
                int goal_count = int.Parse(textBox4.Text);
                string position = textBox5.Text;

                string picture = pictureBox1.Tag.ToString();
                if (oldPhotoName != "")
                {
                    try
                    {
                        if (File.Exists(@"..\..\Resources\leaders\" + picture))
                        {
                            File.Delete(@"..\..\Resources\leaders\" + picture);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    uploadPhoto();
                    picture = newPhotoName;
                }



                ControlResult obj= new ControlResult();
                if (obj.updateSC(new top_scorer(id, name, team_id, goal_count, position, picture)))
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
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["team_id"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["goal_count"].FormattedValue.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["position"].FormattedValue.ToString();

                //pictureBox1.Image = Image.FromFile(@"..\..\Resources\users\" + dataGridView1.Rows[e.RowIndex].Cells["picture"].FormattedValue.ToString());

                using (FileStream fs = new FileStream(@"..\..\Resources\leaders\" + dataGridView1.Rows[e.RowIndex].Cells["picture"].FormattedValue.ToString(), FileMode.Open))
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
                    ControlResult obj = new ControlResult();
                    if (obj.deleteSC(id))
                    {
                        MessageBox.Show("Element o'chirildi.");
                        try
                        {
                            if (File.Exists(@"..\..\Resources\leaders\" + picture))
                            {
                                File.Delete(@"..\..\Resources\leaders\" + picture);
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
                        MessageBox.Show("Element o'chirilmadi.");
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
