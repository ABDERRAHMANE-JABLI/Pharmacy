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
    public partial class modif_fournisseur : Form
    {
        public modif_fournisseur()
        {
            InitializeComponent();
        }

        classes.fournisseur fr = new classes.fournisseur();

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            bool x = classes.Data_Validation.verifier_mot(textBox2.Text.Trim());
            bool y = classes.Data_Validation.verifier_cin(textBox1.Text.Trim());
            bool z = classes.Data_Validation.verifier_tel(textBox5.Text.Trim());
            bool t = classes.Data_Validation.verifier_email(textBox6.Text);
            bool f = classes.Data_Validation.verifier_mot(textBox3.Text.Trim());
            if (x == true && y == true && z == true && t == true && f == true)
            {
                try
                {
                    fr.modifierfourn(textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim(), textBox5.Text.Trim(), textBox6.Text.Trim(), frm_fournisseur.cin);
                    Program.vidercontroles(this);
                    //refresh datagriedview de la form frm_client
                    frm_fournisseur.getform.dataGridView1.DataSource = fr.remplirdatagried();
                    MessageBox.Show("Modification Effectué Avec Succes");
                    this.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message + " : " + ex.Number);
                }
            }
        }

        private void modif_fournisseur_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = fr.cherch_parcin(frm_fournisseur.cin);
                textBox1.Text = dt.Rows[0][0].ToString();
                textBox2.Text = dt.Rows[0][1].ToString();
                textBox3.Text = dt.Rows[0][2].ToString();
                textBox4.Text = dt.Rows[0][3].ToString();
                textBox5.Text = dt.Rows[0][4].ToString();
                textBox6.Text = dt.Rows[0][5].ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.Number);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            bool y = classes.Data_Validation.verifier_cin(textBox1.Text.Trim());
            if (y == false)
            {
                label7.Text = "Format Cin Incorrecte";
                iconButton1.Enabled = false;
            }
            else
            {
                label7.Text = "";
                iconButton1.Enabled = true;
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            bool y = classes.Data_Validation.verifier_mot(textBox2.Text.Trim());
            if (y == false)
            {
                label7.Text = "le champs Nom est Incorrecte";
                iconButton1.Enabled = false;
            }
            else
            {
                label7.Text = "";
                iconButton1.Enabled = true;
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {

            bool y = classes.Data_Validation.verifier_mot(textBox3.Text.Trim());
            if (y == false)
            {
                label7.Text = "le champs Prenom est Incorrecte";
                iconButton1.Enabled = false;
            }
            else
            {
                label7.Text = "";
                iconButton1.Enabled = true;
            }
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {

            bool y = classes.Data_Validation.verifier_tel(textBox5.Text.Trim());
            if (y == false)
            {
                label7.Text = "le champs Telephone est Incorrecte";
                iconButton1.Enabled = false;
            }
            else
            {
                label7.Text = "";
                iconButton1.Enabled = true;
            }
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            bool y = classes.Data_Validation.verifier_email(textBox6.Text.Trim());
            if (y == false)
            {
                label7.Text = "le champs Email est Incorrecte";
                iconButton1.Enabled = false;
            }
            else
            {
                label7.Text = "";
                iconButton1.Enabled = true;
            }
        }

    }
}
