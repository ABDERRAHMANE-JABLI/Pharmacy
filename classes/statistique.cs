using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacie.classes
{
    class statistique
    {
        Data_access app;
        public statistique()
        {
            app = new Data_access();
        }

        public DataTable pie_chart1()
        {
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_statistique1", null);
            return dt;
        }

        public DataTable chart2()
        {
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_statistique2", null);
            return dt;
        }

        public DataTable chart3()
        {       
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_statistique3", null);
            return dt;
        }

        public DataTable calcule()
        {
            DataTable dt = new DataTable();
            dt = app.selectionner("calcule", null);
            return dt;
        }

    }
}
