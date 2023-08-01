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
    public partial class frm_users : Form
    {
        private static frm_users frm;
        static void frm_users_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static frm_users getform
        {
            get
            {
                if (frm == null)
                {
                    frm = new frm_users();
                    frm.FormClosed += new FormClosedEventHandler(frm_users_FormClosed);
                }
                return frm;
            }
        }
        public frm_users()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
        }

        classes.utilisateur u = new classes.utilisateur();
        private void iconButton1_Click(object sender, EventArgs e)
        {
            form.add_user frm = new form.add_user();
            frm.ShowDialog();
        }

        private void frm_users_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = u.remplirdatagried();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                DialogResult rs = MessageBox.Show("Voulez Vous Supprimer Cet ligne ? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    try
                    {
                        u.supprme_user(int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString()));
                        dataGridView1.DataSource = u.remplirdatagried();
                        MessageBox.Show("Suppression Effectuer avec Succes");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message + " : " + ex.Number);
                    }
                }
            }
        }
    }
}
