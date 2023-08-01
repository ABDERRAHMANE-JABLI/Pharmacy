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
    public partial class recherche_achat : Form
    {
        public recherche_achat()
        {
            InitializeComponent();
        }

        classes.fournisseur f = new classes.fournisseur();
        classes.achat ac = new classes.achat();
        private void recherche_achat_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            comboBox1.DataSource = f.combo_fourniss();
            comboBox1.ValueMember = "cin";
            comboBox1.DisplayMember = "nom";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            dataGridView1.DataSource = ac.remplirdatagried();
        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = f.rechercher_achat_parfournisseur(comboBox1.SelectedValue.ToString());
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.Number);
            }
        }
    }
}
