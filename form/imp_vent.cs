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
    public partial class imp_vent : Form
    {
        public imp_vent()
        {
            InitializeComponent();
        }

        classes.vent v = new classes.vent();
        private void imp_vent_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            rapports.vent cv = new rapports.vent();
            cv.SetDataSource(v.cherch_pardate(rech_vent.Datvent));
            crystalReportViewer1.ReportSource = cv;
            this.Cursor = Cursors.Default;
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
