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
    public partial class info_fournisseur : Form
    {
        classes.fournisseur fr = new classes.fournisseur();
        public info_fournisseur()
        {
            InitializeComponent();
        }
        private void iconPictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void info_fournisseur_Load_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = fr.cherch_parcin(frm_fournisseur.cin);
                label1.Text = dt.Rows[0][0].ToString();
                label2.Text = dt.Rows[0][1].ToString();
                label3.Text = dt.Rows[0][2].ToString();
                label4.Text = dt.Rows[0][3].ToString();
                label5.Text = dt.Rows[0][4].ToString();
                label6.Text = dt.Rows[0][5].ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.Number);
            }
        }
    }
}
