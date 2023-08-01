using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacie.form
{
    public partial class info_medicament : Form
    {
        public info_medicament()
        {
            InitializeComponent();
        }
        classes.medicament cl = new classes.medicament();
        private void info_medicament_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                //m.libelle,m.dose,m.prix,m.photo,fa.libelle,f.libelle
                dt = cl.cherch_par_id(frm_medicament.idmed);
                label1.Text = "Medicament : "+dt.Rows[0][0].ToString();
                label2.Text = "Dosage : "+dt.Rows[0][1].ToString();
                label3.Text = "prix : "+dt.Rows[0][2].ToString();
                pictureBox1.Image = Image.FromStream(new MemoryStream((byte[])dt.Rows[0][3]));
                label4.Text = "Famille : "+dt.Rows[0][4].ToString();
                label5.Text = "Forme : "+dt.Rows[0][5].ToString();                        
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.Number);
            }
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
