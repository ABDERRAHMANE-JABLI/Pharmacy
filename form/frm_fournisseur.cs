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
    public partial class frm_fournisseur : Form
    {
        /************************** debut evenement **************/
        private static frm_fournisseur frm;
        static void frm_fournisseur_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        
        public static frm_fournisseur getform
        {
            get
            {
                if (frm == null)
                {
                    frm = new frm_fournisseur();
                    frm.FormClosed += new FormClosedEventHandler(frm_fournisseur_FormClosed_1);
                }
                return frm;
            }
        }

        /*************************** fin evenement ***************/
        public frm_fournisseur()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
        }
        

        classes.fournisseur fr = new classes.fournisseur();
        public static string cin = "";

        //***************************************************
        private void frm_fournisseur_Load_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = fr.remplirdatagried();
        }

        //button ajouter
        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            add_fournisseur frm = new add_fournisseur();
            frm.ShowDialog();
        }


        //pour supprimer modifier et plus d'infos *******************
      
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                DialogResult rs = MessageBox.Show("Voulez Vous Supprimer Cet ligne ? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    try
                    {
                        fr.supprfourn(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                        frm_fournisseur.getform.dataGridView1.DataSource = fr.remplirdatagried();
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
                    cin = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    modif_fournisseur frm = new modif_fournisseur();
                    frm.ShowDialog();
                }
            }
            else if (e.ColumnIndex == 0)
            {
                cin = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                info_fournisseur frm = new info_fournisseur();
                frm.ShowDialog();
            }
        }



        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = fr.les_recherches(textBox1.Text);
        }
    }
}
