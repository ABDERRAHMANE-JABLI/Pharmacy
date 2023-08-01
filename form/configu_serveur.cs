using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacie.form
{
    public partial class configu_serveur : Form
    {
        public configu_serveur()
        {
            InitializeComponent();
        }

        private void radiosql_CheckedChanged(object sender, EventArgs e)
        {
            if (radiosql.Checked)
            {
                txtlogine.Enabled = true;
                txtpassword.Enabled = true;
            }
            else
            {
                txtpassword.Enabled = false;
                txtlogine.Enabled = false;
            }
        }

        private void btn_valider_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.server = txtserveur.Text;
            Properties.Settings.Default.basedonnee = txtbasedonne.Text;
            Properties.Settings.Default.type = radiowindows.Checked == true ? "windows" : "sql";
            Properties.Settings.Default.logine = txtlogine.Text;
            Properties.Settings.Default.motpass = txtpassword.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("configuration effectuée avec succées");
            this.Close();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtserveur_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
