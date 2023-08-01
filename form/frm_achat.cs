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
    public partial class frm_achat : Form
    {
        /************************** debut evenement **************/
        private static frm_achat frm;

        static void frm_achat_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
       
        public static frm_achat getform
        {
            get
            {
                if (frm == null)
                {
                    frm = new frm_achat();
                    frm.FormClosed += new FormClosedEventHandler(frm_achat_FormClosed);
                }
                return frm;
            }
        }

        /*************************** fin evenement ***************/
        public frm_achat()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
        }
        classes.achat cl = new classes.achat();
        public static int id = 0;

        //*******************************************
        

        private void frm_achat_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cl.remplirdatagried();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            add_achat frm = new add_achat();
            frm.ShowDialog();
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
                        cl.supprachat(int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()));
                        MessageBox.Show("Suppression Effectuer avec Succes");
                        dataGridView1.DataSource = cl.remplirdatagried();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message + " : " + ex.Number);
                    }
                }
            }

            else if (e.ColumnIndex == 0)
            {
                id = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                form.info_achat frm = new form.info_achat();
                frm.ShowDialog();
            }
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            recherche_achat ra = new recherche_achat();
            ra.ShowDialog();
        }
    }
}
