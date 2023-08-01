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
    public partial class add_medicament : Form
    {
        public add_medicament()
        {
            InitializeComponent();
        }

        classes.medicament cl = new classes.medicament();
        classes.famille fa = new classes.famille();
        classes.forme fo = new classes.forme();
        string imagelocation;

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

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("remplire les champs par des donnees valide");
            }
            else { 
                try
                {
                    byte[] image = null;
                    FileStream fs = new FileStream(imagelocation, FileMode.Open, FileAccess.Read);
                    BinaryReader rd = new BinaryReader(fs);
                    image = rd.ReadBytes((int)fs.Length);

                    cl.ajoutermedicament(textBox4.Text, textBox1.Text.Trim(), decimal.Parse(textBox2.Text.Trim()), int.Parse(textBox3.Text.Trim()), image, int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox2.SelectedValue.ToString()));
                    Program.vidercontroles(this);
                    //refresh datagriedview de la form
                    frm_medicament.getform.dataGridView1.DataSource = cl.remplirdatagried();
                    MessageBox.Show("Ajout Effectué Avec Succes");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message + " : " + ex.Number);
                }
            }
        }

        private void add_medicament_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = fa.remplirdatagried();
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "libelle";

            comboBox2.DataSource = fo.remplirdatagried();
            comboBox2.ValueMember = "id";
            comboBox2.DisplayMember = "libelle";
        }
    }
}
