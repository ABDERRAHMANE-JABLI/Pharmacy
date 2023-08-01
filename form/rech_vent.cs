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
    public partial class rech_vent : Form
    {
        public rech_vent()
        {
            InitializeComponent();
        }
        classes.vent v = new classes.vent();
        public static DateTime Datvent;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = v.cherch_pardate(dateTimePicker1.Value);
                Datvent = dateTimePicker1.Value;
                iconButton1.Enabled = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.Number);
            }
        }

        private void rech_vent_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = v.remplirdatagried();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            imp_vent im = new imp_vent();
            im.ShowDialog();
        }
    }
}
