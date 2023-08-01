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
    public partial class add_forme : Form
    {
        public add_forme()
        {
            InitializeComponent();
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        classes.forme fo = new classes.forme();
        private void iconButton1_Click(object sender, EventArgs e)
        {
            bool y = classes.Data_Validation.verifier_mot(textBox1.Text.Trim());
            if (y == true)
            {
                try
                {
                    fo.ajouterforme(textBox1.Text.Trim());
                    Program.vidercontroles(this);
                    //refresh datagriedview de la form frm_client
                    frm_forme.getform.dataGridView1.DataSource = fo.remplirdatagried();
                    MessageBox.Show("Ajout Effectué Avec Succes");
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
                label2.Text = "le champs libelle est Incorrecte";
                iconButton1.Enabled = false;
            }
            else
            {
                label2.Text = "";
                iconButton1.Enabled = true;
            }
        }

    }
}
