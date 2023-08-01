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
    public partial class frm_vent : Form
    {
        /************************** debut evenement **************/
        private static frm_vent frm;

        static void frm_vent_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        
        
        public static frm_vent getform
        {
            get
            {
                if (frm == null)
                {
                    frm = new frm_vent();
                    frm.FormClosed += new FormClosedEventHandler(frm_vent_FormClosed);
                }
                return frm;
            }
        }

        /*************************** fin evenement ***************/
        public frm_vent()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
        }

        classes.vent cl = new classes.vent();
        public static int num = 0;

        //*******************************************
        private void frm_vent_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cl.remplirdatagried();
        }
        

        private void iconButton1_Click(object sender, EventArgs e)
        {
            add_vent frm = new add_vent();
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
                        cl.supprvent(int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()));
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
                num = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                form.info_vent frm = new form.info_vent();
                frm.ShowDialog();
            }
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            recherche_vent rv = new recherche_vent();
            rv.ShowDialog();
        }
    }
}
