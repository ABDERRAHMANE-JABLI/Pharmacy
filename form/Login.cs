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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        classes.utilisateur u = new classes.utilisateur();
        DataTable dt;
        private void iconButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconPictureBox4_Click(object sender, EventArgs e)
        {
            form.configu_serveur frm = new configu_serveur();
            frm.ShowDialog();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            bool t = classes.Data_Validation.verifier_email(textBox2.Text);
            bool f = classes.Data_Validation.verifier_password(textBox1.Text.Trim());
            if (t == true && f == true)
            {
                dt = u.se_connecter(textBox2.Text, textBox1.Text);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][1].ToString() == "Admin")
                    {
                        menu.getform.label3.Text = dt.Rows[0][0].ToString();
                        menu.getform.iconButton1.Enabled = true;
                        menu.getform.iconButton2.Enabled = true;
                        menu.getform.iconButton3.Enabled = true;
                        menu.getform.iconButton4.Enabled = true;
                        menu.getform.iconButton20.Enabled = true;
                        menu.getform.iconButton5.Enabled = true;
                        menu.getform.iconButton19.Enabled = true;
                        menu.getform.iconButton22.Enabled = true;
                    }
                    else
                    {
                        menu.getform.label3.Text = dt.Rows[0][0].ToString();
                        //menu.getform.iconButton1.Enabled = true;                   
                        menu.getform.iconButton4.Enabled = true;
                        //menu.getform.iconButton22.Enabled = true;
                    }
                    menu.getform.panel3.Controls.Clear();
                    menu.getform.panel3.Controls.Add(menu.getform.pictureBox1);
                    menu.getform.pictureBox1.Location = new Point(394, 163);
                    menu.getform.iconButton6.Visible = false;
                }
                else
                {
                    MessageBox.Show("Erreur : Email ou Password Incorrecte");
                }
            }
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            if (iconPictureBox3.IconChar == FontAwesome.Sharp.IconChar.Eye)
            {
                iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                textBox1.PasswordChar = '\0';               
            }
            else
            {
                iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.Eye;
                textBox1.PasswordChar = '*';  
            }
        }
    }
}
