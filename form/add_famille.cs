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
    public partial class add_famille : Form
    {
        public add_famille()
        {
            InitializeComponent();
        }
        classes.famille fa = new classes.famille();
        private void iconButton1_Click(object sender, EventArgs e)
        {
            bool y = classes.Data_Validation.verifier_mot(textBox1.Text.Trim());
            if (y == true)
            {
                try
                {
                    fa.ajouterfamille(textBox1.Text.Trim());
                    Program.vidercontroles(this);
                    //refresh datagriedview de la form frm_client
                    frm_famille.getform.dataGridView1.DataSource = fa.remplirdatagried();
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

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
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
