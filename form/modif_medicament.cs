using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacie.form
{
    public partial class modif_medicament : Form
    {
        public modif_medicament()
        {
            InitializeComponent();
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string imagelocation;
        classes.medicament cl = new classes.medicament();
        classes.famille cf = new classes.famille();
        classes.forme fr = new classes.forme();

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagelocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imagelocation;
            }
        }
       
        private void modif_medicament_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                comboBox1.DataSource = cf.remplirdatagried();
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "libelle";

                comboBox2.DataSource = fr.remplirdatagried();
                comboBox2.ValueMember = "id";
                comboBox2.DisplayMember = "libelle";

                dt = cl.cherch_avant_modife(frm_medicament.idmed);
                textBox5.Text = dt.Rows[0][0].ToString();
                textBox4.Text = dt.Rows[0][1].ToString();
                textBox1.Text = dt.Rows[0][2].ToString();
                textBox2.Text = dt.Rows[0][3].ToString();
                textBox3.Text = dt.Rows[0][4].ToString();
                //textBox5.Text = dt.Rows[0][4].ToString();
                pictureBox1.Image = Image.FromStream(new MemoryStream((byte[])dt.Rows[0][5]));
                comboBox1.SelectedValue = dt.Rows[0][6].ToString();
                comboBox2.SelectedValue = dt.Rows[0][7].ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.Number);
            }
            
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] image = null;
                FileStream fs = new FileStream(imagelocation, FileMode.Open, FileAccess.Read);
                BinaryReader rd = new BinaryReader(fs);
                image = rd.ReadBytes((int)fs.Length);

                cl.modifiermedicament(int.Parse(textBox5.Text), textBox4.Text, textBox1.Text.Trim(), decimal.Parse(textBox2.Text.Trim()), int.Parse(textBox3.Text.Trim()), image, int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox2.SelectedValue.ToString()));
                Program.vidercontroles(this);
                //refresh datagriedview de la form 
                frm_medicament.getform.dataGridView1.DataSource = cl.remplirdatagried();
                MessageBox.Show("Modification Effectué Avec Succes");
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.Number);
            }

        }
    }
}
