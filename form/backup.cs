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
    public partial class backup : Form
    {
        public backup()
        {
            InitializeComponent();
        }
        classes.parametre_app p = new classes.parametre_app();
        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                btn_valider.Enabled = true;
            }
        }

        private void btn_valider_Click(object sender, EventArgs e)
        {

            DialogResult rs = MessageBox.Show("vous voulez sauvegarder les donneés ? ", "Remarque", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (rs == DialogResult.Yes)
            {
                try
                {
                    string filename = textBox1.Text + "\\BD_pharmacie" + DateTime.Now.ToShortDateString().Replace('/', '-');
                    p.creer_backup(filename + ".bak");
                    MessageBox.Show("operations effectuée avec succés");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.Close();
            }
        }
    }
}
