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
    public partial class info_vent : Form
    {
        public info_vent()
        {
            InitializeComponent();
        }

        classes.vent cl = new classes.vent();

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void info_vent_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = cl.cherch_parnum(frm_vent.num);
                label1.Text = "Numero : " + dt.Rows[0][0].ToString();
                label2.Text = "Date : " + dt.Rows[0][1].ToString();
                label3.Text = "Qantité : " + dt.Rows[0][2].ToString();
                label4.Text = "Client : " + dt.Rows[0][3].ToString();
                label5.Text = "Medicament : " + dt.Rows[0][4].ToString();
                label6.Text = "Avence : " + dt.Rows[0][5].ToString();
                label7.Text = "Reste : " + dt.Rows[0][6].ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.Number);
            }
        }
    }
}
