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
    public partial class statistique : Form
    {
        public statistique()
        {
            InitializeComponent();
        }

        classes.statistique s = new classes.statistique();
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void statistique_Load(object sender, EventArgs e)
        {
            chart1.DataSource = s.pie_chart1();
            chart1.Series["Series1"].XValueMember = "nomc";
            chart1.Series["Series1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chart1.Series["Series1"].YValueMembers = "valeur";
            chart1.Series["Series1"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;

            DataTable dt = new DataTable();
            dt = s.calcule();
            label1.Text = "" + dt.Rows[0][0] + "\n" + dt.Rows[1][0] + "\n" + dt.Rows[2][0];
            chart2.DataSource = s.chart2();
            chart2.Series["Vente"].XValueMember = "year";
            chart2.Series["Vente"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chart2.Series["Vente"].YValueMembers = "total";
            chart2.Series["Vente"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;

            chart3.DataSource = s.chart3();
            chart3.Series["Achat"].XValueMember = "date";
            chart3.Series["Achat"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chart3.Series["Achat"].YValueMembers = "total";
            chart3.Series["Achat"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
