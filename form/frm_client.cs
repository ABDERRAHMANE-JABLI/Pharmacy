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

namespace pharmacie
{
    public partial class frm_client : Form
    {
        /************************** debut evenement **************/
        private static frm_client frm;
        static void frm_closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static frm_client getform
        {
            get
            {
                if (frm == null)
                {
                    frm = new frm_client();
                    frm.FormClosed += new FormClosedEventHandler(frm_closed);
                }
                return frm;
            }
        }

        /*************************** fin evenement ***************/
        public frm_client()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
        }

        classes.Client cl = new classes.Client();
        public static string cin = "";
        //**************************************************
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cl.remplirdatagried();
        }

        //button ajouter
        private void iconButton1_Click(object sender, EventArgs e)
        {
            add_client frm = new add_client();
            frm.ShowDialog();
        }

        //pour supprimer modifier et plus d'infos *******************
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 2)
            {
                DialogResult rs = MessageBox.Show("Voulez Vous Supprimer Cet ligne ? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    try
                    {
                        cl.supprclient(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                        MessageBox.Show("Suppression Effectuer avec Succes");
                        dataGridView1.DataSource = cl.remplirdatagried();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message + " : " + ex.Number);
                    }
                }
            }
            else if(e.ColumnIndex == 1)
            {
                DialogResult rs = MessageBox.Show("Voulez Vous Modifier Cet ligne ? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    cin = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    modif_client frm = new modif_client();
                    frm.ShowDialog();
                }
            }
            else if (e.ColumnIndex == 0)
            {
                cin = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                form.info_patient frm = new form.info_patient();
                frm.ShowDialog();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cl.les_recherches(textBox1.Text);
        }
    }
}
