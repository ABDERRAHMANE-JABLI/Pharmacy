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
    public partial class rech_achat : Form
    {
        public rech_achat()
        {
            InitializeComponent();
        }
        classes.achat a = new classes.achat();
        public static DateTime Datachat;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = a.cherch_pardate(dateTimePicker1.Value);
                Datachat = dateTimePicker1.Value;
                iconButton1.Enabled = true;
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.Number);
            }
        }      
        
        private void rech_achat_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = a.remplirdatagried();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            imp_achat a = new imp_achat();
            a.ShowDialog();
        }
    }
}
