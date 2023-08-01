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
    public partial class frm_forme : Form
    {
        private static frm_forme frm;


        static void frm_forme_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static frm_forme getform
        {
            get
            {
                if (frm == null)
                {
                    frm = new frm_forme();
                    frm.FormClosed += new FormClosedEventHandler(frm_forme_FormClosed);
                }
                return frm;
            }
        }
        public frm_forme()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
        }

        classes.forme fo = new classes.forme();
        public static int id = 0;
        private void iconButton1_Click(object sender, EventArgs e)
        {
            form.add_forme frm = new add_forme();
            frm.ShowDialog();
        }

        private void frm_forme_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = fo.remplirdatagried();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                DialogResult rs = MessageBox.Show("Voulez Vous Supprimer Cet ligne ? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    try
                    {
                        fo.supprforme(int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()));
                        dataGridView1.DataSource = fo.remplirdatagried();
                        MessageBox.Show("Suppression Effectuer avec Succes");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message + " : " + ex.Number);
                    }
                }
            }
            else if (e.ColumnIndex == 0)
            {
                DialogResult rs = MessageBox.Show("Voulez Vous Modifier Cet ligne ? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    id = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                    modif_forme frm = new modif_forme();
                    frm.ShowDialog();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = fo.les_recherches(textBox1.Text);
        }
    }
}
