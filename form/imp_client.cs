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
    public partial class imp_client : Form
    {
        public imp_client()
        {
            InitializeComponent();
        }
        classes.Client cl = new classes.Client();
        private void imp_client_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            rapports.client c = new rapports.client();
            c.SetDataSource(cl.remplirdatagried());
            crystalReportViewer1.ReportSource = c;
            this.Cursor = Cursors.Default;
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
