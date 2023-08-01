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
    public partial class modif_forme : Form
    {
        public modif_forme()
        {
            InitializeComponent();
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        classes.forme fo = new classes.forme();
        private void modif_forme_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = fo.cherch_par_id(frm_forme.id);
                textBox2.Text = dt.Rows[0][0].ToString();
                textBox1.Text = dt.Rows[0][1].ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.Number);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            bool y = classes.Data_Validation.verifier_mot(textBox1.Text.Trim());
            if (y == true)
            {
                try
                {
                    fo.modifierforme(int.Parse(textBox2.Text.Trim()), textBox1.Text.Trim());
                    Program.vidercontroles(this);
                    //refresh datagriedview de la form 
                    frm_forme.getform.dataGridView1.DataSource = fo.remplirdatagried();
                    MessageBox.Show("Modification Effectué Avec Succes");
                    this.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message + " : " + ex.Number);
                }
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            bool y = classes.Data_Validation.verifier_mot(textBox1.Text.Trim());
            if (y == false)
            {
                label3.Text = "le champs libelle est Incorrecte";
                iconButton1.Enabled = false;
            }
            else
            {
                label3.Text = "";
                iconButton1.Enabled = true;
            }
        }
    }
}
