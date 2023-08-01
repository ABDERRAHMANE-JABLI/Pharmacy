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
    public partial class imp_fournisseur : Form
    {
        public imp_fournisseur()
        {
            InitializeComponent();
        }
        classes.fournisseur f = new classes.fournisseur();
        private void imp_fournisseur_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            rapports.fournisseur c = new rapports.fournisseur();
            c.SetDataSource(f.remplirdatagried());
            crystalReportViewer1.ReportSource = c;
            this.Cursor = Cursors.Default;
        }
    }
}
