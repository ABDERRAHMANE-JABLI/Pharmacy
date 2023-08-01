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
    public partial class info_achat : Form
    {
        public info_achat()
        {
            InitializeComponent();
        }
        classes.achat cl = new classes.achat();
        

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void info_achat_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = cl.cherch_parid(frm_achat.id);
                label1.Text = "id Achat : " + dt.Rows[0][0].ToString();
                label2.Text = "Date : " + dt.Rows[0][1].ToString();
                label3.Text = "Qantité : " + dt.Rows[0][2].ToString();
                label4.Text = "fournisseur : " + dt.Rows[0][3].ToString();
                label5.Text = "Medicament : " + dt.Rows[0][4].ToString();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.Number);
            }
        }
    }
}
