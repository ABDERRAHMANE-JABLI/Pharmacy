using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacie
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new form.menu());
        }
        public static void vidercontroles(Form f)
        {
            foreach (Control c in f.Controls)
            {
                if (c is TextBox)
                {
                    TextBox xx = (TextBox)c;//casting
                    xx.Clear();
                }
                else if (c is RichTextBox)
                {
                    RichTextBox r = (RichTextBox)c;//casting
                    r.Clear();
                }
                else if (c is DateTimePicker)
                {
                    DateTimePicker p = (DateTimePicker)c;
                    p.Value = DateTime.Parse(DateTime.Now.ToShortDateString());
                }
                else if (c is ComboBox)
                {
                    ComboBox b = (ComboBox)c;
                    b.SelectedIndex = -1;
                }
                else if (c is RadioButton)
                {
                    RadioButton r = (RadioButton)c;
                    r.Checked = false;
                }
            }
        }
    }
}
