using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacie.form
{
    public partial class add_user : Form
    {
        public add_user()
        {
            InitializeComponent();
        }

        classes.utilisateur u = new classes.utilisateur();
        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            bool t = classes.Data_Validation.verifier_email(textBox2.Text);
            bool z = classes.Data_Validation.verifier_mot(comboBox1.Text);
            bool f = classes.Data_Validation.verifier_mot(textBox1.Text.Trim());
            bool x = classes.Data_Validation.verifier_password(textBox3.Text.Trim());
            if (t == true && f == true && x == true && z == true)
            {
                try
                {
                    u.ajouterutilisateur(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text);
                    Program.vidercontroles(this);
                    //refresh datagriedview de la form
                    frm_users.getform.dataGridView1.DataSource = u.remplirdatagried();
                    MessageBox.Show("Ajout effectueé avec succes");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message + " : " + ex.Number);
                }
            }
            else
            {
                MessageBox.Show("remplire les champs par des donnees valide");
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            bool y = classes.Data_Validation.verifier_mot(textBox1.Text.Trim());
            if (y == false)
            {
                label1.Text = "username Incorrecte";
                iconButton1.Enabled = false;
            }
            else
            {
                label1.Text = "";
                iconButton1.Enabled = true;
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {

            bool y = classes.Data_Validation.verifier_email(textBox2.Text.Trim());
            if (y == false)
            {
                label1.Text = "le champs Email est Incorrecte";
                iconButton1.Enabled = false;
            }
            else
            {
                label1.Text = "";
                iconButton1.Enabled = true;
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {

            bool y = classes.Data_Validation.verifier_password(textBox3.Text.Trim());
            if (y == false)
            {
                label1.Text = "Minimum 4 caractére : \nSeule [a-z] et/ou les chiffres [0-9] sont autorisés";
                iconButton1.Enabled = false;
            }
            else
            {
                label1.Text = "";
                iconButton1.Enabled = true;
            }
        }

    }
}
