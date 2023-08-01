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
    public partial class add_vent : Form
    {
        public add_vent()
        {
            InitializeComponent();
        }

        classes.vent cl = new classes.vent();
       
        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        classes.medicament me = new classes.medicament();
        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(numericUpDown1.Value.ToString()) > 0)
                {
                    if (radioButton1.Checked)
                    {
                        decimal rest;
                        DataTable dt = new DataTable();
                        dt = me.cherch_par_id(int.Parse(comboBox2.SelectedValue.ToString()));
                        rest = ((decimal.Parse(dt.Rows[0][2].ToString()) * (int.Parse(numericUpDown1.Value.ToString()))) - int.Parse(textBox6.Text));

                        cl.ajoutervent_client(dateTimePicker1.Value, int.Parse(numericUpDown1.Value.ToString()), comboBox1.SelectedValue.ToString(), int.Parse(comboBox2.SelectedValue.ToString()), decimal.Parse(textBox6.Text.Trim()), rest);
                        Program.vidercontroles(this);
                        frm_vent.getform.dataGridView1.DataSource = cl.remplirdatagried();
                        MessageBox.Show("Ajout Effectué Avec Succes");
                    }
                    else
                    {
                        cl.ajoutervent_autre(dateTimePicker1.Value, int.Parse(numericUpDown1.Value.ToString()), int.Parse(comboBox2.SelectedValue.ToString()));
                        Program.vidercontroles(this);
                        frm_vent.getform.dataGridView1.DataSource = cl.remplirdatagried();
                        MessageBox.Show("Ajout Effectué Avec Succes");
                    }
                }
                else
                {
                    MessageBox.Show("la qantite doit etre > 0  !!!!");
                }
                numericUpDown1.Value = 0;                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.Number);
            }
        }

        classes.Client c = new classes.Client();
        classes.medicament m = new classes.medicament();

        private void add_vent_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = c.combo_client();
            comboBox1.ValueMember = "cin";
            comboBox1.DisplayMember = "nom";

            comboBox2.DataSource = m.combo_medicament();
            comboBox2.ValueMember = "id_medi";
            comboBox2.DisplayMember = "medi";

            radioButton1.Checked = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label4.Visible = true;
            comboBox1.Visible = true;
            label6.Visible = true;
            textBox6.Visible = true;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
            comboBox1.Visible = false;
            label6.Visible = false;
            textBox6.Visible = false;
        }
    }
}
