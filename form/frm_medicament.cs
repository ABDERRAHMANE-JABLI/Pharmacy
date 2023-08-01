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
    public partial class frm_medicament : Form
    {
        private static frm_medicament frm;
        static void frm_medicament_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static frm_medicament getform
        {
            get
            {
                if (frm == null)
                {
                    frm = new frm_medicament();
                    frm.FormClosed += new FormClosedEventHandler(frm_medicament_FormClosed);
                }
                return frm;
            }
        }

        public frm_medicament()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
        }

        classes.medicament cl = new classes.medicament();
        public static int idmed = 0;
        private void frm_medicament_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cl.remplirdatagried();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cl.les_recherches(textBox1.Text);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            add_medicament frm  = new add_medicament();
            frm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                DialogResult rs = MessageBox.Show("Voulez Vous Supprimer Cet ligne ? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    try
                    {
                        cl.supprmedicament(int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString()));
                        dataGridView1.DataSource = cl.remplirdatagried();
                        MessageBox.Show("Suppression Effectuer avec Succes");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message + " : " + ex.Number);
                    }
                }
            }
            else if (e.ColumnIndex == 1)
            {
                DialogResult rs = MessageBox.Show("Voulez Vous Modifier Cet ligne ? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    idmed = int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                    modif_medicament frm = new modif_medicament();
                    frm.ShowDialog();
                }
            }
            else if (e.ColumnIndex == 0)
            {
                idmed = int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                form.info_medicament frm = new form.info_medicament();
                frm.ShowDialog();
            }
        }
    }
}
