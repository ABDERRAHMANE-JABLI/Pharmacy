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
    public partial class menu : Form
    {
        private static menu frm;
        static void frm_closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static menu getform
        {
            get
            {
                if (frm == null)
                {
                    frm = new menu();
                    frm.FormClosed += new FormClosedEventHandler(frm_closed);
                }
                return frm;
            }
        }
        public menu()
        {
            InitializeComponent();
            if(frm == null)
            {
                frm = this;
            }
        }

        void fermer_panel()
        {
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panel12.Visible = false;
            panel13.Visible = false;
        }
        public void ouvrirefenetre(Form fenetrenew)
        {
            panel3.Controls.Clear();
            //pour ajouter la fenetre dans panel3:
            fenetrenew.TopLevel = false;
            fenetrenew.Dock = DockStyle.Fill;
            panel3.Controls.Add(fenetrenew);
            fenetrenew.BringToFront();
            fenetrenew.Show();
        }
        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            fermer_panel();
            if (iconPictureBox1.IconChar == FontAwesome.Sharp.IconChar.Outdent)
            {
                panel1.Size = new Size(88, 660);
                iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Indent;
            }
            else if(iconPictureBox1.IconChar == FontAwesome.Sharp.IconChar.Indent)
            {
                iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Outdent;
                panel1.Size = new Size(267, 660);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (panel5.Visible == true)
            {
                panel5.Visible = false;
            }
            else
            {
                fermer_panel();
                panel5.Visible = true;
            }
          
        }

        private void menu_Load(object sender, EventArgs e)
        {
            fermer_panel();
            timer1.Start();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (panel7.Visible == true)
            {
                panel7.Visible = false;
            }
            else
            {
                fermer_panel();
                panel7.Visible = true;
            }
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            ouvrirefenetre(new frm_client());
            fermer_panel();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            if (panel6.Visible == true)
            {
                panel6.Visible = false;
            }
            else
            {
                fermer_panel();
                panel6.Visible = true;
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (panel8.Visible == true)
            {
                panel8.Visible = false;
            }
            else
            {
                fermer_panel();
                panel8.Visible = true;
            }
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            if (panel9.Visible == true)
            {
                panel9.Visible = false;
            }
            else
            {
                fermer_panel();
                panel9.Visible = true;
            }
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            if (panel10.Visible == true)
            {
                panel10.Visible = false;
            }
            else
            {
                fermer_panel();
                panel10.Visible = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToShortDateString();
            label2.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void iconButton21_Click(object sender, EventArgs e)
        {
            //ouvrirefenetre(new parametre());
        }

        /*private void iconButton6_Click(object sender, EventArgs e)
        {
            ouvrirefenetre(new frm_famille());
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            ouvrirefenetre(new frm_forme());
        }*/

        private void iconButton21_Click_1(object sender, EventArgs e)
        {

            if (panel12.Visible == true)
            {
                panel12.Visible = false;
            }
            else
            {
                fermer_panel();
                panel12.Visible = true;
            }
        }

        private void iconButton19_Click(object sender, EventArgs e)
        {
            if (panel13.Visible == true)
            {
                panel13.Visible = false;
            }
            else
            {
                fermer_panel();
                panel13.Visible = true;
            }
        }

        private void iconButton7_Click_1(object sender, EventArgs e)
        {
            if (panel10.Visible == true)
            {
                panel10.Visible = false;
            }
            else
            {
                fermer_panel();
                panel10.Visible = true;
            }
        }

        private void iconButton25_Click(object sender, EventArgs e)
        {
            ouvrirefenetre(new frm_famille());
            fermer_panel();
        }

        private void iconButton24_Click(object sender, EventArgs e)
        {
             ouvrirefenetre(new frm_forme());
            fermer_panel();
        }

        private void iconButton6_Click_1(object sender, EventArgs e)
        {
            ouvrirefenetre(new Login());
            fermer_panel();
        }

        private void iconButton17_Click(object sender, EventArgs e)
        {
            ouvrirefenetre(new frm_medicament());
            fermer_panel();
        }

        private void iconButton23_Click(object sender, EventArgs e)
        {
            fermer_panel();
            form.configu_serveur frm = new configu_serveur();
            frm.ShowDialog();
        }

        private void iconButton20_Click(object sender, EventArgs e)
        {
            fermer_panel();
            ouvrirefenetre(new frm_users());
        }

        private void iconButton26_Click(object sender, EventArgs e)
        {
            fermer_panel();
            ouvrirefenetre(new statistique());
        }

        private void iconButton22_Click(object sender, EventArgs e)
        {
            fermer_panel();
            ouvrirefenetre(new backup());
        }  

        private void iconButton27_Click(object sender, EventArgs e)
        {
            fermer_panel();
            label3.Text = "";
            iconButton1.Enabled = false;
            iconButton2.Enabled = false;
            iconButton3.Enabled = false;
            iconButton4.Enabled = false;
            iconButton20.Enabled = false;
            iconButton5.Enabled = false;
            iconButton19.Enabled = false;
            iconButton6.Visible = true;
            panel3.Controls.Clear();
            panel3.Controls.Add(pictureBox1);
            pictureBox1.Location = new Point(394, 163);
        }

        private void iconButton18_Click(object sender, EventArgs e)
        {
            ouvrirefenetre(new frm_achat());
            fermer_panel();
        }

        private void iconButton13_Click(object sender, EventArgs e)
        {
            ouvrirefenetre(new frm_vent());
            fermer_panel();
        }

        private void iconButton15_Click(object sender, EventArgs e)
        {
            ouvrirefenetre(new frm_fournisseur());
            fermer_panel();
        }

        private void iconButton12_Click(object sender, EventArgs e)
        {
            ouvrirefenetre(new recherche_vent());
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            ouvrirefenetre(new recherche_achat());
        }

        private void iconButton11_Click(object sender, EventArgs e)
        {
            ouvrirefenetre(new imp_client());
        }

        private void iconButton14_Click(object sender, EventArgs e)
        {
            ouvrirefenetre(new imp_fournisseur());
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            ouvrirefenetre(new rech_vent());
        }

        private void iconButton28_Click(object sender, EventArgs e)
        {
            ouvrirefenetre(new rech_achat());
        }
    }
}
