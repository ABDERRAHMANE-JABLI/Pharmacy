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
    public partial class add_achat : Form
    {
        public add_achat()
        {
            InitializeComponent();
        }
        classes.achat cl = new classes.achat();
        

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                cl.ajouterachat(dateTimePicker1.Value, int.Parse(numericUpDown1.Value.ToString()), comboBox1.SelectedValue.ToString(), int.Parse(comboBox2.SelectedValue.ToString()));
                Program.vidercontroles(this);
                frm_achat.getform.dataGridView1.DataSource = cl.remplirdatagried();
                MessageBox.Show("Ajout Effectué Avec Succes");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.Number);
            }
            numericUpDown1.Value = 0;
        }
        classes.fournisseur f = new classes.fournisseur();
        classes.medicament m = new classes.medicament();

        private void add_achat_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = f.combo_fourniss();
            comboBox1.ValueMember = "cin";
            comboBox1.DisplayMember = "nom";

            comboBox2.DataSource = m.combo_medicament();
            comboBox2.ValueMember = "id_medi";
            comboBox2.DisplayMember = "medi";
        }
    }
}
