using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace pharmacie.classes
{
    class Data_access
    {
        public static SqlConnection cx;

        public Data_access()
        {
            if (Properties.Settings.Default.type == "windows")
            {
                cx = new SqlConnection(@"Data Source=" + Properties.Settings.Default.server + ";Initial Catalog=" + Properties.Settings.Default.basedonnee + ";Integrated Security=True");
            }
            else
            {
                cx = new SqlConnection(@"Data Source=" + Properties.Settings.Default.server + ";Initial Catalog=" + Properties.Settings.Default.basedonnee + ";Integrated Security=false; User ID=" + Properties.Settings.Default.logine + "; Password=" + Properties.Settings.Default.motpass);
            }
        }
        
        /*public Data_access()
        {
            cx = new SqlConnection(@"Data Source=ABDOU-JABLI\SQLEXPRESS;Initial Catalog=pharmacie;Integrated Security=True");
        }*/

        public void ouvrirconnexion()
        {
            if (cx.State == ConnectionState.Closed)
            {
                cx.Open();
            }
        }

        public void fermerconnexion()
        {
            if (cx.State == ConnectionState.Open)
            {
                cx.Close();
            }
        }

        //pour les requetes qui ont un retour
        public DataTable selectionner(string proc_stocke, SqlParameter[] p)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = proc_stocke;
            cmd.Connection = cx;
            if (p != null)
            {
                cmd.Parameters.AddRange(p);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);           
            return dt;   
        }

        //pour les requetes insert update delete
        public void mettre_ajour(string proc_stocke, SqlParameter[] p)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = proc_stocke;
            cmd.Connection = cx;
            if (p != null)
            {
                cmd.Parameters.AddRange(p);
            }
            cmd.ExecuteNonQuery();
        }
    }
}
