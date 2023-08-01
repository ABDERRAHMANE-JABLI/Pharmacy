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
    public partial class modif_famille : Form
    {
        public modif_famille()
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
                    fa.modifierfamille(int.Parse(textBox2.Text.Trim()), textBox1.Text.Trim());
                    Program.vidercontroles(this);
                    //refresh datagriedview de la form 
                    frm_famille.getform.dataGridView1.DataSource = fa.remplirdatagried();
                    MessageBox.Show("Modification Effectué Avec Succes");
                    this.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message + " : " + ex.Number);
                }
            }
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void modif_famille_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = fa.cherch_par_id(frm_famille.id);
                textBox2.Text = dt.Rows[0][0].ToString();
                textBox1.Text = dt.Rows[0][1].ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.Number);
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
