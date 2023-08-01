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
    public partial class recherche_vent : Form
    {
        public recherche_vent()
        {
            InitializeComponent();
        }
        classes.Client c = new classes.Client();
        classes.vent v = new classes.vent();
        private void recherche_vent_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            comboBox1.DataSource = c.combo_client();
            comboBox1.ValueMember = "cin";
            comboBox1.DisplayMember = "nom";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            dataGridView1.DataSource = v.remplirdatagried();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = c.rechercher_vent_parclient(comboBox1.SelectedValue.ToString());
                label2.Text = "Le Reste des Achats Du client Selectionner : " + v.calculer_credit(comboBox1.SelectedValue.ToString())+" DH";
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.Number);
            }
        }
    }
}
