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
    public partial class imp_achat : Form
    {
        public imp_achat()
        {
            InitializeComponent();
        }
        classes.achat a = new classes.achat();
        private void imp_achat_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            rapports.achat av = new rapports.achat();
            av.SetDataSource(a.cherch_pardate(rech_achat.Datachat));
            crystalReportViewer1.ReportSource = av;
            this.Cursor = Cursors.Default;
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
