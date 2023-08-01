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
    public partial class info_patient : Form
    {
        public info_patient()
        {
            InitializeComponent();
        }

        classes.Client cl = new classes.Client();
        private void info_patient_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = cl.cherch_parcin(frm_client.cin);
                label1.Text = "CIN : "+dt.Rows[0][0].ToString();
                label2.Text = "Nom : "+dt.Rows[0][1].ToString();
                label3.Text = "Prenom : "+dt.Rows[0][2].ToString();
                label4.Text = "Adresse : "+dt.Rows[0][3].ToString();
                label5.Text = "telephone : "+dt.Rows[0][4].ToString();
                label6.Text = "Email : "+dt.Rows[0][5].ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.Number);
            }
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
