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
    public partial class frm_famille : Form
    {
        private static frm_famille frm;

        static void frm_famille_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static frm_famille getform
        {
            get
            {
                if (frm == null)
                {
                    frm = new frm_famille();
                    frm.FormClosed += new FormClosedEventHandler(frm_famille_FormClosed);
                }
                return frm;
            }
        }
        public frm_famille()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
        }

        classes.famille fa = new classes.famille();
        public static int id = 0;

        private void frm_famille_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = fa.remplirdatagried();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = fa.les_recherches(textBox1.Text);
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
                        fa.supprfamille(int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()));
                        dataGridView1.DataSource = fa.remplirdatagried();
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
                    modif_famille frm = new modif_famille();
                    frm.ShowDialog();
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            form.add_famille frm = new add_famille();
            frm.ShowDialog();
        }
    }
}
